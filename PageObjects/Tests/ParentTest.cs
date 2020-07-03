using AutomationResources;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SeleniumCSharpTest.Tests
{
    [TestClass]
    public class ParentTest
    {
   
        protected static IWebDriver Driver;
        protected static TestContext _testContext;

        public TestContext TestContext { get; set; }

        

        [TestInitialize]
        public void RunBeforeEveryTest()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://test-api.worldticket.net/ui/sms5-single/sms-systests-fork1/");
        }

        [TestCleanup]
        public void RunAfterEveryTestMethod()
        {
            Driver.Close();
            Driver.Quit();
            Trace.Write("RunAfterEveryTestMethod will execute after every single test method in a class");
        }

        [ClassCleanup]
        public static void RunAfterEveryTestClass()
        {
         
            Trace.Write("I will run one time after all the tests in the class finished");
        }
    }
}
