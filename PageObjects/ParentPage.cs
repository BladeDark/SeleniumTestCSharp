using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace PageObjects
{
 
    public abstract class ParentPage
    {

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait;

        public ParentPage(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this); ; ;
        }

        
    }
}
