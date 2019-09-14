using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public abstract class osoba
    {
        //atributi koji opisuju bilo koju osobu
        protected string ime { get; set; }
        protected string prezime { get; set; }
        protected string datumRodjenja;
        protected string maticniBroj { get; set; }
        protected string spol;
        protected string adresaStanovanja;
        protected string bracnostanje;
        protected string sifra { get; set; }
        protected string korisnicko { get; set; }
        //kontruktor kopije
        public osoba(osoba o)
        {
            ime = o.ime;
            prezime = o.prezime;
            datumRodjenja = o.datumRodjenja;
            maticniBroj = o.maticniBroj;
            spol = o.spol;
            adresaStanovanja = o.adresaStanovanja;
            bracnostanje = o.bracnostanje;
        }
        //konstruktor sa parametrom koji postavlja atribute na osnovu onoga sto smo unijeli
        public osoba(string im, string prez, string dR, string mR, string sp, string aS, string bR)
        {
            ime = im;
            prezime = prez;
            datumRodjenja = dR;
            maticniBroj = mR;
            spol = sp;
            adresaStanovanja = aS;
            bracnostanje = bR;
        }

        public string MaticniBroj
        {
            get
            {
                return maticniBroj;
            }
        }
        public string Ime
        {
            get
            {
                return ime;
            }
        }
        public string Prezime
        {
            get
            {
                return prezime;
            }
        }
        public string Sifra
        {
            get
            {
                return sifra;
            }
        }
        public string Korisnicko
        {
            get
            {
                return korisnicko;
            }
        }
    }
}
