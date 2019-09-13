using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaExample
{
    public partial class ContactPage
    {
        //Initialize the web driver
        private readonly IWebDriver driver;
        //This url is the page under test
        private readonly string url = @"https://quartzbytes.com/home/contact";

        //This constructor accepts a web driver as a parameter
        public ContactPage(IWebDriver browser)
        {
            //assign the initialized webdriver to the driver that was passed in
            this.driver = browser;
            //Page Factory is an extension to page objects that are used to initialize the web elements that are defined on the page object. 
            PageFactory.InitElements(browser, this);
            
        }

        //This method watches the browser and waits for the form on the page to have fully loaded before moving forward.
        //It waits for the text box element with the Id of FirstName to be drawn.
        public void WaitForFormShown()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists((By.Id("FirstName"))));
        }

        //This method fills out the form and clicks the submit button
        public void FillOutForm()
        {
            //It use to be considered best practice to maximize the browser before clicking everywhere
            // and sending keys, but in my experience it is rarely needed. This is what that would look
            // like if it was needed though
            driver.Manage().Window.Maximize();

            //This next section of code has the driver finding elements and storing them into IWebElements
            // so I can perform actions on them in the next section.
            IWebElement FirstNameTextBox = driver.FindElement(By.XPath(".//*[@id='FirstName']"));
            IWebElement LastNameTextBox = driver.FindElement(By.XPath(".//*[@id='LastName']"));
            IWebElement CompanyNameTextBox = driver.FindElement(By.XPath(".//*[@id='CompanyName']"));
            IWebElement EmailTextBox = driver.FindElement(By.XPath(".//*[@id='Email']"));
            IWebElement PhoneTextBox = driver.FindElement(By.XPath(".//*[@id='Phone']"));
            IWebElement DescriptionTextBox = driver.FindElement(By.XPath(".//*[@id='Description']"));
            //In best practice every element that should under go automated testing should have an Id
            // in the HTML, but as you can my submit did not have one, so it can be identified in other ways
            IWebElement SubmitButton = driver.FindElement(By.XPath(".//button[contains(.,'Submit')]"));

            //This next block of code sends keys to the text entry fields and fills out the form
            FirstNameTextBox.SendKeys("a first name");
            LastNameTextBox.SendKeys("a last name");
            CompanyNameTextBox.SendKeys("a company name");
            EmailTextBox.SendKeys("test@testing.com");
            PhoneTextBox.SendKeys("1234567890");
            DescriptionTextBox.SendKeys("this is just a quick automated test");

            //And finally we submit the form
            SubmitButton.Click();
        }
    }
}
