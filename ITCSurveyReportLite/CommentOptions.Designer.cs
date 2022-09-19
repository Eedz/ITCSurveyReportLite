namespace ITCSurveyReportLite
{
    partial class CommentOptions
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
            this.lstType = new System.Windows.Forms.ListBox();
            this.lstAuthor = new System.Windows.Forms.ListBox();
            this.lstAuthority = new System.Windows.Forms.ListBox();
            this.dtpCommentsSince = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCommentFilter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstType
            // 
            this.lstType.FormattingEnabled = true;
            this.lstType.ItemHeight = 16;
            this.lstType.Location = new System.Drawing.Point(12, 32);
            this.lstType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstType.Name = "lstType";
            this.lstType.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstType.Size = new System.Drawing.Size(139, 244);
            this.lstType.TabIndex = 0;
            // 
            // lstAuthor
            // 
            this.lstAuthor.FormattingEnabled = true;
            this.lstAuthor.ItemHeight = 16;
            this.lstAuthor.Location = new System.Drawing.Point(168, 32);
            this.lstAuthor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstAuthor.Name = "lstAuthor";
            this.lstAuthor.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAuthor.Size = new System.Drawing.Size(139, 244);
            this.lstAuthor.TabIndex = 1;
            // 
            // lstAuthority
            // 
            this.lstAuthority.FormattingEnabled = true;
            this.lstAuthority.ItemHeight = 16;
            this.lstAuthority.Location = new System.Drawing.Point(329, 32);
            this.lstAuthority.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstAuthority.Name = "lstAuthority";
            this.lstAuthority.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstAuthority.Size = new System.Drawing.Size(139, 244);
            this.lstAuthority.TabIndex = 2;
            // 
            // dtpCommentsSince
            // 
            this.dtpCommentsSince.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpCommentsSince.Location = new System.Drawing.Point(12, 323);
            this.dtpCommentsSince.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpCommentsSince.Name = "dtpCommentsSince";
            this.dtpCommentsSince.Size = new System.Drawing.Size(139, 23);
            this.dtpCommentsSince.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(216, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Author";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(371, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Authority";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 303);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Comments since...";
            // 
            // txtCommentFilter
            // 
            this.txtCommentFilter.Location = new System.Drawing.Point(168, 323);
            this.txtCommentFilter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCommentFilter.Multiline = true;
            this.txtCommentFilter.Name = "txtCommentFilter";
            this.txtCommentFilter.Size = new System.Drawing.Size(300, 63);
            this.txtCommentFilter.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Contains text...";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(275, 409);
            this.cmdOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(87, 28);
            this.cmdOK.TabIndex = 10;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(381, 409);
            this.cmdCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 28);
            this.cmdCancel.TabIndex = 11;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(11, 396);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(450, 2);
            this.label6.TabIndex = 12;
            this.label6.Text = "label6";
            // 
            // CommentOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 449);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCommentFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpCommentsSince);
            this.Controls.Add(this.lstAuthority);
            this.Controls.Add(this.lstAuthor);
            this.Controls.Add(this.lstType);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CommentOptions";
            this.Text = "Comment Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstType;
        private System.Windows.Forms.ListBox lstAuthor;
        private System.Windows.Forms.ListBox lstAuthority;
        private System.Windows.Forms.DateTimePicker dtpCommentsSince;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCommentFilter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label6;
    }
}