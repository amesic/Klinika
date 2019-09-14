using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public class pacijent:osoba
    {
        //atributi koji su zajednicki za sve pacijente
        private string datumPrijema;
        private karton k { get; set; }
        private int racun { get; set; }

        //konstruktor koji postavlja sve atribute i iz osobe tj bazne klase i izvedene tj pacijent
        public pacijent(string im, string prez, string dR, string mR, string sp, string aS, string bR, string dP) : base(im, prez, dR, mR, sp, aS, bR)
        {
            k = new karton();
            datumPrijema = dP;
            racun = 0;
        }
        //kopirajuci kontruktor
        public pacijent(pacijent p) : base(p.ime, p.prezime, p.datumRodjenja, p.maticniBroj, p.spol, p.adresaStanovanja, p.bracnostanje)
        {
            datumPrijema = p.datumPrijema;
            k = p.k;
        }
        //dodaj karton pacijentu
        public void DodajKartonPacijentu(karton Karton)
        {
            k = Karton;
        }
        //daj njegov karton
        public karton DajKartonPacijenta
        {
            get
            {
                return k;
            }
        }
        //daj njegov racun
        public int Racun
        {
            get
            {
                return racun;
            }
        }
        //dodaj na racun
        public void dodajNaRacun(int br)
        {
            racun += br;
        }
        public void dodajSifru(string sif)
        {
            sifra = sif;
        }
        public void dodajKorisnicko(string kor)
        {
            korisnicko = kor;
        }

    }
}
