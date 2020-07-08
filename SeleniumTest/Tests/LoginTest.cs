using AutomationResources;
using SeleniumTest.Pages;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{
    [Binding]
    public class LoginTest : ParentTest
    {
        public LoginTest()
        {
            
        }


        [Given(@"I am on website")]
        public void GivenIAmOnWebsite()
        {
           


        }

        [When(@"I login on the website")]
        public void WhenILoginOnTheWebsite()
        {
            LandingPage landingPage = new LandingPage(Driver);
            landingPage.ValidLogin();
            HomePage homePage = new HomePage(Driver);
            homePage.SearchRecordLocator();
        }

    }
}
