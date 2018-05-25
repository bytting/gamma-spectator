using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace crash
{
    public partial class FormSelectSession : Form
    {
        private FormContainer parent = null;
        private GASettings settings = null;
        private ILog log = null;

        List<APISession> sessionList = null;

        public APISession SelectedSession;

        public FormSelectSession(FormContainer p, GASettings s, ILog l)
        {
            InitializeComponent();
            parent = p;
            settings = s;
            log = l;
        }

        private void FormSelectSession_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            tbAddress.Text = settings.LastUploadHostname;
            tbUsername.Text = settings.LastUploadUsername;
            tbPassword.Text = settings.LastUploadPassword;
        }

        private void btnPopulate_Click(object sender, EventArgs e)
        {            
            string url = tbAddress.Text.Trim();
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url + "/sessions");
            string credentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password));
            request.Headers.Add("Authorization", "Basic " + credentials);
            request.Timeout = 20000;
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";

            string data;
            HttpStatusCode code = Utils.GetResponseData(request, out data);

            if (code != HttpStatusCode.OK)
            {                
                lblStatus.Text = code.ToString() + ": " + data;
                return;
            }
            
            settings.LastUploadHostname = url;
            settings.LastUploadUsername = username;
            settings.LastUploadPassword = password;
            parent.SaveSettings();

            gridSessions.Rows.Clear();
            sessionList = JsonConvert.DeserializeObject<List<APISession>>(data);
            foreach(APISession apiSession in sessionList)
            {
                gridSessions.Rows.Add(new string[] { apiSession.Name, apiSession.Comment, apiSession.Livetime.ToString() });
            }

            lblStatus.Text = "Sessions loaded at " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(gridSessions.SelectedRows.Count < 1)
            {
                MessageBox.Show("You must select a session first");
                return;
            }

            string name = gridSessions.SelectedRows[0].Cells["ColumnName"].Value.ToString();
            SelectedSession = sessionList.Find(x => x.Name == name);

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
