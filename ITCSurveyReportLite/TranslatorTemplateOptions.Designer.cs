namespace ITCSurveyReportLite
{
    partial class TranslatorTemplateOptions
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
            this.dtpBackup = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboRefSurv = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboLang = new System.Windows.Forms.ComboBox();
            this.optUseRef = new System.Windows.Forms.RadioButton();
            this.optUseMain = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(124, 179);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(41, 23);
            this.cmdOK.TabIndex = 16;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // dtpBackup
            // 
            this.dtpBackup.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBackup.Location = new System.Drawing.Point(82, 35);
            this.dtpBackup.Name = "dtpBackup";
            this.dtpBackup.Size = new System.Drawing.Size(83, 21);
            this.dtpBackup.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "on";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Compare with";
            // 
            // cboRefSurv
            // 
            this.cboRefSurv.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRefSurv.FormattingEnabled = true;
            this.cboRefSurv.Location = new System.Drawing.Point(82, 12);
            this.cboRefSurv.Name = "cboRefSurv";
            this.cboRefSurv.Size = new System.Drawing.Size(83, 21);
            this.cboRefSurv.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(25, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Language";
            // 
            // cboLang
            // 
            this.cboLang.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLang.FormattingEnabled = true;
            this.cboLang.Location = new System.Drawing.Point(82, 77);
            this.cboLang.Name = "cboLang";
            this.cboLang.Size = new System.Drawing.Size(83, 21);
            this.cboLang.TabIndex = 17;
            // 
            // optUseRef
            // 
            this.optUseRef.AutoSize = true;
            this.optUseRef.Location = new System.Drawing.Point(81, 156);
            this.optUseRef.Name = "optUseRef";
            this.optUseRef.Size = new System.Drawing.Size(112, 17);
            this.optUseRef.TabIndex = 23;
            this.optUseRef.TabStop = true;
            this.optUseRef.Text = "Reference Survey";
            this.optUseRef.UseVisualStyleBackColor = true;
            // 
            // optUseMain
            // 
            this.optUseMain.AutoSize = true;
            this.optUseMain.Checked = true;
            this.optUseMain.Location = new System.Drawing.Point(81, 133);
            this.optUseMain.Name = "optUseMain";
            this.optUseMain.Size = new System.Drawing.Size(84, 17);
            this.optUseMain.TabIndex = 24;
            this.optUseMain.TabStop = true;
            this.optUseMain.Text = "Main Survey";
            this.optUseMain.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Include language from ";
            // 
            // TranslatorTemplateOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(193, 207);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.optUseMain);
            this.Controls.Add(this.optUseRef);
            this.Controls.Add(this.dtpBackup);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboRefSurv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboLang);
            this.Controls.Add(this.cmdOK);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TranslatorTemplateOptions";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.DateTimePicker dtpBackup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboRefSurv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLang;
        private System.Windows.Forms.RadioButton optUseRef;
        private System.Windows.Forms.RadioButton optUseMain;
        private System.Windows.Forms.Label label4;
    }
}