
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{

    [Binding]
    public class Hooks : ParentTest
    {
        private static ExtentReports extent;
        public Hooks(IWebDriver driver) : base(driver) { }

        [BeforeScenario(Order = 1)]
        public void FeatureContextInjection(FeatureContext featureContextInject)
        {
            FeatureName = extent.CreateTest<Feature>(featureContextInject.FeatureInfo.Title);
        }

        [BeforeScenario(Order = 3)]
        public void AddScenarioName()
        {
            Scenario = FeatureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\RAS_T\source\repos\BladeDark\SeleniumTestCSharp\index.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            extent.Flush();
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                if (stepType == "Given")
                    Scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    Scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    Scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    Scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);

            }
            else if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                if (stepType == "Given")
                {
                    Scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException).Log(Status.Fail);
                }
                else if (stepType == "When")
                {
                    Scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.InnerException).Log(Status.Fail);
                }
                else if (stepType == "Then")
                {
                    Scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message).Log(Status.Fail);
                }
                else if (stepType == "And")
                {
                    Scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message).Log(Status.Fail);
                 
                }
            }
            else if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
            {
                if (stepType == "Given")
                    Scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
                else if (stepType == "When")
                    Scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
                else if (stepType == "Then")
                    Scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
                else if (stepType == "And")
                    Scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {

            if (scenarioContext.TestError != null)
            {
                //TakeScreenshot(_driver, featureContext, scenarioContext);

                var takesScreenshot = driver as ITakesScreenshot;
                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();
                    var tempFileName = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileNameWithoutExtension(Path.GetTempFileName())) + ".jpg";
                    screenshot.SaveAsFile(tempFileName, ScreenshotImageFormat.Png);

                    Console.WriteLine($"SCREENSHOT[ file:///{tempFileName} ]SCREENSHOT");
                }
            }

            driver.Close();
            driver.Quit();

        }

        private void CaptureScreenshotAndReturnModel(string name)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, name).Build();
        }


    }


}
