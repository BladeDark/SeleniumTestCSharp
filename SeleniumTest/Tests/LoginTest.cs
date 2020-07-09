using AutomationResources;
using OpenQA.Selenium;
using SeleniumTest.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{
    [Binding]
    public class LoginTest
    {
        private IWebDriver _driver;
        private LandingPage landingPage => new LandingPage(_driver);
        private HomePage homePage => new HomePage(_driver);

        public LoginTest(IWebDriver driver)
        {
            _driver = driver;
        }


        [Given(@"I am on website")]
        public void GivenIAmOnWebsite()
        {

            _driver.Manage().Window.Maximize();
            var url = "https://test-api.worldticket.net/ui/sms5-single/sms-systests-fork1/";
            _driver.Navigate().GoToUrl(url);

        }

        [When(@"I login on the website")]
        public void WhenILoginOnTheWebsite()
        {
          
            landingPage.ValidLogin();
            homePage.SearchRecordLocator();
        }

    }
}
