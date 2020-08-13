using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{
    public abstract class ParentTest
    {
        protected IWebDriver driver;

        protected ScenarioContext scenarioContext;

        public ParentTest(IWebDriver driver)
        {
            this.driver = driver;
        }

        [BeforeScenario]
        public void ScenarioContextInjection(ScenarioContext scenarioContextInject)
        {
            scenarioContext = scenarioContextInject;
        }
    }
}
