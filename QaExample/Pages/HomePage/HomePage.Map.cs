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
        //The following code finds the main headline by searching for the h1 tag
        // on the page and assigns it to the MainHeadLine object
        [FindsBy(How = How.XPath, Using = "//*/h1")]
        public IWebElement MainHeadline { get; set; }

        //The same idea as before but I am finding the link to the contact page
        [FindsBy(How = How.LinkText, Using = "Contact")]
        public IWebElement GoToContactPage { get; set; }
    }
}
