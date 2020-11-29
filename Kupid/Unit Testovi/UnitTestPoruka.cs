using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Testovi
{
    [TestClass]
    public class UnitTestPoruka
    {
        [TestMethod]
        public void TestKonstruktor()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "Cao");

            Assert.AreEqual(poruka.Posiljalac,k1);
            Assert.AreEqual(poruka.Primalac, k2);
            Assert.AreEqual(poruka.Sadrzaj, "Cao");

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKonstruktor1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = null;

            Poruka poruka = new Poruka(k1, k2, "Cao");


        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestKonstruktor2()
        {
            Korisnik k1 = null;
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "");

        }

        

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSetterSadrzaj()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "cao");
            poruka.Sadrzaj = "cap pogrdna riječ";
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSetterSadrzaj1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "cao");
            poruka.Sadrzaj = "";
        }

        [TestMethod]
        
        public void TestSetterSadrzaj2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "cao");
            poruka.Sadrzaj = "caooo";
            Assert.AreEqual(poruka.Sadrzaj, "caooo");
        }

        [TestMethod]

        public void TestGetterSadrzaj()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "cao");
            Assert.AreEqual(poruka.Sadrzaj, "cao");
        }

        [TestMethod]

        public void TestGetterPrimalac()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "cao");
            Assert.AreEqual(poruka.Primalac.Ime,k2.Ime);
        }

        [TestMethod]

        public void TestGetterPosiljalac()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "cao");
            Assert.AreEqual(poruka.Posiljalac.Ime, k1.Ime);
        }


        [TestMethod]
        public void StoPostoKompatibilnost()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Assert.AreEqual(k1.Lokacija, k2.Lokacija);
            Assert.AreEqual(k1.Godine, k2.Godine);
            Assert.AreEqual(k1.ZeljeniMaxGodina, k2.ZeljeniMaxGodina);
            Assert.AreEqual(k1.ZeljeniMinGodina, k2.ZeljeniMinGodina);

        }

        [TestMethod]
        public void StoPostoKompatibilnost1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "volim te još vise");

            Assert.IsFalse(poruka.Sadrzaj.Contains("ne volim te"));

        }

        [TestMethod]
        public void StoPostoKompatibilnost2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false, 10, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "volim te puno");
            double kompatibilnost = poruka.IzračunajKompatibilnostKorisnika();

            Assert.AreEqual(100,kompatibilnost);
        }

        [TestMethod]
        public void Kompatibilnost1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 25, false, 20, 20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false, 10, 20);

            Poruka poruka = new Poruka(k1, k2, "Pozdrav");
            double kompatibilnost = poruka.IzračunajKompatibilnostKorisnika();

            Assert.IsTrue(kompatibilnost<100);
        }


    }
}