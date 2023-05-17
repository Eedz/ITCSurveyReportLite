using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITCLib;
namespace ITCSurveyReportLite
{
    /// <summary>
    /// 
    /// </summary>
    public static class Globals
    {
        /// <summary>
        /// 
        /// </summary>
        public static List<Survey> FullSurveyList;

        /// <summary>
        /// 
        /// </summary>
        public static void CreateWorld()
        {
            FullSurveyList = new List<Survey>(DBAction.GetAllSurveysInfo());
        }
    }
}
