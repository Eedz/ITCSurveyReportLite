using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ITCLib;

namespace ITCSurveyReportLite
{
    /// <summary>
    /// User interface for generating a Survey-based report.
    /// </summary>
    public partial class SurveyReportForm : Form
    {
        // TODO depending on which type of report is chosen, create an object of that type and bind the controls of the form to that type
        SurveyBasedReport SR;
        // this report survey is just to hold the question filter selections. Just before the report is run, the filters will be copied to each report survey object in the report's list.
        ReportSurvey questionFilters;
        int filterBy;
        Comparison compare;
        ReportTypes reportType;
        UserPrefs UP;
        ReportSurvey CurrentSurvey;
        TabPage pgCompareTab;
        //BindingSource ReportBindingSource;

        // background color RGB values
        //int backColorR = 55;
        //int backColorG = 170;
        //int backColorB = 136;

        // quick report descriptions
        string standardToolTipText = "Standard Survey Printout\r\n" +
                                    "Includes:\r\n" +
                                    "Blank Column\r\n" +
                                    "VarName Changes\r\n" +
                                    "QN Insertion (F2F only)\r\n" +
                                    "Don't Read (F2F only)\r\n" +
                                    "For 2 or more surveys:\r\n" +
                                    "Classic Highlighting with Re-inserted deletions";



        /// <summary>
        /// 
        /// </summary>
        public SurveyReportForm()
        {
            InitializeComponent();

            // add arrow symbol to add/remove buttons
            cmdAddSurvey.Text = char.ConvertFromUtf32(0x2192);
            cmdRemoveSurvey.Text = char.ConvertFromUtf32(0x2190);
            

            // start with blank constructor, default settings
            reportType = ReportTypes.Standard;
            SR = new SurveyBasedReport();
            UP = new UserPrefs();
            questionFilters = new ReportSurvey();
        }

        /// <summary>
        /// After the form is created, perform some initial setup.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SurveyReportForm_Load(object sender, EventArgs e)
        {
            // fill the survey drop down
            cboSurveys.ValueMember = "Survey";
            cboSurveys.DisplayMember = "Survey";
            cboSurveys.DataSource = DBAction.GetSurveyList();

            // add tooltips for the quick reports
            // toolTipStandard.SetToolTip(this.optStd, standardToolTipText);
            toolTipStandard.ShowAlways = true;
            toolTipStandard.AutomaticDelay = 0;
            toolTipStandard.AutoPopDelay = 30000;

            // hide the comparison tab until it is needed
            pgCompareTab = pgCompare;
            tabControlOptions.TabPages.Remove(pgCompare);

            // bind the controls of the form to the SR object
            surveyReportBindingSource.DataSource = SR;

            compare = new Comparison()
            {
                SimilarWords = DBAction.GetSimilarWords() // populate the similar words list
            };

            compareBindingSource.DataSource = compare;

            reportLayoutBindingSource.DataSource = SR.LayoutOptions;

          


            // bind selected surveys to the list of surveys in SR
            lstSelectedSurveys.DataSource = SR.Surveys;
            lstSelectedSurveys.ValueMember = "ID";
            lstSelectedSurveys.DisplayMember = "SurveyCode";

            // bind question filters to the holding object
            filterBy = 1;
         
        

            lblStatus.Visible = false;
            lblStatus.Text = "Ready.";
            cmdCheckOptions.Visible = false;



        }

        //private void ChangeReportType(ReportTypes type)
        //{
        //    switch (type) {
        //        case ReportTypes.Standard:
        //            ReportBindingSource = null;
        //            break;
        //        case ReportTypes.Label:
        //            ReportBindingSource = null;
        //            break;
        //        case ReportTypes.Order:
        //            ReportBindingSource = null;
        //            break;
        //    }
        //}

        private void BindControls()
        {

        }

        #region Menu Strip

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void standardWTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void websiteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void websiteWTranslationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        #endregion



        /// <summary>
        /// Generate the report.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckOptions_Click(object sender, EventArgs e)
        {
            if (lstSelectedSurveys.SelectedItems.Count == 0)
            {
                MessageBox.Show("No surveys selected.");
                return;
            }
            UpdateColumnOrder();
            // set file name to the user's report path
            SR.FileName = UP.ReportPath;

            // get the survey data for all chosen surveys
            PopulateSurveys();

            // if standard is not chosen, create a new SR with the chosen template
            switch (reportType)
            {
                case ReportTypes.Standard:

                    RunSurveyReport();

                    break;
                case ReportTypes.Label:

                    RunLabelReport();

                    break;
            }

        }

        private void RunSurveyReport()
        {
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

        private void RunLabelReport()
        {
            int result;
            TopicContentReport TC = new TopicContentReport(SR);

            result = TC.GenerateLabelReport();
            switch (result)
            {
                case 1:
                    MessageBox.Show("One or more surveys contain no records.");
                    // TODO if a backup was chosen, show a form for selecting a different survey code from that date
                    break;
                default:
                    break;
            }

            TC.OutputReportTable();
        }



        /// <summary>
        /// For each survey in the report, fill the question list, comments and translations as needed.
        /// </summary>
        private void PopulateSurveys()
        {
            // populate the survey and extra fields
            foreach (ReportSurvey rs in SR.Surveys)
            {
                if (filterBy == 1)
                {
                    rs.QRangeHigh = questionFilters.QRangeHigh;
                    rs.QRangeLow = questionFilters.QRangeLow;
                    rs.Prefixes = null;
                    rs.Headings = null;
                }
                else if (filterBy == 2)
                {
                    rs.QRangeHigh = 0;
                    rs.QRangeLow = 0;
                    rs.Prefixes = questionFilters.Prefixes;
                    rs.Headings = null;
                }
                else if (filterBy == 3)
                {
                    rs.QRangeHigh = 0;
                    rs.QRangeLow = 0;
                    rs.Prefixes = null;
                    rs.Headings = questionFilters.Headings;
                }

                rs.Varnames = questionFilters.Varnames;

                rs.Questions.Clear();
                rs.SurveyNotes.Clear();
                rs.VarChanges.Clear();

                // questions
                if (rs.Backend.Date != DateTime.Today)
                    rs.AddQuestions(new BindingList<SurveyQuestion>(DBAction.GetBackupQuestions(rs, rs.Backend)));
                else
                    DBAction.FillQuestions(rs);

                // correct questions // TODO should we only get corrected for current data?
                if (rs.Corrected)
                {
                    DBAction.FillCorrectedQuestions(rs);
                    rs.CorrectWordings();
                }

                // previous names (for Var column)
                DBAction.FillPreviousNames(rs, SR.ExcludeTempChanges);

                if (compare.MatchOnRename && rs.Backend.Date != DateTime.Today)
                {
                    foreach (SurveyQuestion sq in rs.Questions)
                    {
                        sq.VarName = new VariableName(DBAction.GetCurrentName(rs.SurveyCode, sq.VarName.FullVarName, rs.Backend));
                    }

                }
                // survey notes
                if (SR.SurvNotes)
                    rs.SurveyNotes = DBAction.GetSurvCommentsBySurvey(rs.SID);

                // comments
                if (rs.CommentFields.Count > 0)
                {
                    DBAction.FillCommentsBySurvey(rs);
                }

                // translations
                foreach (string language in rs.TransFields)
                    DBAction.FillTranslationsBySurvey(rs, language);

                // filters
                if (rs.FilterCol)
                    rs.MakeFilterList();

                // varchanges (for appendix)
                if (SR.VarChangesApp)
                    rs.VarChanges = DBAction.GetVarNameChangeBySurvey(rs.SurveyCode, SR.ExcludeTempChanges);
            }
        }

        private void UpdateColumnOrder()
        {
            
        }

        #region Current Survey "Load" Methods

        // bind each control to the selected survey's corresponding fields
        private void LoadSurveyOptions()
        {
            if (CurrentSurvey == null)
                return;

            // backend date
            dateBackend.DataBindings.Clear();
            dateBackend.DataBindings.Add("Value", CurrentSurvey, "Backend");

            // question filters will be applied to all surveys rather than individually. so we will not bind these properties
            // filters
            // Qnum range
            //txtQrangeLow.DataBindings.Clear();
            //txtQrangeLow.DataBindings.Add("Text", CurrentSurvey, "QRangeLow");
            //txtQrangeHigh.DataBindings.Clear();
            //txtQrangeHigh.DataBindings.Add("Text", CurrentSurvey, "QRangeHigh");

            //// prefixes
            if (filterBy == 2)
            {
                LoadPrefixes(CurrentSurvey.SurveyCode);
                //lstPrefixes.DataBindings.Clear();
                //lstPrefixes.DataSource = CurrentSurvey.Prefixes;
            }
            else if (filterBy == 3)
            {
                //// headings
                LoadHeadings(CurrentSurvey.SurveyCode);
                //lstHeadings.DataBindings.Clear();
                //lstHeadings.DataSource = CurrentSurvey.Headings;
            }
            //// varnames
            LoadVarNames(CurrentSurvey.SurveyCode);
            //lstSelectedVarNames.DataBindings.Clear();
            //lstSelectedVarNames.DataSource = CurrentSurvey.Varnames;

            // standard fields
            

            // comments and translations
            // list them
            LoadExtraFields(CurrentSurvey);
            // select them
            foreach (object item in CurrentSurvey.TransFields)
            {
                for (int i = 0; i < lstTransFields.Items.Count; i++)
                    if (item.ToString().Equals(lstTransFields.Items[i].ToString()))
                        lstTransFields.SetSelected(i, true);

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

            chkEnglishRouting.DataBindings.Clear();
            chkEnglishRouting.DataBindings.Add("Checked", CurrentSurvey, "EnglishRouting");


           

        }

        private void LoadPrefixes(string survey)
        {
           
        }

        private void LoadVarNames(string survey)
        {
           
        }

        private void LoadHeadings(string survey)
        {
           
        }

        private void LoadExtraFields(Survey survey)
        {
            

        }

        #endregion


        #region Top of Form (Add and Remove surveys)

        private void AddSurvey_Click(object sender, EventArgs e)
        {
            // add survey to the SurveyReport object
            ReportSurvey s;
            try
            {
                s = new ReportSurvey(DBAction.GetSurveyInfo(cboSurveys.SelectedItem.ToString()));
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

            ReportSurvey s;
            Survey item = lstSelectedSurveys.SelectedItem as Survey;
            try
            {
                s = new ReportSurvey(DBAction.GetSurveyInfo(item.SurveyCode));
            }
            catch (Exception)
            {
                MessageBox.Show("Survey not found.");
                return;
            }

            AddSurvey(s);

            // set focus to calendar
            dateBackend.Focus();

        }

        /// <summary>
        /// Add a survey to the report.
        /// </summary>
        /// <param name="s">ReportSurvey object being added to the report.</param>
        private void AddSurvey(ReportSurvey s)
        {

            SR.AddSurvey(s);

            UpdateReportColumns(null, null);
            UpdateGrids();

            // show the options tabs if at least one survey is chosen
            if (lstSelectedSurveys.Items.Count > 0)
            {
                lblStatus.Visible = true;
                cmdCheckOptions.Visible = true;
                tabControlOptions.Visible = true;
            }

            // update report defaults
            ShowTranslationSubsetTableOption();
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
                cmdCheckOptions.Visible = false;
                tabControlOptions.Visible = false;
            }

            // update report defaults
            ShowTranslationSubsetTableOption();
            UpdateDefaultOptions();
            UpdateFileNameTab();
            UpdateReportDetails();
            // set current survey
            UpdateCurrentSurvey();

            // load survey specific options
            LoadSurveyOptions();
        }

        /// <summary>
        /// Update the report type in the SR object.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            reportType = (ReportTypes)sel;
            SR.ReportType = reportType;
            ShowTranslationSubsetTableOption();
            UpdateDefaultOptions();
            UpdateFileNameTab();
        }

        private void dateBackend_ValueChanged(object sender, EventArgs e)
        {

            if (dateBackend.Value == DateTime.Today)
                return;

            string filePath = dateBackend.Value.ToString("yyyy-MM-dd");

            BackupConnection bkp = new BackupConnection(dateBackend.Value);

            if (!bkp.IsValidBackup())
            {

                MessageBox.Show("No backup found for this date.");
                dateBackend.Value = bkp.GetNearestBackup();
            }

            UpdateReportColumns(null, null);

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



        private void UpdateCurrentSurvey()
        {
            CurrentSurvey = (ReportSurvey)lstSelectedSurveys.SelectedItem;
            if (CurrentSurvey == null)
                return;

            lblCurrentSurveyFields.Text = CurrentSurvey.SurveyCode + " (" + CurrentSurvey.Backend.ToString("d") + ") field selections.";
        }

        private void UpdateDefaultOptions()
        {
            int surveyCount = SR.Surveys.Count;
            if (surveyCount > 1 && SR.ReportType == ReportTypes.Standard)
            {
                if (!tabControlOptions.TabPages.Contains(pgCompareTab)) tabControlOptions.TabPages.Insert(2, pgCompareTab);
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
            

            if (surveyCount > 1 || SR.ReportType == ReportTypes.Label)
            {
                SR.SubsetTables = false;
                
                SR.SubsetTablesTranslation = false;
               
            }


            if (SR.ReportType == ReportTypes.Label || !SR.HasF2F())
            {
               

            }
            else
            {
                
            }

            if (surveyCount > 1)
            {
                
            }


            // order comparisons
            // check for order comparison
           
            // table of contents disabled for T/C reports, since it needs headings
            if (SR.ReportType == ReportTypes.Label)
            {
               
            }

          

           
             

     

           
              

           

        }

        private void ShowTranslationSubsetTableOption()
        {
            
        }

        private void UpdateGrids()
        {
            UpdatePrimarySurveyGrid();
            UpdateColumnOrderGrid();
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

        private void UpdateColumnOrderGrid()
        {
            
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
            UpdateColumnOrderGrid();
        }

        private void UpdateFileNameTab()
        {
            if (SR.Surveys.Count == 0)
                return;

            ReportSurvey primary = SR.PrimarySurvey();
            string mainSource = primary.SurveyCode;
            string secondSources = "";

            if (primary.Backend != DateTime.Today)
                mainSource += " on " + primary.Backend;


            foreach (ReportSurvey o in SR.NonPrimarySurveys())
            {
                secondSources += o.SurveyCode;
                if (o.Backend != DateTime.Today)
                {
                    secondSources += " on " + o.Backend;
                }

                secondSources += ", ";
            }

            secondSources = Utilities.TrimString(secondSources, ", ");

            txtMainSource.Text = mainSource;
            txtSecondSources.Text = secondSources;


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


        #region Filters Tab
        // Add the selected prefix to the Current Survey's prefix list and refresh the Prefix listbox
        private void AddPrefix(object sender, EventArgs e)
        {
           
        }

        // Remove the selected prefix from the Current Survey's prefix list and refresh the Prefix listbox
        private void RemovePrefix(object sender, EventArgs e)
        {
            
        }

        private void AddVarName_Click(object sender, EventArgs e)
        {
            
        }

        private void RemoveVarName_Click(object sender, EventArgs e)
        {
           
        }

        private void AddHeading(object sender, EventArgs e)
        {

          

        }

        private void RemoveHeading(object sender, EventArgs e)
        {
           
        }

        private void QuestionFilter_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            filterBy = Convert.ToInt32(r.Tag);

            if (!r.Checked) return;

           

            switch (filterBy)
            {
                case 1:
                   

                    break;
                case 2:
                    

                    break;
                case 3:
                   
                    break;

            }
        }

        #endregion

        #region Fields Tab

        /// <summary>
        /// Adds the selected items in the list to the current survey's standard field list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StdFields_Click(object sender, EventArgs e)
        {
            CurrentSurvey.StdFieldsChosen.Clear();
            
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
            ShowTranslationSubsetTableOption();
            UpdateReportColumns(sender, e);
        }

        /// <summary>
        /// Adds the selected items in the list to the current survey's comment field list. The list is cleared first, then the selected items are added back.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentFields_Click(object sender, EventArgs e)
        {
            
        }

        

        

        

        private void RoutingStyle_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton r = sender as RadioButton;
            int sel = Convert.ToInt32(r.Tag);

            CurrentSurvey.RoutingFormat = (RoutingStyle)sel;
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

        #region Formatting Tab

        

        private void TableFormat_CheckedChanged(object sender, EventArgs e)
        {
            ShowTranslationSubsetTableOption();
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







    }
}
