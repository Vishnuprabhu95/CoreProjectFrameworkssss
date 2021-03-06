﻿using AutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using AutomationTest.Pages;

namespace AutomationTest.Scenarios.NewRelease.StepDefinition
{
    [Binding]
    public class NewReleaseSteps : BaseStep    
    {
        private readonly ParallelConfig _parallelConfig;
        public NewReleaseSteps(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }

        [When(@"the user clicks new release tab")]
        public void WhenTheUserClicksNewReleaseTab()
        {
            _parallelConfig.CurrentPage.As<HomePage>().ClickNewReleaseEle();
        }
        
    }
}
