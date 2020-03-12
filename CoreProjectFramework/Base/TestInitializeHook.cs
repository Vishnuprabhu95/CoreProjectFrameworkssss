using AutoFramework.Config;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;

namespace AutoFramework.Base
{
    public class TestInitializeHook : BaseStep
    {

        //public readonly BrowserType Browser;

        //public TestInitializeHook(BrowserType browser)
        //{
        //    Browser = browser;
        //}

        public readonly ParallelConfig _parallelConfig;

        public TestInitializeHook(ParallelConfig parallelConfig) : base(parallelConfig)
        {
            _parallelConfig = parallelConfig;
        }


        public void InitializeSettings()
        {
            //Set all the settings for the framework
            ConfigReader.SetFrameworkSettings();

            //Set Log Helper
            //LogHelpers.CreateLogFile();


            string EnvBrw = Environment.GetEnvironmentVariable("Browser");
            //string URL = Environment.GetEnvironmentVariable("url");
            if (EnvBrw == null)
            {
                switch (Settings.BrowserUsed)
                {
                    case "Chrome":
                        //Open the browser
                        OpenBrowser(BrowserType.Chrome);
                        Console.WriteLine("Chrome");
                        break;
                    case "Firefox":
                        //Open the browser
                        OpenBrowser(BrowserType.Firefox);
                        Console.WriteLine("Firefox");
                        break;
                        //default:
                        //    //Open the browser
                        //    OpenBrowser(BrowserType.Chrome);
                        //    Console.WriteLine("default browser");
                        //    break;
                }
            }
            else
            {
                switch (EnvBrw)
                {
                    case "Chrome":
                        //Open the browser
                        OpenBrowser(BrowserType.Chrome);
                        Console.WriteLine("Chrome");
                        break;
                    case "Firefox":
                        //Open the browser
                        OpenBrowser(BrowserType.Firefox);
                        Console.WriteLine("Firefox");
                        break;
                        //default:
                        //    //Open the browser
                        //    OpenBrowser(BrowserType.Chrome);
                        //    Console.WriteLine("default browser");
                        //    break;
                }
            }
            


            


        }

        private void OpenBrowser(BrowserType browserType )
        {
            //DesiredCapabilities cap = new DesiredCapabilities();

            switch (browserType)
            {
                case BrowserType.InternetExplorer:
                    _parallelConfig.Driver = new InternetExplorerDriver();
                    //DriverContext.Browser = new Browser(_parallelConfig.Driver);
                    //DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Firefox:
                    _parallelConfig.Driver = new FirefoxDriver();
                    //DriverContext.Browser = new Browser(_parallelConfig.Driver);
                    //DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                case BrowserType.Chrome:
                    ////DesiredCapabilities cap = new DesiredCapabilities();
                    //cap.SetCapability(CapabilityType.BrowserName, "Chrome");
                    //cap.SetCapability(CapabilityType.Platform, new Platform(PlatformType.Windows));
                    //var binary = new ChromeDriver(@"C:\Users\VISHNU\Downloads\chromedriver_win32 (1)\chromedriver.exe");
                    ////var profile = new ChromeProfile();                         

                    _parallelConfig.Driver = new ChromeDriver();
                    //DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
                default:
                    _parallelConfig.Driver = new ChromeDriver();
                    //DriverContext.Browser = new Browser(_parallelConfig.Driver);
                    //DriverContext.Browser = new Browser(DriverContext.Driver);
                    break;
            }

            //_parallelConfig.Driver = new RemoteWebDriver(new Uri("https://localhost::4444/wd/hub"), cap);
        }


 

        
    }
}
