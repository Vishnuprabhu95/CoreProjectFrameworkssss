using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Base
{
    public class Browser
    {
        private readonly DriverContext driverContext;

        //private readonly IWebDriver _driver;

        public Browser(DriverContext driver)
        {
            driverContext = driver;
        }

        public BrowserType Type { get; set; }

      
    }

    public enum BrowserType
        {
            InternetExplorer,
            Firefox,
            Chrome
        }






    
}
