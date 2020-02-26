using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.Pages
{
    internal class BestSellerPage : BasePage
    {
        //public BestSellerPage(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //}

        //[FindsBy(How = How.CssSelector, Using = "#zg_banner_text_wrapper")]
        //private IWebElement BestSellerTitleEle { get; set; }

        private IWebElement BestSellerTitleEle()
        {
            return DriverContext.Driver.FindElement(By.CssSelector("#zg_banner_text_wrapper"));
        }

        public string IsBestSellerEleTitleDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#zg_banner_text_wrapper")));
            return BestSellerTitleEle().GetLinkText();
        }

    }
}
