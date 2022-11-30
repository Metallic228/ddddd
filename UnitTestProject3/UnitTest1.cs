using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp41.Pages;
namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        Autoriz page = new Autoriz();
        [TestMethod]
        public void TestMethod1()
        {
            
           
            Assert.IsFalse(page.Auth("gh","ds"));
        }
        [TestMethod]
        public void TestMethod2()
        {
           // var page = new Autoriz();

            Assert.IsFalse(page.Auth("", "d"));
        }
        [TestMethod]
        public void TestMethod3()
        {
            //var page = new Autoriz();

            Assert.IsFalse(page.Auth("g", ""));
        }
        [TestMethod]
        public void TestMethod4()
        {
            //var page = new Autoriz();

            Assert.IsFalse(page.Auth("", ""));
        }
       

    }
}
