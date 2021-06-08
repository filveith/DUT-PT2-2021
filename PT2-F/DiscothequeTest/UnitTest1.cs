using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WindowsFormsApp1;

namespace DiscothequeTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static void TestMethod1()
        {
            //Assert.IsFalse(Utils.GetABONNÉ().LOGIN_ABONNÉ.Equals("fveith"));
            var bd = Utils.RegisterAbo("Fil","Veith","fveith","123456",1);
        }
    }
}
