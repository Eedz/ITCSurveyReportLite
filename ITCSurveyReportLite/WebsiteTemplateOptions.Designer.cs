namespace ITCSurveyReportLite
{
    partial class WebsiteTemplateOptions
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
            this.chkIncludeEnglish = new System.Windows.Forms.CheckBox();
            this.cboLanguage = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkIncludeTranslation = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chkIncludeEnglish
            // 
            this.chkIncludeEnglish.AutoSize = true;
            this.chkIncludeEnglish.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeEnglish.Location = new System.Drawing.Point(12, 22);
            this.chkIncludeEnglish.Name = "chkIncludeEnglish";
            this.chkIncludeEnglish.Size = new System.Drawing.Size(117, 21);
            this.chkIncludeEnglish.TabIndex = 0;
            this.chkIncludeEnglish.Text = "Include English";
            this.chkIncludeEnglish.UseVisualStyleBackColor = true;
            // 
            // cboLanguage
            // 
            this.cboLanguage.Enabled = false;
            this.cboLanguage.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLanguage.FormattingEnabled = true;
            this.cboLanguage.Location = new System.Drawing.Point(89, 80);
            this.cboLanguage.Name = "cboLanguage";
            this.cboLanguage.Size = new System.Drawing.Size(95, 24);
            this.cboLanguage.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Translation";
            // 
            // cmdOK
            // 
            this.cmdOK.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOK.Location = new System.Drawing.Point(147, 124);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(37, 29);
            this.cmdOK.TabIndex = 3;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkIncludeTranslation
            // 
            this.chkIncludeTranslation.AutoSize = true;
            this.chkIncludeTranslation.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIncludeTranslation.Location = new System.Drawing.Point(12, 49);
            this.chkIncludeTranslation.Name = "chkIncludeTranslation";
            this.chkIncludeTranslation.Size = new System.Drawing.Size(141, 21);
            this.chkIncludeTranslation.TabIndex = 4;
            this.chkIncludeTranslation.Text = "Include Translation";
            this.chkIncludeTranslation.UseVisualStyleBackColor = true;
            this.chkIncludeTranslation.CheckedChanged += new System.EventHandler(this.chkIncludeTranslation_CheckedChanged);
            // 
            // WebsiteTemplateOptions
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(197, 160);
            this.ControlBox = false;
            this.Controls.Add(this.chkIncludeTranslation);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboLanguage);
            this.Controls.Add(this.chkIncludeEnglish);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "WebsiteTemplateOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkIncludeEnglish;
        private System.Windows.Forms.ComboBox cboLanguage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkIncludeTranslation;
    }
}