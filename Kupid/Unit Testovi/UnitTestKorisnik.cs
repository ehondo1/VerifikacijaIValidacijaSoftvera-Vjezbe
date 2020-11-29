
using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Testovi
{ [TestClass]
    public class UnitTestKorisnik
    {
        [TestMethod]
        public void TestPromjenaParametaraSlicno()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false,19,29);
            
            bool slicno = true;
            k1.PromjenaParametara(slicno);
            Assert.AreEqual(k1.ZeljenaLokacija, k1.Lokacija);
            
        }

        [TestMethod]
        public void TestPromjenaParametaraSlicno1()
        {
            Korisnik k2 = new Korisnik("Nadija", "user2*+", Lokacija.Mostar, Lokacija.Bihać, 21, false, 18, 30);
            bool slicno = false;
            k2.PromjenaParametara(slicno);
            Assert.AreEqual(k2.Lokacija,Lokacija.Sarajevo);
           
        }
        [TestMethod]
        public void TestPromjenaParametaraSlicno2()
        {
            Korisnik k2 = new Korisnik("Nadija", "user2*+", Lokacija.Mostar, Lokacija.Bihać, 21, false, 18, 30);
            bool slicno = false;
            k2.PromjenaParametara(slicno);
            Assert.AreEqual(k2.ZeljeniMaxGodina, 31);

        }
    }
}
