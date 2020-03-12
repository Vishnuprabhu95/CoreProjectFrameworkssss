using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Base
{
    public class ParallelConfig
    {
        public IWebDriver Driver { get; set; }

        public BasePage CurrentPage { get; set; }
    }
}
