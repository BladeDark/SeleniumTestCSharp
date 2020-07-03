using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumCSharpTest.Pages;
using System.Diagnostics;
using System.Threading;

namespace SeleniumCSharpTest.Tests
{
    [TestClass]
    public class LoginTest : ParentTest
    {
  
        [TestMethod]
        public void LoginScenario()
        {
          
            LandingPage landingPage = new LandingPage(Driver);
            landingPage.ValidLogin();
            HomePage homePage = new HomePage(Driver);
            homePage.SearchRecordLocator();

        }

        [ClassInitialize]
        public static void RunBeforeAllOfTheTestMethodsStarted(TestContext testContext)
        {
            _testContext = testContext;
            Trace.Write("I will run one time before all the tests in the class started");
        }


    }
}
