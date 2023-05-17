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
    public partial class TranslatorTemplateOptions : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public SurveyBasedReport SR { get; set; }
        public ReportSurvey ReferenceSurvey { get; set; }
        public Language PrimaryLanguage { get; set; }
        public bool UseMain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public TranslatorTemplateOptions(SurveyBasedReport sr)
        {
            
            InitializeComponent();

            SR = sr;

            LoadTranslatorTemplateInfo();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (cboLang.SelectedItem != null)
                PrimaryLanguage = (Language)cboLang.SelectedItem;

            if (cboRefSurv.SelectedItem != null)         
                ReferenceSurvey = new ReportSurvey((Survey)cboRefSurv.SelectedItem); 

            ReferenceSurvey.Backend = dtpBackup.Value;
            
            UseMain = optUseMain.Checked;

            Close();
        }

        private void LoadTranslatorTemplateInfo()
        {
            cboRefSurv.ValueMember = "SID";
            cboRefSurv.DisplayMember = "SurveyCode";
            cboRefSurv.DataSource = new List<Survey>(Globals.FullSurveyList);
            // determine previous wave
            if (SR.Surveys.Count != 1)
                return;
            var current = SR.Surveys[0];
            double targetWave;
            if (current.Wave % 1 == 0)
                targetWave = current.Wave - 1;
            else
                targetWave = Math.Floor(current.Wave);

            var lastWave = Globals.FullSurveyList.Where(x => x.SurveyCodePrefix.Equals(SR.Surveys[0].SurveyCodePrefix) && x.Wave == targetWave).FirstOrDefault();
            if (lastWave != null)
                cboRefSurv.SelectedItem = lastWave;
            else
                cboRefSurv.SelectedItem = null;

            cboLang.ValueMember = "ID";
            cboLang.DisplayMember = "LanguageName";
            if (current.LanguageList.Count == 0)
                cboLang.DataSource = DBAction.ListLanguages();
            else
                cboLang.DataSource = current.LanguageList.Select(x => x.SurvLanguage).ToList();

        }
    }
}
