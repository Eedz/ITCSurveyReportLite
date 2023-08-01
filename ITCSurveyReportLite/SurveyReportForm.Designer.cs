namespace ITCSurveyReportLite
{
    /// <summary>
    /// 
    /// </summary>
    partial class SurveyReportForm
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
            System.Windows.Forms.Label detailsLabel;
            System.Windows.Forms.Label fileNameLabel;
            this.cboSurveys = new System.Windows.Forms.ComboBox();
            this.cmdAddSurvey = new System.Windows.Forms.Button();
            this.cmdRemoveSurvey = new System.Windows.Forms.Button();
            this.lstSelectedSurveys = new System.Windows.Forms.ListBox();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.pgFields = new System.Windows.Forms.TabPage();
            this.groupTRoutingStyle = new System.Windows.Forms.GroupBox();
            this.optTRoutingStyleNone = new System.Windows.Forms.RadioButton();
            this.optTRoutingStyleGrey = new System.Windows.Forms.RadioButton();
            this.optTRoutingStyleNormal = new System.Windows.Forms.RadioButton();
            this.chkIncludeEnglish = new System.Windows.Forms.CheckBox();
            this.cmdCustomizeContent = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmdCommentFields = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lstCommentTypes = new System.Windows.Forms.ListBox();
            this.chkEnglishRouting = new System.Windows.Forms.CheckBox();
            this.lstTransFields = new System.Windows.Forms.ListBox();
            this.lblTransFields = new System.Windows.Forms.Label();
            this.lstExtraFields = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupRoutingStyle = new System.Windows.Forms.GroupBox();
            this.optRoutingStyleNone = new System.Windows.Forms.RadioButton();
            this.optRoutingStyleGrey = new System.Windows.Forms.RadioButton();
            this.optRoutingStyleNormal = new System.Windows.Forms.RadioButton();
            this.lblCurrentSurveyFields = new System.Windows.Forms.Label();
            this.dateBackend = new System.Windows.Forms.DateTimePicker();
            this.lblBackend = new System.Windows.Forms.Label();
            this.pgCompare = new System.Windows.Forms.TabPage();
            this.chklstPrimarySurvey = new System.Windows.Forms.CheckedListBox();
            this.lblPrimarySurvey = new System.Windows.Forms.Label();
            this.groupHighlightOptions = new System.Windows.Forms.GroupBox();
            this.flowHighlightOptions = new System.Windows.Forms.FlowLayoutPanel();
            this.highlightNRCheckBox = new System.Windows.Forms.CheckBox();
            this.compareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ignoreSimilarWordsCheckBox = new System.Windows.Forms.CheckBox();
            this.showDeletedFieldsCheckBox = new System.Windows.Forms.CheckBox();
            this.chkShowDeletedQuestions = new System.Windows.Forms.CheckBox();
            this.chkReInsertDeletions = new System.Windows.Forms.CheckBox();
            this.chkHideReference = new System.Windows.Forms.CheckBox();
            this.chkHideIdenticalWordings = new System.Windows.Forms.CheckBox();
            this.chkHideIdenticalQs = new System.Windows.Forms.CheckBox();
            this.groupHighlightStyle = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.highlightCheckBox = new System.Windows.Forms.CheckBox();
            this.chkCompare = new System.Windows.Forms.CheckBox();
            this.surveyReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pgFileName = new System.Windows.Forms.TabPage();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtSecondSources = new System.Windows.Forms.TextBox();
            this.detailsTextBox = new System.Windows.Forms.TextBox();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.txtMainSource = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmdSelfCompare = new System.Windows.Forms.Button();
            this.toolTipStandard = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipStandardT = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipWeb = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipWebT = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.outputOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupTemplate = new System.Windows.Forms.GroupBox();
            this.cmdOpenTranslatorOptions = new System.Windows.Forms.Button();
            this.chkStdWebTranslation = new System.Windows.Forms.CheckBox();
            this.chkStdTranslation = new System.Windows.Forms.CheckBox();
            this.optTranslator = new System.Windows.Forms.RadioButton();
            this.optNoTemplate = new System.Windows.Forms.RadioButton();
            this.optWebTemplate = new System.Windows.Forms.RadioButton();
            this.optStdTemplate = new System.Windows.Forms.RadioButton();
            this.cmdGenerate = new System.Windows.Forms.Button();
            this.cmdOpenReportFolder = new System.Windows.Forms.Button();
            this.reportLayoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.surveysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            detailsLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            this.tabControlOptions.SuspendLayout();
            this.pgFields.SuspendLayout();
            this.groupTRoutingStyle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupRoutingStyle.SuspendLayout();
            this.pgCompare.SuspendLayout();
            this.groupHighlightOptions.SuspendLayout();
            this.flowHighlightOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareBindingSource)).BeginInit();
            this.groupHighlightStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).BeginInit();
            this.pgFileName.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupTemplate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportLayoutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveysBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // detailsLabel
            // 
            detailsLabel.AutoSize = true;
            detailsLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            detailsLabel.Location = new System.Drawing.Point(99, 254);
            detailsLabel.Name = "detailsLabel";
            detailsLabel.Size = new System.Drawing.Size(105, 16);
            detailsLabel.TabIndex = 27;
            detailsLabel.Text = "Report Details:";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new System.Drawing.Point(13, 298);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(100, 16);
            fileNameLabel.TabIndex = 33;
            fileNameLabel.Text = "Final File Name:";
            // 
            // cboSurveys
            // 
            this.cboSurveys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cboSurveys.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurveys.BackColor = System.Drawing.SystemColors.Window;
            this.cboSurveys.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboSurveys.DisplayMember = "Survey";
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboSurveys.Location = new System.Drawing.Point(22, 76);
            this.cboSurveys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(110, 24);
            this.cboSurveys.TabIndex = 0;
            this.cboSurveys.ValueMember = "Survey";
            this.cboSurveys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Surveys_KeyDown);
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Location = new System.Drawing.Point(138, 75);
            this.cmdAddSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(45, 25);
            this.cmdAddSurvey.TabIndex = 1;
            this.cmdAddSurvey.Text = "->";
            this.cmdAddSurvey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.AddSurvey_Click);
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(138, 107);
            this.cmdRemoveSurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdRemoveSurvey.Name = "cmdRemoveSurvey";
            this.cmdRemoveSurvey.Size = new System.Drawing.Size(45, 25);
            this.cmdRemoveSurvey.TabIndex = 2;
            this.cmdRemoveSurvey.Text = "<-";
            this.cmdRemoveSurvey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdRemoveSurvey.UseVisualStyleBackColor = true;
            this.cmdRemoveSurvey.Click += new System.EventHandler(this.RemoveSurvey_Click);
            // 
            // lstSelectedSurveys
            // 
            this.lstSelectedSurveys.DisplayMember = "SurveyCode";
            this.lstSelectedSurveys.FormattingEnabled = true;
            this.lstSelectedSurveys.ItemHeight = 16;
            this.lstSelectedSurveys.Location = new System.Drawing.Point(189, 76);
            this.lstSelectedSurveys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstSelectedSurveys.Name = "lstSelectedSurveys";
            this.lstSelectedSurveys.Size = new System.Drawing.Size(124, 132);
            this.lstSelectedSurveys.TabIndex = 3;
            this.lstSelectedSurveys.ValueMember = "ID";
            this.lstSelectedSurveys.SelectedIndexChanged += new System.EventHandler(this.SelectedSurveys_SelectedIndexChanged);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.pgFields);
            this.tabControlOptions.Controls.Add(this.pgCompare);
            this.tabControlOptions.Controls.Add(this.pgFileName);
            this.tabControlOptions.Location = new System.Drawing.Point(14, 212);
            this.tabControlOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(511, 440);
            this.tabControlOptions.TabIndex = 5;
            this.tabControlOptions.Visible = false;
            this.tabControlOptions.SelectedIndexChanged += new System.EventHandler(this.tabControlOptions_SelectedIndexChanged);
            // 
            // pgFields
            // 
            this.pgFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFields.Controls.Add(this.groupTRoutingStyle);
            this.pgFields.Controls.Add(this.chkIncludeEnglish);
            this.pgFields.Controls.Add(this.cmdCustomizeContent);
            this.pgFields.Controls.Add(this.panel2);
            this.pgFields.Controls.Add(this.groupRoutingStyle);
            this.pgFields.Controls.Add(this.lblCurrentSurveyFields);
            this.pgFields.Controls.Add(this.dateBackend);
            this.pgFields.Controls.Add(this.lblBackend);
            this.pgFields.Location = new System.Drawing.Point(4, 25);
            this.pgFields.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgFields.Name = "pgFields";
            this.pgFields.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgFields.Size = new System.Drawing.Size(503, 411);
            this.pgFields.TabIndex = 1;
            this.pgFields.Text = "Survey Content";
            // 
            // groupTRoutingStyle
            // 
            this.groupTRoutingStyle.Controls.Add(this.optTRoutingStyleNone);
            this.groupTRoutingStyle.Controls.Add(this.optTRoutingStyleGrey);
            this.groupTRoutingStyle.Controls.Add(this.optTRoutingStyleNormal);
            this.groupTRoutingStyle.Enabled = false;
            this.groupTRoutingStyle.Location = new System.Drawing.Point(197, 329);
            this.groupTRoutingStyle.Name = "groupTRoutingStyle";
            this.groupTRoutingStyle.Size = new System.Drawing.Size(178, 72);
            this.groupTRoutingStyle.TabIndex = 35;
            this.groupTRoutingStyle.TabStop = false;
            this.groupTRoutingStyle.Text = "Translation Routing Style";
            // 
            // optTRoutingStyleNone
            // 
            this.optTRoutingStyleNone.AutoSize = true;
            this.optTRoutingStyleNone.Location = new System.Drawing.Point(73, 45);
            this.optTRoutingStyleNone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optTRoutingStyleNone.Name = "optTRoutingStyleNone";
            this.optTRoutingStyleNone.Size = new System.Drawing.Size(54, 20);
            this.optTRoutingStyleNone.TabIndex = 5;
            this.optTRoutingStyleNone.TabStop = true;
            this.optTRoutingStyleNone.Tag = "3";
            this.optTRoutingStyleNone.Text = "None";
            this.optTRoutingStyleNone.UseVisualStyleBackColor = true;
            this.optTRoutingStyleNone.Visible = false;
            this.optTRoutingStyleNone.CheckedChanged += new System.EventHandler(this.TRoutingStyle_CheckedChanged);
            // 
            // optTRoutingStyleGrey
            // 
            this.optTRoutingStyleGrey.AutoSize = true;
            this.optTRoutingStyleGrey.Location = new System.Drawing.Point(15, 44);
            this.optTRoutingStyleGrey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optTRoutingStyleGrey.Name = "optTRoutingStyleGrey";
            this.optTRoutingStyleGrey.Size = new System.Drawing.Size(51, 20);
            this.optTRoutingStyleGrey.TabIndex = 4;
            this.optTRoutingStyleGrey.TabStop = true;
            this.optTRoutingStyleGrey.Tag = "2";
            this.optTRoutingStyleGrey.Text = "Grey";
            this.optTRoutingStyleGrey.UseVisualStyleBackColor = true;
            this.optTRoutingStyleGrey.CheckedChanged += new System.EventHandler(this.TRoutingStyle_CheckedChanged);
            // 
            // optTRoutingStyleNormal
            // 
            this.optTRoutingStyleNormal.AutoSize = true;
            this.optTRoutingStyleNormal.Location = new System.Drawing.Point(15, 22);
            this.optTRoutingStyleNormal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optTRoutingStyleNormal.Name = "optTRoutingStyleNormal";
            this.optTRoutingStyleNormal.Size = new System.Drawing.Size(66, 20);
            this.optTRoutingStyleNormal.TabIndex = 3;
            this.optTRoutingStyleNormal.TabStop = true;
            this.optTRoutingStyleNormal.Tag = "1";
            this.optTRoutingStyleNormal.Text = "Normal";
            this.optTRoutingStyleNormal.UseVisualStyleBackColor = true;
            this.optTRoutingStyleNormal.CheckedChanged += new System.EventHandler(this.TRoutingStyle_CheckedChanged);
            // 
            // chkIncludeEnglish
            // 
            this.chkIncludeEnglish.AutoSize = true;
            this.chkIncludeEnglish.Location = new System.Drawing.Point(292, 24);
            this.chkIncludeEnglish.Name = "chkIncludeEnglish";
            this.chkIncludeEnglish.Size = new System.Drawing.Size(111, 20);
            this.chkIncludeEnglish.TabIndex = 34;
            this.chkIncludeEnglish.Text = "Include English";
            this.chkIncludeEnglish.UseVisualStyleBackColor = true;
            // 
            // cmdCustomizeContent
            // 
            this.cmdCustomizeContent.Location = new System.Drawing.Point(288, 51);
            this.cmdCustomizeContent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCustomizeContent.Name = "cmdCustomizeContent";
            this.cmdCustomizeContent.Size = new System.Drawing.Size(143, 28);
            this.cmdCustomizeContent.TabIndex = 33;
            this.cmdCustomizeContent.Text = "Customize Content...";
            this.cmdCustomizeContent.UseVisualStyleBackColor = true;
            this.cmdCustomizeContent.Click += new System.EventHandler(this.cmdCustomizeContent_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.cmdCommentFields);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.lstCommentTypes);
            this.panel2.Controls.Add(this.chkEnglishRouting);
            this.panel2.Controls.Add(this.lstTransFields);
            this.panel2.Controls.Add(this.lblTransFields);
            this.panel2.Controls.Add(this.lstExtraFields);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(7, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(471, 221);
            this.panel2.TabIndex = 32;
            // 
            // cmdCommentFields
            // 
            this.cmdCommentFields.Location = new System.Drawing.Point(279, 185);
            this.cmdCommentFields.Name = "cmdCommentFields";
            this.cmdCommentFields.Size = new System.Drawing.Size(143, 26);
            this.cmdCommentFields.TabIndex = 34;
            this.cmdCommentFields.Text = "Comment Options...";
            this.cmdCommentFields.UseVisualStyleBackColor = true;
            this.cmdCommentFields.Click += new System.EventHandler(this.cmdCommentFields_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(312, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 33;
            this.label1.Text = "Comments";
            // 
            // lstCommentTypes
            // 
            this.lstCommentTypes.FormattingEnabled = true;
            this.lstCommentTypes.ItemHeight = 16;
            this.lstCommentTypes.Location = new System.Drawing.Point(279, 30);
            this.lstCommentTypes.Name = "lstCommentTypes";
            this.lstCommentTypes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstCommentTypes.Size = new System.Drawing.Size(144, 148);
            this.lstCommentTypes.TabIndex = 32;
            this.lstCommentTypes.Click += new System.EventHandler(this.lstCommentTypes_Click);
            // 
            // chkEnglishRouting
            // 
            this.chkEnglishRouting.AutoSize = true;
            this.chkEnglishRouting.Location = new System.Drawing.Point(126, 187);
            this.chkEnglishRouting.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkEnglishRouting.Name = "chkEnglishRouting";
            this.chkEnglishRouting.Size = new System.Drawing.Size(138, 20);
            this.chkEnglishRouting.TabIndex = 31;
            this.chkEnglishRouting.Text = "Use English Routing";
            this.chkEnglishRouting.UseVisualStyleBackColor = true;
            this.chkEnglishRouting.Visible = false;
            // 
            // lstTransFields
            // 
            this.lstTransFields.FormattingEnabled = true;
            this.lstTransFields.ItemHeight = 16;
            this.lstTransFields.Location = new System.Drawing.Point(126, 30);
            this.lstTransFields.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstTransFields.Name = "lstTransFields";
            this.lstTransFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTransFields.Size = new System.Drawing.Size(136, 148);
            this.lstTransFields.TabIndex = 14;
            this.lstTransFields.Click += new System.EventHandler(this.TransFields_Click);
            // 
            // lblTransFields
            // 
            this.lblTransFields.AutoSize = true;
            this.lblTransFields.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransFields.Location = new System.Drawing.Point(136, 8);
            this.lblTransFields.Name = "lblTransFields";
            this.lblTransFields.Size = new System.Drawing.Size(118, 16);
            this.lblTransFields.TabIndex = 15;
            this.lblTransFields.Text = "Translation Fields";
            // 
            // lstExtraFields
            // 
            this.lstExtraFields.FormattingEnabled = true;
            this.lstExtraFields.ItemHeight = 16;
            this.lstExtraFields.Items.AddRange(new object[] {
            "Filters",
            "Domain",
            "Topic",
            "Content",
            "VarLabel",
            "Product",
            "AltQnum",
            "AltQnum2",
            "AltQnum3"});
            this.lstExtraFields.Location = new System.Drawing.Point(8, 30);
            this.lstExtraFields.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstExtraFields.Name = "lstExtraFields";
            this.lstExtraFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstExtraFields.Size = new System.Drawing.Size(100, 148);
            this.lstExtraFields.TabIndex = 29;
            this.lstExtraFields.Click += new System.EventHandler(this.lstExtraFields_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 16);
            this.label8.TabIndex = 26;
            this.label8.Text = "Other Fields";
            // 
            // groupRoutingStyle
            // 
            this.groupRoutingStyle.Controls.Add(this.optRoutingStyleNone);
            this.groupRoutingStyle.Controls.Add(this.optRoutingStyleGrey);
            this.groupRoutingStyle.Controls.Add(this.optRoutingStyleNormal);
            this.groupRoutingStyle.Location = new System.Drawing.Point(17, 329);
            this.groupRoutingStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupRoutingStyle.Name = "groupRoutingStyle";
            this.groupRoutingStyle.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupRoutingStyle.Size = new System.Drawing.Size(136, 72);
            this.groupRoutingStyle.TabIndex = 30;
            this.groupRoutingStyle.TabStop = false;
            this.groupRoutingStyle.Text = "Routing Style";
            // 
            // optRoutingStyleNone
            // 
            this.optRoutingStyleNone.AutoSize = true;
            this.optRoutingStyleNone.Location = new System.Drawing.Point(71, 45);
            this.optRoutingStyleNone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optRoutingStyleNone.Name = "optRoutingStyleNone";
            this.optRoutingStyleNone.Size = new System.Drawing.Size(54, 20);
            this.optRoutingStyleNone.TabIndex = 2;
            this.optRoutingStyleNone.TabStop = true;
            this.optRoutingStyleNone.Tag = "3";
            this.optRoutingStyleNone.Text = "None";
            this.optRoutingStyleNone.UseVisualStyleBackColor = true;
            this.optRoutingStyleNone.Visible = false;
            this.optRoutingStyleNone.CheckedChanged += new System.EventHandler(this.RoutingStyle_CheckedChanged);
            // 
            // optRoutingStyleGrey
            // 
            this.optRoutingStyleGrey.AutoSize = true;
            this.optRoutingStyleGrey.Location = new System.Drawing.Point(13, 44);
            this.optRoutingStyleGrey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optRoutingStyleGrey.Name = "optRoutingStyleGrey";
            this.optRoutingStyleGrey.Size = new System.Drawing.Size(51, 20);
            this.optRoutingStyleGrey.TabIndex = 1;
            this.optRoutingStyleGrey.TabStop = true;
            this.optRoutingStyleGrey.Tag = "2";
            this.optRoutingStyleGrey.Text = "Grey";
            this.optRoutingStyleGrey.UseVisualStyleBackColor = true;
            this.optRoutingStyleGrey.CheckedChanged += new System.EventHandler(this.RoutingStyle_CheckedChanged);
            // 
            // optRoutingStyleNormal
            // 
            this.optRoutingStyleNormal.AutoSize = true;
            this.optRoutingStyleNormal.Location = new System.Drawing.Point(13, 22);
            this.optRoutingStyleNormal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optRoutingStyleNormal.Name = "optRoutingStyleNormal";
            this.optRoutingStyleNormal.Size = new System.Drawing.Size(66, 20);
            this.optRoutingStyleNormal.TabIndex = 0;
            this.optRoutingStyleNormal.TabStop = true;
            this.optRoutingStyleNormal.Tag = "1";
            this.optRoutingStyleNormal.Text = "Normal";
            this.optRoutingStyleNormal.UseVisualStyleBackColor = true;
            this.optRoutingStyleNormal.CheckedChanged += new System.EventHandler(this.RoutingStyle_CheckedChanged);
            // 
            // lblCurrentSurveyFields
            // 
            this.lblCurrentSurveyFields.AutoSize = true;
            this.lblCurrentSurveyFields.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSurveyFields.Location = new System.Drawing.Point(17, 14);
            this.lblCurrentSurveyFields.Name = "lblCurrentSurveyFields";
            this.lblCurrentSurveyFields.Size = new System.Drawing.Size(188, 16);
            this.lblCurrentSurveyFields.TabIndex = 29;
            this.lblCurrentSurveyFields.Text = "Current Survey\'s Selections";
            // 
            // dateBackend
            // 
            this.dateBackend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBackend.Location = new System.Drawing.Point(106, 52);
            this.dateBackend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateBackend.Name = "dateBackend";
            this.dateBackend.Size = new System.Drawing.Size(124, 23);
            this.dateBackend.TabIndex = 8;
            this.dateBackend.CloseUp += new System.EventHandler(this.dateBackend_CloseUp);
            // 
            // lblBackend
            // 
            this.lblBackend.AutoSize = true;
            this.lblBackend.Location = new System.Drawing.Point(17, 57);
            this.lblBackend.Name = "lblBackend";
            this.lblBackend.Size = new System.Drawing.Size(83, 16);
            this.lblBackend.TabIndex = 9;
            this.lblBackend.Text = "Backend date";
            // 
            // pgCompare
            // 
            this.pgCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgCompare.Controls.Add(this.chklstPrimarySurvey);
            this.pgCompare.Controls.Add(this.lblPrimarySurvey);
            this.pgCompare.Controls.Add(this.groupHighlightOptions);
            this.pgCompare.Controls.Add(this.chkCompare);
            this.pgCompare.Location = new System.Drawing.Point(4, 25);
            this.pgCompare.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgCompare.Name = "pgCompare";
            this.pgCompare.Size = new System.Drawing.Size(503, 411);
            this.pgCompare.TabIndex = 2;
            this.pgCompare.Text = "Comparison";
            // 
            // chklstPrimarySurvey
            // 
            this.chklstPrimarySurvey.CheckOnClick = true;
            this.chklstPrimarySurvey.FormattingEnabled = true;
            this.chklstPrimarySurvey.Location = new System.Drawing.Point(10, 84);
            this.chklstPrimarySurvey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chklstPrimarySurvey.Name = "chklstPrimarySurvey";
            this.chklstPrimarySurvey.Size = new System.Drawing.Size(255, 148);
            this.chklstPrimarySurvey.TabIndex = 120;
            this.chklstPrimarySurvey.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstPrimarySurvey_ItemCheck);
            this.chklstPrimarySurvey.SelectedIndexChanged += new System.EventHandler(this.chklstPrimarySurvey_SelectedIndexChanged);
            // 
            // lblPrimarySurvey
            // 
            this.lblPrimarySurvey.Location = new System.Drawing.Point(12, 239);
            this.lblPrimarySurvey.Name = "lblPrimarySurvey";
            this.lblPrimarySurvey.Size = new System.Drawing.Size(212, 72);
            this.lblPrimarySurvey.TabIndex = 118;
            this.lblPrimarySurvey.Text = "All other surveys will be compared to the reference survey. Surveys not selected " +
    "will contain highlighting.";
            this.lblPrimarySurvey.Visible = false;
            // 
            // groupHighlightOptions
            // 
            this.groupHighlightOptions.Controls.Add(this.flowHighlightOptions);
            this.groupHighlightOptions.Controls.Add(this.groupHighlightStyle);
            this.groupHighlightOptions.Controls.Add(this.highlightCheckBox);
            this.groupHighlightOptions.Location = new System.Drawing.Point(282, 32);
            this.groupHighlightOptions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupHighlightOptions.Name = "groupHighlightOptions";
            this.groupHighlightOptions.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupHighlightOptions.Size = new System.Drawing.Size(196, 360);
            this.groupHighlightOptions.TabIndex = 11;
            this.groupHighlightOptions.TabStop = false;
            this.groupHighlightOptions.Text = "Highlight Options";
            this.groupHighlightOptions.Visible = false;
            // 
            // flowHighlightOptions
            // 
            this.flowHighlightOptions.Controls.Add(this.highlightNRCheckBox);
            this.flowHighlightOptions.Controls.Add(this.ignoreSimilarWordsCheckBox);
            this.flowHighlightOptions.Controls.Add(this.showDeletedFieldsCheckBox);
            this.flowHighlightOptions.Controls.Add(this.chkShowDeletedQuestions);
            this.flowHighlightOptions.Controls.Add(this.chkReInsertDeletions);
            this.flowHighlightOptions.Controls.Add(this.chkHideReference);
            this.flowHighlightOptions.Controls.Add(this.chkHideIdenticalWordings);
            this.flowHighlightOptions.Controls.Add(this.chkHideIdenticalQs);
            this.flowHighlightOptions.Location = new System.Drawing.Point(10, 123);
            this.flowHighlightOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flowHighlightOptions.Name = "flowHighlightOptions";
            this.flowHighlightOptions.Padding = new System.Windows.Forms.Padding(1);
            this.flowHighlightOptions.Size = new System.Drawing.Size(173, 216);
            this.flowHighlightOptions.TabIndex = 10;
            // 
            // highlightNRCheckBox
            // 
            this.highlightNRCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HighlightNR", true));
            this.highlightNRCheckBox.Location = new System.Drawing.Point(1, 1);
            this.highlightNRCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.highlightNRCheckBox.Name = "highlightNRCheckBox";
            this.highlightNRCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.highlightNRCheckBox.Size = new System.Drawing.Size(164, 25);
            this.highlightNRCheckBox.TabIndex = 29;
            this.highlightNRCheckBox.Text = "Highlight NR";
            this.highlightNRCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreSimilarWordsCheckBox
            // 
            this.ignoreSimilarWordsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "IgnoreSimilarWords", true));
            this.ignoreSimilarWordsCheckBox.Location = new System.Drawing.Point(1, 26);
            this.ignoreSimilarWordsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ignoreSimilarWordsCheckBox.Name = "ignoreSimilarWordsCheckBox";
            this.ignoreSimilarWordsCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.ignoreSimilarWordsCheckBox.Size = new System.Drawing.Size(164, 25);
            this.ignoreSimilarWordsCheckBox.TabIndex = 37;
            this.ignoreSimilarWordsCheckBox.Text = "Ignore Word Variants";
            this.ignoreSimilarWordsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDeletedFieldsCheckBox
            // 
            this.showDeletedFieldsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ShowDeletedFields", true));
            this.showDeletedFieldsCheckBox.Location = new System.Drawing.Point(1, 51);
            this.showDeletedFieldsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.showDeletedFieldsCheckBox.Name = "showDeletedFieldsCheckBox";
            this.showDeletedFieldsCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.showDeletedFieldsCheckBox.Size = new System.Drawing.Size(164, 25);
            this.showDeletedFieldsCheckBox.TabIndex = 47;
            this.showDeletedFieldsCheckBox.Text = "Show Deleted Fields";
            this.showDeletedFieldsCheckBox.UseVisualStyleBackColor = true;
            // 
            // chkShowDeletedQuestions
            // 
            this.chkShowDeletedQuestions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ShowDeletedQuestions", true));
            this.chkShowDeletedQuestions.Location = new System.Drawing.Point(1, 76);
            this.chkShowDeletedQuestions.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowDeletedQuestions.Name = "chkShowDeletedQuestions";
            this.chkShowDeletedQuestions.Padding = new System.Windows.Forms.Padding(1);
            this.chkShowDeletedQuestions.Size = new System.Drawing.Size(182, 25);
            this.chkShowDeletedQuestions.TabIndex = 49;
            this.chkShowDeletedQuestions.Text = "Show Deleted Questions";
            this.chkShowDeletedQuestions.UseVisualStyleBackColor = true;
            this.chkShowDeletedQuestions.CheckedChanged += new System.EventHandler(this.ShowDeletedQuestionsCheckBox_CheckedChanged);
            // 
            // chkReInsertDeletions
            // 
            this.chkReInsertDeletions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ReInsertDeletions", true));
            this.chkReInsertDeletions.Location = new System.Drawing.Point(1, 101);
            this.chkReInsertDeletions.Margin = new System.Windows.Forms.Padding(0);
            this.chkReInsertDeletions.Name = "chkReInsertDeletions";
            this.chkReInsertDeletions.Padding = new System.Windows.Forms.Padding(1);
            this.chkReInsertDeletions.Size = new System.Drawing.Size(143, 25);
            this.chkReInsertDeletions.TabIndex = 43;
            this.chkReInsertDeletions.Text = "Re-insert Deletions";
            this.chkReInsertDeletions.UseVisualStyleBackColor = true;
            // 
            // chkHideReference
            // 
            this.chkHideReference.AutoSize = true;
            this.chkHideReference.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HidePrimary", true));
            this.chkHideReference.Location = new System.Drawing.Point(1, 126);
            this.chkHideReference.Margin = new System.Windows.Forms.Padding(0);
            this.chkHideReference.Name = "chkHideReference";
            this.chkHideReference.Padding = new System.Windows.Forms.Padding(1);
            this.chkHideReference.Size = new System.Drawing.Size(158, 22);
            this.chkHideReference.TabIndex = 50;
            this.chkHideReference.Text = "Hide Reference Survey";
            this.chkHideReference.UseVisualStyleBackColor = true;
            // 
            // chkHideIdenticalWordings
            // 
            this.chkHideIdenticalWordings.AutoSize = true;
            this.chkHideIdenticalWordings.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HideIdenticalWordings", true));
            this.chkHideIdenticalWordings.Location = new System.Drawing.Point(1, 148);
            this.chkHideIdenticalWordings.Margin = new System.Windows.Forms.Padding(0);
            this.chkHideIdenticalWordings.Name = "chkHideIdenticalWordings";
            this.chkHideIdenticalWordings.Padding = new System.Windows.Forms.Padding(1);
            this.chkHideIdenticalWordings.Size = new System.Drawing.Size(163, 22);
            this.chkHideIdenticalWordings.TabIndex = 51;
            this.chkHideIdenticalWordings.Text = "Hide Identical Wordings";
            this.chkHideIdenticalWordings.UseVisualStyleBackColor = true;
            // 
            // chkHideIdenticalQs
            // 
            this.chkHideIdenticalQs.AutoSize = true;
            this.chkHideIdenticalQs.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.compareBindingSource, "HideIdenticalQuestions", true));
            this.chkHideIdenticalQs.Location = new System.Drawing.Point(1, 170);
            this.chkHideIdenticalQs.Margin = new System.Windows.Forms.Padding(0);
            this.chkHideIdenticalQs.Name = "chkHideIdenticalQs";
            this.chkHideIdenticalQs.Padding = new System.Windows.Forms.Padding(1);
            this.chkHideIdenticalQs.Size = new System.Drawing.Size(165, 22);
            this.chkHideIdenticalQs.TabIndex = 52;
            this.chkHideIdenticalQs.Text = "Hide Identical Questions";
            this.chkHideIdenticalQs.UseVisualStyleBackColor = true;
            // 
            // groupHighlightStyle
            // 
            this.groupHighlightStyle.Controls.Add(this.radioButton1);
            this.groupHighlightStyle.Location = new System.Drawing.Point(10, 52);
            this.groupHighlightStyle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupHighlightStyle.Name = "groupHighlightStyle";
            this.groupHighlightStyle.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupHighlightStyle.Size = new System.Drawing.Size(145, 57);
            this.groupHighlightStyle.TabIndex = 3;
            this.groupHighlightStyle.TabStop = false;
            this.groupHighlightStyle.Text = "Highlight Style";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 22);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(116, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = "1";
            this.radioButton1.Text = "Classic highlight";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.HighlightStyle_CheckedChanged);
            // 
            // highlightCheckBox
            // 
            this.highlightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "Highlight", true));
            this.highlightCheckBox.Enabled = false;
            this.highlightCheckBox.Location = new System.Drawing.Point(12, 23);
            this.highlightCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.highlightCheckBox.Name = "highlightCheckBox";
            this.highlightCheckBox.Size = new System.Drawing.Size(121, 25);
            this.highlightCheckBox.TabIndex = 27;
            this.highlightCheckBox.Text = "Highlight";
            this.highlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // chkCompare
            // 
            this.chkCompare.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.surveyReportBindingSource, "CompareWordings", true));
            this.chkCompare.Location = new System.Drawing.Point(15, 32);
            this.chkCompare.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkCompare.Name = "chkCompare";
            this.chkCompare.Size = new System.Drawing.Size(121, 30);
            this.chkCompare.TabIndex = 21;
            this.chkCompare.Text = "Compare?";
            this.chkCompare.UseVisualStyleBackColor = true;
            this.chkCompare.CheckedChanged += new System.EventHandler(this.Compare_CheckedChanged);
            // 
            // surveyReportBindingSource
            // 
            this.surveyReportBindingSource.DataSource = typeof(ITCReportLib.SurveyReport);
            // 
            // pgFileName
            // 
            this.pgFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFileName.Controls.Add(this.label14);
            this.pgFileName.Controls.Add(this.label13);
            this.pgFileName.Controls.Add(this.label12);
            this.pgFileName.Controls.Add(detailsLabel);
            this.pgFileName.Controls.Add(this.txtSecondSources);
            this.pgFileName.Controls.Add(fileNameLabel);
            this.pgFileName.Controls.Add(this.detailsTextBox);
            this.pgFileName.Controls.Add(this.fileNameTextBox);
            this.pgFileName.Controls.Add(this.txtMainSource);
            this.pgFileName.Controls.Add(this.label11);
            this.pgFileName.Location = new System.Drawing.Point(4, 25);
            this.pgFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgFileName.Name = "pgFileName";
            this.pgFileName.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pgFileName.Size = new System.Drawing.Size(503, 411);
            this.pgFileName.TabIndex = 6;
            this.pgFileName.Text = "File Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(100, 122);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 16);
            this.label14.TabIndex = 37;
            this.label14.Text = "Main source(s)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(217, 180);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 16);
            this.label13.TabIndex = 36;
            this.label13.Text = "vs.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(14, 345);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(404, 16);
            this.label12.TabIndex = 35;
            this.label12.Text = "Note: Date and Time will be appended to the above file name.";
            // 
            // txtSecondSources
            // 
            this.txtSecondSources.Location = new System.Drawing.Point(213, 207);
            this.txtSecondSources.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSecondSources.Name = "txtSecondSources";
            this.txtSecondSources.Size = new System.Drawing.Size(213, 23);
            this.txtSecondSources.TabIndex = 2;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.surveyReportBindingSource, "Details", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.detailsTextBox.Location = new System.Drawing.Point(213, 254);
            this.detailsTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(215, 23);
            this.detailsTextBox.TabIndex = 28;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(13, 318);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(465, 23);
            this.fileNameTextBox.TabIndex = 34;
            // 
            // txtMainSource
            // 
            this.txtMainSource.Location = new System.Drawing.Point(212, 146);
            this.txtMainSource.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMainSource.Name = "txtMainSource";
            this.txtMainSource.Size = new System.Drawing.Size(215, 23);
            this.txtMainSource.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(27, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(451, 48);
            this.label11.TabIndex = 0;
            this.label11.Text = "The following pieces of information will be part of the file name. You can also e" +
    "nter a file name which will override the defaults.";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(165, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(233, 33);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "ITC Survey Report";
            // 
            // cmdSelfCompare
            // 
            this.cmdSelfCompare.Location = new System.Drawing.Point(22, 107);
            this.cmdSelfCompare.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdSelfCompare.Name = "cmdSelfCompare";
            this.cmdSelfCompare.Size = new System.Drawing.Size(111, 28);
            this.cmdSelfCompare.TabIndex = 58;
            this.cmdSelfCompare.Text = "Self-comparison";
            this.cmdSelfCompare.UseVisualStyleBackColor = true;
            this.cmdSelfCompare.Click += new System.EventHandler(this.SelfCompare_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(28, 668);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(56, 16);
            this.lblStatus.TabIndex = 60;
            this.lblStatus.Text = "lblStatus";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.outputOptionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 61;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.optionsToolStripMenuItem.Text = "Report Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // outputOptionsToolStripMenuItem
            // 
            this.outputOptionsToolStripMenuItem.Name = "outputOptionsToolStripMenuItem";
            this.outputOptionsToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.outputOptionsToolStripMenuItem.Text = "Output Options...";
            this.outputOptionsToolStripMenuItem.Click += new System.EventHandler(this.outputOptionsToolStripMenuItem_Click);
            // 
            // groupTemplate
            // 
            this.groupTemplate.Controls.Add(this.cmdOpenTranslatorOptions);
            this.groupTemplate.Controls.Add(this.chkStdWebTranslation);
            this.groupTemplate.Controls.Add(this.chkStdTranslation);
            this.groupTemplate.Controls.Add(this.optTranslator);
            this.groupTemplate.Controls.Add(this.optNoTemplate);
            this.groupTemplate.Controls.Add(this.optWebTemplate);
            this.groupTemplate.Controls.Add(this.optStdTemplate);
            this.groupTemplate.Enabled = false;
            this.groupTemplate.Location = new System.Drawing.Point(319, 62);
            this.groupTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupTemplate.Name = "groupTemplate";
            this.groupTemplate.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupTemplate.Size = new System.Drawing.Size(200, 107);
            this.groupTemplate.TabIndex = 62;
            this.groupTemplate.TabStop = false;
            this.groupTemplate.Text = "Report Template";
            // 
            // cmdOpenTranslatorOptions
            // 
            this.cmdOpenTranslatorOptions.Location = new System.Drawing.Point(93, 77);
            this.cmdOpenTranslatorOptions.Name = "cmdOpenTranslatorOptions";
            this.cmdOpenTranslatorOptions.Size = new System.Drawing.Size(38, 23);
            this.cmdOpenTranslatorOptions.TabIndex = 10;
            this.cmdOpenTranslatorOptions.Text = "...";
            this.cmdOpenTranslatorOptions.UseVisualStyleBackColor = true;
            this.cmdOpenTranslatorOptions.Click += new System.EventHandler(this.cmdOpenTranslatorOptions_Click);
            // 
            // chkStdWebTranslation
            // 
            this.chkStdWebTranslation.AutoSize = true;
            this.chkStdWebTranslation.Enabled = false;
            this.chkStdWebTranslation.Location = new System.Drawing.Point(59, 60);
            this.chkStdWebTranslation.Name = "chkStdWebTranslation";
            this.chkStdWebTranslation.Size = new System.Drawing.Size(109, 20);
            this.chkStdWebTranslation.TabIndex = 9;
            this.chkStdWebTranslation.Text = "w/ Translation";
            this.chkStdWebTranslation.UseVisualStyleBackColor = true;
            // 
            // chkStdTranslation
            // 
            this.chkStdTranslation.AutoSize = true;
            this.chkStdTranslation.Enabled = false;
            this.chkStdTranslation.Location = new System.Drawing.Point(85, 39);
            this.chkStdTranslation.Name = "chkStdTranslation";
            this.chkStdTranslation.Size = new System.Drawing.Size(109, 20);
            this.chkStdTranslation.TabIndex = 8;
            this.chkStdTranslation.Text = "w/ Translation";
            this.chkStdTranslation.UseVisualStyleBackColor = true;
            // 
            // optTranslator
            // 
            this.optTranslator.AutoSize = true;
            this.optTranslator.Location = new System.Drawing.Point(6, 78);
            this.optTranslator.Name = "optTranslator";
            this.optTranslator.Size = new System.Drawing.Size(84, 20);
            this.optTranslator.TabIndex = 5;
            this.optTranslator.TabStop = true;
            this.optTranslator.Tag = "Translator";
            this.optTranslator.Text = "Translator";
            this.optTranslator.UseVisualStyleBackColor = true;
            this.optTranslator.CheckedChanged += new System.EventHandler(this.ReportTemplate_CheckChanged);
            // 
            // optNoTemplate
            // 
            this.optNoTemplate.AutoSize = true;
            this.optNoTemplate.Location = new System.Drawing.Point(6, 18);
            this.optNoTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optNoTemplate.Name = "optNoTemplate";
            this.optNoTemplate.Size = new System.Drawing.Size(68, 20);
            this.optNoTemplate.TabIndex = 4;
            this.optNoTemplate.TabStop = true;
            this.optNoTemplate.Tag = "Custom";
            this.optNoTemplate.Text = "Custom";
            this.optNoTemplate.UseVisualStyleBackColor = true;
            this.optNoTemplate.CheckedChanged += new System.EventHandler(this.ReportTemplate_CheckChanged);
            // 
            // optWebTemplate
            // 
            this.optWebTemplate.AutoSize = true;
            this.optWebTemplate.Location = new System.Drawing.Point(6, 59);
            this.optWebTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optWebTemplate.Name = "optWebTemplate";
            this.optWebTemplate.Size = new System.Drawing.Size(51, 20);
            this.optWebTemplate.TabIndex = 2;
            this.optWebTemplate.TabStop = true;
            this.optWebTemplate.Tag = "Web";
            this.optWebTemplate.Text = "Web";
            this.optWebTemplate.UseVisualStyleBackColor = true;
            this.optWebTemplate.CheckedChanged += new System.EventHandler(this.ReportTemplate_CheckChanged);
            // 
            // optStdTemplate
            // 
            this.optStdTemplate.AutoSize = true;
            this.optStdTemplate.Location = new System.Drawing.Point(6, 38);
            this.optStdTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.optStdTemplate.Name = "optStdTemplate";
            this.optStdTemplate.Size = new System.Drawing.Size(77, 20);
            this.optStdTemplate.TabIndex = 0;
            this.optStdTemplate.TabStop = true;
            this.optStdTemplate.Tag = "Std";
            this.optStdTemplate.Text = "Standard";
            this.optStdTemplate.UseVisualStyleBackColor = true;
            this.optStdTemplate.CheckedChanged += new System.EventHandler(this.ReportTemplate_CheckChanged);
            // 
            // cmdGenerate
            // 
            this.cmdGenerate.Location = new System.Drawing.Point(421, 656);
            this.cmdGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdGenerate.Name = "cmdGenerate";
            this.cmdGenerate.Size = new System.Drawing.Size(99, 41);
            this.cmdGenerate.TabIndex = 5;
            this.cmdGenerate.Text = "Generate";
            this.cmdGenerate.UseVisualStyleBackColor = true;
            this.cmdGenerate.Click += new System.EventHandler(this.cmdQuickGenerate_Click);
            // 
            // cmdOpenReportFolder
            // 
            this.cmdOpenReportFolder.Image = global::ITCSurveyReportLite.Properties.Resources.FolderOpened;
            this.cmdOpenReportFolder.Location = new System.Drawing.Point(378, 656);
            this.cmdOpenReportFolder.Name = "cmdOpenReportFolder";
            this.cmdOpenReportFolder.Size = new System.Drawing.Size(37, 41);
            this.cmdOpenReportFolder.TabIndex = 63;
            this.cmdOpenReportFolder.UseVisualStyleBackColor = true;
            this.cmdOpenReportFolder.Visible = false;
            this.cmdOpenReportFolder.Click += new System.EventHandler(this.cmdOpenReportFolder_Click);
            // 
            // surveysBindingSource
            // 
            this.surveysBindingSource.DataMember = "Surveys";
            this.surveysBindingSource.DataSource = this.surveyReportBindingSource;
            // 
            // SurveyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(537, 712);
            this.Controls.Add(this.cmdOpenReportFolder);
            this.Controls.Add(this.cmdGenerate);
            this.Controls.Add(this.groupTemplate);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdSelfCompare);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdAddSurvey);
            this.Controls.Add(this.cmdRemoveSurvey);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.lstSelectedSurveys);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "SurveyReportForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ITC Survey Report";
            this.Load += new System.EventHandler(this.SurveyReportForm_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.pgFields.ResumeLayout(false);
            this.pgFields.PerformLayout();
            this.groupTRoutingStyle.ResumeLayout(false);
            this.groupTRoutingStyle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupRoutingStyle.ResumeLayout(false);
            this.groupRoutingStyle.PerformLayout();
            this.pgCompare.ResumeLayout(false);
            this.groupHighlightOptions.ResumeLayout(false);
            this.flowHighlightOptions.ResumeLayout(false);
            this.flowHighlightOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareBindingSource)).EndInit();
            this.groupHighlightStyle.ResumeLayout(false);
            this.groupHighlightStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).EndInit();
            this.pgFileName.ResumeLayout(false);
            this.pgFileName.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupTemplate.ResumeLayout(false);
            this.groupTemplate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportLayoutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveysBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurveys;
        private System.Windows.Forms.Button cmdAddSurvey;
        private System.Windows.Forms.Button cmdRemoveSurvey;
        private System.Windows.Forms.ListBox lstSelectedSurveys;
        private System.Windows.Forms.TabControl tabControlOptions;
        private System.Windows.Forms.TabPage pgFields;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TabPage pgCompare;
        private System.Windows.Forms.DateTimePicker dateBackend;
        private System.Windows.Forms.Label lblBackend;
        private System.Windows.Forms.Label lblTransFields;
        private System.Windows.Forms.ListBox lstTransFields;
        private System.Windows.Forms.GroupBox groupHighlightOptions;
        private System.Windows.Forms.FlowLayoutPanel flowHighlightOptions;
        private System.Windows.Forms.GroupBox groupHighlightStyle;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox detailsTextBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.TabPage pgFileName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtSecondSources;
        private System.Windows.Forms.TextBox txtMainSource;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkCompare;
        private System.Windows.Forms.CheckBox highlightCheckBox;
        private System.Windows.Forms.CheckBox highlightNRCheckBox;
        private System.Windows.Forms.CheckBox ignoreSimilarWordsCheckBox;
        private System.Windows.Forms.CheckBox chkReInsertDeletions;
        private System.Windows.Forms.CheckBox showDeletedFieldsCheckBox;
        private System.Windows.Forms.CheckBox chkShowDeletedQuestions;
        private System.Windows.Forms.BindingSource surveyReportBindingSource;
        private System.Windows.Forms.Label lblPrimarySurvey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdSelfCompare;
        private System.Windows.Forms.ToolTip toolTipStandard;
        private System.Windows.Forms.ToolTip toolTipStandardT;
        private System.Windows.Forms.ToolTip toolTipWeb;
        private System.Windows.Forms.ToolTip toolTipWebT;
        private System.Windows.Forms.BindingSource compareBindingSource;
        private System.Windows.Forms.BindingSource reportLayoutBindingSource;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label lblCurrentSurveyFields;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupRoutingStyle;
        private System.Windows.Forms.RadioButton optRoutingStyleNone;
        private System.Windows.Forms.RadioButton optRoutingStyleGrey;
        private System.Windows.Forms.RadioButton optRoutingStyleNormal;
        private System.Windows.Forms.CheckBox chkEnglishRouting;
        private System.Windows.Forms.BindingSource surveysBindingSource;
        private System.Windows.Forms.CheckedListBox chklstPrimarySurvey;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListBox lstExtraFields;
        private System.Windows.Forms.GroupBox groupTemplate;
        private System.Windows.Forms.RadioButton optWebTemplate;
        private System.Windows.Forms.RadioButton optStdTemplate;
        private System.Windows.Forms.Button cmdGenerate;
        private System.Windows.Forms.Button cmdCustomizeContent;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Button cmdCommentFields;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstCommentTypes;
        private System.Windows.Forms.ToolStripMenuItem outputOptionsToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkHideReference;
        private System.Windows.Forms.CheckBox chkHideIdenticalWordings;
        private System.Windows.Forms.CheckBox chkHideIdenticalQs;
        private System.Windows.Forms.CheckBox chkIncludeEnglish;
        private System.Windows.Forms.CheckBox chkStdWebTranslation;
        private System.Windows.Forms.CheckBox chkStdTranslation;
        private System.Windows.Forms.RadioButton optTranslator;
        private System.Windows.Forms.RadioButton optNoTemplate;
        private System.Windows.Forms.GroupBox groupTRoutingStyle;
        private System.Windows.Forms.RadioButton optTRoutingStyleNone;
        private System.Windows.Forms.RadioButton optTRoutingStyleGrey;
        private System.Windows.Forms.RadioButton optTRoutingStyleNormal;
        private System.Windows.Forms.Button cmdOpenReportFolder;
        private System.Windows.Forms.Button cmdOpenTranslatorOptions;
    }
}

