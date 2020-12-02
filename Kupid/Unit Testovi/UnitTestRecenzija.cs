using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Testovi
{
    [TestClass]
    public class UnitTestRecenzija
    {
     

        [TestMethod]
        public void TestDajUtisak()
        {
            IRecenzija i = new Recenzija();
            Assert.AreEqual(i.DajUtisak(), "Pozitivan");
            
        }

      
    }
}