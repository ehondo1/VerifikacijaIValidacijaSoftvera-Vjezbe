using Kupid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Unit_Testovi
{
    [TestClass]
    public class UnitTestChat
    {

        [TestMethod]
        [ExpectedException(typeof (InvalidOperationException))]
        public void TestBrojPoruka()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "volim te");
            chat.DodajNovuPoruku(k2, k1, "pogrdna riječ");
        }

        [TestMethod]
       
        public void TestBrojPoruka1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k3 = new Korisnik("user3", "user3*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k4 = new Korisnik("user4", "user4*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "volim te");
            chat.DodajNovuPoruku(k2, k1, "pozdravljam te");
            chat.DodajNovuPoruku(k1, k4, "razvoj programskih rjesenja");
            chat.DodajNovuPoruku(k2, k3, "bilo kakva poruka");

            Assert.AreEqual(chat.Poruke.Count,4);

        }

        [TestMethod]
        
        public void TestKonstruktor()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat(k1, k2);
            Assert.IsFalse(chat.Poruke.Count == 1);

        }

        [TestMethod]
        public void TestKonstruktor1()
        {
           
            Chat chat = new Chat();
            Assert.IsTrue(chat.PocetakChata<=DateTime.Now);

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSetterNajnovijaPoruka()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat(k1, k2);
            chat.NajnovijaPoruka = new DateTime(2050, 12, 12);
        }

        [TestMethod]
        public void TestSetterNajnovijaPoruka1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat(k1, k2);
            chat.NajnovijaPoruka = DateTime.Now;
            Assert.IsTrue(chat.NajnovijaPoruka<=DateTime.Now);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestSetterPocetakChata()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat(k1, k2);
            chat.PocetakChata = new DateTime(2050, 12, 12);
        }

        [TestMethod]
        public void TestSetterPocetakChata1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat(k1, k2);
            chat.PocetakChata = DateTime.Now;
            Assert.IsTrue(chat.PocetakChata<=DateTime.Now);
        }

        [TestMethod]
        public void TestGetterPocetakChata()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat(k1, k2);
            Assert.IsTrue(chat.PocetakChata<=DateTime.Now);
        }

        [TestMethod]
        public void TestGetterKorisnici()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat(k1, k2);
            Assert.AreEqual(chat.Korisnici.Count,2);
            Assert.AreEqual(chat.Poruke.Count, 0);
        }

        [TestMethod]
        public void TestGetterKorisnici1()
        {
            Chat chat = new Chat();
            Assert.AreEqual(chat.Korisnici.Count, 0);
            Assert.AreEqual(chat.Poruke.Count, 0);
        }

        [TestMethod]
        public void TestGetterPoruke()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            Poruka poruka = new Poruka(k1, k2, "pozdravljam te");
            Poruka poruka1 = new Poruka(k2, k1, "i ja tebe");
            Chat chat = new Chat(k1, k2);
            chat.Poruke.Add(poruka);
            chat.Poruke.Add(poruka1);
            Assert.AreEqual(chat.Korisnici.Count, 2);
            Assert.AreEqual(chat.Poruke.Count, 2);
        }

        [TestMethod]
        public void TestGetterPoruke1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);

            Poruka poruka = new Poruka(k1, k2, "pozdravljam te");
            Poruka poruka1 = new Poruka(k2, k1, "i ja tebe");
            Chat chat = new Chat();
            chat.Poruke.Add(poruka);
            chat.Poruke.Add(poruka1);

            Assert.IsNotNull(chat);
            Assert.AreEqual(chat.Korisnici.Count, 0);
            Assert.AreEqual(chat.Poruke.Count, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDodavanjePoruka()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat();

            chat.Poruke.Add(new Poruka(k1,k2,"ovo je pogrdna riječ"));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestDodavanjePoruka1()
        {
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false);
            Chat chat = new Chat();

            chat.DodajNovuPoruku(k1, k2, null);
        }

    }
}
