using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumCSharpTest.Pages
{
    public class LandingPage: ParentPage
    {


        public LandingPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement TxtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement BtnLogin { get; set; }

        public void ValidLogin()
        {
            TxtUsername.SendKeys("admin");
            TxtPassword.SendKeys("wtqwerty");
            BtnLogin.Click();
        }

    }
}

