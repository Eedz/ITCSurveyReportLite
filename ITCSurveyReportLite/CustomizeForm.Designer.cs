namespace ITCSurveyReportLite
{
    partial class CustomizeForm
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
            this.lblSurvey = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelQnumRange = new System.Windows.Forms.Panel();
            this.cmdShowLowest = new System.Windows.Forms.Button();
            this.cmdShowMax = new System.Windows.Forms.Button();
            this.txtUpperQnum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLowerQnum = new System.Windows.Forms.TextBox();
            this.lstFilterType = new System.Windows.Forms.ListBox();
            this.rbProduct = new System.Windows.Forms.RadioButton();
            this.rbHeading = new System.Windows.Forms.RadioButton();
            this.rbQnum = new System.Windows.Forms.RadioButton();
            this.rbPrefix = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lstWordingFields = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lstVarName = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.chkRemoveOtherSpecify = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panelQnumRange.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSurvey
            // 
            this.lblSurvey.AutoSize = true;
            this.lblSurvey.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSurvey.Location = new System.Drawing.Point(156, 9);
            this.lblSurvey.Name = "lblSurvey";
            this.lblSurvey.Size = new System.Drawing.Size(216, 27);
            this.lblSurvey.TabIndex = 0;
            this.lblSurvey.Text = "Survey Code Content";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panelQnumRange);
            this.panel1.Controls.Add(this.lstFilterType);
            this.panel1.Controls.Add(this.rbProduct);
            this.panel1.Controls.Add(this.rbHeading);
            this.panel1.Controls.Add(this.rbQnum);
            this.panel1.Controls.Add(this.rbPrefix);
            this.panel1.Location = new System.Drawing.Point(8, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 474);
            this.panel1.TabIndex = 1;
            // 
            // panelQnumRange
            // 
            this.panelQnumRange.Controls.Add(this.cmdShowLowest);
            this.panelQnumRange.Controls.Add(this.cmdShowMax);
            this.panelQnumRange.Controls.Add(this.txtUpperQnum);
            this.panelQnumRange.Controls.Add(this.label1);
            this.panelQnumRange.Controls.Add(this.txtLowerQnum);
            this.panelQnumRange.Location = new System.Drawing.Point(92, 27);
            this.panelQnumRange.Name = "panelQnumRange";
            this.panelQnumRange.Size = new System.Drawing.Size(133, 40);
            this.panelQnumRange.TabIndex = 8;
            this.panelQnumRange.Visible = false;
            // 
            // cmdShowLowest
            // 
            this.cmdShowLowest.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowLowest.Location = new System.Drawing.Point(6, 6);
            this.cmdShowLowest.Name = "cmdShowLowest";
            this.cmdShowLowest.Size = new System.Drawing.Size(14, 23);
            this.cmdShowLowest.TabIndex = 9;
            this.cmdShowLowest.Text = "L";
            this.cmdShowLowest.UseCompatibleTextRendering = true;
            this.cmdShowLowest.UseVisualStyleBackColor = true;
            this.cmdShowLowest.Click += new System.EventHandler(this.cmdShowLowest_Click);
            // 
            // cmdShowMax
            // 
            this.cmdShowMax.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdShowMax.Location = new System.Drawing.Point(107, 6);
            this.cmdShowMax.Name = "cmdShowMax";
            this.cmdShowMax.Size = new System.Drawing.Size(14, 23);
            this.cmdShowMax.TabIndex = 8;
            this.cmdShowMax.Text = "H";
            this.cmdShowMax.UseCompatibleTextRendering = true;
            this.cmdShowMax.UseVisualStyleBackColor = true;
            this.cmdShowMax.Click += new System.EventHandler(this.cmdShowMax_Click);
            // 
            // txtUpperQnum
            // 
            this.txtUpperQnum.Location = new System.Drawing.Point(74, 6);
            this.txtUpperQnum.Name = "txtUpperQnum";
            this.txtUpperQnum.Size = new System.Drawing.Size(29, 23);
            this.txtUpperQnum.TabIndex = 7;
            this.txtUpperQnum.TextChanged += new System.EventHandler(this.txtUpperQnum_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "-";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // txtLowerQnum
            // 
            this.txtLowerQnum.Location = new System.Drawing.Point(26, 6);
            this.txtLowerQnum.Name = "txtLowerQnum";
            this.txtLowerQnum.Size = new System.Drawing.Size(29, 23);
            this.txtLowerQnum.TabIndex = 5;
            this.txtLowerQnum.TextChanged += new System.EventHandler(this.txtLowerQnum_TextChanged);
            // 
            // lstFilterType
            // 
            this.lstFilterType.FormattingEnabled = true;
            this.lstFilterType.ItemHeight = 16;
            this.lstFilterType.Location = new System.Drawing.Point(4, 96);
            this.lstFilterType.Name = "lstFilterType";
            this.lstFilterType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstFilterType.Size = new System.Drawing.Size(292, 372);
            this.lstFilterType.TabIndex = 4;
            this.lstFilterType.Click += new System.EventHandler(this.lstFilterType_Click);
            // 
            // rbProduct
            // 
            this.rbProduct.AutoSize = true;
            this.rbProduct.Location = new System.Drawing.Point(6, 67);
            this.rbProduct.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbProduct.Name = "rbProduct";
            this.rbProduct.Size = new System.Drawing.Size(68, 20);
            this.rbProduct.TabIndex = 3;
            this.rbProduct.TabStop = true;
            this.rbProduct.Text = "Product";
            this.rbProduct.UseVisualStyleBackColor = true;
            this.rbProduct.Visible = false;
            this.rbProduct.Click += new System.EventHandler(this.rbProduct_Click);
            // 
            // rbHeading
            // 
            this.rbHeading.AutoSize = true;
            this.rbHeading.Location = new System.Drawing.Point(6, 47);
            this.rbHeading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbHeading.Name = "rbHeading";
            this.rbHeading.Size = new System.Drawing.Size(71, 20);
            this.rbHeading.TabIndex = 2;
            this.rbHeading.TabStop = true;
            this.rbHeading.Text = "Heading";
            this.rbHeading.UseVisualStyleBackColor = true;
            this.rbHeading.Click += new System.EventHandler(this.rbHeading_Click);
            // 
            // rbQnum
            // 
            this.rbQnum.AutoSize = true;
            this.rbQnum.Location = new System.Drawing.Point(6, 27);
            this.rbQnum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbQnum.Name = "rbQnum";
            this.rbQnum.Size = new System.Drawing.Size(59, 20);
            this.rbQnum.TabIndex = 1;
            this.rbQnum.TabStop = true;
            this.rbQnum.Text = "Qnum";
            this.rbQnum.UseVisualStyleBackColor = true;
            this.rbQnum.Click += new System.EventHandler(this.rbQnum_Click);
            // 
            // rbPrefix
            // 
            this.rbPrefix.AutoSize = true;
            this.rbPrefix.Location = new System.Drawing.Point(6, 7);
            this.rbPrefix.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbPrefix.Name = "rbPrefix";
            this.rbPrefix.Size = new System.Drawing.Size(57, 20);
            this.rbPrefix.TabIndex = 0;
            this.rbPrefix.TabStop = true;
            this.rbPrefix.Text = "Prefix";
            this.rbPrefix.UseVisualStyleBackColor = true;
            this.rbPrefix.Click += new System.EventHandler(this.rbPrefix_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter by...";
            // 
            // lstWordingFields
            // 
            this.lstWordingFields.FormattingEnabled = true;
            this.lstWordingFields.ItemHeight = 16;
            this.lstWordingFields.Items.AddRange(new object[] {
            "PreP",
            "PreI",
            "PreA",
            "LitQ",
            "RespOptions",
            "NRCodes",
            "PstI",
            "PstP"});
            this.lstWordingFields.Location = new System.Drawing.Point(414, 80);
            this.lstWordingFields.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstWordingFields.Name = "lstWordingFields";
            this.lstWordingFields.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstWordingFields.Size = new System.Drawing.Size(109, 132);
            this.lstWordingFields.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(421, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Question Fields";
            // 
            // lstVarName
            // 
            this.lstVarName.FormattingEnabled = true;
            this.lstVarName.ItemHeight = 16;
            this.lstVarName.Location = new System.Drawing.Point(313, 80);
            this.lstVarName.Name = "lstVarName";
            this.lstVarName.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstVarName.Size = new System.Drawing.Size(97, 468);
            this.lstVarName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(329, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "VarNames";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(340, 597);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 28);
            this.cmdOK.TabIndex = 7;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(435, 597);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 28);
            this.cmdCancel.TabIndex = 8;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // chkRemoveOtherSpecify
            // 
            this.chkRemoveOtherSpecify.AutoSize = true;
            this.chkRemoveOtherSpecify.Location = new System.Drawing.Point(313, 554);
            this.chkRemoveOtherSpecify.Name = "chkRemoveOtherSpecify";
            this.chkRemoveOtherSpecify.Size = new System.Drawing.Size(161, 20);
            this.chkRemoveOtherSpecify.TabIndex = 9;
            this.chkRemoveOtherSpecify.Text = "Remove Other (specify)";
            this.chkRemoveOtherSpecify.UseVisualStyleBackColor = true;
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 648);
            this.ControlBox = false;
            this.Controls.Add(this.chkRemoveOtherSpecify);
            this.Controls.Add(this.lstVarName);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstWordingFields);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblSurvey);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CustomizeForm";
            this.Text = "Content for";
            this.Load += new System.EventHandler(this.CustomizeForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelQnumRange.ResumeLayout(false);
            this.panelQnumRange.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSurvey;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbProduct;
        private System.Windows.Forms.RadioButton rbHeading;
        private System.Windows.Forms.RadioButton rbQnum;
        private System.Windows.Forms.RadioButton rbPrefix;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstWordingFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.ListBox lstFilterType;
        private System.Windows.Forms.ListBox lstVarName;
        private System.Windows.Forms.TextBox txtUpperQnum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLowerQnum;
        private System.Windows.Forms.Panel panelQnumRange;
        private System.Windows.Forms.Button cmdShowLowest;
        private System.Windows.Forms.Button cmdShowMax;
        private System.Windows.Forms.CheckBox chkRemoveOtherSpecify;
    }
}