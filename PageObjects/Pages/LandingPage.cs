using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace SeleniumCSharpTest.Pages
{
    public class LandingPage: ParentPage
    {


        public LandingPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement _txtUsername { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _txtPassword { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        private IWebElement _btnLogin { get; set; }

        public void ValidLogin()
        {
             _txtUsername.SendKeys("admin");
             _txtPassword.SendKeys("wtqwerty");
            _btnLogin.Click();
        }

    }
}

