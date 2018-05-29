/*	
	Gamma Spectator - Monitoring application for Gamma Analyzer sessions
    Copyright (C) 2018  Norwegian Radiation Protection Authority

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
// Authors: Dag Robole,

using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using System.Globalization;
using Newtonsoft.Json;
using ZedGraph;
using MathNet.Numerics;
using log4net;
using System.Net;

namespace crash
{
    public partial class FormMain : Form
    {        
        private FormContainer parent = null;
        private GASettings settings = null;
        private ILog log = null;

        // Concurrent queue used to receive messages from network thread
        static ConcurrentQueue<APISpectrum> recvq = new ConcurrentQueue<APISpectrum>();

        // Sync thread
        static SessionSync syncService = null;
        static Thread syncThread = null;
        static SessionSyncArgs syncArgs = new SessionSyncArgs();

        // Timer used to add spectrums to session
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        // Currently loaded sessions
        private Session session = null;

        // Point lists with graph data        
        private PointPairList sessionGraphList = new PointPairList();
        private PointPairList bkgGraphList = new PointPairList();

        // Livetime scale factor for currently loaded background
        private float bkgScale = 1f;

        // Structure containing loaded nuclide library
        private List<NuclideInfo> NuclideLibrary = new List<NuclideInfo>();
        
        private int selectedChannel = 0;

        // Array containing currently selected energies/channels
        private List<ChannelEnergy> energyLines = new List<ChannelEnergy>();

        private int currentGroundLevelIndex = -1;

        // Enumeration used to keep track of graph object types
        public enum GraphObjectType
        {
            Spectrum,
            Background,
            Energy,
            EnergyTolerance,
            EnergyCalibration            
        };

        public FormMain(FormContainer p, GASettings s, ILog l)
        {
            InitializeComponent();

            MdiParent = parent = p;
            settings = s;
            log = l;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                // Hide tabs on tabcontrol
                tabs.ItemSize = new Size(0, 1);
                tabs.SizeMode = TabSizeMode.Fixed;
                tabs.SelectedTab = pageMenu;

                menuItemConvertToLocalTime.Checked = settings.DisplayLocalTime;

                LoadNuclideLibrary();                

                // Populate UI
                lblGroundLevelIndex.Text = "";
                lblSessionSelChannel.Text = "";
                lblSessionsDatabase.Text = "";                
                lblSessionChannel.Text = "";
                lblSessionEnergy.Text = "";                

                lblSessionDetector.Text = "";
                lblBackground.Text = "";
                lblComment.Text = "";
                ClearSpectrumInfo();                

                menu.Visible = false;

                // Create sync thread
                syncService = new SessionSync(log, recvq);
                syncThread = new Thread(syncService.DoWork);

                // Start thread
                syncThread.Start();
                while (!syncThread.IsAlive) ;

                // Start timer for adding spectrums to session
                timer.Interval = 10;
                timer.Tick += timer_Tick;
                timer.Start();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }        

        void timer_Tick(object sender, EventArgs e)
        {
            // Process waiting network messages
            while (!recvq.IsEmpty)
            {
                APISpectrum apiSpec;
                if (recvq.TryDequeue(out apiSpec))
                    dispatchRecvMsg(apiSpec);
            }            
        }

        public void makeGraphObjectType(ref object tag, GraphObjectType got)
        {
            // Create a graph object type
            tag = new GraphObjectType();
            tag = got;
        }

        public bool isGraphObjectType(object tag, GraphObjectType got)
        {
            // Check graph object type
            return tag != null && (GraphObjectType)tag == got;
        }        

        private bool LoadNuclideLibrary()
        {
            if (!File.Exists(GAEnvironment.NuclideLibraryFile))
                return false;

            try
            {
                // Load nuclide library from file
                using (TextReader reader = File.OpenText(GAEnvironment.NuclideLibraryFile))
                {
                    NuclideLibrary.Clear();
                    char[] itemDelims = new char[] { ' ', '\t' };
                    char[] energyDelims = new char[] { ':' };
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (String.IsNullOrEmpty(line) || line.StartsWith("#")) // Skip comments
                            continue;
                        string[] items = line.Split(itemDelims, StringSplitOptions.RemoveEmptyEntries);
                        string name = items[0];
                        double halfLife = Convert.ToDouble(items[1], CultureInfo.InvariantCulture);
                        string halfLifeUnit = items[2];

                        // Parse nuclide
                        NuclideInfo ni = new NuclideInfo(name, halfLife, halfLifeUnit);

                        // Parse energies
                        for (int i = 3; i < items.Length; i++)
                        {
                            string[] energy = items[i].Split(energyDelims, StringSplitOptions.RemoveEmptyEntries);
                            double e = Convert.ToDouble(energy[0], CultureInfo.InvariantCulture);
                            double p = Convert.ToDouble(energy[1], CultureInfo.InvariantCulture);
                            ni.Energies.Add(new NuclideEnergy(e, p));
                        }

                        // Store nuclide
                        NuclideLibrary.Add(ni);
                    }
                }
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }

            return true;
        }        

        private bool dispatchRecvMsg(APISpectrum apiSpec)
        {
            // Handle messages received from network                        

            try
            {                                
                // Session spectrum received successfully
                Spectrum spec = new Spectrum(apiSpec);
                        
                // Normal session spectrum received
                log.Info(spec.Label + " received");

                // Add spectrum to session
                if (session != null && session.IsLoaded && session.Name == spec.SessionName)
                {
                    session.Add(spec);

                    // Add spectrum to UI list
                    bool updateSelectedIndex = false;
                    if (lbSession.SelectedIndex == 0)
                        updateSelectedIndex = true;

                    int index = 0, last_index = 0;

                    for (int i = 0; i < lbSession.Items.Count; i++)
                    {
                        Spectrum s = lbSession.Items[i] as Spectrum;
                        last_index = s.SessionIndex;
                        if (last_index < spec.SessionIndex)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (last_index > spec.SessionIndex)
                        lbSession.Items.Add(spec);
                    else
                        lbSession.Items.Insert(index, spec);

                    if (updateSelectedIndex)
                    {
                        lbSession.ClearSelected();
                        lbSession.SetSelected(0, true);
                    }

                    // Notify external forms about new spectrum

                    parent.AddSpectrum(spec);
                }                                    
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
                return false;
            }

            return true;
        }

        public void SetSelectedSessionIndex(int index)
        {
            int idx = lbSession.FindStringExact(session.Name + " - " + index);
            if (idx == -1)
                return;

            ClearSpectrumInfo();

            lbSession.SelectedIndexChanged -= lbSession_SelectedIndexChanged;
            lbSession.ClearSelected();
            lbSession.SetSelected(idx, true);
            lbSession.SelectedIndexChanged += lbSession_SelectedIndexChanged;

            // Populate session UI with one spectrum
            bkgScale = 1;

            Spectrum s = lbSession.Items[idx] as Spectrum;

            ShowSpectrum(s.SessionName + " - " + s.SessionIndex, s.Channels.ToArray(), s.MaxCount, s.MinCount);
            lblRealtime.Text = "Realtime:" + ((double)s.Realtime) / 1000000.0;
            lblLivetime.Text = "Livetime:" + ((double)s.Livetime) / 1000000.0;
            lblSession.Text = "Session: " + s.SessionName;
            lblSessionDetector.Text = "Det." + session.Detector.Serialnumber + " (" + session.Detector.TypeName + ")";
            lblIndex.Text = "Index: " + s.SessionIndex;
            lblLatitude.Text = "Latitude: " + s.Latitude.ToString("#00.0000000") + " ±" + s.LatitudeError.ToString("###0.0#");
            lblLongitude.Text = "Longitude: " + s.Longitude.ToString("#00.0000000") + " ±" + s.LongitudeError.ToString("###0.0#");
            lblAltitude.Text = "Altitude: " + s.Altitude.ToString("#####0.0#") + " ±" + s.AltitudeError.ToString("###0.0#");
            if(currentGroundLevelIndex > -1 && currentGroundLevelIndex < session.Spectrums.Count)
            {
                double relativeHeight = s.Altitude - session.Spectrums[currentGroundLevelIndex].Altitude;
                lblAltitude.Text += " (rel. " + relativeHeight.ToString("######0.0#") + ")";
            }
            lblGpsTime.Text = "Time: " + (menuItemConvertToLocalTime.Checked ? s.GpsTime.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss") : s.GpsTime.ToString("yyyy-MM-dd HH:mm:ss"));
            lblMaxCount.Text = "Max count: " + s.MaxCount;
            lblMinCount.Text = "Min count: " + s.MinCount;
            lblTotalCount.Text = "Total count: " + s.TotalCount;
            if (s.Doserate == 0.0)
                lblDoserate.Text = "";
            else lblDoserate.Text = "Doserate (μSv/h): " + String.Format("{0:###0.0##}", s.Doserate / 1000.0);
        }

        public void SetSelectedSessionIndices(int index1, int index2)
        {
            int idx1 = lbSession.FindStringExact(session.Name + " - " + index1);
            int idx2 = lbSession.FindStringExact(session.Name + " - " + index2);
            if (idx1 == -1 || idx2 == -1)
                return;            

            if (idx1 > idx2)            
                Utils.Swap(ref idx1, ref idx2);

            ClearSpectrumInfo();

            lbSession.SelectedIndexChanged -= lbSession_SelectedIndexChanged;
            lbSession.ClearSelected();
            for (int i = idx1; i <= idx2; i++)
                lbSession.SetSelected(i, true);
            lbSession.SelectedIndexChanged += lbSession_SelectedIndexChanged;

            bkgScale = (float)lbSession.SelectedIndices.Count; // Store scalefactor for background livetime

            Spectrum s1 = (Spectrum)lbSession.Items[idx2];
            Spectrum s2 = (Spectrum)lbSession.Items[idx1];

            double realTime = 0;
            double liveTime = 0;

            // Merge spectrums
            string title = "Merged: " + s1.SessionIndex + " - " + s2.SessionIndex;
            float[] chans = new float[(int)s1.NumChannels];
            float maxCnt = s1.MaxCount, minCnt = s1.MinCount;
            float totCnt = 0;
            for (int i = 0; i < lbSession.SelectedItems.Count; i++)
            {
                Spectrum s = (Spectrum)lbSession.SelectedItems[i];
                for (int j = 0; j < s.NumChannels; j++)
                    chans[j] += s.Channels[j];

                if (s.MaxCount > maxCnt)
                    maxCnt = s.MaxCount;
                if (s.MinCount < minCnt)
                    minCnt = s.MinCount;

                totCnt += s.TotalCount;

                realTime += ((double)s.Realtime) / 1000000.0;
                liveTime += ((double)s.Livetime) / 1000000.0;
            }

            // Populate controls
            ShowSpectrum(title, chans, maxCnt, minCnt);

            lblRealtime.Text = "Realtime:" + realTime;
            lblLivetime.Text = "Livetime:" + liveTime;
            lblSession.Text = "Session: " + s1.SessionName;
            lblIndex.Text = "Index: " + s1.SessionIndex + " - " + s2.SessionIndex;
            lblLatitude.Text = "";
            lblLongitude.Text = "";
            lblAltitude.Text = "";
            lblGpsTime.Text = "";
            lblMaxCount.Text = "Max count: " + maxCnt;
            lblMinCount.Text = "Min count: " + minCnt;
            lblTotalCount.Text = "Total count: " + totCnt;
            lblDoserate.Text = "";
        }

        private void ClearSpectrumInfo()
        {
            // Clear info about currently selected spectrum
            lblSession.Text = "";
            lblRealtime.Text = "";
            lblLivetime.Text = "";
            lblIndex.Text = "";
            lblLatitude.Text = "";
            lblLongitude.Text = "";
            lblAltitude.Text = "";
            lblGpsTime.Text = "";
            lblMaxCount.Text = "";
            lblMinCount.Text = "";
            lblTotalCount.Text = "";
            lblDoserate.Text = "";
            lblSessionChannel.Text = "";
            lblSessionEnergy.Text = "";

            // Reset nuclide UI
            graphSession.GraphPane.GraphObjList.Clear();
            lbNuclides.Items.Clear();
        }        

        public void ClearSession()
        {
            // Clear currently loaded session
            lbSession.Items.Clear();
            lblSessionDetector.Text = "";
            lblComment.Text = "";
            lblBackground.Text = "";
            ClearSpectrumInfo();

            graphSession.GraphPane.Title.Text = " ";
            graphSession.GraphPane.CurveList.Clear();
            graphSession.GraphPane.GraphObjList.Clear();
            graphSession.Invalidate();

            if (session != null)
                session.Clear();
        }

        private void ClearBackground()
        {
            if (session == null)
                return;

            // Clear currently selected background and update state
            session.SetBackgroundSession(null);

            lblBackground.Text = "";
            graphSession.Invalidate();
        }

        public void ShowSpectrum(string title, float[] channels, float maxCount, float minCount)
        {
            if (session == null)
                return;

            try
            {
                // Reset spectrum graphpane
                GraphPane pane = graphSession.GraphPane;
                pane.Chart.Fill = new Fill(SystemColors.ButtonFace);
                pane.Fill = new Fill(SystemColors.ButtonFace);

                pane.Title.Text = title;
                pane.XAxis.Title.Text = "Channel";
                pane.YAxis.Title.Text = "Counts";

                pane.XAxis.Scale.Min = 0;
                pane.XAxis.Scale.Max = maxCount;

                pane.YAxis.Scale.Min = minCount;
                pane.YAxis.Scale.Max = maxCount + (maxCount / 10.0);

                pane.CurveList.Clear();

                // Update background graph
                if (session.Background != null && !menuItemSubtractBackground.Checked)
                {
                    bkgGraphList.Clear();
                    for (int i = 0; i < session.Background.Length; i++)
                        bkgGraphList.Add((double)i, (double)session.Background[i] * bkgScale);

                    LineItem bkgCurve = pane.AddCurve("Background", bkgGraphList, Color.Blue, SymbolType.None);
                    bkgCurve.Line.IsSmooth = true;
                    bkgCurve.Line.SmoothTension = 0.5f;
                }

                // Update spectrum graph
                sessionGraphList.Clear();
                for (int i = 0; i < channels.Length; i++)
                {
                    double cnt = (double)channels[i];
                    if (session.Background != null && menuItemSubtractBackground.Checked)
                    {
                        cnt -= session.Background[i] * bkgScale;
                        if (menuItemLockBackgroundToZero.Checked)
                            if (cnt < 0.0)
                                cnt = 0.0;
                    }

                    sessionGraphList.Add((double)i, cnt);
                }

                LineItem curve = pane.AddCurve("Spectrum", sessionGraphList, Color.Red, SymbolType.None);
                curve.Line.IsSmooth = true;
                curve.Line.SmoothTension = 0.5f;

                // Update state
                pane.Chart.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
                pane.Legend.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);
                pane.Fill = new Fill(SystemColors.ButtonFace, SystemColors.ButtonFace);

                graphSession.RestoreScale(pane);
                graphSession.AxisChange();
                graphSession.Refresh();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void GetGraphPointFromMousePos(int posX, int posY, ZedGraphControl graph, out int x, out int y)
        {
            // Convert mouse position to graph position
            int index = 0;
            object nearestobject = null;
            PointF clickedPoint = new PointF(posX, posY);
            graph.GraphPane.FindNearestObject(clickedPoint, this.CreateGraphics(), out nearestobject, out index);
            double dx, dy;
            graph.GraphPane.ReverseTransform(clickedPoint, out dx, out dy);
            x = (int)dx;
            y = (int)dy;
        }        

        int GetChannelFromEnergy(Detector det, double E, int startX, int endX)
        {
            // Locate a suitable channel for a given energy, return -1 if none is found

            // FIXME: O(log n) ?
            double epsilon = 2d;
            for (int x = startX; x < endX; x++)
            {
                double e = det.GetEnergy(x);
                if (Math.Abs(E - e) < epsilon)
                    return x;
            }
            return -1;
        }

        private void btnMenuSession_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageSessions;
        }

        private void tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update UI based on selected tab
            Text = "Session - " + tabs.SelectedTab.Text;
            
            menuItemView.Visible = true;
            menuItemSession.Visible = false;

            if (tabs.SelectedTab == pageSessions)
            {
                parent.SetUILayout(UILayout.Session1);
                menuItemSession.Visible = true;
            }                        
            else if (tabs.SelectedTab == pageMenu)
            {
                parent.SetUILayout(UILayout.Menu);
                menuItemView.Visible = false;
            }            
        }             

        private void lbSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbSession.SelectedItems.Count < 1)
            {                
                parent.SetSelectedSessionIndex(-1);
            }                
            else if (lbSession.SelectedItems.Count == 1)
            {
                Spectrum s = lbSession.SelectedItem as Spectrum;
                parent.SetSelectedSessionIndex(s.SessionIndex);
            }
            else
            {                
                Spectrum s1 = lbSession.SelectedItems[lbSession.SelectedIndices.Count - 1] as Spectrum;
                Spectrum s2 = lbSession.SelectedItems[0] as Spectrum;
                parent.SetSelectedSessionIndices(s1.SessionIndex, s2.SessionIndex);
            }
        }

        private void menuItemLoadSession_Click(object sender, EventArgs e)
        {            
            FormSelectSession form = new FormSelectSession(parent, settings, log);
            if (form.ShowDialog() != DialogResult.OK)
                return;

            syncService.Deactivate();

            parent.ClearSession();

            session = new Session(form.SelectedSession);

            parent.SetSession(session);            

            syncArgs.WSAddress = settings.LastUploadHostname;
            syncArgs.Username = settings.LastUploadUsername;
            syncArgs.Password = settings.LastUploadPassword;
            syncArgs.SessionName = session.Name;
            syncArgs.LastSessionIndex = -1;

            syncService.Activate(syncArgs);

            log.Info("Session " + session.Name + " loaded");
        }

        public void SetSession(Session s)
        {
            foreach (Spectrum spec in s.Spectrums)            
                lbSession.Items.Insert(0, spec);

            lblSessionsDatabase.Text = "Session: " + session.Name;
            lblSession.Text = "Session: " + session.Name;
            lblComment.Text = session.Comment;
        }

        private void graphSession_MouseMove(object sender, MouseEventArgs e)
        {            
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            lblSessionChannel.Text = "Ch: " + String.Format("{0:####0}", x);

            // Show energy
            if (session != null && session.IsLoaded && session.Detector != null)            
                lblSessionEnergy.Text = "En: " + String.Format("{0:#######0.0###}", session.Detector.GetEnergy(x));            
            else lblSessionEnergy.Text = "";
        }

        private void menuItemSessionUnselect_Click(object sender, EventArgs e)
        {
            // Unselect session spectrum
            lbSession.ClearSelected();
            graphSession.GraphPane.GraphObjList.Clear();
            graphSession.GraphPane.CurveList.Clear();

            graphSession.RestoreScale(graphSession.GraphPane);
            graphSession.AxisChange();
            graphSession.Refresh();

            lbNuclides.ClearSelected();
            lbNuclides.Items.Clear();
        }        

        private void menuItemSessionInfo_Click(object sender, EventArgs e)
        {
            if(session == null || !session.IsLoaded)
            {
                MessageBox.Show("Can not open session info. No session loaded");
                return;
            }

            FormSessionInfo form = new FormSessionInfo(settings, log, session, "Session Info");
            form.ShowDialog();
        }

        private void menuItemClearSession_Click(object sender, EventArgs e)
        {
            parent.ClearSession();
        }

        private void menuItemClearBackground_Click(object sender, EventArgs e)
        {
            ClearBackground();
        }

        private void menuItemShowROIHistory_Click(object sender, EventArgs e)
        {
            FormROIHist form = new FormROIHist(settings, log, session);
            form.ShowDialog();
        }                        

        private void graphSession_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (session == null || !session.IsLoaded)
                return;

            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            double E = session.Detector.GetEnergy(x);
            if(E == 0.0)
            {
                log.Warn("Unable to get energy for detector " + session.Detector.Serialnumber);
                return;
            }

            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.Clear();            

            LineObj line1 = new LineObj(Color.Black, (double)x - tbarNuclides.Value, pane.YAxis.Scale.Min, (double)x - tbarNuclides.Value, pane.YAxis.Scale.Max);
            makeGraphObjectType(ref line1.Tag, GraphObjectType.EnergyTolerance);
            line1.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            pane.GraphObjList.Add(line1);

            LineObj line2 = new LineObj(Color.Black, (double)x + tbarNuclides.Value, pane.YAxis.Scale.Min, (double)x + tbarNuclides.Value, pane.YAxis.Scale.Max);
            makeGraphObjectType(ref line2.Tag, GraphObjectType.EnergyTolerance);
            line2.Line.Style = System.Drawing.Drawing2D.DashStyle.Dot;
            pane.GraphObjList.Add(line2);

            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();

            // List nuclides            
            lbNuclides.Items.Clear();
            foreach(NuclideInfo ni in NuclideLibrary)
            {            
                foreach(NuclideEnergy ne in ni.Energies)
                {
                    if (ne.Energy > E - (double)tbarNuclides.Value && ne.Energy < E + (double)tbarNuclides.Value)
                    {
                        lbNuclides.Items.Add(ni);
                        break;
                    }
                }
            }
        }        

        private void tbarNuclides_ValueChanged(object sender, EventArgs e)
        {
            // Update value label
            lblSessionETOL.Text = tbarNuclides.Value.ToString();
        }

        private void lbNuclides_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)
                return;            

            // Remove current nuclide lines from graph
            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.RemoveAll(o => isGraphObjectType(o.Tag, GraphObjectType.Energy));

            if (lbNuclides.SelectedItems.Count > 0)
            {
                double offset_y = 0d;

                // Display lines for currently selected nuclide
                NuclideInfo ni = (NuclideInfo)lbNuclides.SelectedItems[0];
                foreach(NuclideEnergy ne in ni.Energies)
                {
                    int ch = GetChannelFromEnergy(session.Detector, ne.Energy, 0, (int)session.NumChannels);
                    if(ch == -1)
                    {
                        // If no channel is found, or energy is outside current spectrum, continue to next energy
                        log.Warn("No channel found for energy: " + ni.Name + " " + ne.Energy.ToString());
                        continue;
                    }

                    // Add energy line
                    LineObj line = new LineObj(Color.ForestGreen, (double)ch, pane.YAxis.Scale.Min, (double)ch, pane.YAxis.Scale.Max);
                    makeGraphObjectType(ref line.Tag, GraphObjectType.Energy);
                    pane.GraphObjList.Add(line);
                               
                    // Add probability text
                    TextObj label = new TextObj(ne.Probability.ToString() + " %", (double)ch, pane.YAxis.Scale.Max - offset_y, CoordType.AxisXY2Scale, AlignH.Left, AlignV.Top);
                    makeGraphObjectType(ref label.Tag, GraphObjectType.Energy);                    
                    label.FontSpec.Border.IsVisible = false;
                    label.FontSpec.Size = 9f;
                    label.FontSpec.Fill.Color = SystemColors.ButtonFace;
                    label.ZOrder = ZOrder.D_BehindAxis;
                    pane.GraphObjList.Add(label);
                    offset_y += pane.YAxis.Scale.Max / 25d;
                }                
            }

            // Update graph
            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();
        }

        private void menuItemSaveAsCSV_Click(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)
                return;

            // Show dialog for file selection
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Log File (*.csv)|*.csv|All Files (*.*)|*.*";
            dialog.DefaultExt = "csv";
            dialog.FileName = session.Name;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                SessionExporter.ExportAsCSV(log, session, dialog.FileName);
            }
            catch(Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void menuItemSaveAsCHN_Click(object sender, EventArgs e)
        {
            if (session == null || session.IsEmpty)
            {
                MessageBox.Show("No session active");
                return;
            }

            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;
                dialog.Description = "Select folder to store CHN files";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    SessionExporter.ExportAsCHN(log, session, dialog.SelectedPath);
                    log.Info("session " + session.Name + " stored with CHN format in " + dialog.SelectedPath);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void menuItemSaveAsKMZ_Click(object sender, EventArgs e)
        {
            if (session == null || session.IsEmpty)
            {
                MessageBox.Show("No session active");
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Kmz File (*.kmz)|*.kmz";
            dialog.DefaultExt = "kmz";
            dialog.FileName = session.Name;
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                SessionExporter.ExportAsKMZ(log, session, dialog.FileName);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void menuItemNuclidesUnselect_Click(object sender, EventArgs e)
        {
            // Clear nuclide UI
            lbNuclides.ClearSelected();

            // Remove energy lines from graph
            GraphPane pane = graphSession.GraphPane;
            pane.GraphObjList.RemoveAll(o => o.Tag != null && (Int32)o.Tag == 2);   
         
            // Update graph
            graphSession.RestoreScale(pane);
            graphSession.AxisChange();
            graphSession.Refresh();
        }

        private void menuItemConvertToLocalTime_CheckedChanged(object sender, EventArgs e)
        {
            settings.DisplayLocalTime = menuItemConvertToLocalTime.Checked;
        }

        private void btnSessionsClose_Click(object sender, EventArgs e)
        {
            tabs.SelectedTab = pageMenu;
        }                                                

        private void menuItemLoadBackgroundSelection_Click(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)
            {
                MessageBox.Show("You must load a session first");
                return;
            }

            if(lbSession.SelectedItems.Count < 1)
            {
                MessageBox.Show("No spectrums selected");
                return;
            }

            ClearBackground();

            int minIndex = -1, maxIndex = -1;
            List<Spectrum> spectrumSelection = new List<Spectrum>();
            foreach(object o in lbSession.SelectedItems)
            {
                Spectrum spec = o as Spectrum;
                spectrumSelection.Add(spec);

                if(minIndex == -1 && maxIndex == -1)
                {
                    minIndex = spec.SessionIndex;
                    maxIndex = spec.SessionIndex;
                }
                else
                {
                    if (spec.SessionIndex < minIndex)
                        minIndex = spec.SessionIndex;
                    if (spec.SessionIndex > maxIndex)
                        maxIndex = spec.SessionIndex;
                }
            }

            // Store background in session
            session.SetBackground(spectrumSelection);

            lblBackground.Text = "Background: " + minIndex + " -> " + maxIndex;
            log.Info("Background selection " + minIndex + " -> " + maxIndex + " loaded for session " + session.Name);            
        }

        private void graphSession_MouseClick(object sender, MouseEventArgs e)
        {
            int x, y;
            GetGraphPointFromMousePos(e.X, e.Y, graphSession, out x, out y);

            selectedChannel = x;
            lblSessionSelChannel.Text = "[" + String.Format("{0:####0}", selectedChannel) + "]";
        }

        public void Shutdown()
        {
            if (syncService.IsRunning())
            {
                syncService.RequestStop();
                syncThread.Join();
                log.Info("sync service closed");
            }
            
            timer.Stop();
        }        

        private void menuItemUseAsGroundLevel_Click(object sender, EventArgs e)
        {
            if (session == null || !session.IsLoaded)            
                return;

            if (lbSession.SelectedItems.Count != 1)
            {
                MessageBox.Show("Only a single spectrum can be used as ground level");
                return;
            }

            Spectrum spec = lbSession.SelectedItems[0] as Spectrum;
            currentGroundLevelIndex = spec.SessionIndex;
            lblGroundLevelIndex.Text = "Gnd idx: " + currentGroundLevelIndex;
        }
    }    
}
