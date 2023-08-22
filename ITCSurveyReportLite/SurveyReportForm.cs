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
    /// User interface for generating a Survey-based report.
    /// </summary>
    public partial class SurveyReportForm : Form
    {
        SurveyBasedReport SR;
        // this report survey is just to hold the question filter selections. Just before the report is run, the filters will be copied to each report survey object in the report's list.
        ReportSurvey questionFilters;

        Comparison compare;
        
        UserPrefs UP;
        ReportSurvey CurrentSurvey;
        TabPage pgCompareTab;
        ReportTemplate CurrentTemplate;

        ReportSurvey TranslatorReference;


        //BindingSource ReportBindingSource;

        // background color RGB values
        //int backColorR = 55;
        //int backColorG = 170;
        //int backColorB = 136;

        /// <summary>
        /// 
        /// </summary>
        public SurveyReportForm()
        {
            InitializeComponent();

            Globals.CreateWorld();

            // add arrow symbol to add/remove buttons
            cmdAddSurvey.Text = char.ConvertFromUtf32(0x2192);
            cmdRemoveSurvey.Text = char.ConvertFromUtf32(0x2190);

            // fill the survey drop down
            cboSurveys.ValueMember = "SID";
            cboSurveys.DisplayMember = "SurveyCode";
            cboSurveys.DataSource = new List<Survey>(Globals.FullSurveyList);

            // add tooltips for the quick reports
            // toolTipStandard.SetToolTip(this.optStd, standardToolTipText);
            toolTipStandard.ShowAlways = true;
            toolTipStandard.AutomaticDelay = 0;
            toolTipStandard.AutoPopDelay = 30000;

            // hide the comparison tab until it is needed
            pgCompareTab = pgCompare;
            tabControlOptions.TabPages.Remove(pgCompare);

            // start with blank constructor, default settings
            NewReport(new List<ReportSurvey>());

            UP = new UserPrefs();
            questionFilters = new ReportSurvey();

            // bind the controls of the form to the SR object
            surveyReportBindingSource.DataSource = SR;

            compareBindingSource.DataSource = compare;

            reportLayoutBindingSource.DataSource = SR.LayoutOptions;

            optNoTemplate.Checked = true;

            // bind selected surveys to the list of surveys in SR
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";
            lstSelectedSurveys.DataSource = SR.Surveys;

            lblStatus.Visible = false;
            lblStatus.Text = "Ready.";
            cmdOpenReportFolder.Visible = false;
            cmdGenerate.Visible = false;

        }

        /// <summary>
        /// After the form is created, perform some initial setup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyReportForm_Load(object sender, EventArgs e)
        {

        }


        private void BindControls()
        {
            // done with designer
        }

        #region Menu Strip

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewReport(new List<ReportSurvey>());
            optNoTemplate.Checked = true;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Report Templates
        private void ReportTemplate_CheckChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            string tag = rb.Tag.ToString();
            if (rb.Checked)
            {
                chkStdTranslation.Enabled = false;
                cmdOpenWebsiteOptions.Enabled = false;
                cmdOpenTranslatorOptions.Enabled = false;
                
                switch (tag)
                {
                    case "Std":
                        NewReport(SR.Surveys.ToList());
                        CurrentTemplate = ReportTemplate.Standard;
                        chkStdTranslation.Enabled = true;
                        break;
                    case "Web":
                        NewReport(SR.Surveys.ToList().FirstOrDefault() ?? new ReportSurvey() );
                        CurrentTemplate = ReportTemplate.Website;
                        cmdOpenWebsiteOptions.Enabled = true;
                           break;
                    case "Translator":
                        NewReport(SR.Surveys.ToList().FirstOrDefault() ?? new ReportSurvey());
                        CurrentTemplate = ReportTemplate.Translator;
                        cmdOpenTranslatorOptions.Enabled = true;
                        break;
                    case "Custom":
                        NewReport(SR.Surveys.ToList());
                        CurrentTemplate = ReportTemplate.Custom;
                        break;
                }

                cmdSelfCompare.Enabled = tag.Equals("Custom");

                foreach (TabPage p in tabControlOptions.TabPages)
                    p.Enabled = CurrentTemplate == ReportTemplate.Custom;
            }
        }

        private void cmdOpenWebsiteOptions_Click(object sender, EventArgs e)
        {
            if (SR.Surveys.Count == 0)
            {
                MessageBox.Show("Choose a survey first.");
            }

            WebsiteTemplateOptions frm = new WebsiteTemplateOptions(SR.Surveys[0]);
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(MousePosition.X, MousePosition.Y);

            frm.ShowDialog();

            if (!string.IsNullOrEmpty(frm.Language))
            {
                SR.Surveys[0].TransFields.Add(frm.Language);
                SR.Surveys[0].ShowQuestion = frm.IncludeEnglish;
                SR.ShowQuestion = frm.IncludeEnglish;
            }
        }

        private void cmdOpenTranslatorOptions_Click(object sender, EventArgs e)
        {
            TranslatorTemplateOptions frm = new TranslatorTemplateOptions(SR);
            frm.StartPosition = FormStartPosition.Manual;
            frm.Location = new Point(MousePosition.X, MousePosition.Y); 
           
            frm.ShowDialog();

            TranslatorReference = frm.ReferenceSurvey;

            if (TranslatorReference != null)
            {
                SR.AddSurvey(TranslatorReference);
            }

            bool useMain = frm.UseMain;
            Language language = frm.PrimaryLanguage;
            if (language != null)
            {
                if (useMain)
                {
                    SR.QnumSurvey().TransFields.Add(language.LanguageName);
                }else
                {
                    SR.PrimarySurvey().TransFields.Add(language.LanguageName);
                }
            }
            else
                SR.PrimarySurvey().TransFields = DBAction.ListLanguages(SR.QnumSurvey()).Select(x=>x.LanguageName).ToList();
        }

        private void RunSurveyReport()
        {
            int result;

            // get the survey data for all chosen surveys
            PopulateSurveys();

            SurveyReport survReport = new SurveyReport(SR)
            {
                SurveyCompare = compare
            };

            if (SR.Surveys.Count == 1 && (SR.IncludeImages || SR.ImageAppendix))
                survReport.Images = DBAction.GetSurveyImagesFromFolder(SR.Surveys[0]);

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", survReport, "ReportStatus"));

            result = survReport.GenerateReport();
            switch (result)
            {
                case 1:
                    MessageBox.Show("One or more surveys contain no records.");
                    // TODO if a backup was chosen, show a form for selecting a different survey code from that date
                    break;
                default:
                    break;
            }


            // output report to Word/PDF
            survReport.OutputReportTableXML();

        }

        private void RunStandardReport(bool withTranslation = false)
        {
            string mode;
            bool englishRouting;

            mode = SR.Surveys[0].Mode.ModeAbbrev;
            if (SR.Surveys.Count == 1)
            {

                englishRouting = SR.Surveys[0].EnglishRouting;

                SR.Surveys[0].Qnum = true;
            }
            else
            {

                int primeID = 0;
                if (SR.Surveys.Count >= 3)
                    primeID = 1;
                else
                    primeID = 2;

                SR.SetPrimary(primeID);

                SR.Surveys[0].Qnum = true;

                SR.CompareWordings = true;
                compare.ShowDeletedQuestions = true;
                compare.ShowDeletedFields = true;
                compare.ReInsertDeletions = true;
                compare.Highlight = true;

            }

            if (withTranslation)
            {
                foreach (ReportSurvey rs in SR.Surveys)
                {
                    List<string> langs = DBAction.ListLanguages(rs).Select(x => x.LanguageName).ToList();
                    langs.Remove("English");
                    rs.TransFields = langs;
                }
            }

            switch (mode)
            {
                case "F2F":
                case "mail":
                case "semi-tel":
                    SR.QNInsertion = true;
                    SR.NrFormat = ReadOutOptions.DontReadOut;
                    break;
                case "CATI":
                case "web":
                case "tel":
                case "CAPI":
                    SR.QNInsertion = false;
                    SR.NrFormat = ReadOutOptions.Neither;
                    break;
            }

            SR.LayoutOptions.BlankColumn = true;
            SR.VarChangesCol = true;
            SR.ExcludeTempChanges = true;
            SR.Details = "";

            // get the survey data for all chosen surveys
            PopulateSurveys();

            int result;
            SurveyReport survReport = new SurveyReport(SR)
            {
                SurveyCompare = compare
            };

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", survReport, "ReportStatus"));

            result = survReport.GenerateReport();
            switch (result)
            {
                case 1:
                    MessageBox.Show("One or more surveys contain no records.");
                    // TODO if a backup was chosen, show a form for selecting a different survey code from that date
                    break;
                default:
                    break;
            }


            // output report to Word/PDF
            survReport.OutputReportTableXML();
        }

        private void RunWebReport()
        {
            ReportSurvey survey = SR.Surveys[0];

            PopulateWebsiteReport(survey);

            WebsiteSurveyReport report = new WebsiteSurveyReport(survey);
            report.Images = DBAction.GetSurveyImagesFromFolder(SR.Surveys[0]);

            report.UpdateColumnOrder();

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", report, "ReportStatus"));

            try
            {
                report.CreateReport();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error generating this report. " + e.Message);
            }
        }

        /// <summary>
        /// Populates a ReportSurvey object populated with the data for a website survey. All questions with previous names and, optionally a translation.
        /// </summary>
        /// <param name="survey"></param>
        /// <returns></returns>
        private void PopulateWebsiteReport(ReportSurvey survey)
        {
            survey.Questions.Clear();
            survey.AddQuestions(DBAction.GetSurveyQuestions(survey));

            // previous VarNames
            DBAction.FillPreviousNames(survey, true);

            foreach (string language in survey.TransFields)
                if (!language.Equals("English"))
                {
                    var translations = DBAction.GetSurveyTranslation(survey.SurveyCode, language);

                    foreach (Translation t in translations)
                        survey.QuestionByID(t.QID).Translations.Add(t);
                }

            survey.VarChanges = new List<VarNameChange>(DBAction.GetVarNameChanges(survey).Where(x => !x.PreFWChange));

            survey.LastUpdate = DBAction.GetSurveyLastUpdate(survey);
        }

        private void RunTranslatorReport()
        {
            TranslatorReport report = new TranslatorReport(SR.Surveys.ToList());

            report.UpdateColumnOrder();

            // get the survey data for all chosen surveys
            PopulateTranslatorSurveys();

            report.SurveyCompare = compare;

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", report, "ReportStatus"));

            try
            {
                report.CreateReport();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error generating this report. " + e.Message);
            }
        }

        /// <summary>
        /// For each survey in the report, fill the question list and translations as needed.
        /// </summary>
        private void PopulateTranslatorSurveys()
        {
            // populate the survey and extra fields
            foreach (ReportSurvey rs in SR.Surveys)
            {
                rs.Questions.Clear();
                rs.SurveyNotes.Clear();
                rs.VarChanges.Clear();

                // questions
                if (rs.Backend.Date != DateTime.Today)
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetBackupQuestions(rs, rs.Backend)));
                else
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetSurveyQuestions(rs)));

                if (SR.Surveys.Count > 1 && compare.MatchOnRename && rs.Backend.Date != DateTime.Today)
                {
                    foreach (SurveyQuestion sq in rs.Questions)
                    {
                        sq.VarName.VarName = DBAction.GetCurrentName(rs.SurveyCode, sq.VarName.VarName, rs.Backend);
                    }
                }

                // translations
                if (rs.Backend.Date != DateTime.Today)
                    DBAction.FillBackupTranslation(rs, rs.Backend.Date, rs.TransFields);
                else
                {
                    foreach (string language in rs.TransFields)
                    {
                        var translations = DBAction.GetSurveyTranslation(rs.SurveyCode, language);

                        foreach (Translation t in translations)
                            rs.QuestionByID(t.QID).Translations.Add(t);
                    }
                }

                rs.LastUpdate = DBAction.GetSurveyLastUpdate(rs);
            }
        }

        #endregion 

        private void cmdQuickGenerate_Click(object sender, EventArgs e)
        {
            surveyReportBindingSource.EndEdit();

            if (lstSelectedSurveys.SelectedItems.Count == 0)
            {
                MessageBox.Show("No surveys selected.");
                return;
            }

            if (SR.Surveys.Any(x=>x.TransFields.Count==0) && SR.SubsetTablesTranslation)
            {
                MessageBox.Show("You have selected Translation Subset Tables but no translation language was selected.");
                return;
            }

            UpdateColumnOrder();
            // set file name to the user's report path
            SR.FileName = UP.ReportPath;

            if (optStdTemplate.Checked)
            {
                RunStandardReport(chkStdTranslation.Checked);

            }
            else if (optWebTemplate.Checked)
            {
                RunWebReport();

                if (SR.Surveys.Count > 1)
                {
                    MessageBox.Show("All selected surveys have been generated. They can be found in the Reports folder under ISR.");
                }
            }
            else if (optTranslator.Checked)
            {
                if (SR.Surveys.Count>2)
                {
                    MessageBox.Show("Translator template requires 1 or 2 surveys.");
                    return;
                }
                RunTranslatorReport();
            }
            else if (optNoTemplate.Checked)
            {
                RunSurveyReport();
            }
            else
            {
                // no option checked
                MessageBox.Show("Error: unknown selection.");
            }

            GC.Collect();
        }

        private void cmdOpenReportFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports\ISR");
        }

        /// <summary>
        /// For each survey in the report, fill the question list, comments and translations as needed.
        /// </summary>
        private void PopulateSurveys()
        {
            // populate the survey and extra fields
            foreach (ReportSurvey rs in SR.Surveys)
            {
                rs.Questions.Clear();
                rs.SurveyNotes.Clear();
                rs.VarChanges.Clear();


                // questions
                if (rs.Backend.Date != DateTime.Today)
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetBackupQuestions(rs, rs.Backend)));
                else
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetSurveyQuestions(rs)));

                List<QuestionTimeFrame> timeframes = DBAction.GetTimeFrames(rs.SurveyCode);
                foreach (SurveyQuestion question in rs.Questions)
                {
                    question.TimeFrames = timeframes.Where(x => x.QID == question.ID).ToList();
                }

                // correct questions // TODO should we only get corrected for current data?
                if (rs.Corrected)
                {
                    rs.CorrectedQuestions = DBAction.GetCorrectedWordings(rs);
                    rs.CorrectWordings();
                }

                // previous names (for Var column)
                DBAction.FillPreviousNames(rs, SR.ExcludeTempChanges);

                if (SR.Surveys.Count> 1 && compare.MatchOnRename && rs.Backend.Date != DateTime.Today)
                {
                    foreach (SurveyQuestion sq in rs.Questions)
                    {
                        sq.VarName.VarName = DBAction.GetCurrentName(rs.SurveyCode, sq.VarName.VarName, rs.Backend);
                    }

                }

                // survey notes
                if (SR.SurvNotes)
                    rs.SurveyNotes = DBAction.GetSurvComments(rs);

                // comments
                if (rs.CommentFields.Count > 0)
                {
                    DBAction.FillCommentsBySurvey(rs);
                }

                // translations
                if (rs.Backend.Date != DateTime.Today)
                    DBAction.FillBackupTranslation(rs, rs.Backend.Date, rs.TransFields);
                else
                {
                    foreach (string language in rs.TransFields)
                    {
                        var translations = DBAction.GetSurveyTranslation(rs.SurveyCode, language);

                        foreach (Translation t in translations)
                            rs.QuestionByID(t.QID).Translations.Add(t);
                    }
                }
                        

                // filters
                if (rs.FilterCol)
                    rs.MakeFilterList();

                // varchanges (for appendix)
                if (SR.VarChangesApp)
                    rs.VarChanges = new List<VarNameChange> (DBAction.GetVarNameChanges(rs).Where(x=>x.PreFWChange != SR.ExcludeTempChanges));

                rs.LastUpdate = DBAction.GetSurveyLastUpdate(rs);
            }
        }

        private void UpdateColumnOrder()
        {
            SR.UpdateColumnOrder();
        }

        #region Top of Form (Add and Remove surveys, quick reports)
        private void AddSurvey_Click(object sender, EventArgs e)
        {
            // add survey to the SurveyReport object
            ReportSurvey s;
            try
            {
                s = new ReportSurvey((Survey)cboSurveys.SelectedItem);
            }
            catch (Exception)
            {
                MessageBox.Show("Survey not found.");
                return;
            }

            if (cboSurveys.SelectedIndex < cboSurveys.Items.Count - 1)
                cboSurveys.SelectedIndex++;

            AddSurvey(s);
        }

        private void SelfCompare_Click(object sender, EventArgs e)
        {
            // add another survey with the already selected survey code
            if (lstSelectedSurveys.SelectedItem == null) return;
            ReportSurvey s;
            Survey item = lstSelectedSurveys.SelectedItem as Survey;
            try
            {

                s = new ReportSurvey(item);

                BackupConnection bkp = new BackupConnection(DateTime.Today.AddDays(-1));
                s.Backend = bkp.GetNextBackup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            AddSurvey(s);

            // select the added survey and set focus to calendar
            lstSelectedSurveys.SelectedIndex = lstSelectedSurveys.Items.Count - 1;
            dateBackend.Focus();

        }

        /// <summary>
        /// Add a survey to the report.
        /// </summary>
        /// <param name="s">ReportSurvey object being added to the report.</param>
        private void AddSurvey(ReportSurvey s)
        {
            if (SR.HasSurvey(s))
            {
                BackupConnection bkp = new BackupConnection(s.Backend);
                s.Backend = bkp.GetNearestBackup();
            }

            SR.AddSurvey(s);

            UpdateReportColumns(null, null);
            UpdateGrids();

            // show the options tabs if at least one survey is chosen
            if (lstSelectedSurveys.Items.Count > 0)
            {
                lblStatus.Visible = true;
                cmdOpenReportFolder.Visible = true;
                cmdGenerate.Visible = true;
                //tabControlOptions.Enabled = CurrentTemplate == ReportTemplate.Custom;
                groupTemplate.Enabled = true;
                foreach (TabPage p in tabControlOptions.TabPages)
                    p.Enabled = CurrentTemplate == ReportTemplate.Custom;

                tabControlOptions.Visible = true;

            }

            // update report defaults
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();

            // load survey specific options
            LoadSurveyOptions();
        }

        private void RemoveSurvey_Click(object sender, EventArgs e)
        {
            RemoveSurvey((ReportSurvey)lstSelectedSurveys.SelectedItem);
        }

        /// <summary>
        /// Remove a survey from the report.
        /// </summary>
        /// <param name="s">ReportSurvey object being removed from the report.</param>
        private void RemoveSurvey(ReportSurvey s)
        {
            // remove survey from the SurveyReport object
            SR.RemoveSurvey((ReportSurvey)lstSelectedSurveys.SelectedItem);
            GC.Collect();

            UpdateReportColumns(null, null);
            UpdateGrids();

            // hide the options tabs no surveys are chosen
            if (lstSelectedSurveys.Items.Count < 1)
            {
                lblStatus.Visible = false;
                cmdOpenReportFolder.Visible = false;
                cmdGenerate.Visible = false;
                tabControlOptions.Visible = false;
                groupTemplate.Enabled = false;
            }

            // update report defaults
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();

            // load survey specific options
            LoadSurveyOptions();
        }

        /// <summary>
        /// Allow Enter/Return key to add the currently highlighted Survey in the combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Surveys_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
               // cboSurveys.DroppedDown = false;
               // cboSurveys.SelectedItem = null;
               cmdAddSurvey.PerformClick();
               cboSurveys.Focus();
            }
        }

        /// <summary>
        /// Set the CurrentSurvey object to the currently selected survey in the list box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedSurveys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSelectedSurveys.SelectedItem != null)
            {
                UpdateCurrentSurvey();
                LoadSurveyOptions();
            }
        }
        #endregion

        #region Current Survey "Load" Methods

        // bind each control to the selected survey's corresponding fields
        private void LoadSurveyOptions()
        {
            if (CurrentSurvey == null)
                return;

            // backend date
            dateBackend.DataBindings.Clear();
            dateBackend.DataBindings.Add("Value", CurrentSurvey, "Backend");

            // standard fields

            // extra fields
            lstExtraFields.ClearSelected();
            for (int i = 0; i < lstExtraFields.Items.Count; i++)
            {
                string item = lstExtraFields.Items[i].ToString();
                switch (item)
                {
                    case "Filters":
                        lstExtraFields.SetSelected(i, CurrentSurvey.FilterCol);
                        break;
                    case "Domain":
                        lstExtraFields.SetSelected(i, CurrentSurvey.DomainLabelCol);
                        break;
                    case "Topic":
                        lstExtraFields.SetSelected(i, CurrentSurvey.TopicLabelCol);
                        break;
                    case "Content":
                        lstExtraFields.SetSelected(i, CurrentSurvey.ContentLabelCol);
                        break;
                    case "VarLabel":
                        lstExtraFields.SetSelected(i, CurrentSurvey.VarLabelCol);
                        break;
                    case "Product":
                        lstExtraFields.SetSelected(i, CurrentSurvey.ProductLabelCol);
                        break;
                    case "AltQnum":
                        lstExtraFields.SetSelected(i, CurrentSurvey.AltQnumCol);
                        break;
                    case "AltQnum2":
                        lstExtraFields.SetSelected(i, CurrentSurvey.AltQnum2Col);
                        break;
                    case "AltQnum3":
                        lstExtraFields.SetSelected(i, CurrentSurvey.AltQnum3Col);
                        break;
                }
            }

            chkIncludeEnglish.DataBindings.Clear();
            chkIncludeEnglish.DataBindings.Add("Checked", CurrentSurvey, "ShowQuestion");

            // translations
            // list them
            LoadExtraFields(CurrentSurvey);
            // select translations
            foreach (object item in CurrentSurvey.TransFields)
            {
                for (int i = 0; i < lstTransFields.Items.Count; i++)
                    if (item.ToString().Equals(lstTransFields.Items[i].ToString()))
                        lstTransFields.SetSelected(i, true);
            }

            // select comments
            foreach (object item in CurrentSurvey.CommentFields)
            {
                for (int i = 0; i < lstCommentTypes.Items.Count; i++)
                    if (item.ToString().Equals(lstCommentTypes.Items[i].ToString()))
                        lstCommentTypes.SetSelected(i, true);
            }

            switch (CurrentSurvey.RoutingFormat)
            {
                case RoutingStyle.Normal:
                    optRoutingStyleNormal.Checked = true;
                    break;
                case RoutingStyle.Grey:
                    optRoutingStyleGrey.Checked = true;
                    break;
                case RoutingStyle.None:
                    optRoutingStyleNone.Checked = true;
                    break;
            }

            switch (CurrentSurvey.TranslationRoutingFormat)
            {
                case RoutingStyle.Normal:
                    optTRoutingStyleNormal.Checked = true;
                    break;
                case RoutingStyle.Grey:
                    optTRoutingStyleGrey.Checked = true;
                    break;
                case RoutingStyle.None:
                    optTRoutingStyleNone.Checked = true;
                    break;
            }

            chkEnglishRouting.DataBindings.Clear();
            chkEnglishRouting.DataBindings.Add("Checked", CurrentSurvey, "EnglishRouting");

        }

        private void LoadExtraFields(Survey survey)
        {
            // load translation languages
            List<string> langs = DBAction.ListLanguages(survey).Select(x => x.LanguageName).ToList();

            lstTransFields.Items.Clear();
            foreach (string s in langs)
                if (!s.Equals("English"))
                    lstTransFields.Items.Add(s);

            List<CommentType> commentTypes = DBAction.GetCommentTypes(survey);
            lstCommentTypes.DisplayMember = "TypeName";
            lstCommentTypes.ValueMember = "ID";
            lstCommentTypes.DataSource = commentTypes;
            lstCommentTypes.SelectedItem = null;
        }

        #endregion

        private void NewReport(List<ReportSurvey> surveys)
        {
            // reset report settings
            SR = new SurveyBasedReport(surveys);
            SR.LayoutOptions.ToC = TableOfContents.PageNums;

            compare = new Comparison()
            {
                SimilarWords = DBAction.GetSimilarWords() // populate the similar words list
            };

            // reset form controls
            chkStdTranslation.Checked = false;

            lblStatus.Visible = SR.Surveys.Count > 0;
            cmdOpenReportFolder.Visible = SR.Surveys.Count > 0;
            cmdGenerate.Visible = SR.Surveys.Count > 0;
            tabControlOptions.Visible = SR.Surveys.Count>0;

            lstSelectedSurveys.DataSource = null;
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";

            // update report defaults
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();
            // load survey specific options
            LoadSurveyOptions();
        }

        private void NewReport(ReportSurvey survey)
        {
            // reset report settings
            SR = new SurveyBasedReport();
            SR.AddSurvey(survey);
            SR.LayoutOptions.ToC = TableOfContents.PageNums;

            compare = new Comparison()
            {
                SimilarWords = DBAction.GetSimilarWords() 
            };

            // reset form controls
            chkStdTranslation.Checked = false;

            lblStatus.Visible = SR.Surveys.Count > 0;
            cmdOpenReportFolder.Visible = SR.Surveys.Count > 0;
            cmdGenerate.Visible = SR.Surveys.Count > 0;
            tabControlOptions.Visible = SR.Surveys.Count > 0;

            lstSelectedSurveys.DataSource = null;
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";

            // update report defaults
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();
            // load survey specific options
            LoadSurveyOptions();
        }

        private void UpdateCurrentSurvey()
        {
            CurrentSurvey = (ReportSurvey)lstSelectedSurveys.SelectedItem;
            if (CurrentSurvey == null)
                return;

            lblCurrentSurveyFields.Text = CurrentSurvey.SurveyCode + " (" + CurrentSurvey.Backend.ToString("d") + ") selections.";
        }

        private void UpdateDefaultOptions()
        {
            int surveyCount = SR.Surveys.Count;
            if (surveyCount > 1)
            {
                if (!tabControlOptions.TabPages.Contains(pgCompareTab)) tabControlOptions.TabPages.Insert(1, pgCompareTab);
                chkCompare.Enabled = true;
                chkCompare.Checked = true;
            }
            else
            {
                tabControlOptions.TabPages.Remove(pgCompareTab);
                chkCompare.Enabled = false;
                chkCompare.Checked = false;
            }

            if (!SR.CheckForDiffCountry())
                compare.MatchOnRename = true;
            else
                compare.MatchOnRename = false;

            if (surveyCount == 2)
            {
                if (SR.Surveys[0].SurveyCode == SR.Surveys[1].SurveyCode) // self compare
                {
                   
                    compare.HighlightScheme = HScheme.Sequential;
                    
                }
                else if (SR.CheckForDiffCountry())
                {

                    
                    compare.HighlightScheme = HScheme.AcrossCountry;
                    
                }
                else
                {
                    compare.HighlightScheme = HScheme.Sequential;
                 

                }
            }
            else
            {
                
            }
            

            if (surveyCount > 1)
            {
                SR.SubsetTables = false;
                SR.SubsetTablesTranslation = false;               
            }
        }

        private void UpdateGrids()
        {
            UpdatePrimarySurveyGrid();
           
            UpdateQnumSurveyGrid();
        }

        private void UpdatePrimarySurveyGrid()
        {
            // populate the primary survey list
            chklstPrimarySurvey.Items.Clear();
            chklstPrimarySurvey.Items.AddRange(SR.Surveys.ToArray());

            // check off the primary survey
            for (int i = 0; i < chklstPrimarySurvey.Items.Count; i++)
            {
                ReportSurvey r = (ReportSurvey)chklstPrimarySurvey.Items[i];
                if (r.Primary)
                {
                    chklstPrimarySurvey.SetItemChecked(i, true);
                    chklstPrimarySurvey.SelectedItem = chklstPrimarySurvey.Items[i];
                }
                else
                    chklstPrimarySurvey.SetItemChecked(i, false);
            }
        }

        private void UpdateQnumSurveyGrid()
        {
           
        }

        private void UpdateReportColumns(object sender, EventArgs e)
        {
            // force property to update before refreshing column list
            if (sender != null && sender is CheckBox)
            {
                CheckBox c = (CheckBox)sender;
                c.DataBindings[0].WriteValue();
            }

            SR.UpdateColumnOrder();
            
        }

        private void UpdateFileNameTab()
        {
            if (SR.Surveys.Count == 0)
                return;

            if (CurrentTemplate == ReportTemplate.Website)
            {
                fileNameTextBox.Text = SR.Surveys[0].WebName ?? SR.Surveys[0].SurveyCode + " web name not set.";
                return;
            }

            ReportSurvey primary = SR.PrimarySurvey();
            string mainSource = primary.SurveyCode;
            string secondSources = "";

            if (primary.Backend != DateTime.Today)
                mainSource += " on " + primary.Backend.ToString("dd-MMM-yyyy");


            foreach (ReportSurvey o in SR.NonPrimarySurveys())
            {
                secondSources += o.SurveyCode;
                if (o.Backend != DateTime.Today)
                {
                    secondSources += " on " + o.Backend.ToString("dd-MMM-yyyy");
                }

                secondSources += ", ";
            }

            secondSources = Utilities.TrimString(secondSources, ", ");

            txtMainSource.Text = mainSource;
            txtSecondSources.Text = secondSources;

            fileNameTextBox.Text = mainSource;
            if (!string.IsNullOrEmpty(secondSources))
                fileNameTextBox.Text += " vs. " + secondSources;

        }

        private void UpdateReportDetails()
        {
            string details = "";
            string extras = "", comments = "", translation = "", filters = "", labels = "";
            switch (SR.ReportType)
            {
                case ReportTypes.Standard:
                    break;
                case ReportTypes.Label:
                    details += "Content comparison.";
                    break;
                case ReportTypes.Order:
                    details += "Order comparison.";
                    break;
            }

            foreach (ReportSurvey rs in SR.Surveys)
            {
                if (rs.CommentFields.Count > 0 && string.IsNullOrEmpty(comments))
                    comments += "comments, ";

                if (rs.TransFields.Count > 1 && string.IsNullOrEmpty(translation))
                    translation += "translation, ";

                if ((rs.VarLabelCol || rs.TopicLabelCol || rs.DomainLabelCol || rs.ContentLabelCol || rs.ProductLabelCol) && string.IsNullOrEmpty(labels))
                    labels += "labels, ";

                if (rs.FilterCol && string.IsNullOrEmpty(filters))
                    filters += "Filters, ";

            }

            extras = comments + translation + filters + labels;

            if (!string.IsNullOrEmpty(extras))
                details += " With " + extras;

            SR.Details = details;
        }

        #region Survey Content Tab
      
        /// <summary>
        /// After a date is chosen, check that a backup exists for that date. If the date chosen is today, do nothing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateBackend_CloseUp(object sender, EventArgs e)
        {
            if (dateBackend.Value == DateTime.Today)
                return;

            if (CurrentSurvey == null)
                return;

            string filePath = dateBackend.Value.ToString("yyyy-MM-dd");
            try
            {
                BackupConnection bkp = new BackupConnection(dateBackend.Value);

                if (!bkp.IsValidBackup())
                {

                    MessageBox.Show("No backup found for this date. Getting nearest valid date");
                    dateBackend.Value = bkp.GetNearestBackup();
                }

                CurrentSurvey.Backend = dateBackend.Value;
                UpdateReportColumns(null, null);
                UpdateFileNameTab();
                UpdateCurrentSurvey();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's translation list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.TransFields.Clear();
            for (int i = 0; i < lstTransFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.TransFields.Add(lstTransFields.SelectedItems[i].ToString());
            }

            if (lstTransFields.SelectedItems.Count > 0 & CurrentSurvey.EnglishRouting)
            {
                groupTRoutingStyle.Enabled = true;
                chkEnglishRouting.Visible = true;
            }

            UpdateReportColumns(sender, e);
        }

        private void lstCommentTypes_Click(object sender, EventArgs e)
        {
            CurrentSurvey.CommentFields.Clear();
            foreach (CommentType type in lstCommentTypes.SelectedItems)
            {
                CurrentSurvey.CommentFields.Add(type.TypeName);
            }

            UpdateReportColumns(sender, e);
        }

        private void lstExtraFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.FilterCol = false;
            CurrentSurvey.DomainLabelCol = false;
            CurrentSurvey.TopicLabelCol = false;
            CurrentSurvey.ContentLabelCol = false;
            CurrentSurvey.VarLabelCol = false;
            CurrentSurvey.ProductLabelCol = false;
            CurrentSurvey.AltQnum2Col = false;
            CurrentSurvey.AltQnum3Col = false;

            for (int i =0;i <lstExtraFields.SelectedItems.Count; i++)
            {
                string item =  lstExtraFields.SelectedItems[i].ToString();
                switch (item)
                {
                    case "Filters":
                        CurrentSurvey.FilterCol = true;
                        break;
                    case "Domain":
                        CurrentSurvey.DomainLabelCol = true;
                        break;
                    case "Topic":
                        CurrentSurvey.TopicLabelCol = true;
                        break;
                    case "Content":
                        CurrentSurvey.ContentLabelCol = true;
                        break;
                    case "VarLabel":
                        CurrentSurvey.VarLabelCol = true;
                        break;
                    case "Product":
                        CurrentSurvey.ProductLabelCol = true;
                        break;
                    case "AltQnum":
                        CurrentSurvey.AltQnumCol = true;
                        break;
                    case "AltQnum2":
                        CurrentSurvey.AltQnum2Col = true;
                        break;
                    case "AltQnum3":
                        CurrentSurvey.AltQnum3Col = true;
                        break;
                    
                }
            }
            SR.UpdateColumnOrder();
        }

        private void RoutingStyle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            CurrentSurvey.RoutingFormat = (RoutingStyle)sel;
        }

        private void TRoutingStyle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            CurrentSurvey.TranslationRoutingFormat = (RoutingStyle)sel;
        }

        private void cmdCustomizeContent_Click(object sender, EventArgs e)
        {
            CustomizeForm frm = new CustomizeForm(CurrentSurvey);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();
        }

        #endregion

        #region Comparison Tab

        private void Compare_CheckedChanged(object sender, EventArgs e)
        {
            lblPrimarySurvey.Visible = chkCompare.Checked;
           
            groupHighlightOptions.Visible = chkCompare.Checked;
            
        }

        private void chklstPrimarySurvey_SelectedIndexChanged(object sender, EventArgs e)
        {
            var checkedItems = chklstPrimarySurvey.CheckedItems;

            ReportSurvey r = (ReportSurvey)checkedItems[0];
            SR.SetPrimary(r.ID);
        }

        private void chklstPrimarySurvey_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (chklstPrimarySurvey.CheckedItems.Count == 1)
            {
                bool isCheckedItemBeingUnchecked = (e.CurrentValue == CheckState.Checked);
                if (isCheckedItemBeingUnchecked)
                {
                    e.NewValue = CheckState.Checked;
                }
                else
                {
                    Int32 checkedItemIndex = chklstPrimarySurvey.CheckedIndices[0];
                    chklstPrimarySurvey.ItemCheck -= chklstPrimarySurvey_ItemCheck;
                    chklstPrimarySurvey.SetItemChecked(checkedItemIndex, false);
                    chklstPrimarySurvey.ItemCheck += chklstPrimarySurvey_ItemCheck;
                }

                return;
            }
        }

        private void HighlightStyle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            compare.HighlightStyle = (HStyle)sel;
        }

        private void ShowDeletedQuestionsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            chkReInsertDeletions.Visible = chkShowDeletedQuestions.Checked;
        }

        #endregion

        #region Order and Numbering tab

        private void gridColumnOrder_ColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            List<ReportColumn> columns = new List<ReportColumn>();
            DataGridView dgv = (DataGridView)sender;
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                columns.Add(new ReportColumn(dgv.Columns[i].HeaderText, e.Column.Index + 1));
            }
            SR.ColumnOrder = columns;
        }

        #endregion

        #region Output Tab
        private void FileFormat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.LayoutOptions.FileFormat = (FileFormats)sel;
        }

        private void ToC_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.LayoutOptions.ToC = (TableOfContents)sel;
        }

        private void PaperSize_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.LayoutOptions.PaperSize = (PaperSizes)sel;
        }

        private void NRFormat_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            SR.NrFormat = (ReadOutOptions)sel;
        }


        #endregion



        private void tabControlOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SR.UpdateColumnOrder();
            //UpdateGrids();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OptionsForm frm = new OptionsForm(SR);

            frm.ShowDialog();
        }

        private void cmdCommentFields_Click(object sender, EventArgs e)
        {
            CommentOptions frm = new CommentOptions(CurrentSurvey);
            frm.ShowDialog();
        }

        private void outputOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OutputOptionsForm frm = new OutputOptionsForm(SR);
            frm.ShowDialog();
        }

        
    }
}
