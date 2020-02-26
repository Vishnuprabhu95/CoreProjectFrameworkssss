using AutoFramework.Base;
using AutoFramework.Extensions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest.Pages
{
    internal class LoginPage : BasePage
    {
        //public LoginPage(ParallelConfig parallelConfig) : base(parallelConfig)
        //{
        //}

        ////Intialize page
        //public LoginPage(IWebDriver driver) : base(driver)
        //{

        //}


        [FindsBy(How = How.Name, Using = "email")]
        private IWebElement UserNameEle{ get; set;}

        [FindsBy(How = How.Id, Using = "continue")]
        private IWebElement continueEle { get; set; }

        [FindsBy(How = How.Id, Using = "ap_password")]
        private IWebElement passwordEle { get; set; }

        [FindsBy(How = How.Id, Using = "signInSubmit")]
        private IWebElement signInEle { get; set; }


        public void userName(string user)
        {
            DriverContext.Driver.FindElement(By.Id("nav-signin-tooltip")).Click();
            UserNameEle.SendKeys(user);
        }
        public void continueClick()
        {
            continueEle.Click();
        }
        public void password()
        {
            passwordEle.SendKeys("hatelife");
        }
        public AuthorizationPage signIn()
        {
            signInEle.Click();
            return new AuthorizationPage();
        }

    }
}
