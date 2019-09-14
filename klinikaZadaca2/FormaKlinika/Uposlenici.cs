using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public class Uposlenici:osoba
    {
        public Uposlenici(string im, string prez, string dR, string mR, string sp, string aS, string bR) : base(im, prez, dR, mR, sp, aS, bR)
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
