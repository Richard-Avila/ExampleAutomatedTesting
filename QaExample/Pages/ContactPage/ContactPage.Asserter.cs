using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaExample
{
    public partial class ContactPage
    {
        //This method determines whether the current page's Title is equal to "Thanks - QuartzBytes
        public void AssertTitle()
        {
            Assert.AreEqual(this.driver.Title, "Thanks - QuartzBytes");
        }
    }
}
