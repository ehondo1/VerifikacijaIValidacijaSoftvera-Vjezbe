using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class UnitTestGrupniChat
    {


        [TestMethod]
        public void TestKonstruktor()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Banja_Luka, Lokacija.Sarajevo, 21, false);

            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici.Add(k1);
            korisnici.Add(k2);
            korisnici.Add(k3);

            GrupniChat grupnichat = new GrupniChat(korisnici);
            Assert.IsTrue(grupnichat.Korisnici.Count == 3);
            Assert.IsTrue(grupnichat.Poruke.Count == 0);

        }


        [TestMethod]
        public void TestKonstruktor1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Banja_Luka, Lokacija.Sarajevo, 21, false);
            Korisnik k4 = new Korisnik("user4", "user4*+", Lokacija.Banja_Luka, Lokacija.Zenica, 22, true);
            Korisnik k5 = new Korisnik("user5", "user5*+", Lokacija.Bihać, Lokacija.Mostar, 21, true);

            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici.Add(k1);
            korisnici.Add(k2);
            korisnici.Add(k3);
            korisnici.Add(k4);
            korisnici.Add(k5);

            GrupniChat grupnichat = new GrupniChat(korisnici);
            Assert.IsTrue(grupnichat.Korisnici.Count == 5);
            Assert.IsTrue(grupnichat.Poruke.Count == 0);
            Assert.IsTrue(grupnichat.PocetakChata <= DateTime.Now);
        }

        [TestMethod]
        public void TestKonstruktor2()
        {

            List<Korisnik> korisnici;
            korisnici = null;
       
            GrupniChat grupnichat = new GrupniChat(korisnici);
            Assert.AreEqual(grupnichat.Korisnici.Count, 0);
        }


        [TestMethod]
        public void TestPošaljiPorukuVišeKorisnika()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Banja_Luka, Lokacija.Sarajevo, 21, false);
            Korisnik k4 = new Korisnik("user4", "user4*+", Lokacija.Banja_Luka, Lokacija.Zenica, 22, true);
            Korisnik k5 = new Korisnik("user5", "user5*+", Lokacija.Bihać, Lokacija.Mostar, 21, true);

            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici.Add(k1);
            korisnici.Add(k2);
            korisnici.Add(k3);
            korisnici.Add(k4);

            GrupniChat grupnichat = new GrupniChat(korisnici);
            grupnichat.PosaljiPorukuViseKorisnika(k5, korisnici, "cao");

            Assert.IsTrue(grupnichat.Poruke.Count == 4);
            Assert.IsTrue(grupnichat.PocetakChata <= DateTime.Now);

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPošaljiPorukuVišeKorisnika1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
           
            List<Korisnik> korisnici = new List<Korisnik>();

            GrupniChat grupnichat = new GrupniChat(korisnici);
            grupnichat.PosaljiPorukuViseKorisnika(k1,korisnici , "cao");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPošaljiPorukuVišeKorisnika2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = null;
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Banja_Luka, Lokacija.Sarajevo, 21, false);
            Korisnik k4 = new Korisnik("user4", "user4*+", Lokacija.Banja_Luka, Lokacija.Zenica, 22, true);

            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici.Add(k1);
            korisnici.Add(k3);
            korisnici.Add(k4);

            GrupniChat grupnichat = new GrupniChat(korisnici);
            grupnichat.PosaljiPorukuViseKorisnika(k2, korisnici, "cao");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestPošaljiPorukuVišeKorisnika3()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            
            Korisnik k5 = new Korisnik("user5", "user5*+", Lokacija.Bihać, Lokacija.Mostar, 21, true);

            List<Korisnik> korisnici = new List<Korisnik>();
            korisnici.Add(k1);
         

            GrupniChat grupnichat = new GrupniChat(korisnici);
            grupnichat.PosaljiPorukuViseKorisnika(k5, korisnici, "cao");

        }

    }
    
}

