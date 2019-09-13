using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaExample
{
    public partial class HomePage
    {
        //Initialize a web driver
        private readonly IWebDriver driver;
        //This url string represents the page that this object will act on
        private readonly string url = @"http://quartzbytes.com";
        //This constructor is called upon initialization of this object and accepts
        //a selenium webdriver parameter
        public HomePage(IWebDriver browser)
        {
            //assigned the passed in driver to the initialized driver
            this.driver = browser;
            //PageFactory is an extension to page objects that are used to initialize
            // web elementsthat are defined on the page object
            PageFactory.InitElements(browser, this);
        }
        //This method directs the web driver to open a browser and go to the defined url
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }
        //This method tells the driver to click on that link to the contact page
        public void GoToContact()
        {
            //Defined in HomePage.Map.cs
            this.GoToContactPage.Click();
        }
    }
}
