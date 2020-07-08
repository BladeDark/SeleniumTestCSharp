using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumCSharpTest.Pages;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace SeleniumCSharpTest.Tests
{
    [Binding]
    public class LoginTest : ParentTest
    {

        [Given(@"I am on website")]
        public void GivenIAmOnWebsite()
        {
            var url = "https://test-api.worldticket.net/ui/sms5-single/sms-systests-fork1/";
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            logger.Info($"Open url=>{url}");


        }

        [Given(@"I login on the website")]
        public void GivenILoginOnTheWebsite()
        {
            LandingPage landingPage = new LandingPage(Driver);
            landingPage.ValidLogin();
            HomePage homePage = new HomePage(Driver);
            homePage.SearchRecordLocator();
        }



        /*[ClassInitialize]
        public static void RunBeforeAllOfTheTestMethodsStarted(TestContext testContext)
        {
            _testContext = testContext;
            Trace.Write("I will run one time before all the tests in the class started");
        }*/


    }
}
