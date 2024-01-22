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
    public partial class CommentOptions : Form
    {
        ReportSurvey TheSurvey;
        /// <summary>
        /// 
        /// </summary>
        public CommentOptions(ReportSurvey survey)
        {
            InitializeComponent();
            TheSurvey = survey;

            LoadLists();

            LoadSurveyOptions();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SaveSelections();

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadLists()
        {
            List<QuestionComment> comments = DBAction.GetQuesComments(TheSurvey);

            if (comments == null)
                return;
            var types = comments.GroupBy(x => x.NoteType.ID).Select(grp => grp.ToList()).ToList();

            foreach (var type in types)
            {
                lstType.Items.Add(type[0].NoteType.TypeName);
            }

            var authors = comments.OrderBy(x => x.Author.Name).GroupBy(x => x.Author.ID).Select(grp => grp.ToList()).ToList();

            foreach (var author in authors)
            {
                lstAuthor.Items.Add(author[0].Author);
            }

            var authority = comments.OrderBy(x => x.SourceName).GroupBy(x => x.SourceName).Select(grp => grp.ToList()).ToList();

            foreach (var author in authority)
            {
                lstAuthority.Items.Add(author[0].SourceName);
            }
        }

        private void LoadSurveyOptions()
        {
            foreach (string s in TheSurvey.ContentOptions.CommentOptions.CommentFields)
            {
                lstType.SetSelected(lstType.FindStringExact(s), true);
            }

            foreach (Person p in TheSurvey.ContentOptions.CommentOptions.CommentAuthors)
            {
                lstAuthor.SetSelected(lstAuthor.FindStringExact(p.Name), true);
            }

            foreach (string s in TheSurvey.ContentOptions.CommentOptions.CommentSources)
            {
                lstAuthor.SetSelected(lstAuthority.FindStringExact(s), true);
            }

            if (TheSurvey.ContentOptions.CommentOptions.CommentDate != null)
                dtpCommentsSince.Value = TheSurvey.ContentOptions.CommentOptions.CommentDate.Value;

            if (!string.IsNullOrEmpty(TheSurvey.ContentOptions.CommentOptions.CommentText))
                txtCommentFilter.Text = TheSurvey.ContentOptions.CommentOptions.CommentText;
        }

        private void SaveSelections()
        {
            foreach (string type in lstType.SelectedItems)
                TheSurvey.ContentOptions.CommentOptions.CommentFields.Add(type);

            foreach (Person author in lstAuthor.SelectedItems)
                TheSurvey.ContentOptions.CommentOptions.CommentAuthors.Add(author);

            foreach (string author in lstAuthority.SelectedItems)
                TheSurvey.ContentOptions.CommentOptions.CommentSources.Add(author);

            if (dtpCommentsSince.Checked)
                TheSurvey.ContentOptions.CommentOptions.CommentDate = dtpCommentsSince.Value;

            if (!string.IsNullOrEmpty(txtCommentFilter.Text))
                TheSurvey.ContentOptions.CommentOptions.CommentText = txtCommentFilter.Text;
        }
        
    }
}
