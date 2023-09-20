using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwapOutInterfaceForTestingDemo.Enums;
using SwapOutInterfaceForTestingDemo.Interfaces;
using System;

namespace UnitTestsForApi
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new Toon();
            a.Name = "bob"
            
            var b = new Toon()
            {
                Name= "bob"
            }

            Assert.AreNotEqual(a, b);
        }
    }
}
