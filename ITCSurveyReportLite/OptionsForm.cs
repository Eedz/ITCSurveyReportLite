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
            rbInsertQnum.Checked = SR.QNInsertion;
            rbInsertAQN.Checked = SR.AQNInsertion;
            chkInsertCC.Checked = SR.CCInsertion;
            chkInlineRouting.Checked = SR.InlineRouting;
            rbEnglishSubsetTables.Checked = SR.SubsetTables;
            rbTranslationSubsetTables.Checked = SR.SubsetTablesTranslation;
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

            chkBlankColumn.Checked = SR.LayoutOptions.BlankColumn;
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
            SR.SubsetTables = rbEnglishSubsetTables.Checked;
            SR.SubsetTablesTranslation = rbTranslationSubsetTables.Checked;
            SR.SemiTel = chkSemiTelephone.Checked;

            if (rbNRNormal.Checked)
                SR.NrFormat = ReadOutOptions.Neither;
            else if (rbNRDR.Checked)
                SR.NrFormat = ReadOutOptions.DontRead;
            else if (rbNRDRO.Checked)
                SR.NrFormat = ReadOutOptions.DontReadOut;

            SR.LayoutOptions.BlankColumn = chkBlankColumn.Checked;
            SR.SurvNotes = chkSurveyNotes.Checked;
            SR.VarChangesCol = chkVarChangesColumn.Checked;
            SR.VarChangesApp = chkVarChangesAppendix.Checked;
            SR.ExcludeTempChanges = chkExcludeHiddenChanges.Checked;
            Close();
        }

        private void chkInsertQnums_Click(object sender, EventArgs e)
        {
            panelInsertQnums.Enabled = chkInsertQnums.Checked;
            if (!chkInsertQnums.Checked)
            {
                rbInsertQnum.Checked = false;
                rbInsertAQN.Checked = false;
            }else
            {
                rbInsertQnum.Checked = true;
            }

        }

        private void chkSubsetTables_Click(object sender, EventArgs e)
        {
            panelSubsetTables.Enabled = chkSubsetTables.Checked;
            if (!chkSubsetTables.Checked)
            {
                rbEnglishSubsetTables.Checked = false;
                rbTranslationSubsetTables.Checked = false;
            }
            else
            {
                rbEnglishSubsetTables.Checked = true;
            }
        }


    }
}
