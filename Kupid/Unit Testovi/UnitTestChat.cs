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

        
    }
}
