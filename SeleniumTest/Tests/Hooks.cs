using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SeleniumTest.Tests
{
    [Binding]
    class Hooks
    {
        private IWebDriver _driver;

        public Hooks(IWebDriver driver)
        {
            _driver = driver;
        }


        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
            _driver.Quit();

        }

    }
}
