using AutomationResources;
using SeleniumTest.Tests;

using TechTalk.SpecFlow;

namespace SeleniumTest
{
    [Binding]
    public class Hooks: ParentTest
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public void BeforeScenario()
        {
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            var url = "https://test-api.worldticket.net/ui/sms5-single/sms-systests-fork1/";
            Driver.Navigate().GoToUrl(url);
            logger.Info($"Open url=>{url}");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Driver.Close();
            Driver.Quit();

        }
    }
}
