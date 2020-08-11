using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using SeleniumTest.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{
    [Binding]
    class HomeTest : ParentTest
    {
        private LandingPage LandingPage => new LandingPage(driver);
        private HomePage HomePage => new HomePage(driver);
        public HomeTest(IWebDriver driver) : base(driver) {}

        [When(@"I login on the website")]
        public void WhenILoginOnTheWebsite()
        {
            LandingPage.ValidLogin();
            HomePage.SearchRecordLocator();
            scenarioContext["Test"] = "Test";
        }
    }
}
