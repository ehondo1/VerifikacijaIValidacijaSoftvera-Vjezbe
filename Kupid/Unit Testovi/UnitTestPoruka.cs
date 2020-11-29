using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Testovi
{
    [TestClass]
    public class UnitTestPoruka
    {

        [TestMethod]
        public void StoPostoKompatibilnost()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Trebinje, 20, false,10,20);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Bihać, 20, false,10,20);

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