using AutoFramework.Base;
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
    internal class HomePage : BasePage
    {
        //public HomePage(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //}

        private IWebElement BestSellerEle()
        {
             return DriverContext.Driver.FindElement(By.XPath("//a[text()='Best Sellers']")); 
        }
        
        private IWebElement NewReleaseEle
        {
           get { return DriverContext.Driver.FindElement(By.XPath("//*[@id='nav-xshop']/a[3]"));  }
        }

        private IWebElement SearchEle
        {
            get { return DriverContext.Driver.FindElement(By.Id("twotabsearchtextbox")); }
        }

        private IWebElement SearchButtonEle
        {
            get { return DriverContext.Driver.FindElement(By.ClassName("nav-input")); }
        }

        private IWebElement NoResultEle
        {
            get { return DriverContext.Driver.FindElement(By.XPath("//*[@id='search']/div[1]/div[2]/div/span[3]/span/div/div/div[1]/span[1]")); }
        }
        //[FindsBy(How = How.XPath, Using = "//*[@id='nav-xshop']/a[1]")]
        //private IWebElement BestSellerEle { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='nav-xshop']/a[3]")]
        //private IWebElement NewReleaseEle { get; set; }

        //[FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
        //private IWebElement SearchEle { get; set; }

        //[FindsBy(How = How.ClassName, Using = "nav-input")]
        //private IWebElement SearchButtonEle { get; set; }

        //[FindsBy(How = How.XPath, Using = "//*[@id='search']/div[1]/div[2]/div/span[3]/span/div/div/div[1]/span[1]")]
        //private IWebElement NoResultEle { get; set; }

        public BestSellerPage ClickBestSellerEle()
        {
            BestSellerEle().Click();
            return new BestSellerPage();
        }

        public BestSellerPage ClickNewReleaseEle()
        {
            NewReleaseEle.Click();
            return new BestSellerPage();
        }

        public void Search(string term)
        {
            SearchEle.SendKeys(term);
            SearchButtonEle.Click();
        }

        public bool NoResultEleDisplayed()
        {
            WebDriverWait wait = new WebDriverWait(DriverContext.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='search']/div[1]/div[2]/div/span[3]/span/div/div/div[1]/span[1]")));
            return NoResultEle.Displayed;
        }

    }
}
