using AutoFramework.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.Pages
{
    internal class ServicePage : BasePage
    {
        //public ServicePage(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //}

        [FindsBy(How = How.CssSelector, Using = ".help-content")]
        private IWebElement AccountSettingEle { get; set; }

        public bool IsAccountSettingEleDisplayed()
        {
            return AccountSettingEle.Displayed;
        }
    }
}
