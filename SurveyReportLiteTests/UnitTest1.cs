using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ITCReportLib;
using DiffPlex;
using DiffPlex.Model;

namespace SurveyReportLiteTests
{
    [TestClass]
    public class DiffPlexTests
    {
        [TestMethod]
        public void DiffPlex_Character()
        {
            string original = "Coding for 4CV4 is as follows:";
            string revised = "Coding for 4CV5 is as follows:";

            Comparison c = new Comparison();
            c.SimilarWords = new string[][] { new string[0] };
            string result = c.GenerateHtmlFromDiff(original, revised);

            Assert.IsTrue(result.Equals("Coding for 4CV<del>4</del><ins>5</ins> is as follows:"));
        }
    }
}
