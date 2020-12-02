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

        [TestMethod]
        public void TestZaKonstruktor()
        {

            Komunikator k = new Komunikator();

            Assert.AreEqual(k.Korisnici.Count, 0);
            Assert.AreEqual(k.Razgovori.Count, 0);
        }


        [TestMethod]
        public void TestZaGetterRazgovori()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            
            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "Cao");
            chat.DodajNovuPoruku(k2, k1, "Cao, pozdravljam te");
            chat.DodajNovuPoruku(k1, k2, "Neka poruka");

            Chat chat1 = new Chat(k1, k2);
            chat1.DodajNovuPoruku(k1, k2, "Cao i tebi");
            chat1.DodajNovuPoruku(k2, k1, "Neka poruka");
            chat1.DodajNovuPoruku(k1, k2, "Okej");
            chat1.DodajNovuPoruku(k2, k1, "Dosadan si");

            Komunikator k = new Komunikator();

            k.Razgovori.Add(chat);
            k.Razgovori.Add(chat1);

            Assert.AreEqual(k.Razgovori.Count, 2);
            
        }

        [TestMethod]
        public void TestZaGetterKorisnike()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);


            Komunikator k = new Komunikator();
            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);

            Assert.AreEqual(k.Korisnici.Count, 2);

        }


        [TestMethod]
        public void TestRadSaKorisnikom()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);


            Komunikator k = new Komunikator();
            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);

            k.RadSaKorisnikom(k3, 0);

            Assert.AreEqual(k.Korisnici.Count, 3);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadSaKorisnikom1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);


            Komunikator k = new Komunikator();
            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);

            k.RadSaKorisnikom(k2, 0);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadSaKorisnikom2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

            Komunikator k = new Komunikator();
            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);

            k.RadSaKorisnikom(k3, 1);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestRadSaKorisnikom3()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);
            Korisnik k4 = new Korisnik("user4", "user4*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

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
     
            Komunikator k = new Komunikator();

            k.Razgovori.Add(chat);
            k.Razgovori.Add(chat1);
            k.Razgovori.Add(chat2);

            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);
            k.Korisnici.Add(k3);

            k.RadSaKorisnikom(k4, 1);

        }

        [TestMethod]
        public void TestRadSaKorisnikom4()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);
            Korisnik k4 = new Korisnik("user4", "user4*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

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

            Komunikator k = new Komunikator();

            k.Razgovori.Add(chat);
            k.Razgovori.Add(chat1);
            k.Razgovori.Add(chat2);

            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);
            k.Korisnici.Add(k3);
            k.Korisnici.Add(k4);

            k.RadSaKorisnikom(k4, 1);

            Assert.AreEqual(k.Korisnici.Count, 3);
            Assert.AreEqual(k.Razgovori.Count, 3);

        }

        [TestMethod]
        public void TestRadSaKorisnikom5()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);
            Korisnik k4 = new Korisnik("user4", "user4*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

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

            Komunikator k = new Komunikator();

            k.Razgovori.Add(chat);
            k.Razgovori.Add(chat1);
            k.Razgovori.Add(chat2);

            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);
            k.Korisnici.Add(k3);
            k.Korisnici.Add(k4);

            k.RadSaKorisnikom(k3, 1);

            Assert.AreEqual(k.Korisnici.Count, 3);
            Assert.AreEqual(k.Razgovori.Count, 2);

        }

        [TestMethod]
        public void TestDodavanjeRazgovora()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            List<Korisnik> lista = new List<Korisnik>();
            lista.Add(k1);
            lista.Add(k2);


            Komunikator k = new Komunikator();

            k.DodavanjeRazgovora(lista, false);

            Assert.AreEqual(k.Razgovori.Count, 1);

        }


        [TestMethod]
        public void TestDodavanjeRazgovora1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            List<Korisnik> lista = new List<Korisnik>();
            lista.Add(k1);
            lista.Add(k2);


            Komunikator k = new Komunikator();

            k.DodavanjeRazgovora(lista, true);

            Assert.AreEqual(k.Razgovori.Count, 1);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDodavanjeRazgovora2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            List<Korisnik> lista = new List<Korisnik>();
            lista.Add(k1);


            Komunikator k = new Komunikator();

            k.DodavanjeRazgovora(lista, true);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDodavanjeRazgovora3()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

            List<Korisnik> lista = new List<Korisnik>();
            lista.Add(k1);
            lista.Add(k2);
            lista.Add(k3);

            Komunikator k = new Komunikator();

            k.DodavanjeRazgovora(lista, false);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDodavanjeRazgovora4()
        {
            Korisnik k1 = new Korisnik();

            List<Korisnik> lista = new List<Korisnik>();
            lista.Add(k1);

            Komunikator k = new Komunikator();

            k.DodavanjeRazgovora(lista, true);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDaLiJeSpajanjeUspjesno()
        {
            Chat c = new GrupniChat(new List<Korisnik>());
            IRecenzija i = new Recenzija();

            Komunikator k = new Komunikator();

            k.DaLiJeSpajanjeUspjesno(c, i);

        }

        [TestMethod]
        public void TestDaLiJeSpajanjeUspjesno1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Mostar, Lokacija.Bihać, 21, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "Cao");
            chat.DodajNovuPoruku(k2, k1, "Cao, pozdravljam te");
            chat.DodajNovuPoruku(k1, k2, "Neka poruka");
            IRecenzija i = new Recenzija();

            Komunikator k = new Komunikator();

            bool uspjesno = k.DaLiJeSpajanjeUspjesno(chat, i);

            Assert.IsFalse(uspjesno);

        }

        [TestMethod]
        public void TestDaLiJeSpajanjeUspjesno2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "Cao");
            chat.DodajNovuPoruku(k2, k1, "Cao, volim te");
            chat.DodajNovuPoruku(k1, k2, "Neka poruka");
            IRecenzija i = new Recenzija();

            Komunikator k = new Komunikator();

            bool uspjesno = k.DaLiJeSpajanjeUspjesno(chat, i);

            Assert.IsTrue(uspjesno);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestSpajanjeKorisnika()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Bihać, Lokacija.Mostar, 20, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "Cao");
            chat.DodajNovuPoruku(k2, k1, "Cao, pozdravljam te");
            chat.DodajNovuPoruku(k1, k2, "Neka poruka");


            Chat chat1 = new Chat(k1, k2);
            chat1.DodajNovuPoruku(k1, k2, "Cao i tebi");
            chat1.DodajNovuPoruku(k2, k1, "Neka poruka");
            chat1.DodajNovuPoruku(k1, k2, "Okej");
            chat1.DodajNovuPoruku(k2, k1, "Dosadan si");

            Komunikator k = new Komunikator();

            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);
            k.Razgovori.Add(chat);
            k.Razgovori.Add(chat1);

            k.SpajanjeKorisnika();


        }

        [TestMethod]
        public void TestSpajanjeKorisnika1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Bihać, Lokacija.Mostar, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Mostar, Lokacija.Sarajevo, 21, false);

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

            Komunikator k = new Komunikator();
            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);
            k.Razgovori.Add(chat);
            k.Razgovori.Add(chat1);
            k.Razgovori.Add(chat2);

            k.SpajanjeKorisnika();

            Assert.AreEqual(k.Razgovori.Count, 4);

        }


        [TestMethod]
        public void TestSpajanjeKorisnika2()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Bihać, Lokacija.Mostar, 20, false);

            Chat chat = new Chat();

            Komunikator k = new Komunikator();
            k.Korisnici.Add(k1);
            k.Korisnici.Add(k2);
            k.Razgovori.Add(chat);

            k.SpajanjeKorisnika();

            Assert.AreEqual(k.Razgovori.Count, 3);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestIzlistavanjePoruka3()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Poruka poruka1 = new Poruka(k1, k2, "Cao, pozdravljam te");
            List<Poruka> lista = new List<Poruka>();
            lista.Add(poruka1);

            Chat chat = new Chat(k1, k2);

            Komunikator k = new Komunikator();
            List<Poruka> rezultat = new List<Poruka>();
            rezultat = k.IzlistavanjeSvihPorukaSaSadržajem(null);

        }

    }
}
