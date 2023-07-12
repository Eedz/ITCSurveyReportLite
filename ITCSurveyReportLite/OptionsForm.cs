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

namespace ITCSurveyReportLite
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OptionsForm : Form
    {
        SurveyBasedReport SR;
        
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

            chkSubsetTables.Checked = SR.SubsetTables || SR.SubsetTablesTranslation;
            rbEnglishSubsetTables.Checked = SR.SubsetTables;
            rbTranslationSubsetTables.Checked = SR.SubsetTablesTranslation;

            ToggleSubsetTableOptions();

            chkSemiTelephone.Checked = SR.SemiTel;

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

            switch (SR.Numbering)
            {
                case Enumeration.Qnum:
                    optQnum.Checked = true; break;
                case Enumeration.AltQnum:
                    optAltQnum.Checked = true;
                    break;
                case Enumeration.Both:
                    optBothQnums.Checked = true; break;
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

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SR.ShowLongLists = chkLongLists.Checked;
            SR.QNInsertion = rbInsertQnum.Checked;
            SR.AQNInsertion = rbInsertAQN.Checked;
            SR.CCInsertion = chkInsertCC.Checked;
            SR.InlineRouting = chkInlineRouting.Checked;
            SR.SubsetTables = rbEnglishSubsetTables.Checked || rbTranslationSubsetTables.Checked;
            SR.SubsetTablesTranslation = rbTranslationSubsetTables.Checked;
            SR.SemiTel = chkSemiTelephone.Checked;

            if (rbNRNormal.Checked)
                SR.NrFormat = ReadOutOptions.Neither;
            else if (rbNRDR.Checked)
                SR.NrFormat = ReadOutOptions.DontRead;
            else if (rbNRDRO.Checked)
                SR.NrFormat = ReadOutOptions.DontReadOut;

            if (optQnum.Checked)
                SR.Numbering = Enumeration.Qnum;
            else if (optAltQnum.Checked)
                SR.Numbering = Enumeration.AltQnum;
            else if (optBothQnums.Checked)
                SR.Numbering = Enumeration.Both;


            SR.LayoutOptions.BlankColumn = chkBlankColumn.Checked;
            SR.IncludeImages = chkIncludeImages.Checked;
            SR.ImageAppendix = chkImageAppendix.Checked;
            SR.SurvNotes = chkSurveyNotes.Checked;
            SR.VarChangesCol = chkVarChangesColumn.Checked;
            SR.VarChangesApp = chkVarChangesAppendix.Checked;
            SR.ExcludeTempChanges = chkExcludeHiddenChanges.Checked;
            Close();
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

        private void chkSubsetTables_Click(object sender, EventArgs e)
        {
            ToggleSubsetTableOptions();
        }

        private void ToggleSubsetTableOptions()
        {
            panelSubsetTables.Enabled = chkSubsetTables.Checked;
            if (!chkSubsetTables.Checked)
            {
                rbEnglishSubsetTables.Checked = false;
                rbTranslationSubsetTables.Checked = false;
            }
            else
            {
                // if neither are true, set the default
                if (!SR.SubsetTables && !SR.SubsetTablesTranslation)
                    rbEnglishSubsetTables.Checked = true;
            }
        }

    }
}
