using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;

using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SeleniumCSharpTest.Tests
{
    [Binding]
    public class ParentTest
    {
   
        protected IWebDriver Driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();
        protected static TestContext _testContext;

        public TestContext TestContext { get; set; }

        
        /*
        [TestInitialize]
        public void RunBeforeEveryTest()
        {
            var url = "https://test-api.worldticket.net/ui/sms5-single/sms-systests-fork1/";
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            logger.Info($"Open url=>{url}");


        }

        [TestCleanup]
        public void RunAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
   
        }

        [ClassCleanup]
        public static void RunAfterEveryTestClass()
        {
         
            Trace.Write("I will run one time after all the tests in the class finished");
        }
        */
    }
}
