using AutoFramework.Base;
using AutoFramework.Config;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Tracing;

namespace AutomationTest
{
    [Binding]
    public class HookInitialize : TestInitializeHook
    {
        //private readonly ParallelConfig _parallelConfig;
        //private readonly FeatureContext _featureContext;
        //private readonly ScenarioContext _scenarioContext;


        //  public HookInitialize() : base(BrowserType.Chrome)
        //{
        //    InitializeSettings();
        //}

        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static AventStack.ExtentReports.ExtentReports extent;

        //public HookInitialize(ParallelConfig parallelConfig, FeatureContext featureContext, ScenarioContext scenarioContext) : base(parallelConfig)
        //{
        //    _parallelConfig = parallelConfig;
        //    _featureContext = featureContext;
        //    _scenarioContext = scenarioContext;
        //}

        //private static KlovReporter klov;

        //public HookInitialize()
        //{
        //    InitializeSettings();
        //}

        [AfterStep]
        public void AfterEachStep(ScenarioContext ScenarioContext)
        {
            ////            var StepInfo = ScenarioContext.StepContext.StepInfo;
            ////            var StepType = StepInfo.StepInstance.StepDefinitionType.ToString();

            ////            ExtentTest StepNode = null;
            ////            switch(StepType)
            ////            {
            ////                case "Given":
            ////StepNode = scenario.CreateNode(StepInfo.Text);
            ////                break;
            ////                case "When":
            ////StepNode = scenario.CreateNode(StepInfo.Text);
            ////                    break;
            ////                case "Then":
            ////StepNode = scenario.CreateNode(StepInfo.Text);
            ////                    break;
            ////            }

            ////            if(ScenarioContext.ScenarioExecutionStatus != ScenarioExecutionStatus.OK)
            ////{
            ////                Screenshot Ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ////                String Screenshot = Ss.AsBase64EncodedString;

            ////                IList FailTypes = new ArrayList
            ////{
            ////                    ScenarioExecutionStatus.BindingError,
            ////ScenarioExecutionStatus.TestError,
            ////ScenarioExecutionStatus.UndefinedStep
            ////};

            ////                if(ScenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
            ////{
            ////                    scenario.Skip("This Step Has Been Skipped And Not Executed.", MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot).Build());
            ////                }
            ////                else if(FailTypes.Contains(ScenarioContext.ScenarioExecutionStatus))
            ////                {
            ////                    scenario.Fail(ScenarioContext.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromBase64String(Screenshot).Build());
            ////                }
            ////            }


            //var stepName = ScenarioContext.Current.StepContext.StepInfo.Text;
            //var featureName = FeatureContext.Current.FeatureInfo.Title;
            //var scenarioName = ScenarioContext.Current.ScenarioInfo.Title;

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            //Console.WriteLine(ScenarioContext.Current.TestError);
            //Console.WriteLine(ScenarioContext.Current.ScenarioExecutionStatus);
            ////FOr pending status in extentreport
            //PropertyInfo PInfo = typeof(ScenarioContext).GetProperty("ScenarioExecutionStatus", BindingFlags.Instance | BindingFlags.Public);
            //MethodInfo Getter = PInfo.GetGetMethod(nonPublic: true);
            //Object TestResult = Getter.Invoke(ScenarioContext.Current, null);

            if (ScenarioContext.Current.ScenarioExecutionStatus.ToString().Contains("OK"))
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else 
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                //else if (stepType == "And")
                //    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException);
            }
            /////*((ScenarioContext.Current.TestError.ToString()).Contains("failed"))*/
            //else if (ScenarioContext.Current.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
            //{
            //    if (stepType == "Given")
            //        scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("This Step Has Been Skipped And Not Executed.");
            //    else if (stepType == "When")
            //        scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("This Step Has Been Skipped And Not Executed.");
            //    else if (stepType == "Then")
            //        scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("This Step Has Been Skipped And Not Executed.");
            //    //else if (stepType == "And")
            //    //    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            //}

        }

        [AfterScenario]
        public void Close()
        {
            DriverContext.Driver.Close();
            DriverContext.Driver.Dispose();
        }

        [BeforeScenario]
        public void TestInitializer()
        {
            //HookInitialize init = new HookInitialize();
            //TestInitializeHook init = new TestInitializeHook();
            InitializeSettings();
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);       

        }
        [BeforeFeature]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test start
            string _logFileName = string.Format("{0:yyyy-dd-M--HH-mm-ss}", DateTime.Now);

            string dir = @"C:\\dev\\ExtentReport\\ER--"+ _logFileName;

            if (Directory.Exists(dir))
            {
               
            }
            else
            {
                Directory.CreateDirectory(dir);
                
            }

            var htmlReporter = new ExtentHtmlReporter(@"C:\\dev\\CoreProjectFramework\\ExtentReport\\ER--"+ _logFileName + "\\");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            //Attach report to reporter
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

            //Need DB server to view the extent report

            //klov = new KlovReporter();

            //klov.InitMongoDbConnection("localhost", 27017);
            //klov.ProjectName = "AutomationProject";
            //klov.ReportName = "Vishnu" + DateTime.Now.ToString();

            //extent.AttachReporter(htmlReporter, klov);

        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [AfterStep]
        public void AfterWebTest()
        {
            if (!ScenarioContext.Current.ScenarioExecutionStatus.ToString().Contains("OK"))
            {
                TakeScreenshot(DriverContext.Driver);
            }
        }

        
        private void TakeScreenshot(IWebDriver driver)
        {
            try
            {
                string fileNameBase = string.Format("error_{0}_{1}_{2}",
                                                    FeatureContext.Current.FeatureInfo.Title.ToIdentifier(),
                                                    ScenarioContext.Current.ScenarioInfo.Title.ToIdentifier(),
                                                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine("C:\\dev\\CoreProjectFramework\\", "Failed_Test_Screenshot");
                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                string pageSource = driver.PageSource;
                string sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath, OpenQA.Selenium.ScreenshotImageFormat.Png);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }

            //try
            //{
            //    //Initialize Extent report before test start
            //    string _logFileName = string.Format("{0:yyyy-dd-M--HH-mm-ss}", DateTime.Now);

            //    string dir = @"C:\\dev\\Screenshots";

            //    if (Directory.Exists(dir))
            //    {

            //    }
            //    else
            //    {
            //        Directory.CreateDirectory(dir);

            //    }

            //    Screenshot file = ((ITakesScreenshot)DriverContext.Driver).GetScreenshot();
            //    file.SaveAsFile(@"C:\\dev\\Screenshots\\FS--"+ ScenarioContext.Current.ScenarioInfo.Title+"--"+_logFileName+".png");
            //    //Screenshot file = ((ITakesScreenshot)driver).GetScreenshot();
            //    //byte[] image = file.AsByteArray;

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Error while taking screenshot: {0}", ex);
            //}
        }
    }
}
