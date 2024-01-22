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

        Comparison compare;
        
        UserPrefs UserPreferences;
        ReportSurvey CurrentSurvey;
        TabPage pgCompareTab;
        ReportTemplate CurrentTemplate;

        ReportSurvey TranslatorReference;

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

            UserPreferences = new UserPrefs();

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
                SR.Surveys[0].ContentOptions.TranslationOptions.TransFields.Add(frm.Language);
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
                SR.QnumSurvey().ContentOptions.TranslationOptions.TransFields.Add(language.LanguageName);
                SR.PrimarySurvey().ContentOptions.TranslationOptions.TransFields.Add(language.LanguageName);
            }
            else
                SR.PrimarySurvey().ContentOptions.TranslationOptions.TransFields = DBAction.ListLanguages(SR.QnumSurvey()).Select(x=>x.LanguageName).ToList();
        }

        #endregion 

        private void cmdQuickGenerate_Click(object sender, EventArgs e)
        {
            surveyReportBindingSource.EndEdit();

            if (SR.Surveys.Count == 0)
            {
                MessageBox.Show("No surveys selected.");
                return;
            }

            if (SR.Surveys.Any(x=>x.ContentOptions.TranslationOptions.TransFields.Count==0) && SR.SubsetTablesTranslation)
            {
                MessageBox.Show("You have selected Translation Subset Tables but no translation language was selected.");
                return;
            }

            SR.UpdateColumnOrder();
            // set file name to the user's report path
            SR.FileName = UserPreferences.ReportPath;

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
                if (SR.Surveys.Count > 1)
                    RunComparisonReport();
                else
                    RunSurveyReport();
                //else
                //{
                //    if (SR.SubsetTables)
                //        RunTableFormatReport();
                //    else
                //        RunSingleSurveyReport();

                //}
            }
            else
            {
                // no option checked
                MessageBox.Show("Error: unknown selection.");
            }

            GC.Collect();
        }

        private void GenerateReport()
        {
            // check template
            switch (CurrentTemplate)
            {
                case ReportTemplate.Translator:
                    break;
                case ReportTemplate.Website:
                    break;
                case ReportTemplate.Standard:
                    break;
                case ReportTemplate.Custom:

                    if (SR.Surveys.Count > 1)
                        RunComparisonReport();
                    else
                    {
                        if (SR.SubsetTables)
                            RunTableFormatReport();
                        else
                            RunSingleSurveyReport();
                    }
                    break;

            }
        }


        /// <summary>
        /// Run a survey report with 1 survey.
        /// </summary>
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
            {
                List<List<SurveyImage>> allImages = SR.Surveys.SelectMany(x => x.Questions.Select(q => q.Images)).ToList();
                List<SurveyImage> Images = allImages.SelectMany(i => i).ToList();
                survReport.Images = Images;
            }

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", survReport, "ReportStatus"));

            if (chkTranslationFirst.Checked)
            {
                survReport.UpdateColumnOrder(true);
            }

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

            if (survReport.LayoutOptions.PaperSize == PaperSizes.Letter)
            {
                if (survReport.ColumnOrder.Count >= 6)
                    survReport.LayoutOptions.PaperSize = PaperSizes.Eleven17;
                else if (survReport.ColumnOrder.Count >= 4)
                    survReport.LayoutOptions.PaperSize = PaperSizes.Legal;
            }

            // output report to Word/PDF
            survReport.OutputReportTableXML();
        }

        /// <summary>
        /// Run a survey report with 1 survey in table format.
        /// </summary>
        private void RunTableFormatReport()
        {
            // get the survey data for all chosen surveys
            PopulateSurveys();
          
            try
            {
                TableFormatReport report = new TableFormatReport(SR.Surveys[0]);

                report.ColumnOrder = SR.ColumnOrder;

                // bind status label to survey report's status property
                lblStatus.DataBindings.Clear();
                lblStatus.DataBindings.Add(new Binding("Text", report, "ReportStatus"));

                report.CreateReport();

                TableFormatPrinter printer = new TableFormatPrinter(report);
                printer.OutputOptions.FileFormat = SR.LayoutOptions.FileFormat;
                printer.OutputOptions.PaperSize = PaperSizes.Letter;
                printer.ToC = true;
                printer.Unattended = false;
                

                printer.PrintReport();
            }
            catch
            {
                MessageBox.Show("Error generating report.");
            }

        }


        /// <summary>
        /// Run a survey report with 1 survey.
        /// </summary>
        private void RunSingleSurveyReport()
        {
            // get the survey data for all chosen surveys
            PopulateSurveys();

            SurveyReport survReport = new SurveyReport(SR);

            if (chkTranslationFirst.Checked)
            {
                survReport.UpdateColumnOrder(true);
            }
            //try
            //{
                StandardSurveyReport report = new StandardSurveyReport(SR.Surveys[0]);

                report.ColumnOrder = survReport.ColumnOrder;

                // bind status label to survey report's status property
                lblStatus.DataBindings.Clear();
                lblStatus.DataBindings.Add(new Binding("Text", report, "ReportStatus"));

                report.CreateReport();

                StandardReportPrinter printer = new StandardReportPrinter(report);
                printer.OutputOptions.FileFormat = SR.LayoutOptions.FileFormat;
                printer.ToC = true;
                printer.Unattended = false;
                if (printer.OutputOptions.PaperSize == PaperSizes.Letter)
                {
                    if (report.ColumnOrder.Count >= 6)
                        printer.OutputOptions.PaperSize = PaperSizes.Eleven17;
                    else if (report.ColumnOrder.Count >= 4)
                        printer.OutputOptions.PaperSize = PaperSizes.Legal;
                }

                printer.PrintReport();
            //}
            //catch
            //{
            //    MessageBox.Show("Error generating report.");
            //}
            
        }

        /// <summary>
        /// Run a survey report with 2 or more surveys.
        /// </summary>
        private void RunComparisonReport()
        {
            int result;

            // get the survey data for all chosen surveys
            PopulateComparisonSurveys();


            SurveyReport survReport = new SurveyReport(SR)
            {
                SurveyCompare = compare
            };

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", survReport, "ReportStatus"));

            if (chkTranslationFirst.Checked)
            {
                survReport.UpdateColumnOrder(true);
            }

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

            if (survReport.LayoutOptions.PaperSize == PaperSizes.Letter)
            {
                if (survReport.ColumnOrder.Count >= 6)
                    survReport.LayoutOptions.PaperSize = PaperSizes.Eleven17;
                else if (survReport.ColumnOrder.Count >= 4)
                    survReport.LayoutOptions.PaperSize = PaperSizes.Legal;
            }

            // output report to Word/PDF
            survReport.OutputReportTableXML();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="withTranslation"></param>
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
                    rs.ContentOptions.TranslationOptions.TransFields = langs;
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

        /// <summary>
        /// Run a survey report for 1 survey to be posted to the web.
        /// </summary>
        private void RunWebReport()
        {
            ReportSurvey survey = SR.Surveys[0];

            PopulateWebsiteReport(survey);

            WebsiteSurveyReport report = new WebsiteSurveyReport(survey);
            report.ShowEnglish = survey.ShowQuestion;
            report.UpdateColumnOrder();

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", report, "ReportStatus"));

            try
            {
                report.CreateReport();

                WebsiteReportPrinter printer = new WebsiteReportPrinter(report, report.SurveyContent.WebName);
                printer.PrintReport();
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
            var images = DBAction.GetSurveyImagesFromFolder(survey);

            foreach (SurveyImage img in images)
            {
                var q = survey.QuestionByRefVar(img.VarName);
                if (q != null) q.Images.Add(img);
            }

            // previous VarNames
            DBAction.FillPreviousNames(survey, true);

            foreach (string language in survey.ContentOptions.TranslationOptions.TransFields)
                if (!language.Equals("English"))
                {
                    var translations = DBAction.GetSurveyTranslation(survey.SurveyCode, language);

                    foreach (Translation t in translations)
                        survey.QuestionByID(t.QID).Translations.Add(t);
                }

            survey.VarChanges = new List<VarNameChange>(DBAction.GetVarNameChanges(survey).Where(x => !x.PreFWChange));

            survey.LastUpdate = DBAction.GetSurveyLastUpdate(survey);
        }

        /// <summary>
        /// Run a survey report to be sent for translation.
        /// </summary>
        private void RunTranslatorReport()
        {
            if (SR.Surveys.Count != 2)
            {
                MessageBox.Show("Translator options not set.");
                return;
            }

            SR.Surveys[0].Qnum = true;
            SR.Surveys[1].Primary = true;

            // get the survey data for all chosen surveys
            PopulateTranslatorSurveys();

            TranslatorReport report = new TranslatorReport(SR.Surveys[0], SR.Surveys[1]);
            report.Comparer.SimilarWords = DBAction.GetSimilarWords();
            report.UpdateColumnOrder();

            // bind status label to survey report's status property
            lblStatus.DataBindings.Clear();
            lblStatus.DataBindings.Add(new Binding("Text", report, "ReportStatus"));

            try
            {
                report.CreateReport();
                TranslatorReportPrinter printer = new TranslatorReportPrinter(report, report.ReportTitle());
                printer.PrintReport();
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
                    DBAction.FillBackupTranslation(rs, rs.Backend.Date, rs.ContentOptions.TranslationOptions.TransFields);
                else
                {
                    foreach (string language in rs.ContentOptions.TranslationOptions.TransFields)
                    {
                        var translations = DBAction.GetSurveyTranslation(rs.SurveyCode, language);

                        foreach (Translation t in translations)
                            rs.QuestionByID(t.QID).Translations.Add(t);
                    }
                }

                rs.LastUpdate = DBAction.GetSurveyLastUpdate(rs);
            }
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
                {
                    rs.AddQuestions(DBAction.GetBackupQuestions(rs, rs.Backend));
                    List<QuestionTimeFrame> timeframes = DBAction.GetTimeFrames(rs.SurveyCode);
                    foreach (SurveyQuestion question in rs.Questions)
                    {
                        question.TimeFrames = timeframes.Where(x => x.QID == question.ID).ToList();
                    }
                }
                else
                    rs.AddQuestions(DBAction.GetSurveyQuestions(rs));

                foreach (SurveyQuestion q in rs.Questions)
                {
                    string groups = DBAction.GetSurveyGroups(rs.SurveyCode, q.VarName.RefVarName);
                    rs.ProjectGroups.Add(q, groups);
                }

                var images = DBAction.GetSurveyImagesFromFolder(rs);
                foreach (SurveyImage img in images)
                {
                    var q = SR.Surveys[0].QuestionByRefVar(img.VarName);
                    if (q != null) q.Images.Add(img);
                }


                // correct questions
                if (rs.Corrected)
                {
                    rs.CorrectedQuestions = DBAction.GetCorrectedWordings(rs);
                    rs.CorrectWordings();
                }

                // previous names (for Var column)
                DBAction.FillPreviousNames(rs, SR.ExcludeTempChanges);

                if (SR.Surveys.Count > 1 && compare.MatchOnRename && rs.Backend.Date != DateTime.Today)
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
                if (rs.ContentOptions.CommentOptions.CommentFields.Count > 0)
                {
                    DBAction.FillCommentsBySurvey(rs);
                }

                // translations
                if (rs.Backend.Date != DateTime.Today)
                    DBAction.FillBackupTranslation(rs, rs.Backend.Date, rs.ContentOptions.TranslationOptions.TransFields);
                else
                {
                    foreach (string language in rs.ContentOptions.TranslationOptions.TransFields)
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
                    rs.VarChanges = new List<VarNameChange>(DBAction.GetVarNameChanges(rs).Where(x => x.PreFWChange != SR.ExcludeTempChanges));

                rs.LastUpdate = DBAction.GetSurveyLastUpdate(rs);
            }
        }

        private void PopulateComparisonSurveys()
        {
            // populate the survey and extra fields
            foreach (ReportSurvey rs in SR.Surveys)
            {
                rs.Questions.Clear();
                rs.SurveyNotes.Clear();
                rs.VarChanges.Clear();

                // questions
                if (rs.Backend.Date != DateTime.Today)
                {
                    rs.AddQuestions(DBAction.GetBackupQuestions(rs, rs.Backend));
                    List<QuestionTimeFrame> timeframes = DBAction.GetTimeFrames(rs.SurveyCode);
                    foreach (SurveyQuestion question in rs.Questions)
                    {
                        question.TimeFrames = timeframes.Where(x => x.QID == question.ID).ToList();
                    }
                }
                else
                    rs.AddQuestions(DBAction.GetSurveyQuestions(rs));

                foreach (SurveyQuestion q in rs.Questions)
                {
                    string groups = DBAction.GetSurveyGroups(rs.SurveyCode, q.VarName.RefVarName);
                    rs.ProjectGroups.Add(q, groups);
                }

                var images = DBAction.GetSurveyImagesFromFolder(rs);
                foreach (SurveyImage img in images)
                {
                    var q = SR.Surveys[0].QuestionByRefVar(img.VarName);
                    if (q != null) q.Images.Add(img);
                }


                // correct questions
                if (rs.Corrected)
                {
                    rs.CorrectedQuestions = DBAction.GetCorrectedWordings(rs);
                    rs.CorrectWordings();
                }

                // previous names (for Var column)
                DBAction.FillPreviousNames(rs, SR.ExcludeTempChanges);

                if (compare.MatchOnRename && rs.Backend.Date != DateTime.Today)
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
                if (rs.ContentOptions.CommentOptions.CommentFields.Count > 0)
                {
                    DBAction.FillCommentsBySurvey(rs);
                }

                // translations
                if (rs.Backend.Date != DateTime.Today)
                    DBAction.FillBackupTranslation(rs, rs.Backend.Date, rs.ContentOptions.TranslationOptions.TransFields);
                else
                {
                    foreach (string language in rs.ContentOptions.TranslationOptions.TransFields)
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
                    rs.VarChanges = new List<VarNameChange>(DBAction.GetVarNameChanges(rs).Where(x => x.PreFWChange != SR.ExcludeTempChanges));

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
                    case "Parallel Vars":
                        lstExtraFields.SetSelected(i, CurrentSurvey.ParallelVarsCol);
                        break;
                    case "Survey Groups":
                        lstExtraFields.SetSelected(i, CurrentSurvey.SurveyGroupCol);
                        break;
                }
            }

            chkIncludeEnglish.DataBindings.Clear();
            chkIncludeEnglish.DataBindings.Add("Checked", CurrentSurvey, "ShowQuestion");

            // translations
            // list them
            LoadExtraFields(CurrentSurvey);
            // select translations
            foreach (object item in CurrentSurvey.ContentOptions.TranslationOptions.TransFields)
            {
                for (int i = 0; i < lstTransFields.Items.Count; i++)
                    if (item.ToString().Equals(lstTransFields.Items[i].ToString()))
                        lstTransFields.SetSelected(i, true);
            }

            // select comments
            foreach (object item in CurrentSurvey.ContentOptions.CommentOptions.CommentFields)
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

            switch (CurrentSurvey.ContentOptions.TranslationOptions.TranslationRoutingFormat)
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
            string extras, comments = "", translation = "", filters = "", labels = "";

            foreach (ReportSurvey rs in SR.Surveys)
            {
                if (rs.ContentOptions.CommentOptions.CommentFields.Count > 0 && string.IsNullOrEmpty(comments))
                    comments += "comments, ";

                if (rs.ContentOptions.TranslationOptions.TransFields.Count > 1 && string.IsNullOrEmpty(translation))
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
            CurrentSurvey.ContentOptions.TranslationOptions.TransFields.Clear();
            for (int i = 0; i < lstTransFields.SelectedItems.Count; i++)
            {
                CurrentSurvey.ContentOptions.TranslationOptions.TransFields.Add(lstTransFields.SelectedItems[i].ToString());
            }
            
            chkTranslationFirst.Visible = lstTransFields.SelectedItems.Count > 0;

            if (lstTransFields.SelectedItems.Count > 0 & CurrentSurvey.EnglishRouting)
            {
                groupTRoutingStyle.Enabled = true;
                chkEnglishRouting.Visible = true;
            }

            UpdateReportColumns(sender, e);
        }

        private void lstCommentTypes_Click(object sender, EventArgs e)
        {
            CurrentSurvey.ContentOptions.CommentOptions.CommentFields.Clear();
            foreach (CommentType type in lstCommentTypes.SelectedItems)
            {
                CurrentSurvey.ContentOptions.CommentOptions.CommentFields.Add(type.TypeName);
            }

            UpdateReportColumns(sender, e);
        }

        private void lstExtraFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.ContentOptions.ContentColumns.Clear();
            CurrentSurvey.FilterCol = false;
            CurrentSurvey.DomainLabelCol = false;
            CurrentSurvey.TopicLabelCol = false;
            CurrentSurvey.ContentLabelCol = false;
            CurrentSurvey.VarLabelCol = false;
            CurrentSurvey.ProductLabelCol = false;
            CurrentSurvey.AltQnum2Col = false;
            CurrentSurvey.AltQnum3Col = false;
            CurrentSurvey.ParallelVarsCol = false;
            CurrentSurvey.SurveyGroupCol = false;

            for (int i =0;i <lstExtraFields.SelectedItems.Count; i++)
            {
                string item =  lstExtraFields.SelectedItems[i].ToString();
                switch (item)
                {
                    case "Filters":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("Filters");
                        CurrentSurvey.FilterCol = true;
                        break;
                    case "Domain":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("Domain");
                        CurrentSurvey.DomainLabelCol = true;
                        break;
                    case "Topic":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("Topic");
                        CurrentSurvey.TopicLabelCol = true;
                        break;
                    case "Content":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("Content");
                        CurrentSurvey.ContentLabelCol = true;
                        break;
                    case "VarLabel":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("VarLabel");
                        CurrentSurvey.VarLabelCol = true;
                        break;
                    case "Product":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("Product");
                        CurrentSurvey.ProductLabelCol = true;
                        break;
                    case "AltQnum":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("AltQnum");
                        CurrentSurvey.AltQnumCol = true;
                        break;
                    case "AltQnum2":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("AltQnum2");
                        CurrentSurvey.AltQnum2Col = true;
                        break;
                    case "AltQnum3":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("AltQnum3");
                        CurrentSurvey.AltQnum3Col = true;
                        break;
                    case "Parallel Vars":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("Parallel Vars");
                        CurrentSurvey.ParallelVarsCol = true;
                        break;
                    case "Survey Groups":
                        CurrentSurvey.ContentOptions.ContentColumns.Add("Survey Groups");
                        CurrentSurvey.SurveyGroupCol = true;
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

            CurrentSurvey.ContentOptions.TranslationOptions.TranslationRoutingFormat = (RoutingStyle)sel;
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

        private void cmdOpenReportFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"\\psychfile\psych$\psych-lab-gfong\SMG\SDI\Reports\ISR");
        }
    }
}
