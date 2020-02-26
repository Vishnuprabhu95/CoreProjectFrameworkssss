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
    internal class AuthorizationPage : BasePage
    {
        //public AuthorizationPage(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //}

        ////Intialize page
        //public AuthorizationPage(IWebDriver driver) : base(driver)
        //{

        //}


        [FindsBy(How = How.CssSelector, Using = "div.a-section > a.a-link-normal")]
        private IWebElement ServiceEle { get; set; }

        public ServicePage ServiceEleClick()
        {
            ServiceEle.Click();
            return new ServicePage();
        }

    }
}
