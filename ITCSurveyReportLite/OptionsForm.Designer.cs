namespace ITCSurveyReportLite
{
    partial class OptionsForm
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkLongLists = new System.Windows.Forms.CheckBox();
            this.chkInsertQnums = new System.Windows.Forms.CheckBox();
            this.chkInsertCC = new System.Windows.Forms.CheckBox();
            this.chkInlineRouting = new System.Windows.Forms.CheckBox();
            this.chkSemiTelephone = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSubsetTables = new System.Windows.Forms.CheckBox();
            this.panelInsertQnums = new System.Windows.Forms.Panel();
            this.rbInsertAQN = new System.Windows.Forms.RadioButton();
            this.rbInsertQnum = new System.Windows.Forms.RadioButton();
            this.panelSubsetTables = new System.Windows.Forms.Panel();
            this.rbTranslationSubsetTables = new System.Windows.Forms.RadioButton();
            this.rbEnglishSubsetTables = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.groupNRFormat = new System.Windows.Forms.GroupBox();
            this.rbNRDRO = new System.Windows.Forms.RadioButton();
            this.rbNRDR = new System.Windows.Forms.RadioButton();
            this.rbNRNormal = new System.Windows.Forms.RadioButton();
            this.chkSurveyNotes = new System.Windows.Forms.CheckBox();
            this.chkVarChangesColumn = new System.Windows.Forms.CheckBox();
            this.chkVarChangesAppendix = new System.Windows.Forms.CheckBox();
            this.chkExcludeHiddenChanges = new System.Windows.Forms.CheckBox();
            this.panelInsertQnums.SuspendLayout();
            this.panelSubsetTables.SuspendLayout();
            this.groupNRFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(231, 333);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 28);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(339, 333);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 28);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkLongLists
            // 
            this.chkLongLists.AutoSize = true;
            this.chkLongLists.Location = new System.Drawing.Point(12, 86);
            this.chkLongLists.Name = "chkLongLists";
            this.chkLongLists.Size = new System.Drawing.Size(119, 20);
            this.chkLongLists.TabIndex = 2;
            this.chkLongLists.Text = "Show Long Lists";
            this.chkLongLists.UseVisualStyleBackColor = true;
            // 
            // chkInsertQnums
            // 
            this.chkInsertQnums.AutoSize = true;
            this.chkInsertQnums.Location = new System.Drawing.Point(12, 113);
            this.chkInsertQnums.Name = "chkInsertQnums";
            this.chkInsertQnums.Size = new System.Drawing.Size(104, 20);
            this.chkInsertQnums.TabIndex = 3;
            this.chkInsertQnums.Text = "Insert Qnums";
            this.chkInsertQnums.UseVisualStyleBackColor = true;
            this.chkInsertQnums.Click += new System.EventHandler(this.chkInsertQnums_Click);
            // 
            // chkInsertCC
            // 
            this.chkInsertCC.AutoSize = true;
            this.chkInsertCC.Location = new System.Drawing.Point(12, 178);
            this.chkInsertCC.Name = "chkInsertCC";
            this.chkInsertCC.Size = new System.Drawing.Size(147, 20);
            this.chkInsertCC.TabIndex = 4;
            this.chkInsertCC.Text = "Insert Country Codes";
            this.chkInsertCC.UseVisualStyleBackColor = true;
            // 
            // chkInlineRouting
            // 
            this.chkInlineRouting.AutoSize = true;
            this.chkInlineRouting.Location = new System.Drawing.Point(12, 204);
            this.chkInlineRouting.Name = "chkInlineRouting";
            this.chkInlineRouting.Size = new System.Drawing.Size(110, 20);
            this.chkInlineRouting.TabIndex = 5;
            this.chkInlineRouting.Text = "In-line Routing";
            this.chkInlineRouting.UseVisualStyleBackColor = true;
            // 
            // chkSemiTelephone
            // 
            this.chkSemiTelephone.AutoSize = true;
            this.chkSemiTelephone.Location = new System.Drawing.Point(12, 300);
            this.chkSemiTelephone.Name = "chkSemiTelephone";
            this.chkSemiTelephone.Size = new System.Drawing.Size(121, 20);
            this.chkSemiTelephone.TabIndex = 6;
            this.chkSemiTelephone.Text = "Semi-Telephone";
            this.chkSemiTelephone.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 27);
            this.label1.TabIndex = 8;
            this.label1.Text = "Survey Report Global Options";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(303, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "These options will apply to all surveys in the report.";
            // 
            // chkSubsetTables
            // 
            this.chkSubsetTables.AutoSize = true;
            this.chkSubsetTables.Location = new System.Drawing.Point(12, 230);
            this.chkSubsetTables.Name = "chkSubsetTables";
            this.chkSubsetTables.Size = new System.Drawing.Size(145, 20);
            this.chkSubsetTables.TabIndex = 10;
            this.chkSubsetTables.Text = "Insert Subset Tables";
            this.chkSubsetTables.UseVisualStyleBackColor = true;
            this.chkSubsetTables.Click += new System.EventHandler(this.chkSubsetTables_Click);
            // 
            // panelInsertQnums
            // 
            this.panelInsertQnums.Controls.Add(this.rbInsertAQN);
            this.panelInsertQnums.Controls.Add(this.rbInsertQnum);
            this.panelInsertQnums.Enabled = false;
            this.panelInsertQnums.Location = new System.Drawing.Point(60, 135);
            this.panelInsertQnums.Name = "panelInsertQnums";
            this.panelInsertQnums.Size = new System.Drawing.Size(80, 40);
            this.panelInsertQnums.TabIndex = 12;
            // 
            // rbInsertAQN
            // 
            this.rbInsertAQN.AutoSize = true;
            this.rbInsertAQN.Location = new System.Drawing.Point(3, 19);
            this.rbInsertAQN.Name = "rbInsertAQN";
            this.rbInsertAQN.Size = new System.Drawing.Size(75, 20);
            this.rbInsertAQN.TabIndex = 1;
            this.rbInsertAQN.TabStop = true;
            this.rbInsertAQN.Text = "AltQnum";
            this.rbInsertAQN.UseVisualStyleBackColor = true;
            // 
            // rbInsertQnum
            // 
            this.rbInsertQnum.AutoSize = true;
            this.rbInsertQnum.Location = new System.Drawing.Point(3, 0);
            this.rbInsertQnum.Name = "rbInsertQnum";
            this.rbInsertQnum.Size = new System.Drawing.Size(60, 20);
            this.rbInsertQnum.TabIndex = 0;
            this.rbInsertQnum.TabStop = true;
            this.rbInsertQnum.Text = "Qnum";
            this.rbInsertQnum.UseVisualStyleBackColor = true;
            // 
            // panelSubsetTables
            // 
            this.panelSubsetTables.Controls.Add(this.rbTranslationSubsetTables);
            this.panelSubsetTables.Controls.Add(this.rbEnglishSubsetTables);
            this.panelSubsetTables.Enabled = false;
            this.panelSubsetTables.Location = new System.Drawing.Point(59, 256);
            this.panelSubsetTables.Name = "panelSubsetTables";
            this.panelSubsetTables.Size = new System.Drawing.Size(100, 40);
            this.panelSubsetTables.TabIndex = 13;
            // 
            // rbTranslationSubsetTables
            // 
            this.rbTranslationSubsetTables.AutoSize = true;
            this.rbTranslationSubsetTables.Location = new System.Drawing.Point(6, 17);
            this.rbTranslationSubsetTables.Name = "rbTranslationSubsetTables";
            this.rbTranslationSubsetTables.Size = new System.Drawing.Size(90, 20);
            this.rbTranslationSubsetTables.TabIndex = 1;
            this.rbTranslationSubsetTables.TabStop = true;
            this.rbTranslationSubsetTables.Text = "Translation";
            this.rbTranslationSubsetTables.UseVisualStyleBackColor = true;
            // 
            // rbEnglishSubsetTables
            // 
            this.rbEnglishSubsetTables.AutoSize = true;
            this.rbEnglishSubsetTables.Location = new System.Drawing.Point(6, 0);
            this.rbEnglishSubsetTables.Name = "rbEnglishSubsetTables";
            this.rbEnglishSubsetTables.Size = new System.Drawing.Size(66, 20);
            this.rbEnglishSubsetTables.TabIndex = 0;
            this.rbEnglishSubsetTables.TabStop = true;
            this.rbEnglishSubsetTables.Text = "English";
            this.rbEnglishSubsetTables.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(6, 328);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(430, 2);
            this.label4.TabIndex = 16;
            this.label4.Text = "label4";
            // 
            // groupNRFormat
            // 
            this.groupNRFormat.Controls.Add(this.rbNRDRO);
            this.groupNRFormat.Controls.Add(this.rbNRDR);
            this.groupNRFormat.Controls.Add(this.rbNRNormal);
            this.groupNRFormat.Location = new System.Drawing.Point(181, 86);
            this.groupNRFormat.Name = "groupNRFormat";
            this.groupNRFormat.Size = new System.Drawing.Size(126, 86);
            this.groupNRFormat.TabIndex = 17;
            this.groupNRFormat.TabStop = false;
            this.groupNRFormat.Text = "NR Format";
            // 
            // rbNRDRO
            // 
            this.rbNRDRO.AutoSize = true;
            this.rbNRDRO.Location = new System.Drawing.Point(7, 61);
            this.rbNRDRO.Name = "rbNRDRO";
            this.rbNRDRO.Size = new System.Drawing.Size(112, 20);
            this.rbNRDRO.TabIndex = 2;
            this.rbNRDRO.Text = "Don\'t Read Out";
            this.rbNRDRO.UseVisualStyleBackColor = true;
            // 
            // rbNRDR
            // 
            this.rbNRDR.AutoSize = true;
            this.rbNRDR.Location = new System.Drawing.Point(7, 40);
            this.rbNRDR.Name = "rbNRDR";
            this.rbNRDR.Size = new System.Drawing.Size(88, 20);
            this.rbNRDR.TabIndex = 1;
            this.rbNRDR.Text = "Don\'t Read";
            this.rbNRDR.UseVisualStyleBackColor = true;
            // 
            // rbNRNormal
            // 
            this.rbNRNormal.AutoSize = true;
            this.rbNRNormal.Checked = true;
            this.rbNRNormal.Location = new System.Drawing.Point(7, 19);
            this.rbNRNormal.Name = "rbNRNormal";
            this.rbNRNormal.Size = new System.Drawing.Size(67, 20);
            this.rbNRNormal.TabIndex = 0;
            this.rbNRNormal.TabStop = true;
            this.rbNRNormal.Text = "Neither";
            this.rbNRNormal.UseVisualStyleBackColor = true;
            // 
            // chkSurveyNotes
            // 
            this.chkSurveyNotes.AutoSize = true;
            this.chkSurveyNotes.Location = new System.Drawing.Point(181, 192);
            this.chkSurveyNotes.Name = "chkSurveyNotes";
            this.chkSurveyNotes.Size = new System.Drawing.Size(102, 20);
            this.chkSurveyNotes.TabIndex = 18;
            this.chkSurveyNotes.Text = "Survey Notes";
            this.chkSurveyNotes.UseVisualStyleBackColor = true;
            // 
            // chkVarChangesColumn
            // 
            this.chkVarChangesColumn.AutoSize = true;
            this.chkVarChangesColumn.Location = new System.Drawing.Point(181, 218);
            this.chkVarChangesColumn.Name = "chkVarChangesColumn";
            this.chkVarChangesColumn.Size = new System.Drawing.Size(259, 20);
            this.chkVarChangesColumn.TabIndex = 19;
            this.chkVarChangesColumn.Text = "VarName Changes (in VarName column)";
            this.chkVarChangesColumn.UseVisualStyleBackColor = true;
            // 
            // chkVarChangesAppendix
            // 
            this.chkVarChangesAppendix.AutoSize = true;
            this.chkVarChangesAppendix.Location = new System.Drawing.Point(181, 244);
            this.chkVarChangesAppendix.Name = "chkVarChangesAppendix";
            this.chkVarChangesAppendix.Size = new System.Drawing.Size(213, 20);
            this.chkVarChangesAppendix.TabIndex = 20;
            this.chkVarChangesAppendix.Text = "VarName Changes (in Appendix)";
            this.chkVarChangesAppendix.UseVisualStyleBackColor = true;
            // 
            // chkExcludeHiddenChanges
            // 
            this.chkExcludeHiddenChanges.Checked = true;
            this.chkExcludeHiddenChanges.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExcludeHiddenChanges.Location = new System.Drawing.Point(199, 268);
            this.chkExcludeHiddenChanges.Name = "chkExcludeHiddenChanges";
            this.chkExcludeHiddenChanges.Size = new System.Drawing.Size(234, 38);
            this.chkExcludeHiddenChanges.TabIndex = 21;
            this.chkExcludeHiddenChanges.Text = "Exclude Hidden changes (in column and appendix)";
            this.chkExcludeHiddenChanges.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(441, 372);
            this.ControlBox = false;
            this.Controls.Add(this.chkExcludeHiddenChanges);
            this.Controls.Add(this.chkVarChangesAppendix);
            this.Controls.Add(this.chkVarChangesColumn);
            this.Controls.Add(this.chkSurveyNotes);
            this.Controls.Add(this.groupNRFormat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panelSubsetTables);
            this.Controls.Add(this.panelInsertQnums);
            this.Controls.Add(this.chkSubsetTables);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSemiTelephone);
            this.Controls.Add(this.chkInlineRouting);
            this.Controls.Add(this.chkInsertCC);
            this.Controls.Add(this.chkInsertQnums);
            this.Controls.Add(this.chkLongLists);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "OptionsForm";
            this.Text = "Report Options";
            this.panelInsertQnums.ResumeLayout(false);
            this.panelInsertQnums.PerformLayout();
            this.panelSubsetTables.ResumeLayout(false);
            this.panelSubsetTables.PerformLayout();
            this.groupNRFormat.ResumeLayout(false);
            this.groupNRFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.CheckBox chkLongLists;
        private System.Windows.Forms.CheckBox chkInsertQnums;
        private System.Windows.Forms.CheckBox chkInsertCC;
        private System.Windows.Forms.CheckBox chkInlineRouting;
        private System.Windows.Forms.CheckBox chkSemiTelephone;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkSubsetTables;
        private System.Windows.Forms.Panel panelInsertQnums;
        private System.Windows.Forms.RadioButton rbInsertAQN;
        private System.Windows.Forms.RadioButton rbInsertQnum;
        private System.Windows.Forms.Panel panelSubsetTables;
        private System.Windows.Forms.RadioButton rbTranslationSubsetTables;
        private System.Windows.Forms.RadioButton rbEnglishSubsetTables;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupNRFormat;
        private System.Windows.Forms.RadioButton rbNRDRO;
        private System.Windows.Forms.RadioButton rbNRDR;
        private System.Windows.Forms.RadioButton rbNRNormal;
        private System.Windows.Forms.CheckBox chkSurveyNotes;
        private System.Windows.Forms.CheckBox chkVarChangesColumn;
        private System.Windows.Forms.CheckBox chkVarChangesAppendix;
        private System.Windows.Forms.CheckBox chkExcludeHiddenChanges;
    }
}