using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
    public class LandingPage: ParentPage
    {


        public LandingPage(IWebDriver driver) : base(driver) { }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement _username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        private IWebElement _password { get; set; }

        public void ValidLogin()
        {
             _username.SendKeys("admin");
             _password.SendKeys("wtqwerty");

        }

    }
}

