
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
        private static ExtentReports _extent;
        private ExtentTest _featureName;
        private ExtentTest _scenario;
        public Hooks(IWebDriver driver) : base(driver) { }

        /*[BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContextInject)
        {
            _featureName = _extent.CreateTest<Feature>(featureContextInject.FeatureInfo.Title);
        }*/
        [BeforeScenario(Order = 1)]
        public void AddFeatureName(FeatureContext featureContextInject)
        {
            _featureName = _extent.CreateTest<Feature>(featureContextInject.FeatureInfo.Title);
        }

        [BeforeScenario(Order = 2)]
        public void AddScenarioName(ScenarioContext scenarioContext)
        {
            _scenario = _featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title).AssignCategory(scenarioContext.ScenarioInfo.Tags);
        }

        [BeforeTestRun]
        public static void InitializeReport()
        {
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\RAS_T\source\repos\BladeDark\SeleniumTestCSharp\index.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            _extent.Flush();
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.OK)
            {
                _scenario.ToString();
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text);

            }
            else if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.TestError)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message).Log(Status.Fail);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message).Log(Status.Fail);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message).Log(Status.Fail);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Fail(scenarioContext.TestError.Message).Log(Status.Fail);
                 
                }
            }
            else if (scenarioContext.ScenarioExecutionStatus == ScenarioExecutionStatus.StepDefinitionPending)
            {
                if (stepType == "Given")
                    _scenario.CreateNode<Given>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
                else if (stepType == "When")
                    _scenario.CreateNode<When>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
                else if (stepType == "Then")
                    _scenario.CreateNode<Then>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
                else if (stepType == "And")
                    _scenario.CreateNode<And>(scenarioContext.StepContext.StepInfo.Text).Skip("Step Definition Pending").Log(Status.Skip);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver.Close();
            driver.Quit();
        }
    }


}
