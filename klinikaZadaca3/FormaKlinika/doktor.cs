using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public class doktor: osoba
    {
        //konstuktor za doktora
        public doktor(string im, string prez, string dR, string mR, string sp, string aS, string bR) : base(im, prez, dR, mR, sp, aS, bR)
        { }
        //konstuktor kopije
        public doktor(doktor d) : base(d.ime, d.prezime, d.datumRodjenja, d.maticniBroj, d.spol, d.adresaStanovanja, d.bracnostanje)
        { }
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
