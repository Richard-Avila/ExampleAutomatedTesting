using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QaExample
{
    public partial class HomePage
    {
        //This method determines whether The main headline is "Custom Software Development"
        // If it is not an exception is thrown and this test fails
        public void AssertHeadline()
        {
            Assert.IsTrue(this.MainHeadline.Text.Contains("Custom Software Development"));
        }
    }
}
