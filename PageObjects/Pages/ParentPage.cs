using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace SeleniumCSharpTest.Pages
{
 
    public abstract class ParentPage
    {

        protected IWebDriver Driver { get; set; }
        protected WebDriverWait Wait;

        public ParentPage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(Driver, this); ; ;
        }

        
    }
}
