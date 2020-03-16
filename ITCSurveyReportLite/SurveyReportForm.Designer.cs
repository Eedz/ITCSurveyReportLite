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
            this.cmdCheckOptions = new System.Windows.Forms.Button();
            this.tabControlOptions = new System.Windows.Forms.TabControl();
            this.pgFields = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lstTransFields = new System.Windows.Forms.ListBox();
            this.lblTransFields = new System.Windows.Forms.Label();
            this.chkEnglishRouting = new System.Windows.Forms.CheckBox();
            this.groupRoutingStyle = new System.Windows.Forms.GroupBox();
            this.optRoutingStyleNone = new System.Windows.Forms.RadioButton();
            this.optRoutingStyleGrey = new System.Windows.Forms.RadioButton();
            this.optRoutingStyleNormal = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstExtraFields = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCurrentSurveyFields = new System.Windows.Forms.Label();
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
            this.reportLayoutBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.surveysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblTitle = new System.Windows.Forms.Label();
            this.dateBackend = new System.Windows.Forms.DateTimePicker();
            this.lblBackend = new System.Windows.Forms.Label();
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
            this.quickReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardWTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteWTranslationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            detailsLabel = new System.Windows.Forms.Label();
            fileNameLabel = new System.Windows.Forms.Label();
            this.tabControlOptions.SuspendLayout();
            this.pgFields.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupRoutingStyle.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pgCompare.SuspendLayout();
            this.groupHighlightOptions.SuspendLayout();
            this.flowHighlightOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.compareBindingSource)).BeginInit();
            this.groupHighlightStyle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).BeginInit();
            this.pgFileName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportLayoutBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveysBindingSource)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // detailsLabel
            // 
            detailsLabel.AutoSize = true;
            detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            detailsLabel.Location = new System.Drawing.Point(84, 220);
            detailsLabel.Name = "detailsLabel";
            detailsLabel.Size = new System.Drawing.Size(92, 13);
            detailsLabel.TabIndex = 27;
            detailsLabel.Text = "Report Details:";
            // 
            // fileNameLabel
            // 
            fileNameLabel.AutoSize = true;
            fileNameLabel.Location = new System.Drawing.Point(6, 421);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new System.Drawing.Size(82, 13);
            fileNameLabel.TabIndex = 33;
            fileNameLabel.Text = "Final File Name:";
            // 
            // cboSurveys
            // 
            this.cboSurveys.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboSurveys.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboSurveys.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.cboSurveys.DisplayMember = "Survey";
            this.cboSurveys.FormattingEnabled = true;
            this.cboSurveys.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cboSurveys.Location = new System.Drawing.Point(13, 118);
            this.cboSurveys.Name = "cboSurveys";
            this.cboSurveys.Size = new System.Drawing.Size(108, 21);
            this.cboSurveys.TabIndex = 0;
            this.cboSurveys.ValueMember = "Survey";
            this.cboSurveys.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Surveys_KeyDown);
            // 
            // cmdAddSurvey
            // 
            this.cmdAddSurvey.Location = new System.Drawing.Point(127, 117);
            this.cmdAddSurvey.Name = "cmdAddSurvey";
            this.cmdAddSurvey.Size = new System.Drawing.Size(39, 20);
            this.cmdAddSurvey.TabIndex = 1;
            this.cmdAddSurvey.Text = "->";
            this.cmdAddSurvey.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.cmdAddSurvey.UseVisualStyleBackColor = true;
            this.cmdAddSurvey.Click += new System.EventHandler(this.AddSurvey_Click);
            // 
            // cmdRemoveSurvey
            // 
            this.cmdRemoveSurvey.Location = new System.Drawing.Point(127, 143);
            this.cmdRemoveSurvey.Name = "cmdRemoveSurvey";
            this.cmdRemoveSurvey.Size = new System.Drawing.Size(38, 25);
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
            this.lstSelectedSurveys.Location = new System.Drawing.Point(172, 115);
            this.lstSelectedSurveys.Name = "lstSelectedSurveys";
            this.lstSelectedSurveys.Size = new System.Drawing.Size(114, 108);
            this.lstSelectedSurveys.TabIndex = 3;
            this.lstSelectedSurveys.ValueMember = "ID";
            this.lstSelectedSurveys.SelectedIndexChanged += new System.EventHandler(this.SelectedSurveys_SelectedIndexChanged);
            // 
            // cmdCheckOptions
            // 
            this.cmdCheckOptions.Location = new System.Drawing.Point(398, 760);
            this.cmdCheckOptions.Name = "cmdCheckOptions";
            this.cmdCheckOptions.Size = new System.Drawing.Size(88, 33);
            this.cmdCheckOptions.TabIndex = 4;
            this.cmdCheckOptions.Text = "Generate";
            this.cmdCheckOptions.UseVisualStyleBackColor = true;
            this.cmdCheckOptions.Click += new System.EventHandler(this.CheckOptions_Click);
            // 
            // tabControlOptions
            // 
            this.tabControlOptions.Controls.Add(this.pgFields);
            this.tabControlOptions.Controls.Add(this.pgCompare);
            this.tabControlOptions.Controls.Add(this.pgFileName);
            this.tabControlOptions.Location = new System.Drawing.Point(13, 229);
            this.tabControlOptions.Name = "tabControlOptions";
            this.tabControlOptions.SelectedIndex = 0;
            this.tabControlOptions.Size = new System.Drawing.Size(473, 529);
            this.tabControlOptions.TabIndex = 5;
            this.tabControlOptions.Visible = false;
            this.tabControlOptions.SelectedIndexChanged += new System.EventHandler(this.tabControlOptions_SelectedIndexChanged);
            // 
            // pgFields
            // 
            this.pgFields.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgFields.Controls.Add(this.panel3);
            this.pgFields.Controls.Add(this.panel2);
            this.pgFields.Controls.Add(this.lblCurrentSurveyFields);
            this.pgFields.Location = new System.Drawing.Point(4, 22);
            this.pgFields.Name = "pgFields";
            this.pgFields.Padding = new System.Windows.Forms.Padding(3);
            this.pgFields.Size = new System.Drawing.Size(465, 503);
            this.pgFields.TabIndex = 1;
            this.pgFields.Text = "Fields";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.lstTransFields);
            this.panel3.Controls.Add(this.lblTransFields);
            this.panel3.Controls.Add(this.chkEnglishRouting);
            this.panel3.Controls.Add(this.groupRoutingStyle);
            this.panel3.Location = new System.Drawing.Point(9, 209);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(429, 123);
            this.panel3.TabIndex = 33;
            // 
            // lstTransFields
            // 
            this.lstTransFields.FormattingEnabled = true;
            this.lstTransFields.Location = new System.Drawing.Point(89, 21);
            this.lstTransFields.Name = "lstTransFields";
            this.lstTransFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstTransFields.Size = new System.Drawing.Size(117, 95);
            this.lstTransFields.TabIndex = 14;
            this.lstTransFields.Click += new System.EventHandler(this.TransFields_Click);
            // 
            // lblTransFields
            // 
            this.lblTransFields.AutoSize = true;
            this.lblTransFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransFields.Location = new System.Drawing.Point(86, 2);
            this.lblTransFields.Name = "lblTransFields";
            this.lblTransFields.Size = new System.Drawing.Size(122, 15);
            this.lblTransFields.TabIndex = 15;
            this.lblTransFields.Text = "Translation Fields";
            // 
            // chkEnglishRouting
            // 
            this.chkEnglishRouting.AutoSize = true;
            this.chkEnglishRouting.Location = new System.Drawing.Point(236, 2);
            this.chkEnglishRouting.Name = "chkEnglishRouting";
            this.chkEnglishRouting.Size = new System.Drawing.Size(122, 17);
            this.chkEnglishRouting.TabIndex = 31;
            this.chkEnglishRouting.Text = "Use English Routing";
            this.chkEnglishRouting.UseVisualStyleBackColor = true;
            // 
            // groupRoutingStyle
            // 
            this.groupRoutingStyle.Controls.Add(this.optRoutingStyleNone);
            this.groupRoutingStyle.Controls.Add(this.optRoutingStyleGrey);
            this.groupRoutingStyle.Controls.Add(this.optRoutingStyleNormal);
            this.groupRoutingStyle.Location = new System.Drawing.Point(236, 25);
            this.groupRoutingStyle.Name = "groupRoutingStyle";
            this.groupRoutingStyle.Size = new System.Drawing.Size(117, 92);
            this.groupRoutingStyle.TabIndex = 30;
            this.groupRoutingStyle.TabStop = false;
            this.groupRoutingStyle.Text = "Routing Style";
            // 
            // optRoutingStyleNone
            // 
            this.optRoutingStyleNone.AutoSize = true;
            this.optRoutingStyleNone.Location = new System.Drawing.Point(11, 66);
            this.optRoutingStyleNone.Name = "optRoutingStyleNone";
            this.optRoutingStyleNone.Size = new System.Drawing.Size(51, 17);
            this.optRoutingStyleNone.TabIndex = 2;
            this.optRoutingStyleNone.TabStop = true;
            this.optRoutingStyleNone.Tag = "3";
            this.optRoutingStyleNone.Text = "None";
            this.optRoutingStyleNone.UseVisualStyleBackColor = true;
            this.optRoutingStyleNone.CheckedChanged += new System.EventHandler(this.RoutingStyle_CheckedChanged);
            // 
            // optRoutingStyleGrey
            // 
            this.optRoutingStyleGrey.AutoSize = true;
            this.optRoutingStyleGrey.Location = new System.Drawing.Point(11, 43);
            this.optRoutingStyleGrey.Name = "optRoutingStyleGrey";
            this.optRoutingStyleGrey.Size = new System.Drawing.Size(47, 17);
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
            this.optRoutingStyleNormal.Location = new System.Drawing.Point(11, 20);
            this.optRoutingStyleNormal.Name = "optRoutingStyleNormal";
            this.optRoutingStyleNormal.Size = new System.Drawing.Size(58, 17);
            this.optRoutingStyleNormal.TabIndex = 0;
            this.optRoutingStyleNormal.TabStop = true;
            this.optRoutingStyleNormal.Tag = "1";
            this.optRoutingStyleNormal.Text = "Normal";
            this.optRoutingStyleNormal.UseVisualStyleBackColor = true;
            this.optRoutingStyleNormal.CheckedChanged += new System.EventHandler(this.RoutingStyle_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.lstExtraFields);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(9, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(429, 172);
            this.panel2.TabIndex = 32;
            // 
            // lstExtraFields
            // 
            this.lstExtraFields.FormattingEnabled = true;
            this.lstExtraFields.Items.AddRange(new object[] {
            "Filters",
            "Domain",
            "Topic",
            "Content",
            "VarLabel",
            "Product",
            "AltQNum 2",
            "AltQNum 3"});
            this.lstExtraFields.Location = new System.Drawing.Point(216, 24);
            this.lstExtraFields.Name = "lstExtraFields";
            this.lstExtraFields.Size = new System.Drawing.Size(86, 108);
            this.lstExtraFields.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(217, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 15);
            this.label8.TabIndex = 26;
            this.label8.Text = "Other Fields";
            // 
            // lblCurrentSurveyFields
            // 
            this.lblCurrentSurveyFields.AutoSize = true;
            this.lblCurrentSurveyFields.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentSurveyFields.Location = new System.Drawing.Point(15, 11);
            this.lblCurrentSurveyFields.Name = "lblCurrentSurveyFields";
            this.lblCurrentSurveyFields.Size = new System.Drawing.Size(249, 17);
            this.lblCurrentSurveyFields.TabIndex = 29;
            this.lblCurrentSurveyFields.Text = "Current Survey\'s Field Selections";
            // 
            // pgCompare
            // 
            this.pgCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(170)))), ((int)(((byte)(136)))));
            this.pgCompare.Controls.Add(this.chklstPrimarySurvey);
            this.pgCompare.Controls.Add(this.lblPrimarySurvey);
            this.pgCompare.Controls.Add(this.groupHighlightOptions);
            this.pgCompare.Controls.Add(this.chkCompare);
            this.pgCompare.Location = new System.Drawing.Point(4, 22);
            this.pgCompare.Name = "pgCompare";
            this.pgCompare.Size = new System.Drawing.Size(465, 503);
            this.pgCompare.TabIndex = 2;
            this.pgCompare.Text = "Comparison";
            // 
            // chklstPrimarySurvey
            // 
            this.chklstPrimarySurvey.CheckOnClick = true;
            this.chklstPrimarySurvey.FormattingEnabled = true;
            this.chklstPrimarySurvey.Location = new System.Drawing.Point(9, 68);
            this.chklstPrimarySurvey.Name = "chklstPrimarySurvey";
            this.chklstPrimarySurvey.Size = new System.Drawing.Size(219, 124);
            this.chklstPrimarySurvey.TabIndex = 120;
            this.chklstPrimarySurvey.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.chklstPrimarySurvey_ItemCheck);
            this.chklstPrimarySurvey.SelectedIndexChanged += new System.EventHandler(this.chklstPrimarySurvey_SelectedIndexChanged);
            // 
            // lblPrimarySurvey
            // 
            this.lblPrimarySurvey.Location = new System.Drawing.Point(10, 194);
            this.lblPrimarySurvey.Name = "lblPrimarySurvey";
            this.lblPrimarySurvey.Size = new System.Drawing.Size(182, 47);
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
            this.groupHighlightOptions.Location = new System.Drawing.Point(253, 26);
            this.groupHighlightOptions.Name = "groupHighlightOptions";
            this.groupHighlightOptions.Size = new System.Drawing.Size(191, 315);
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
            this.flowHighlightOptions.Location = new System.Drawing.Point(28, 164);
            this.flowHighlightOptions.Margin = new System.Windows.Forms.Padding(0);
            this.flowHighlightOptions.Name = "flowHighlightOptions";
            this.flowHighlightOptions.Padding = new System.Windows.Forms.Padding(1);
            this.flowHighlightOptions.Size = new System.Drawing.Size(157, 143);
            this.flowHighlightOptions.TabIndex = 10;
            // 
            // highlightNRCheckBox
            // 
            this.highlightNRCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "HighlightNR", true));
            this.highlightNRCheckBox.Location = new System.Drawing.Point(1, 1);
            this.highlightNRCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.highlightNRCheckBox.Name = "highlightNRCheckBox";
            this.highlightNRCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.highlightNRCheckBox.Size = new System.Drawing.Size(141, 20);
            this.highlightNRCheckBox.TabIndex = 29;
            this.highlightNRCheckBox.Text = "Highlight NR";
            this.highlightNRCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreSimilarWordsCheckBox
            // 
            this.ignoreSimilarWordsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "IgnoreSimilarWords", true));
            this.ignoreSimilarWordsCheckBox.Location = new System.Drawing.Point(1, 21);
            this.ignoreSimilarWordsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.ignoreSimilarWordsCheckBox.Name = "ignoreSimilarWordsCheckBox";
            this.ignoreSimilarWordsCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.ignoreSimilarWordsCheckBox.Size = new System.Drawing.Size(141, 20);
            this.ignoreSimilarWordsCheckBox.TabIndex = 37;
            this.ignoreSimilarWordsCheckBox.Text = "Ignore Word Variants";
            this.ignoreSimilarWordsCheckBox.UseVisualStyleBackColor = true;
            // 
            // showDeletedFieldsCheckBox
            // 
            this.showDeletedFieldsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ShowDeletedFields", true));
            this.showDeletedFieldsCheckBox.Location = new System.Drawing.Point(1, 41);
            this.showDeletedFieldsCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.showDeletedFieldsCheckBox.Name = "showDeletedFieldsCheckBox";
            this.showDeletedFieldsCheckBox.Padding = new System.Windows.Forms.Padding(1);
            this.showDeletedFieldsCheckBox.Size = new System.Drawing.Size(141, 20);
            this.showDeletedFieldsCheckBox.TabIndex = 47;
            this.showDeletedFieldsCheckBox.Text = "Show Deleted Fields";
            this.showDeletedFieldsCheckBox.UseVisualStyleBackColor = true;
            // 
            // chkShowDeletedQuestions
            // 
            this.chkShowDeletedQuestions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ShowDeletedQuestions", true));
            this.chkShowDeletedQuestions.Location = new System.Drawing.Point(1, 61);
            this.chkShowDeletedQuestions.Margin = new System.Windows.Forms.Padding(0);
            this.chkShowDeletedQuestions.Name = "chkShowDeletedQuestions";
            this.chkShowDeletedQuestions.Padding = new System.Windows.Forms.Padding(1);
            this.chkShowDeletedQuestions.Size = new System.Drawing.Size(156, 20);
            this.chkShowDeletedQuestions.TabIndex = 49;
            this.chkShowDeletedQuestions.Text = "Show Deleted Questions";
            this.chkShowDeletedQuestions.UseVisualStyleBackColor = true;
            this.chkShowDeletedQuestions.CheckedChanged += new System.EventHandler(this.ShowDeletedQuestionsCheckBox_CheckedChanged);
            // 
            // chkReInsertDeletions
            // 
            this.chkReInsertDeletions.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.compareBindingSource, "ReInsertDeletions", true));
            this.chkReInsertDeletions.Location = new System.Drawing.Point(1, 81);
            this.chkReInsertDeletions.Margin = new System.Windows.Forms.Padding(0);
            this.chkReInsertDeletions.Name = "chkReInsertDeletions";
            this.chkReInsertDeletions.Padding = new System.Windows.Forms.Padding(1);
            this.chkReInsertDeletions.Size = new System.Drawing.Size(123, 20);
            this.chkReInsertDeletions.TabIndex = 43;
            this.chkReInsertDeletions.Text = "Re-insert Deletions";
            this.chkReInsertDeletions.UseVisualStyleBackColor = true;
            // 
            // groupHighlightStyle
            // 
            this.groupHighlightStyle.Controls.Add(this.radioButton1);
            this.groupHighlightStyle.Location = new System.Drawing.Point(18, 42);
            this.groupHighlightStyle.Name = "groupHighlightStyle";
            this.groupHighlightStyle.Size = new System.Drawing.Size(152, 51);
            this.groupHighlightStyle.TabIndex = 3;
            this.groupHighlightStyle.TabStop = false;
            this.groupHighlightStyle.Text = "Highlight Style";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(10, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(100, 17);
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
            this.highlightCheckBox.Location = new System.Drawing.Point(29, 19);
            this.highlightCheckBox.Name = "highlightCheckBox";
            this.highlightCheckBox.Size = new System.Drawing.Size(104, 20);
            this.highlightCheckBox.TabIndex = 27;
            this.highlightCheckBox.Text = "Highlight";
            this.highlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // chkCompare
            // 
            this.chkCompare.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.surveyReportBindingSource, "CompareWordings", true));
            this.chkCompare.Location = new System.Drawing.Point(13, 26);
            this.chkCompare.Name = "chkCompare";
            this.chkCompare.Size = new System.Drawing.Size(104, 24);
            this.chkCompare.TabIndex = 21;
            this.chkCompare.Text = "Compare?";
            this.chkCompare.UseVisualStyleBackColor = true;
            this.chkCompare.CheckedChanged += new System.EventHandler(this.Compare_CheckedChanged);
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
            this.pgFileName.Location = new System.Drawing.Point(4, 22);
            this.pgFileName.Name = "pgFileName";
            this.pgFileName.Padding = new System.Windows.Forms.Padding(3);
            this.pgFileName.Size = new System.Drawing.Size(465, 503);
            this.pgFileName.TabIndex = 6;
            this.pgFileName.Text = "File Name";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(86, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(90, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Main source(s)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(186, 146);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 13);
            this.label13.TabIndex = 36;
            this.label13.Text = "vs.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(7, 459);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(360, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Note: Date and Time will be appended to the above file name.";
            // 
            // txtSecondSources
            // 
            this.txtSecondSources.Location = new System.Drawing.Point(183, 168);
            this.txtSecondSources.Name = "txtSecondSources";
            this.txtSecondSources.Size = new System.Drawing.Size(183, 20);
            this.txtSecondSources.TabIndex = 2;
            // 
            // detailsTextBox
            // 
            this.detailsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.surveyReportBindingSource, "Details", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.detailsTextBox.Location = new System.Drawing.Point(182, 220);
            this.detailsTextBox.Name = "detailsTextBox";
            this.detailsTextBox.Size = new System.Drawing.Size(185, 20);
            this.detailsTextBox.TabIndex = 28;
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.surveyReportBindingSource, "FileName", true));
            this.fileNameTextBox.Location = new System.Drawing.Point(6, 437);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(419, 20);
            this.fileNameTextBox.TabIndex = 34;
            // 
            // txtMainSource
            // 
            this.txtMainSource.Location = new System.Drawing.Point(182, 119);
            this.txtMainSource.Name = "txtMainSource";
            this.txtMainSource.Size = new System.Drawing.Size(185, 20);
            this.txtMainSource.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(23, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(421, 39);
            this.label11.TabIndex = 0;
            this.label11.Text = "The following pieces of information will be part of the file name. You can also e" +
    "nter a file name which will override the defaults.";
            // 
            // surveysBindingSource
            // 
            this.surveysBindingSource.DataMember = "Surveys";
            this.surveysBindingSource.DataSource = this.surveyReportBindingSource;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(7, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(240, 31);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "ITC Survey Report";
            // 
            // dateBackend
            // 
            this.dateBackend.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBackend.Location = new System.Drawing.Point(328, 117);
            this.dateBackend.Name = "dateBackend";
            this.dateBackend.Size = new System.Drawing.Size(119, 20);
            this.dateBackend.TabIndex = 8;
            this.dateBackend.ValueChanged += new System.EventHandler(this.dateBackend_ValueChanged);
            // 
            // lblBackend
            // 
            this.lblBackend.AutoSize = true;
            this.lblBackend.Location = new System.Drawing.Point(292, 121);
            this.lblBackend.Name = "lblBackend";
            this.lblBackend.Size = new System.Drawing.Size(30, 13);
            this.lblBackend.TabIndex = 9;
            this.lblBackend.Text = "From";
            // 
            // cmdSelfCompare
            // 
            this.cmdSelfCompare.Location = new System.Drawing.Point(12, 145);
            this.cmdSelfCompare.Name = "cmdSelfCompare";
            this.cmdSelfCompare.Size = new System.Drawing.Size(108, 23);
            this.cmdSelfCompare.TabIndex = 58;
            this.cmdSelfCompare.Text = "Self-comparison";
            this.cmdSelfCompare.UseVisualStyleBackColor = true;
            this.cmdSelfCompare.Click += new System.EventHandler(this.SelfCompare_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(19, 761);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 13);
            this.lblStatus.TabIndex = 60;
            this.lblStatus.Text = "lblStatus";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.quickReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(496, 24);
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
            // quickReportToolStripMenuItem
            // 
            this.quickReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.standardWTranslationToolStripMenuItem,
            this.websiteToolStripMenuItem,
            this.websiteWTranslationToolStripMenuItem});
            this.quickReportToolStripMenuItem.Name = "quickReportToolStripMenuItem";
            this.quickReportToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.quickReportToolStripMenuItem.Text = "Quick Report";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.standardToolStripMenuItem.Text = "Standard";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // standardWTranslationToolStripMenuItem
            // 
            this.standardWTranslationToolStripMenuItem.Name = "standardWTranslationToolStripMenuItem";
            this.standardWTranslationToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.standardWTranslationToolStripMenuItem.Text = "Standard w/ Translation";
            this.standardWTranslationToolStripMenuItem.Click += new System.EventHandler(this.standardWTranslationToolStripMenuItem_Click);
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            this.websiteToolStripMenuItem.Click += new System.EventHandler(this.websiteToolStripMenuItem_Click);
            // 
            // websiteWTranslationToolStripMenuItem
            // 
            this.websiteWTranslationToolStripMenuItem.Name = "websiteWTranslationToolStripMenuItem";
            this.websiteWTranslationToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.websiteWTranslationToolStripMenuItem.Text = "Website w/ Translation";
            this.websiteWTranslationToolStripMenuItem.Click += new System.EventHandler(this.websiteWTranslationToolStripMenuItem_Click);
            // 
            // SurveyReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(496, 798);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmdSelfCompare);
            this.Controls.Add(this.lblBackend);
            this.Controls.Add(this.dateBackend);
            this.Controls.Add(this.cboSurveys);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.cmdAddSurvey);
            this.Controls.Add(this.cmdRemoveSurvey);
            this.Controls.Add(this.tabControlOptions);
            this.Controls.Add(this.cmdCheckOptions);
            this.Controls.Add(this.lstSelectedSurveys);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "SurveyReportForm";
            this.Text = "Survey Report";
            this.Load += new System.EventHandler(this.SurveyReportForm_Load);
            this.tabControlOptions.ResumeLayout(false);
            this.pgFields.ResumeLayout(false);
            this.pgFields.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupRoutingStyle.ResumeLayout(false);
            this.groupRoutingStyle.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.pgCompare.ResumeLayout(false);
            this.groupHighlightOptions.ResumeLayout(false);
            this.flowHighlightOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.compareBindingSource)).EndInit();
            this.groupHighlightStyle.ResumeLayout(false);
            this.groupHighlightStyle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.surveyReportBindingSource)).EndInit();
            this.pgFileName.ResumeLayout(false);
            this.pgFileName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportLayoutBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.surveysBindingSource)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSurveys;
        private System.Windows.Forms.Button cmdAddSurvey;
        private System.Windows.Forms.Button cmdRemoveSurvey;
        private System.Windows.Forms.ListBox lstSelectedSurveys;
        private System.Windows.Forms.Button cmdCheckOptions;
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
        private System.Windows.Forms.ToolStripMenuItem quickReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardWTranslationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteWTranslationToolStripMenuItem;
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ListBox lstExtraFields;
    }
}

