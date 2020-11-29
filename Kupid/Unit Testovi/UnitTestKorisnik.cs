
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
        [TestMethod]
        public void TestKonstruktor()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 19, 29);

          
            Assert.AreEqual(k1.ZeljenaLokacija, Lokacija.Zenica);

        } 

        [TestMethod]
        public void TestKonstruktor1()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 17, 29);


            Assert.AreEqual(k1.ZeljeniMinGodina,21);

        }

        [TestMethod]
        public void TestKonstruktor2()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false,0,20);


            Assert.AreEqual(k1.ZeljeniMaxGodina, 20);

        }

        [TestMethod]
        public void TestKonstruktor3()
        {
            Korisnik k1 = new Korisnik();


            Assert.AreEqual(k1.Ime, null);

        }

        [TestMethod]
        public void TestSetterIme()
        {
            Korisnik k1 = new Korisnik();
            k1.Ime = "Mubina";

            Assert.AreEqual(k1.Ime, "Mubina");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterIme1()
        {
            Korisnik k1 = new Korisnik();
            k1.Ime = "";

           

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterIme2()
        {
            Korisnik k1 = new Korisnik();
            k1.Ime = "Husoemanegramuhamedmubinafarisabdulahmubina";


        }

        [TestMethod]
        
        public void TestGetterIme()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);

            Assert.AreEqual(k1.Ime, "Mubina");

        }


        [TestMethod]
       
        public void TestSetterPassword()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);

            Assert.AreEqual(k1.Password, "xyz*+");

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterPassword1()
        {
            Korisnik k1 = new Korisnik();
            k1.Password = "xy";



        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterPassword2()
        {
            Korisnik k1 = new Korisnik();
            k1.Password = "";



        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterPassword3()
        {
            Korisnik k1 = new Korisnik();
            k1.Password = "xy+";



        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterPassword4()
        {
            Korisnik k1 = new Korisnik();
            k1.Password = "xy*";



        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterPassword5()
        {
            Korisnik k1 = new Korisnik();
            k1.Password = "ovojeetf+*";



        }

        [TestMethod]
    
        public void TestGetterPassword()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);
            Assert.AreEqual(k1.Password, "xyz*+");

        }

        [TestMethod]

        public void TestSetterLokacija()
        {
            Korisnik k1 = new Korisnik();
            k1.Lokacija = Lokacija.Sarajevo;
            Assert.AreEqual(k1.Lokacija, Lokacija.Sarajevo);

        }

        [TestMethod]

        public void TestGetterLokacija()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);
            
            Assert.AreEqual(k1.Lokacija, Lokacija.Sarajevo);

        }


        [TestMethod]

        public void TestSetterZeljenaLokacija()
        {
            Korisnik k1 = new Korisnik();
            k1.ZeljenaLokacija = Lokacija.Sarajevo;
            Assert.AreEqual(k1.ZeljenaLokacija, Lokacija.Sarajevo);

        }

        [TestMethod]

        public void TestGetterZeljenaLokacija()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);

            Assert.AreEqual(k1.ZeljenaLokacija, Lokacija.Zenica);

        }


        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterGodine()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 15;
          

        }

        [TestMethod]

        public void TestSetterGodine1()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 20;
            Assert.AreEqual(k1.Godine, 20);

        }

        [TestMethod]
        public void TestGetterGodine()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);
            
            Assert.AreEqual(k1.Godine, 21);

        }
        [TestMethod]
        public void TestSetterZeljeniMinGodina()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 21;
            k1.ZeljeniMinGodina = 11;
            
            Assert.AreEqual(k1.ZeljeniMinGodina, 11);

        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterZeljeniMinGodina1()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 20;
            k1.ZeljeniMinGodina = 8;

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterZeljeniMinGodina2()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 19;
            k1.ZeljeniMinGodina = 25;

        }

        [TestMethod]
        
        public void TestGetterZeljeniMinGodina()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);

            Assert.AreEqual(k1.ZeljeniMinGodina, 21);
        }

        [TestMethod]
        public void TestSetterZeljeniMaxGodina()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 21;
            k1.ZeljeniMaxGodina = 17;

            Assert.AreEqual(k1.ZeljeniMaxGodina, 17);

        }
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterZeljeniMaxGodina1()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 20;
            k1.ZeljeniMaxGodina = 10;

        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestSetterZeljeniMaxGodina2()
        {
            Korisnik k1 = new Korisnik();
            k1.Godine = 19;
            k1.ZeljeniMaxGodina = 35;

        }

        [TestMethod]

        public void TestGetterZeljeniMaxGodina()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, false, 0, 20);

            Assert.AreEqual(k1.ZeljeniMaxGodina, 20);
        }

        [TestMethod]

        public void TestSetterRazvod()
        {
            Korisnik k1 = new Korisnik();
            k1.Razvod = false;
            Assert.IsFalse(k1.Razvod);
        }

        [TestMethod]

        public void TestGetterRazvod()
        {
            Korisnik k1 = new Korisnik("Mubina", "xyz*+", Lokacija.Sarajevo, Lokacija.Zenica, 21, true, 0, 20);
           
            Assert.IsTrue(k1.Razvod);
        }
    }
}
