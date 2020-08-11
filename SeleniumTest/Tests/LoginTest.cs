using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{
    [Binding]
    public class LoginTest : ParentTest
    {
        public LoginTest(IWebDriver driver) : base(driver) { }

        [Given(@"I am on website")]
        public void GivenIAmOnWebsite()
        {
            driver.Manage().Window.Maximize();
            var url = "https://test-api.worldticket.net/ui/sms5-single/sms-systests-fork1/";
            driver.Navigate().GoToUrl(url);
        }

    }
}
