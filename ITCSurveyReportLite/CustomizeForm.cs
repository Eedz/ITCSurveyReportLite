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
    /// Form for specifying which parts of the survey to include.
    /// </summary>
    public partial class CustomizeForm : Form
    {

        enum FilterBy { Prefix, Qnum, Heading, Product }

        ReportSurvey Survey;
        List<SurveyQuestion> SurveyContent;
        FilterBy FilterType;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="survey"></param>
        public CustomizeForm(ReportSurvey survey)
        {
            InitializeComponent();

            Survey = survey;
            SurveyContent = new List<SurveyQuestion>(DBAction.GetSurveyQuestions(survey));

            this.Text = "Content for " + survey.SurveyCode + " from " + survey.Backend.ToString("d");
            lblSurvey.Text = survey.SurveyCode + " Content";
            lblSurvey.Left = (this.Width - lblSurvey.Width) / 2;

            cmdShowLowest.Text = char.ConvertFromUtf32(0x2193);
            cmdShowMax.Text = char.ConvertFromUtf32(0x2191);

            for (int i = 0; i < lstWordingFields.Items.Count; i++)
                lstWordingFields.SetSelected(i, true);

            SelectFilters();
            
            LoadVarNames();

            SelectVarNames();
        }

        #region Events 
        private void rbPrefix_Click(object sender, EventArgs e)
        {
            FilterType = FilterBy.Prefix;
            UpdateFilterType();
        }

        private void rbQnum_Click(object sender, EventArgs e)
        {
            FilterType = FilterBy.Qnum;
            UpdateFilterType();
        }

        private void rbHeading_Click(object sender, EventArgs e)
        {
            FilterType = FilterBy.Heading;
            UpdateFilterType();
        }

        private void rbProduct_Click(object sender, EventArgs e)
        {
            FilterType = FilterBy.Product;
            UpdateFilterType();
        }
        private void cmdOK_Click(object sender, EventArgs e)
        {
            SaveFilter();
            SaveFieldInfo();
            Survey.RemoveOtherSpecify = chkRemoveOtherSpecify.Checked;

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lstFilterType_Click(object sender, EventArgs e)
        {
            LoadVarNames();
            SelectVarNames();
        }

        private void txtLowerQnum_TextChanged(object sender, EventArgs e)
        {
            UpdateQnumRangeVars();
        }

        private void txtUpperQnum_TextChanged(object sender, EventArgs e)
        {
            UpdateQnumRangeVars();
        }

        private void cmdShowLowest_Click(object sender, EventArgs e)
        {
            txtLowerQnum.Text = SurveyContent.Min(x => x.Qnum);
        }

        private void cmdShowMax_Click(object sender, EventArgs e)
        {
            txtUpperQnum.Text = SurveyContent.Max(x => x.Qnum);
        }

        #endregion

        #region Methods

        private void UpdateFilterType()
        {
            lstFilterType.Items.Clear();
            panelQnumRange.Visible = FilterType == FilterBy.Qnum;
            lstFilterType.Enabled = FilterType != FilterBy.Qnum;
            switch (FilterType)
            {
                case FilterBy.Prefix:
                    LoadPrefixes();
                    break;
                case FilterBy.Qnum:
                    LoadQnumRange();
                    txtLowerQnum.Focus();
                    break;
                case FilterBy.Heading:
                    LoadHeadings();
                    break;
                case FilterBy.Product:
                    LoadProducts();
                    break;
            }
        }

        private void LoadPrefixes()
        {
            var prefixes = SurveyContent.OrderBy(y => y.VarName.RefVarName).GroupBy(x => x.VarName.Prefix).Select(grp => grp.ToList()).ToList();
            foreach (var grp in prefixes)
            {
                if (!string.IsNullOrEmpty(grp[0].VarName.Prefix)  && !grp[0].VarName.Prefix.StartsWith("Z"))
                    lstFilterType.Items.Add(grp[0].VarName.Prefix);
            }

        }

        private void LoadQnumRange()
        {
            txtLowerQnum.Text = SurveyContent.Min(x => x.Qnum);
            txtUpperQnum.Text = SurveyContent.Max(x => x.Qnum);
        }

        private void LoadHeadings()
        {
            foreach (SurveyQuestion q in SurveyContent)
            {
                if (q.IsHeading() || q.IsSubHeading())
                    lstFilterType.Items.Add(q.PreP + " - " + q.VarName.RefVarName);
            }
        }

        private void LoadProducts()
        {
            var products = SurveyContent.GroupBy(x => x.VarName.Product.LabelText).Select(grp => grp.ToList()).ToList();
            foreach (var grp in products)
            {
                if (!string.IsNullOrEmpty(grp[0].VarName.Product.LabelText))
                    lstFilterType.Items.Add(grp[0].VarName.Product.LabelText);
            }
        }

        private void LoadVarNames()
        {
            // load varname list based on what is selected
            List<SurveyQuestion> varList = new List<SurveyQuestion>();
            switch (FilterType)
            {
                case FilterBy.Prefix:
                    foreach (string prefix in lstFilterType.SelectedItems)
                        varList.AddRange(SurveyContent.Where(x => x.VarName.RefVarName.StartsWith(prefix)));
                    break;
                case FilterBy.Heading:
                    varList = GetHeadingVarNames();
                    break;
                case FilterBy.Product:
                    foreach (string product in lstFilterType.SelectedItems)
                        varList.AddRange(SurveyContent.Where(x => x.VarName.Product.LabelText.Equals(product)));
                    break;
            }

            lstVarName.ValueMember = "VarName.RefVarName";
            lstVarName.DisplayMember = "VarName.RefVarName";
            lstVarName.DataSource = varList;
            lstVarName.SelectedItem = null;
        }

        private void SelectFilters()
        {
            if (Survey.Prefixes.Count > 0)
            {
                rbPrefix.Checked = true;
                FilterType = FilterBy.Prefix;
                UpdateFilterType();
                foreach (string p in Survey.Prefixes)
                {
                    int index = lstFilterType.FindStringExact(p);
                    lstFilterType.SetSelected(index, true);
                }

            }
            else if (Survey.QRangeHigh != 0)
            {
                rbQnum.Checked = true;
                FilterType = FilterBy.Qnum;
                UpdateFilterType();
                txtLowerQnum.Text = Survey.QRangeLow.ToString();
                txtUpperQnum.Text = Survey.QRangeHigh.ToString();
            }
            else if (Survey.Headings.Count > 0)
            {
                rbHeading.Checked = true;
                FilterType = FilterBy.Heading;
                UpdateFilterType();
                foreach (Heading h in Survey.Headings)
                {
                    int index = lstFilterType.FindStringExact(h.PreP + " - " + h.VarName.RefVarName);
                    lstFilterType.SetSelected(index, true);
                }
            }
            else
            {
                rbPrefix.Checked = true;
                FilterType = FilterBy.Prefix;
                UpdateFilterType();
            }
        }

        private void SelectVarNames()
        {
            foreach(VariableName v in Survey.Varnames)
            {
                int index = lstVarName.FindStringExact(v.RefVarName);
                lstVarName.SetSelected(index, true);
            }
        }

        private void SaveFilter()
        {
            Survey.Prefixes.Clear();
            Survey.Headings.Clear();
            Survey.Products.Clear();
            Survey.QRangeHigh = 0;
            Survey.QRangeLow = 0;

            // apply filter choices to provided survey object
            switch (FilterType)
            {
                case FilterBy.Prefix:
                    Survey.Prefixes.AddRange(lstFilterType.SelectedItems.Cast<string>().ToList());
                    break;
                case FilterBy.Heading:
                    foreach (string s in lstFilterType.SelectedItems)
                        foreach (SurveyQuestion sq in SurveyContent)
                            if (sq.VarName.RefVarName.Equals(s.Substring(s.LastIndexOf(" - ") + 3)))
                            {
                                Heading h = new Heading(sq.Qnum, sq.PreP);
                                h.VarName = new VariableName(sq.VarName.VarName);
                                Survey.Headings.Add(h);
                            }
                    break;
                case FilterBy.Qnum:
                    if (Int32.TryParse(txtLowerQnum.Text, out int low))
                        Survey.QRangeLow = low;

                    if (Int32.TryParse(txtUpperQnum.Text, out int high))
                        Survey.QRangeHigh = high;

                    break;

                case FilterBy.Product:
                    foreach (string s in lstFilterType.SelectedItems)
                        Survey.Products.Add(new ProductLabel(0, s));
                    break;

            }


            foreach (SurveyQuestion sq in lstVarName.SelectedItems)
                Survey.Varnames.Add(sq.VarName);
        }

        private void SaveFieldInfo()
        {
            Survey.StdFieldsChosen = lstWordingFields.SelectedItems.Cast<string>().ToList();
        }

        private List<SurveyQuestion> GetHeadingVarNames()
        {
            List<SurveyQuestion> varList = new List<SurveyQuestion>();
            bool inSection;
            foreach (string s in lstFilterType.SelectedItems)
            {
                inSection = false;
                string headingVar = s.Substring(s.LastIndexOf(" - ") + 3);
                foreach (SurveyQuestion sq in SurveyContent)
                {
                    string currentVar = sq.VarName.RefVarName;
                    if (sq.VarName.RefVarName.Equals(headingVar))
                    {
                        inSection = true;
                        continue;
                    }
                    else if (sq.IsHeading() && inSection)
                    {
                        break;
                    }
                    else if (sq.IsSubHeading() && headingVar.EndsWith("s") && inSection)
                    {
                        break;
                    }

                    if (inSection && !varList.Contains(sq))
                        varList.Add(sq);
                }
            }
            return varList;
        }

        private void UpdateQnumRangeVars()
        {
            List<SurveyQuestion> varList = new List<SurveyQuestion>();
          bool low = Int32.TryParse(txtLowerQnum.Text, out int lower);
            bool high = Int32.TryParse(txtUpperQnum.Text, out int upper);
            if (low && high)
                varList.AddRange(SurveyContent.Where(x => x.GetQnumValue() >= lower && x.GetQnumValue() <= upper));
            else if (low && !high)
                varList.AddRange(SurveyContent.Where(x => x.GetQnumValue() >= lower));
            else if (!low && high)
                varList.AddRange(SurveyContent.Where(x => x.GetQnumValue() <= upper));

            lstVarName.ValueMember = "VarName.RefVarName";
            lstVarName.DisplayMember = "VarName.RefVarName";
            lstVarName.DataSource = varList;
            lstVarName.SelectedItem = null;
        }

        #endregion

        private void CustomizeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
