using System;
using CommunityToolkit.Mvvm;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITCLib;
using System.Data;
using ITCReportLib;

namespace SurveyReportLiteTests
{
    [TestClass]
    public class SRLColumnTesting
    {
        [TestMethod]
        public void SingleVarName()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            s.AddQuestion(new SurveyQuestion("AA000", "001"));

            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameSingleTranslation()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");
            q.Translations.Add(new Translation()
            {
                LanguageName = new Language() { LanguageName = "TestLang" },
                TranslationText = "Translation Text"
            });
            s.AddQuestion(q);
            s.ContentOptions.TranslationOptions.TransFields.Add("TestLang");
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasTranslationCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " " + s.ContentOptions.TranslationOptions.TransFields[0]);
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasTranslationCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameTwoTranslation()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");
            q.Translations.Add(new Translation()
            {
                LanguageName = new Language() { LanguageName = "TestLang" },
                TranslationText = "Translation Text"
            });
            q.Translations.Add(new Translation()
            {
                LanguageName = new Language() { LanguageName = "TestLang2" },
                TranslationText = "Translation Text"
            });
            s.AddQuestion(q);
            s.ContentOptions.TranslationOptions.TransFields.Add("TestLang");
            s.ContentOptions.TranslationOptions.TransFields.Add("TestLang2");
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasTranslationCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " " + s.ContentOptions.TranslationOptions.TransFields[0]);
            bool hasTranslationCol2 = dt.Columns[4].ColumnName.Equals(s.SurveyCode + " " + s.ContentOptions.TranslationOptions.TransFields[1]);
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasTranslationCol && hasTranslationCol2;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameFilters()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");
            
            s.AddQuestion(q);
            s.FilterCol = true;
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasFilterCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " Filters");
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasFilterCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameDomain()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");

            s.AddQuestion(q);
            s.DomainLabelCol = true;
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasDomainCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " Domain");
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasDomainCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameTopic()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");

            s.AddQuestion(q);
            s.TopicLabelCol = true;
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasTopicCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " Topic");
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasTopicCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameContent()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");

            s.AddQuestion(q);
            s.ContentLabelCol = true;
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasContentCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " Content");
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasContentCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameProduct()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");

            s.AddQuestion(q);
            s.ProductLabelCol = true;
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasProductCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " Product");
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasProductCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }

        [TestMethod]
        public void SingleVarNameVarLabel()
        {
            SurveyReport SR = new SurveyReport();

            ReportSurvey s = new ReportSurvey("TT1");
            SurveyQuestion q = new SurveyQuestion("AA000", "001");

            s.AddQuestion(q);
            s.VarLabelCol = true;
            SR.AddSurvey(s);

            SR.GenerateReport();

            DataTable dt = SR.ReportTable;

            bool hasQnumCol = dt.Columns[0].ColumnName.Equals("Qnum");
            bool hasVarNameCol = dt.Columns[1].ColumnName.Equals("VarName");
            bool hasQuestionCol = dt.Columns[2].ColumnName.Equals(s.SurveyCode);
            bool hasVarLabelCol = dt.Columns[3].ColumnName.Equals(s.SurveyCode + " VarLabel");
            bool hasRows = dt.Rows.Count == s.Questions.Count;

            bool hasAllColumns = hasQnumCol && hasVarNameCol && hasQuestionCol && hasVarLabelCol;

            Assert.IsTrue(hasAllColumns && hasRows);
        }
    }
}
