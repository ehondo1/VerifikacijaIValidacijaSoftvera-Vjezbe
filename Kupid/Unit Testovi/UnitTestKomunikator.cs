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
            Poruka poruka1 = new Poruka(k1, k2, "Cao, pozdravljam te");
            Poruka poruka2 = new Poruka(k2, k1, "Cao, cao");
            List<Poruka> lista = new List<Poruka>();
            lista.Add(poruka1);
            lista.Add(poruka2);
            Chat chat = new Chat(k1, k2);
            chat.DodajNovuPoruku(k1, k2, "volim te");
            Komunikator k = new Komunikator();
            List<Poruka> rezultat = new List<Poruka>();
            rezultat = k.IzlistavanjeSvihPorukaSaSadržajem("Cao");
        

            Assert.AreEqual(rezultat.Count, 2);
        }
  
    }
}
