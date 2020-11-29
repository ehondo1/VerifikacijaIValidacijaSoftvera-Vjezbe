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

            Assert.AreEqual(chat.Poruke.Count, 1);
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
            Korisnik k1 = new Korisnik("user1", "user1*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false, 20, 18);
            Korisnik k2 = new Korisnik("user2", "user2*+", Lokacija.Sarajevo, Lokacija.Sarajevo, 20, false, 30, 20);
            Chat chat = new Chat(k1, k2);
            Assert.IsFalse(chat.Poruke.Count == 1);

        }


    }
}
