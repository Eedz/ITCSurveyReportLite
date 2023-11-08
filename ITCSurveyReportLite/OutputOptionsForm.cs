using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ITCReportLib;

namespace ITCSurveyReportLite
{
    /// <summary>
    /// 
    /// </summary>
    public partial class OutputOptionsForm : Form
    {
        SurveyBasedReport SR;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sr"></param>
        public OutputOptionsForm(SurveyBasedReport sr)
        {
            InitializeComponent();

            SR = sr;

            chkCoverPage.Checked = SR.LayoutOptions.CoverPage;
            rbTOCNone.Checked = SR.LayoutOptions.ToC == TableOfContents.None;
            rbTOCPages.Checked = SR.LayoutOptions.ToC == TableOfContents.PageNums;
            rbTOCQnums.Checked = SR.LayoutOptions.ToC == TableOfContents.Qnums;
            rbSizeLetter.Checked = SR.LayoutOptions.PaperSize == PaperSizes.Letter;
            rbSizeLegal.Checked = SR.LayoutOptions.PaperSize == PaperSizes.Legal;
            rbSize11x17.Checked = SR.LayoutOptions.PaperSize == PaperSizes.Eleven17;
            rbSizeA4.Checked = SR.LayoutOptions.PaperSize == PaperSizes.A4;
            rbFormatDOC.Checked = SR.LayoutOptions.FileFormat == FileFormats.DOC;
            rbFormatPDF.Checked = SR.LayoutOptions.FileFormat == FileFormats.PDF;

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SR.LayoutOptions.CoverPage = chkCoverPage.Checked;

            if (rbTOCNone.Checked)
                SR.LayoutOptions.ToC = TableOfContents.None;
            else if (rbTOCPages.Checked)
                SR.LayoutOptions.ToC = TableOfContents.PageNums;
            else if (rbTOCQnums.Checked)
                SR.LayoutOptions.ToC = TableOfContents.Qnums;

            if (rbSizeLetter.Checked)
                SR.LayoutOptions.PaperSize = PaperSizes.Letter;
            else if (rbSizeLegal.Checked)
                SR.LayoutOptions.PaperSize = PaperSizes.Legal;
            else if (rbSize11x17.Checked)
                SR.LayoutOptions.PaperSize = PaperSizes.Eleven17;
            else if (rbSizeA4.Checked)
                SR.LayoutOptions.PaperSize = PaperSizes.A4;

            if (rbFormatDOC.Checked)
                SR.LayoutOptions.FileFormat = FileFormats.DOC;
            else if (rbFormatPDF.Checked)
                SR.LayoutOptions.FileFormat = FileFormats.PDF;

            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        { 
            Close();
        }
    }
}
