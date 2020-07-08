using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SeleniumTest.Pages
{
    public class HomePage : ParentPage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.XPath, Using = "//app-header-search//button")]
        private IWebElement BtnSearch { get; set; }

        public void SearchRecordLocator()
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(BtnSearch));
            BtnSearch.Click();
        }
    }
}
