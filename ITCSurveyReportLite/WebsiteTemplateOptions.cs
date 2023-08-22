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
    public partial class WebsiteTemplateOptions : Form
    {
        public bool IncludeEnglish;
        public string Language;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="survey"></param>
        public WebsiteTemplateOptions(Survey survey)
        {
            InitializeComponent();

            chkIncludeEnglish.Checked = true;

            cboLanguage.ValueMember = "ID";
            cboLanguage.DisplayMember = "LanguageName";
            var languages = survey.LanguageList.Select(x => x.SurvLanguage).ToList();
            var english = languages.Where(x => x.LanguageName.Equals("English")).FirstOrDefault();
            if (english!=null)
                languages.Remove(english);

            cboLanguage.DataSource = languages;
            cboLanguage.SelectedItem = null;
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            IncludeEnglish = chkIncludeEnglish.Checked;

            if (cboLanguage.SelectedItem != null)
                Language = ((Language)cboLanguage.SelectedItem).LanguageName;

            Close();
            DialogResult = DialogResult.OK;
        }

        private void chkIncludeTranslation_CheckedChanged(object sender, EventArgs e)
        {
            cboLanguage.Enabled = chkIncludeTranslation.Checked;

            if (!chkIncludeTranslation.Checked )
            {
                cboLanguage.SelectedItem = null;
            }
        }
    }
}
