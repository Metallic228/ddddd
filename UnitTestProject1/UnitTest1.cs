using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp41.Pages;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var page = new Autoriz();

            Assert.IsTrue(page.Auth("",""));
        }
    }
}
