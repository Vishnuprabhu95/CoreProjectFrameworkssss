using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFramework.Base
{
    public static class DriverContext
    {

        private static IWebDriver _driver;

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }

        //public readonly ParallelConfig _parallelConfig;

        //public DriverContext(ParallelConfig parallelConfig)
        //{
        //    _parallelConfig = parallelConfig;
        //}

        public static Browser Browser { get; set; }

        //public void GoToUrl(string url)
        //{
        //    DriverContext.Driver.Url = url;
        //}

    }
}
