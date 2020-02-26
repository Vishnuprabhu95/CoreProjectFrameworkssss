using AutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AutomationTest.Pages;
using AutoFramework.Config;

namespace AutomationTest.Scenarios
{
    [Binding]
    public class ExtendedSteps : BaseStep
    {
        //private readonly ParallelConfig _parallelConfig;
        //public ExtendedSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //    _parallelConfig = parallelConfig;
        //}


        [Given(@"the user is on application home page")]
        public void GivenTheUserIsOnApplicationHomePage()
        {
            NavigateSite();
            CurrentPage = new HomePage();
        }

        public void NavigateSite()
        {
            DriverContext.Driver.Navigate().GoToUrl(Settings.AUT);
        }
    }
}
