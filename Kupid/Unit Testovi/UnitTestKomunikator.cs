using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Unit_Testovi
{
    [TestClass]
    public class UnitTestKomunikator
    {


        [TestMethod]
        public void TestIzlistavanjePoruka()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            //Korisnik k3 = new Korisnik("admin", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "Cao");
            chat.DodajNovuPoruku(k2, k1, "Cao, pozdravljam te");
            chat.DodajNovuPoruku(k1, k2, "Neka poruka");


            Chat chat1= new Chat(k1, k2);
            chat1.DodajNovuPoruku(k1, k2, "Cao i tebi");
            chat1.DodajNovuPoruku(k2, k1, "Neka poruka");
            chat1.DodajNovuPoruku(k1, k2, "Okej");
            chat1.DodajNovuPoruku(k2, k1, "Dosadan si");

            Komunikator komunikator = new Komunikator();
            komunikator.Korisnici.Add(k1);
            komunikator.Korisnici.Add(k2);
            komunikator.Razgovori.Add(chat);
            komunikator.Razgovori.Add(chat1);

            List<Poruka> rezultat = komunikator.IzlistavanjeSvihPorukaSaSadržajem("Cao");

            Assert.AreEqual(rezultat.Count, 3);
        }



            [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIzlistavanjePoruka1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Poruka poruka1 = new Poruka(k1, k2, "Cao, pozdravljam te");
            List<Poruka> lista = new List<Poruka>();
            lista.Add(poruka1);
           
            Chat chat = new Chat(k1, k2);
           
            Komunikator k = new Komunikator();
            List<Poruka> rezultat = new List<Poruka>();
            rezultat = k.IzlistavanjeSvihPorukaSaSadržajem("");
            

            Assert.AreEqual(rezultat.Count, 0);
        }

        [TestMethod]
        public void TestIzlistavanjePoruka2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("admin", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "Cao");
            chat.DodajNovuPoruku(k2, k1, "Cao, pozdravljam te");
            chat.DodajNovuPoruku(k1, k2, "Neka poruka");


            Chat chat1 = new Chat(k1, k2);
            chat1.DodajNovuPoruku(k1, k2, "Cao i tebi");
            chat1.DodajNovuPoruku(k2, k1, "Neka poruka");
            chat1.DodajNovuPoruku(k1, k2, "Okej");
            chat1.DodajNovuPoruku(k2, k1, "Dosadan si");

            Chat chat2 = new Chat(k1, k3);
            chat2.DodajNovuPoruku(k1, k3, "Cao admine");
            chat2.DodajNovuPoruku(k3, k1, "Neka poruka od admina");
            chat2.DodajNovuPoruku(k1, k3, "Okej");
            chat2.DodajNovuPoruku(k3, k1, "Dosadan si");

            Chat chat3 = new Chat(k2, k3);
            chat3.DodajNovuPoruku(k2, k3, "Hej");
            chat3.DodajNovuPoruku(k3, k2, "Danas");
            chat3.DodajNovuPoruku(k2, k3, "Sam");
            chat3.DodajNovuPoruku(k3, k2, "Okej");

            Komunikator komunikator = new Komunikator();
            komunikator.Korisnici.Add(k1);
            komunikator.Korisnici.Add(k2);
            komunikator.Razgovori.Add(chat);
            komunikator.Razgovori.Add(chat1);
            komunikator.Razgovori.Add(chat2);
            komunikator.Razgovori.Add(chat3);

            List<Poruka> rezultat = komunikator.IzlistavanjeSvihPorukaSaSadržajem("Cao");

            Assert.AreEqual(rezultat.Count, 3);
        }

    }
}
