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
    public partial class TemplateSelector : Form
    {
        List<Survey> SurveyList;

        public TemplateSelector(List<Survey> surveys)
        {
            InitializeComponent();
            SurveyList = surveys;
        }

        
    }
}
