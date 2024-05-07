using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITCLib;
using ITCReportLib;

namespace ITCSurveyReportLite
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OptionsForm : Form
    {
        SurveyBasedReport SR;
        IReport Report;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sr"></param>
        public OptionsForm(SurveyBasedReport sr)
        {
            InitializeComponent();
            SR = sr;

            chkLongLists.Checked = SR.ShowLongLists;

            chkInsertQnums.Checked = SR.QNInsertion || SR.AQNInsertion;
            rbInsertQnum.Checked = SR.QNInsertion;
            rbInsertAQN.Checked = SR.AQNInsertion;

            ToggleQnumInsertionOptions();

            chkInsertCC.Checked = SR.CCInsertion;
            chkInlineRouting.Checked = SR.InlineRouting;

            switch (SR.NrFormat)
            {
                case ReadOutOptions.Neither:
                    rbNRNormal.Checked = true;
                    break;
                case ReadOutOptions.DontRead:
                    rbNRDR.Checked = true;
                    break;
                case ReadOutOptions.DontReadOut:
                    rbNRDRO.Checked = true;
                    break;
            }

            chkBlankColumn.Checked = SR.LayoutOptions.BlankColumn;
            chkIncludeImages.Checked = SR.IncludeImages;
            chkImageAppendix.Checked = SR.ImageAppendix;
            chkSurveyNotes.Checked = SR.SurvNotes;
            chkVarChangesColumn.Checked = SR.VarChangesCol;
            chkVarChangesAppendix.Checked = SR.VarChangesApp;
            chkExcludeHiddenChanges.Checked = SR.ExcludeTempChanges;

            if (sr.Surveys.Count > 1 || !sr.HasF2F())
            {
                chkInlineRouting.Enabled = false;
                chkInlineRouting.Checked = false;
            }
            else
            {
                chkInlineRouting.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="report"></param>
        public OptionsForm(IReport report)
        {
            InitializeComponent();
            Report = report;

            chkLongLists.Checked = Report.Options.FormattingOptions.ShowLongLists;

            chkInsertQnums.Checked = Report.Options.FormattingOptions.QNInsertion != QnumInsertion.Neither;
            rbInsertQnum.Checked = Report.Options.FormattingOptions.QNInsertion == QnumInsertion.QN;
            rbInsertAQN.Checked = Report.Options.FormattingOptions.QNInsertion == QnumInsertion.AQN;

            ToggleQnumInsertionOptions();

            chkInsertCC.Checked = Report.Options.FormattingOptions.CCInsertion;
            chkInlineRouting.Checked = Report.Options.FormattingOptions.InlineRouting;

            switch (Report.Options.FormattingOptions.NrFormat)
            {
                case ReadOutOptions.Neither:
                    rbNRNormal.Checked = true;
                    break;
                case ReadOutOptions.DontRead:
                    rbNRDR.Checked = true;
                    break;
                case ReadOutOptions.DontReadOut:
                    rbNRDRO.Checked = true;
                    break;
            }

            chkBlankColumn.Checked = Report.BlankColumn;
            //chkIncludeImages.Checked = Report.IncludeImages;
            chkImageAppendix.Checked = Report.Appendices.Contains("Images");
            chkSurveyNotes.Checked = Report.Appendices.Contains("Notes");
            chkVarChangesColumn.Checked = Report.Options.FormattingOptions.VarChangesCol;
            chkVarChangesAppendix.Checked = Report.Appendices.Contains("Renames");
            chkExcludeHiddenChanges.Checked = Report.Options.FormattingOptions.ExcludeTempChanges;

            if (Report.Surveys.Count > 1 || !Report.Surveys.Any(x=>x.Mode.ModeAbbrev.Equals("F2F")))
            {
                chkInlineRouting.Enabled = false;
                chkInlineRouting.Checked = false;
            }
            else
            {
                chkInlineRouting.Enabled = true;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //SaveReportOptions();
            SaveSROptions();
            Close();
        }

        private void SaveReportOptions()
        {
            Report.Options.FormattingOptions.ShowLongLists = chkLongLists.Checked;
            if (rbInsertQnum.Checked)
            {
                Report.Options.FormattingOptions.QNInsertion = QnumInsertion.QN;
            }else if (rbInsertAQN.Checked)
            {
                Report.Options.FormattingOptions.QNInsertion = QnumInsertion.AQN;
            }
            else
            {
                Report.Options.FormattingOptions.QNInsertion = QnumInsertion.Neither;
            }
            
            Report.Options.FormattingOptions.CCInsertion = chkInsertCC.Checked;
            Report.Options.FormattingOptions.InlineRouting = chkInlineRouting.Checked;
            
            if (rbNRNormal.Checked)
                Report.Options.FormattingOptions.NrFormat = ReadOutOptions.Neither;
            else if (rbNRDR.Checked)
                Report.Options.FormattingOptions.NrFormat = ReadOutOptions.DontRead;
            else if (rbNRDRO.Checked)
                Report.Options.FormattingOptions.NrFormat = ReadOutOptions.DontReadOut;

            Report.BlankColumn = chkBlankColumn.Checked;
            //Report.IncludeImages = chkIncludeImages.Checked;

            if (chkImageAppendix.Checked && !Report.Appendices.Contains("Images"))
                Report.Appendices.Add("Images");

            if (chkSurveyNotes.Checked && !Report.Appendices.Contains("Notes"))
                Report.Appendices.Add("Notes");

            Report.Options.FormattingOptions.VarChangesCol = chkVarChangesColumn.Checked;


            if (chkVarChangesAppendix.Checked && !Report.Appendices.Contains("Renames"))
                Report.Appendices.Add("Renames");

            Report.Options.FormattingOptions.ExcludeTempChanges = chkExcludeHiddenChanges.Checked;
        }

        private void SaveSROptions()
        {
            SR.ShowLongLists = chkLongLists.Checked;
            SR.QNInsertion = rbInsertQnum.Checked;
            SR.AQNInsertion = rbInsertAQN.Checked;
            SR.CCInsertion = chkInsertCC.Checked;
            SR.InlineRouting = chkInlineRouting.Checked;
            
            if (rbNRNormal.Checked)
                SR.NrFormat = ReadOutOptions.Neither;
            else if (rbNRDR.Checked)
                SR.NrFormat = ReadOutOptions.DontRead;
            else if (rbNRDRO.Checked)
                SR.NrFormat = ReadOutOptions.DontReadOut;

            SR.LayoutOptions.BlankColumn = chkBlankColumn.Checked;
            SR.IncludeImages = chkIncludeImages.Checked;
            SR.ImageAppendix = chkImageAppendix.Checked;
            SR.SurvNotes = chkSurveyNotes.Checked;
            SR.VarChangesCol = chkVarChangesColumn.Checked;
            SR.VarChangesApp = chkVarChangesAppendix.Checked;
            SR.ExcludeTempChanges = chkExcludeHiddenChanges.Checked;
        }


        private void chkInsertQnums_Click(object sender, EventArgs e)
        {
            ToggleQnumInsertionOptions();
        }

        private void ToggleQnumInsertionOptions()
        {
            panelInsertQnums.Enabled = chkInsertQnums.Checked;
            if (!chkInsertQnums.Checked)
            {
                rbInsertQnum.Checked = false;
                rbInsertAQN.Checked = false;
            }
            else
            {
                // if neither are true, set the default
                if (!SR.QNInsertion && !SR.AQNInsertion)
                    rbInsertQnum.Checked = true;
            }
        }
    }
}
