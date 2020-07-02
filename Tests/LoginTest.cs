using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using PageObjects;
using System.Diagnostics;
using System.Threading;

namespace Tests
{
    [TestClass]
    public class LoginTest : ParentTest
    {
  
        [TestMethod]
        public void LoginScenario()
        {
          
            LandingPage landingPage = new LandingPage(Driver);
            landingPage.ValidLogin();
            


        }

        [ClassInitialize]
        public static void RunBeforeAllOfTheTestMethodsStarted(TestContext testContext)
        {
            _testContext = testContext;
            Trace.Write("I will run one time before all the tests in the class started");
        }


    }
}
