using AutomationResources;
using BoDi;
using OpenQA.Selenium;
using SeleniumTest.Tests;

using TechTalk.SpecFlow;

namespace SeleniumTest
{
    
    [Binding]
    public class DriverSetupHook
    {
        private readonly IObjectContainer objectContainer;
        private IWebDriver _driver;


        public DriverSetupHook(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }
     

        [BeforeScenario(Order = 0)]
        public void InitializeWebDriver()
        {
            var factory = new WebDriverFactory();
            _driver = factory.Create(BrowserType.Chrome);
            objectContainer.RegisterInstanceAs<IWebDriver>(_driver);
        }

       


    }
}
