namespace crash
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuItemSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearSession = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSessionInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemLoadBackgroundSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemClearBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsCHN = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsKMZ = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSaveAsCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemShowROIHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuSession = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemSessionUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSetAsBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemUseAsGroundLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuNuclides = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemNuclidesUnselect = new System.Windows.Forms.ToolStripMenuItem();
            this.openSessionDialog = new System.Windows.Forms.OpenFileDialog();
            this.pageSessions = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainerSessionLeft = new System.Windows.Forms.SplitContainer();
            this.lbSession = new System.Windows.Forms.ListBox();
            this.panelNuclides = new System.Windows.Forms.Panel();
            this.lbNuclides = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.tbarNuclides = new System.Windows.Forms.TrackBar();
            this.lblSessionETOL = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.graphSession = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.lblGpsTime = new System.Windows.Forms.Label();
            this.lblSession = new System.Windows.Forms.Label();
            this.lblBackground = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblLivetime = new System.Windows.Forms.Label();
            this.lblRealtime = new System.Windows.Forms.Label();
            this.lblIndex = new System.Windows.Forms.Label();
            this.lblSessionDetector = new System.Windows.Forms.Label();
            this.lblMaxCount = new System.Windows.Forms.Label();
            this.lblMinCount = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblDoserate = new System.Windows.Forms.Label();
            this.toolsSession = new System.Windows.Forms.ToolStrip();
            this.btnOptions = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuItemSubtractBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemLockBackgroundToZero = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConvertToLocalTime = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSessionEnergy = new System.Windows.Forms.Label();
            this.lblSessionSelChannel = new System.Windows.Forms.Label();
            this.lblSessionChannel = new System.Windows.Forms.Label();
            this.lblGroundLevelIndex = new System.Windows.Forms.Label();
            this.panelSessionsControl = new System.Windows.Forms.Panel();
            this.lblSessionsDatabase = new System.Windows.Forms.Label();
            this.btnSessionsBrowse = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.tabs = new System.Windows.Forms.TabControl();
            this.menu.SuspendLayout();
            this.contextMenuSession.SuspendLayout();
            this.contextMenuNuclides.SuspendLayout();
            this.pageSessions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSessionLeft)).BeginInit();
            this.splitContainerSessionLeft.Panel1.SuspendLayout();
            this.splitContainerSessionLeft.Panel2.SuspendLayout();
            this.splitContainerSessionLeft.SuspendLayout();
            this.panelNuclides.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarNuclides)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.toolsSession.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSessionsControl.SuspendLayout();
            this.tabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSession,
            this.menuItemView});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menu.Size = new System.Drawing.Size(1219, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuItemSession
            // 
            this.menuItemSession.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemClearSession,
            this.menuItemSessionInfo,
            this.toolStripSeparator4,
            this.menuItemLoadBackgroundSelection,
            this.menuItemClearBackground,
            this.toolStripSeparator7,
            this.menuItemExport});
            this.menuItemSession.Name = "menuItemSession";
            this.menuItemSession.Size = new System.Drawing.Size(58, 20);
            this.menuItemSession.Text = "&Session";
            // 
            // menuItemClearSession
            // 
            this.menuItemClearSession.Name = "menuItemClearSession";
            this.menuItemClearSession.Size = new System.Drawing.Size(217, 22);
            this.menuItemClearSession.Text = "C&lear session";
            this.menuItemClearSession.Click += new System.EventHandler(this.menuItemClearSession_Click);
            // 
            // menuItemSessionInfo
            // 
            this.menuItemSessionInfo.Name = "menuItemSessionInfo";
            this.menuItemSessionInfo.Size = new System.Drawing.Size(217, 22);
            this.menuItemSessionInfo.Text = "Edit &session info";
            this.menuItemSessionInfo.Click += new System.EventHandler(this.menuItemSessionInfo_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(214, 6);
            // 
            // menuItemLoadBackgroundSelection
            // 
            this.menuItemLoadBackgroundSelection.Name = "menuItemLoadBackgroundSelection";
            this.menuItemLoadBackgroundSelection.Size = new System.Drawing.Size(217, 22);
            this.menuItemLoadBackgroundSelection.Text = "Load background selection";
            this.menuItemLoadBackgroundSelection.Click += new System.EventHandler(this.menuItemLoadBackgroundSelection_Click);
            // 
            // menuItemClearBackground
            // 
            this.menuItemClearBackground.Name = "menuItemClearBackground";
            this.menuItemClearBackground.Size = new System.Drawing.Size(217, 22);
            this.menuItemClearBackground.Text = "Clear back&ground session";
            this.menuItemClearBackground.Click += new System.EventHandler(this.menuItemClearBackground_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(214, 6);
            // 
            // menuItemExport
            // 
            this.menuItemExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSaveAsCHN,
            this.menuItemSaveAsKMZ,
            this.menuItemSaveAsCSV});
            this.menuItemExport.Name = "menuItemExport";
            this.menuItemExport.Size = new System.Drawing.Size(217, 22);
            this.menuItemExport.Text = "E&xport session as ...";
            // 
            // menuItemSaveAsCHN
            // 
            this.menuItemSaveAsCHN.Name = "menuItemSaveAsCHN";
            this.menuItemSaveAsCHN.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsCHN.Text = "&CHN";
            this.menuItemSaveAsCHN.ToolTipText = "Save session as multiple CHN files";
            this.menuItemSaveAsCHN.Click += new System.EventHandler(this.menuItemSaveAsCHN_Click);
            // 
            // menuItemSaveAsKMZ
            // 
            this.menuItemSaveAsKMZ.Name = "menuItemSaveAsKMZ";
            this.menuItemSaveAsKMZ.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsKMZ.Text = "KM&Z";
            this.menuItemSaveAsKMZ.ToolTipText = "Save session as a KMZ file";
            this.menuItemSaveAsKMZ.Click += new System.EventHandler(this.menuItemSaveAsKMZ_Click);
            // 
            // menuItemSaveAsCSV
            // 
            this.menuItemSaveAsCSV.Name = "menuItemSaveAsCSV";
            this.menuItemSaveAsCSV.Size = new System.Drawing.Size(180, 22);
            this.menuItemSaveAsCSV.Text = "CSV (simple log file)";
            this.menuItemSaveAsCSV.ToolTipText = "Save session as a CSV file";
            this.menuItemSaveAsCSV.Click += new System.EventHandler(this.menuItemSaveAsCSV_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemShowROIHistory});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(48, 20);
            this.menuItemView.Text = "&Tools";
            // 
            // menuItemShowROIHistory
            // 
            this.menuItemShowROIHistory.Name = "menuItemShowROIHistory";
            this.menuItemShowROIHistory.Size = new System.Drawing.Size(166, 22);
            this.menuItemShowROIHistory.Text = "Show ROI &History";
            this.menuItemShowROIHistory.ToolTipText = "Show current ROI history in separate window";
            this.menuItemShowROIHistory.Click += new System.EventHandler(this.menuItemShowROIHistory_Click);
            // 
            // contextMenuSession
            // 
            this.contextMenuSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSessionUnselect,
            this.menuItemSetAsBackground,
            this.menuItemUseAsGroundLevel});
            this.contextMenuSession.Name = "contextMenuSession";
            this.contextMenuSession.Size = new System.Drawing.Size(177, 70);
            // 
            // menuItemSessionUnselect
            // 
            this.menuItemSessionUnselect.Name = "menuItemSessionUnselect";
            this.menuItemSessionUnselect.Size = new System.Drawing.Size(176, 22);
            this.menuItemSessionUnselect.Text = "&Unselect";
            this.menuItemSessionUnselect.Click += new System.EventHandler(this.menuItemSessionUnselect_Click);
            // 
            // menuItemSetAsBackground
            // 
            this.menuItemSetAsBackground.Name = "menuItemSetAsBackground";
            this.menuItemSetAsBackground.Size = new System.Drawing.Size(176, 22);
            this.menuItemSetAsBackground.Text = "Set as background";
            this.menuItemSetAsBackground.Click += new System.EventHandler(this.menuItemLoadBackgroundSelection_Click);
            // 
            // menuItemUseAsGroundLevel
            // 
            this.menuItemUseAsGroundLevel.Name = "menuItemUseAsGroundLevel";
            this.menuItemUseAsGroundLevel.Size = new System.Drawing.Size(176, 22);
            this.menuItemUseAsGroundLevel.Text = "Use as ground level";
            this.menuItemUseAsGroundLevel.Click += new System.EventHandler(this.menuItemUseAsGroundLevel_Click);
            // 
            // contextMenuNuclides
            // 
            this.contextMenuNuclides.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemNuclidesUnselect});
            this.contextMenuNuclides.Name = "contextMenuNuclides";
            this.contextMenuNuclides.Size = new System.Drawing.Size(120, 26);
            // 
            // menuItemNuclidesUnselect
            // 
            this.menuItemNuclidesUnselect.Name = "menuItemNuclidesUnselect";
            this.menuItemNuclidesUnselect.Size = new System.Drawing.Size(119, 22);
            this.menuItemNuclidesUnselect.Text = "&Unselect";
            this.menuItemNuclidesUnselect.Click += new System.EventHandler(this.menuItemNuclidesUnselect_Click);
            // 
            // openSessionDialog
            // 
            this.openSessionDialog.DefaultExt = "db";
            // 
            // pageSessions
            // 
            this.pageSessions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pageSessions.Controls.Add(this.splitContainer2);
            this.pageSessions.Controls.Add(this.panelSessionsControl);
            this.pageSessions.Location = new System.Drawing.Point(4, 25);
            this.pageSessions.Name = "pageSessions";
            this.pageSessions.Size = new System.Drawing.Size(1211, 599);
            this.pageSessions.TabIndex = 4;
            this.pageSessions.Text = "Sessions";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainerSessionLeft);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.graphSession);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer2.Panel2.Controls.Add(this.toolsSession);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(1211, 574);
            this.splitContainer2.SplitterDistance = 174;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 6;
            // 
            // splitContainerSessionLeft
            // 
            this.splitContainerSessionLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerSessionLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainerSessionLeft.Name = "splitContainerSessionLeft";
            this.splitContainerSessionLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerSessionLeft.Panel1
            // 
            this.splitContainerSessionLeft.Panel1.Controls.Add(this.lbSession);
            // 
            // splitContainerSessionLeft.Panel2
            // 
            this.splitContainerSessionLeft.Panel2.Controls.Add(this.panelNuclides);
            this.splitContainerSessionLeft.Size = new System.Drawing.Size(172, 572);
            this.splitContainerSessionLeft.SplitterDistance = 334;
            this.splitContainerSessionLeft.TabIndex = 9;
            // 
            // lbSession
            // 
            this.lbSession.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbSession.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbSession.ContextMenuStrip = this.contextMenuSession;
            this.lbSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSession.FormattingEnabled = true;
            this.lbSession.ItemHeight = 15;
            this.lbSession.Location = new System.Drawing.Point(0, 0);
            this.lbSession.Name = "lbSession";
            this.lbSession.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbSession.Size = new System.Drawing.Size(172, 334);
            this.lbSession.TabIndex = 7;
            this.lbSession.SelectedIndexChanged += new System.EventHandler(this.lbSession_SelectedIndexChanged);
            // 
            // panelNuclides
            // 
            this.panelNuclides.Controls.Add(this.lbNuclides);
            this.panelNuclides.Controls.Add(this.label12);
            this.panelNuclides.Controls.Add(this.panel8);
            this.panelNuclides.Controls.Add(this.label19);
            this.panelNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNuclides.Location = new System.Drawing.Point(0, 0);
            this.panelNuclides.Name = "panelNuclides";
            this.panelNuclides.Size = new System.Drawing.Size(172, 234);
            this.panelNuclides.TabIndex = 8;
            // 
            // lbNuclides
            // 
            this.lbNuclides.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lbNuclides.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbNuclides.ContextMenuStrip = this.contextMenuNuclides;
            this.lbNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbNuclides.FormattingEnabled = true;
            this.lbNuclides.ItemHeight = 15;
            this.lbNuclides.Location = new System.Drawing.Point(0, 63);
            this.lbNuclides.Name = "lbNuclides";
            this.lbNuclides.Size = new System.Drawing.Size(172, 171);
            this.lbNuclides.TabIndex = 2;
            this.lbNuclides.SelectedIndexChanged += new System.EventHandler(this.lbNuclides_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(0, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Nuclide suggestions";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.tbarNuclides);
            this.panel8.Controls.Add(this.lblSessionETOL);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel8.Location = new System.Drawing.Point(0, 21);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(172, 27);
            this.panel8.TabIndex = 4;
            // 
            // tbarNuclides
            // 
            this.tbarNuclides.AutoSize = false;
            this.tbarNuclides.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbarNuclides.Location = new System.Drawing.Point(0, 0);
            this.tbarNuclides.Maximum = 200;
            this.tbarNuclides.Minimum = 1;
            this.tbarNuclides.Name = "tbarNuclides";
            this.tbarNuclides.Size = new System.Drawing.Size(151, 27);
            this.tbarNuclides.TabIndex = 1;
            this.tbarNuclides.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbarNuclides.Value = 20;
            this.tbarNuclides.ValueChanged += new System.EventHandler(this.tbarNuclides_ValueChanged);
            // 
            // lblSessionETOL
            // 
            this.lblSessionETOL.AutoSize = true;
            this.lblSessionETOL.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblSessionETOL.Location = new System.Drawing.Point(151, 0);
            this.lblSessionETOL.Name = "lblSessionETOL";
            this.lblSessionETOL.Size = new System.Drawing.Size(21, 15);
            this.lblSessionETOL.TabIndex = 0;
            this.lblSessionETOL.Text = "20";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(3);
            this.label19.Size = new System.Drawing.Size(121, 21);
            this.label19.TabIndex = 0;
            this.label19.Text = "Energy tolerance";
            // 
            // graphSession
            // 
            this.graphSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graphSession.IsShowPointValues = true;
            this.graphSession.Location = new System.Drawing.Point(0, 110);
            this.graphSession.Name = "graphSession";
            this.graphSession.ScrollGrace = 0D;
            this.graphSession.ScrollMaxX = 0D;
            this.graphSession.ScrollMaxY = 0D;
            this.graphSession.ScrollMaxY2 = 0D;
            this.graphSession.ScrollMinX = 0D;
            this.graphSession.ScrollMinY = 0D;
            this.graphSession.ScrollMinY2 = 0D;
            this.graphSession.Size = new System.Drawing.Size(1030, 435);
            this.graphSession.TabIndex = 5;
            this.graphSession.UseExtendedPrintDialog = true;
            this.graphSession.MouseClick += new System.Windows.Forms.MouseEventHandler(this.graphSession_MouseClick);
            this.graphSession.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.graphSession_MouseDoubleClick);
            this.graphSession.MouseMove += new System.Windows.Forms.MouseEventHandler(this.graphSession_MouseMove);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.lblLatitude, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblLongitude, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblAltitude, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblGpsTime, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSession, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblBackground, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblComment, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblLivetime, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRealtime, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblIndex, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSessionDetector, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblMaxCount, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblMinCount, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTotalCount, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblDoserate, 3, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1030, 85);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLatitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatitude.Location = new System.Drawing.Point(3, 40);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(251, 20);
            this.lblLatitude.TabIndex = 0;
            this.lblLatitude.Text = "<Latitude>";
            this.lblLatitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLongitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLongitude.Location = new System.Drawing.Point(260, 40);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(251, 20);
            this.lblLongitude.TabIndex = 1;
            this.lblLongitude.Text = "<Longitude>";
            this.lblLongitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAltitude
            // 
            this.lblAltitude.AutoSize = true;
            this.lblAltitude.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAltitude.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAltitude.Location = new System.Drawing.Point(517, 40);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(251, 20);
            this.lblAltitude.TabIndex = 9;
            this.lblAltitude.Text = "<Altitude>";
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblGpsTime
            // 
            this.lblGpsTime.AutoSize = true;
            this.lblGpsTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGpsTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGpsTime.Location = new System.Drawing.Point(774, 40);
            this.lblGpsTime.Name = "lblGpsTime";
            this.lblGpsTime.Size = new System.Drawing.Size(253, 20);
            this.lblGpsTime.TabIndex = 10;
            this.lblGpsTime.Text = "<GpsTimeStart>";
            this.lblGpsTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSession
            // 
            this.lblSession.AutoSize = true;
            this.lblSession.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSession.Location = new System.Drawing.Point(3, 0);
            this.lblSession.Name = "lblSession";
            this.lblSession.Size = new System.Drawing.Size(251, 20);
            this.lblSession.TabIndex = 4;
            this.lblSession.Text = "<lblSession>";
            this.lblSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBackground
            // 
            this.lblBackground.AutoSize = true;
            this.lblBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBackground.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBackground.Location = new System.Drawing.Point(774, 0);
            this.lblBackground.Name = "lblBackground";
            this.lblBackground.Size = new System.Drawing.Size(253, 20);
            this.lblBackground.TabIndex = 16;
            this.lblBackground.Text = "<lblBackground>";
            this.lblBackground.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lblComment, 2);
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(260, 0);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(508, 20);
            this.lblComment.TabIndex = 17;
            this.lblComment.Text = "<lblComment>";
            this.lblComment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLivetime
            // 
            this.lblLivetime.AutoSize = true;
            this.lblLivetime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLivetime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLivetime.Location = new System.Drawing.Point(774, 20);
            this.lblLivetime.Name = "lblLivetime";
            this.lblLivetime.Size = new System.Drawing.Size(253, 20);
            this.lblLivetime.TabIndex = 3;
            this.lblLivetime.Text = "<Livetime>";
            this.lblLivetime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRealtime
            // 
            this.lblRealtime.AutoSize = true;
            this.lblRealtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRealtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRealtime.Location = new System.Drawing.Point(517, 20);
            this.lblRealtime.Name = "lblRealtime";
            this.lblRealtime.Size = new System.Drawing.Size(251, 20);
            this.lblRealtime.TabIndex = 2;
            this.lblRealtime.Text = "<Realtime>";
            this.lblRealtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndex.Location = new System.Drawing.Point(260, 20);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(251, 20);
            this.lblIndex.TabIndex = 5;
            this.lblIndex.Text = "<Index>";
            this.lblIndex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSessionDetector
            // 
            this.lblSessionDetector.AutoSize = true;
            this.lblSessionDetector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSessionDetector.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionDetector.Location = new System.Drawing.Point(3, 20);
            this.lblSessionDetector.Name = "lblSessionDetector";
            this.lblSessionDetector.Size = new System.Drawing.Size(251, 20);
            this.lblSessionDetector.TabIndex = 18;
            this.lblSessionDetector.Text = "<lblSessionDetector>";
            this.lblSessionDetector.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMaxCount
            // 
            this.lblMaxCount.AutoSize = true;
            this.lblMaxCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCount.Location = new System.Drawing.Point(3, 60);
            this.lblMaxCount.Name = "lblMaxCount";
            this.lblMaxCount.Size = new System.Drawing.Size(251, 20);
            this.lblMaxCount.TabIndex = 6;
            this.lblMaxCount.Text = "<MaxCount>";
            this.lblMaxCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinCount
            // 
            this.lblMinCount.AutoSize = true;
            this.lblMinCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMinCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinCount.Location = new System.Drawing.Point(260, 60);
            this.lblMinCount.Name = "lblMinCount";
            this.lblMinCount.Size = new System.Drawing.Size(251, 20);
            this.lblMinCount.TabIndex = 7;
            this.lblMinCount.Text = "<MinCount>";
            this.lblMinCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCount.Location = new System.Drawing.Point(517, 60);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(251, 20);
            this.lblTotalCount.TabIndex = 8;
            this.lblTotalCount.Text = "<TotalCount>";
            this.lblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblDoserate
            // 
            this.lblDoserate.AutoSize = true;
            this.lblDoserate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDoserate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoserate.Location = new System.Drawing.Point(774, 60);
            this.lblDoserate.Name = "lblDoserate";
            this.lblDoserate.Size = new System.Drawing.Size(253, 20);
            this.lblDoserate.TabIndex = 15;
            this.lblDoserate.Text = "<Doserate>";
            this.lblDoserate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolsSession
            // 
            this.toolsSession.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolsSession.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOptions});
            this.toolsSession.Location = new System.Drawing.Point(0, 0);
            this.toolsSession.Name = "toolsSession";
            this.toolsSession.Size = new System.Drawing.Size(1030, 25);
            this.toolsSession.TabIndex = 7;
            this.toolsSession.Text = "toolStrip1";
            // 
            // btnOptions
            // 
            this.btnOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSubtractBackground,
            this.menuItemLockBackgroundToZero,
            this.menuItemConvertToLocalTime});
            this.btnOptions.Image = global::crash.Properties.Resources.options1_16;
            this.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOptions.Name = "btnOptions";
            this.btnOptions.Size = new System.Drawing.Size(78, 22);
            this.btnOptions.Text = "Options";
            this.btnOptions.ToolTipText = "Session options";
            // 
            // menuItemSubtractBackground
            // 
            this.menuItemSubtractBackground.CheckOnClick = true;
            this.menuItemSubtractBackground.Name = "menuItemSubtractBackground";
            this.menuItemSubtractBackground.Size = new System.Drawing.Size(205, 22);
            this.menuItemSubtractBackground.Text = "Subtract background";
            // 
            // menuItemLockBackgroundToZero
            // 
            this.menuItemLockBackgroundToZero.CheckOnClick = true;
            this.menuItemLockBackgroundToZero.Name = "menuItemLockBackgroundToZero";
            this.menuItemLockBackgroundToZero.Size = new System.Drawing.Size(205, 22);
            this.menuItemLockBackgroundToZero.Text = "Lock background to zero";
            // 
            // menuItemConvertToLocalTime
            // 
            this.menuItemConvertToLocalTime.Checked = true;
            this.menuItemConvertToLocalTime.CheckOnClick = true;
            this.menuItemConvertToLocalTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemConvertToLocalTime.Name = "menuItemConvertToLocalTime";
            this.menuItemConvertToLocalTime.Size = new System.Drawing.Size(205, 22);
            this.menuItemConvertToLocalTime.Text = "Show local time";
            this.menuItemConvertToLocalTime.ToolTipText = "Show dates using local time";
            this.menuItemConvertToLocalTime.CheckedChanged += new System.EventHandler(this.menuItemConvertToLocalTime_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblSessionEnergy);
            this.panel1.Controls.Add(this.lblSessionSelChannel);
            this.panel1.Controls.Add(this.lblSessionChannel);
            this.panel1.Controls.Add(this.lblGroundLevelIndex);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 545);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1030, 27);
            this.panel1.TabIndex = 6;
            // 
            // lblSessionEnergy
            // 
            this.lblSessionEnergy.AutoSize = true;
            this.lblSessionEnergy.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSessionEnergy.Location = new System.Drawing.Point(400, 0);
            this.lblSessionEnergy.Name = "lblSessionEnergy";
            this.lblSessionEnergy.Size = new System.Drawing.Size(116, 15);
            this.lblSessionEnergy.TabIndex = 1;
            this.lblSessionEnergy.Text = "<lblSessionEnergy>";
            // 
            // lblSessionSelChannel
            // 
            this.lblSessionSelChannel.AutoSize = true;
            this.lblSessionSelChannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSessionSelChannel.ForeColor = System.Drawing.Color.Crimson;
            this.lblSessionSelChannel.Location = new System.Drawing.Point(258, 0);
            this.lblSessionSelChannel.Name = "lblSessionSelChannel";
            this.lblSessionSelChannel.Size = new System.Drawing.Size(142, 15);
            this.lblSessionSelChannel.TabIndex = 3;
            this.lblSessionSelChannel.Text = "<lblSessionSelChannel>";
            // 
            // lblSessionChannel
            // 
            this.lblSessionChannel.AutoSize = true;
            this.lblSessionChannel.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblSessionChannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionChannel.Location = new System.Drawing.Point(134, 0);
            this.lblSessionChannel.Name = "lblSessionChannel";
            this.lblSessionChannel.Size = new System.Drawing.Size(124, 15);
            this.lblSessionChannel.TabIndex = 0;
            this.lblSessionChannel.Text = "<lblSessionChannel>";
            // 
            // lblGroundLevelIndex
            // 
            this.lblGroundLevelIndex.AutoSize = true;
            this.lblGroundLevelIndex.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblGroundLevelIndex.Location = new System.Drawing.Point(0, 0);
            this.lblGroundLevelIndex.Name = "lblGroundLevelIndex";
            this.lblGroundLevelIndex.Size = new System.Drawing.Size(134, 15);
            this.lblGroundLevelIndex.TabIndex = 4;
            this.lblGroundLevelIndex.Text = "<lblGroundLevelIndex>";
            // 
            // panelSessionsControl
            // 
            this.panelSessionsControl.Controls.Add(this.lblSessionsDatabase);
            this.panelSessionsControl.Controls.Add(this.btnSessionsBrowse);
            this.panelSessionsControl.Controls.Add(this.progress);
            this.panelSessionsControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSessionsControl.Location = new System.Drawing.Point(0, 0);
            this.panelSessionsControl.Name = "panelSessionsControl";
            this.panelSessionsControl.Size = new System.Drawing.Size(1211, 25);
            this.panelSessionsControl.TabIndex = 7;
            // 
            // lblSessionsDatabase
            // 
            this.lblSessionsDatabase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSessionsDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSessionsDatabase.Location = new System.Drawing.Point(130, 0);
            this.lblSessionsDatabase.Name = "lblSessionsDatabase";
            this.lblSessionsDatabase.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.lblSessionsDatabase.Size = new System.Drawing.Size(941, 25);
            this.lblSessionsDatabase.TabIndex = 4;
            this.lblSessionsDatabase.Text = "<lblSessionsDatabase>";
            // 
            // btnSessionsBrowse
            // 
            this.btnSessionsBrowse.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSessionsBrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSessionsBrowse.Location = new System.Drawing.Point(0, 0);
            this.btnSessionsBrowse.Name = "btnSessionsBrowse";
            this.btnSessionsBrowse.Size = new System.Drawing.Size(130, 25);
            this.btnSessionsBrowse.TabIndex = 3;
            this.btnSessionsBrowse.Text = "Open session";
            this.btnSessionsBrowse.UseVisualStyleBackColor = true;
            this.btnSessionsBrowse.Click += new System.EventHandler(this.menuItemLoadSession_Click);
            // 
            // progress
            // 
            this.progress.Dock = System.Windows.Forms.DockStyle.Right;
            this.progress.Location = new System.Drawing.Point(1071, 0);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(140, 25);
            this.progress.Step = 1;
            this.progress.TabIndex = 5;
            this.progress.Visible = false;
            // 
            // tabs
            // 
            this.tabs.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabs.Controls.Add(this.pageSessions);
            this.tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabs.Location = new System.Drawing.Point(0, 24);
            this.tabs.Margin = new System.Windows.Forms.Padding(2);
            this.tabs.Name = "tabs";
            this.tabs.Padding = new System.Drawing.Point(2, 2);
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1219, 628);
            this.tabs.TabIndex = 5;
            this.tabs.SelectedIndexChanged += new System.EventHandler(this.tabs_SelectedIndexChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1219, 652);
            this.ControlBox = false;
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.menu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 320);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Session";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.contextMenuSession.ResumeLayout(false);
            this.contextMenuNuclides.ResumeLayout(false);
            this.pageSessions.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainerSessionLeft.Panel1.ResumeLayout(false);
            this.splitContainerSessionLeft.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerSessionLeft)).EndInit();
            this.splitContainerSessionLeft.ResumeLayout(false);
            this.panelNuclides.ResumeLayout(false);
            this.panelNuclides.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbarNuclides)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.toolsSession.ResumeLayout(false);
            this.toolsSession.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelSessionsControl.ResumeLayout(false);
            this.tabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuItemSession;
        private System.Windows.Forms.ContextMenuStrip contextMenuSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionUnselect;
        private System.Windows.Forms.ToolStripMenuItem menuItemSessionInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearSession;
        private System.Windows.Forms.ToolStripMenuItem menuItemClearBackground;
        private System.Windows.Forms.ToolStripMenuItem menuItemView;
        private System.Windows.Forms.ToolStripMenuItem menuItemShowROIHistory;
        private System.Windows.Forms.ToolStripMenuItem menuItemExport;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsCHN;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsKMZ;
        private System.Windows.Forms.ToolStripMenuItem menuItemSaveAsCSV;
        private System.Windows.Forms.ContextMenuStrip contextMenuNuclides;
        private System.Windows.Forms.ToolStripMenuItem menuItemNuclidesUnselect;
        private System.Windows.Forms.OpenFileDialog openSessionDialog;
        private System.Windows.Forms.ToolStripMenuItem menuItemLoadBackgroundSelection;
        private System.Windows.Forms.ToolStripMenuItem menuItemSetAsBackground;
        private System.Windows.Forms.ToolStripMenuItem menuItemUseAsGroundLevel;
        private System.Windows.Forms.TabPage pageSessions;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainerSessionLeft;
        private System.Windows.Forms.ListBox lbSession;
        private System.Windows.Forms.Panel panelNuclides;
        private System.Windows.Forms.ListBox lbNuclides;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.TrackBar tbarNuclides;
        private System.Windows.Forms.Label lblSessionETOL;
        private System.Windows.Forms.Label label19;
        private ZedGraph.ZedGraphControl graphSession;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Label lblGpsTime;
        private System.Windows.Forms.Label lblSession;
        private System.Windows.Forms.Label lblBackground;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblLivetime;
        private System.Windows.Forms.Label lblRealtime;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label lblSessionDetector;
        private System.Windows.Forms.Label lblMaxCount;
        private System.Windows.Forms.Label lblMinCount;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblDoserate;
        private System.Windows.Forms.ToolStrip toolsSession;
        private System.Windows.Forms.ToolStripDropDownButton btnOptions;
        private System.Windows.Forms.ToolStripMenuItem menuItemSubtractBackground;
        private System.Windows.Forms.ToolStripMenuItem menuItemLockBackgroundToZero;
        private System.Windows.Forms.ToolStripMenuItem menuItemConvertToLocalTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSessionEnergy;
        private System.Windows.Forms.Label lblSessionSelChannel;
        private System.Windows.Forms.Label lblSessionChannel;
        private System.Windows.Forms.Label lblGroundLevelIndex;
        private System.Windows.Forms.Panel panelSessionsControl;
        private System.Windows.Forms.Label lblSessionsDatabase;
        private System.Windows.Forms.Button btnSessionsBrowse;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.ProgressBar progress;
    }
}

