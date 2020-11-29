using System;
using System.Collections.Generic;
using System.Text;

namespace Kupid
{
    public class Komunikator
    {
        #region Atributi

        List<Korisnik> korisnici;
        List<Chat> razgovori;

        #endregion

        #region Properties

        public List<Korisnik> Korisnici
        {
            get => korisnici;
        }

        public List<Chat> Razgovori
        {
            get => razgovori;
        }

        #endregion

        #region Konstruktor

        public Komunikator()
        {
            korisnici = new List<Korisnik>();
            razgovori = new List<Chat>();
        }

        #endregion

        #region Metode

        public void RadSaKorisnikom(Korisnik k, int opcija)
        {
            if (opcija == 0)
            {
                Korisnik postojeci = korisnici.Find(korisnik => korisnik.Ime == k.Ime);
                if (postojeci != null)
                    throw new InvalidOperationException("Korisnik već postoji!");

                korisnici.Add(k);
            }
            else if (opcija == 1)
            {
                Korisnik postojeci = korisnici.Find(korisnik => korisnik.Ime == k.Ime);
                if (postojeci == null)
                    throw new InvalidOperationException("Korisnik ne postoji!");

                korisnici.Remove(k);

                List<Chat> razgovoriZaBrisanje = new List<Chat>();
                foreach (Chat c in razgovori)
                {
                    if (c.Korisnici.Find(korisnik => korisnik.Ime == k.Ime) != null)
                        razgovoriZaBrisanje.Add(c);
                }

                foreach (Chat brisanje in razgovoriZaBrisanje)
                    razgovori.Remove(brisanje);
            }
        }

        public void DodavanjeRazgovora(List<Korisnik> korisnici, bool grupniChat)
        {
            if (korisnici == null || korisnici.Count < 2 || (!grupniChat && korisnici.Count > 2))
                throw new ArgumentException("Nemoguće dodati razgovor!");

            if (grupniChat)
                razgovori.Add(new GrupniChat(korisnici));

            else
                razgovori.Add(new Chat(korisnici[0], korisnici[1]));
        }

        /// <summary>
        /// Metoda u kojoj se vrši pronalazak svih poruka koje u sebi sadrže traženi sadržaj.
        /// Ukoliko je sadržaj prazan ili ne postoji nijedan chat, baca se izuzetak.
        /// U razmatranje se uzimaju i grupni, i individualni chatovi, a ne smije se uzeti u razmatranje
        /// nijedan chat u kojem se nalazi korisnik sa imenom "admin".
        /// </summary>
        public List<Poruka> IzlistavanjeSvihPorukaSaSadržajem(string sadržaj)
        {   
            List<Poruka> lista = new List<Poruka>();

            if(sadržaj==null) throw new InvalidOperationException("Prazan sadržaj");
            if(razgovori.Count==0) throw new InvalidOperationException("Ne postoji nijedan chat");
            foreach(Chat c in razgovori) {
                foreach(Poruka p in c.Poruke) {
                    if(p.Sadrzaj.Contains(sadržaj) && p.Primalac.Ime!="admin" && p.Posiljalac.Ime!="admin")
                        lista.Add(p);
                }
            }
            return lista;
        }

        public bool DaLiJeSpajanjeUspjesno(Chat c, IRecenzija r)
        {
            if (c is GrupniChat)
                throw new InvalidOperationException("Grupni chatovi nisu podržani!");

            if (c.Poruke.Find(poruka => poruka.IzračunajKompatibilnostKorisnika() == 100) != null
                && r.DajUtisak() == "Pozitivan")
                return true;

            else
                return false;
        }

        public void SpajanjeKorisnika()
        {
            bool postoji = false;
            foreach(Korisnik k in korisnici)
            {
                foreach(Korisnik k1 in korisnici)
                {
                    if(k1.Ime!=k.Ime && ((k1.Lokacija.Equals(k.Lokacija) && k1.ZeljenaLokacija.Equals(k.ZeljenaLokacija)) || k1.Godine.Equals(k.Godine)))
                    {

                        Chat chat = new Chat(k, k1);
                        if (razgovori.Count >= 1)
                        {
                            foreach (Chat c in razgovori)
                            {
                                if (!c.Korisnici.Contains(k1) || !c.Korisnici.Contains(k))
                                {
                                    razgovori.Add(chat);
                                    postoji = true;
                                }
                                if (postoji) break;

                            }
                        }
                        else
                        {
                            razgovori.Add(chat);
                            postoji = true;
                        }
                    }
                   if (postoji) break;

                }
            }
            if (!postoji) throw new ArgumentException("Nema spajanja");
        }

        #endregion
    }
}
