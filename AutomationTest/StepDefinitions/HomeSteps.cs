using AutoFramework.Base;
using AutoFramework.Helpers;
using TechTalk.SpecFlow;
using AutomationTest.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutomationTest.Scenarios.Home.StepDefinition
{
    [Binding]
    public sealed class HomeSteps : BaseStep
    {
        //private readonly ParallelConfig _parallelConfig;
        //public HomeSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //    _parallelConfig = parallelConfig;
        //}

        [When(@"the user clicks best seller tab")]
        public void WhenTheUserClicksBestSellerTab()
        {
            CurrentPage = CurrentPage.As<HomePage>().ClickBestSellerEle();
        }

        [Then(@"the ""(.*)"" title displays in best seller tab")]
        public void ThenTheTitleDisplaysInBestSellerTab(string title)
        {
            Assert.IsTrue((CurrentPage.As<BestSellerPage>().IsBestSellerEleTitleDisplayed()).Equals(title));
        }

        [When(@"the user performs search")]
        public void WhenTheUserPerformsSearch()
        {
            string fileName = @"C:\Users\VISHNU\source\repos\CoreProjectFramework\AutomationTest\Data\Login.xlsx";
            ExcelHelpers.PopulateInCollection(fileName);
            CurrentPage.As<HomePage>().Search(ExcelHelpers.ReadData(1, "UserName"));
        }

        [Then(@"the results page displayed")]
        public void ThenTheResultsPageDisplayed()
        {
            Assert.IsTrue(CurrentPage.As<HomePage>().NoResultEleDisplayed().Equals(true));
        }

    }
}
