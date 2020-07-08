using NLog;
using OpenQA.Selenium;

using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{
    [Binding]
    public class ParentTest
    {
   
        protected static IWebDriver Driver { get;set; }
       
        protected static Logger logger = LogManager.GetCurrentClassLogger();
    }
}
