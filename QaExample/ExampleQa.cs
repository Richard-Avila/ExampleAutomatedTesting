using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace QaExample
{
    [TestClass]
    public class ExampleQa
    {
        //Initialize the Selenium WebDriver
        private IWebDriver driver;
        
        /*
         * The test is to leverage the selenium web driver to navigate to quartzbytes.com,
         * verify the page loads, navigate to the contact page, fill out the contact form,
         * and verify that the form was submitted.
             */
        [TestMethod]
        [TestCategory("Chrome")]
        public void HomePageTests()
        {
            //Initiate the HomePage object and pass the selenium web driver as a parameter
            var homePage = new HomePage(this.driver);
            //Call the Navigate method within the homePage object to go the the url of the home page
            homePage.Navigate();
            //As a check to see if it worked, I am seeing if the page loaded has the correct title
            homePage.AssertHeadline();
            //The GoToContact method is then called and this method locates the link to the contact page
            // and clicks the link
            homePage.GoToContact();

            // Initiate a ContactPage object and pass in the driver
            var contactPage = new ContactPage(this.driver);
            //The WaitForFormShown method waits for the existance of a textbox with an element id
            // of 'FirstName' to prove that the page has loaded and the form is shown before attempting
            // to perform any actions upon the page.
            contactPage.WaitForFormShown();
            //I then call the FillOutForm method within the ContactPage object to fill out of the form
            // and click submit. The purpose here is to test the critical functionality of this page.
            contactPage.FillOutForm();
            //This delay is in place just so when viewing the test we can see that all the fields
            // of the form have in fact been filled out.
            Task.Delay(1500);
            //After the form is submitted a user is directed to a thank you page. We assert whether or not
            // users are directed there by checking the title of the page.
            contactPage.AssertTitle();
        }

        //This method prepares the selenium driver for the browser we intended to test with
        //and is called before any test methods are fired
        [TestInitialize()]
        public void SetupTest()
        {
            //At the moment this is just a static value. I just want to show the capability of
            //running the same tests on multiple broswers
            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        //This method is called after all test methods have been fired
        //This simply closes the browser and selenium web driver
        [TestCleanup()]
        public void MyTestCleanup()
        {
            driver.Quit();
        }
    }
}
