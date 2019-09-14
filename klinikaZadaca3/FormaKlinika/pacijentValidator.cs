using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public sealed class pacijentValidator
    {
        //konstruktor bez parametara
        private pacijentValidator() { }
        //provjera validnosti imena
        public static bool validnostImena(string ime)
        {
            if (ime != "\0" && Regex.IsMatch(ime, "^[A-Z]{1}[a-z]{2,}$")) return true;
            return false;
        }
        //provjera validnosti prezimena
        public static bool validnostPrezimena(string prezime)
        {
            if (prezime != "\0" && Regex.IsMatch(prezime, "^[A-Z]{1}[a-z]{2,}$")) return true;
            return false;
        }
        //validnost JMBG:
        private static bool validnostDatumaJMBG(string jmbg)
        {
            DateTime datumJmbg;
            if (DateTime.TryParse(jmbg.Substring(2, 2) + "/" + jmbg.Substring(0, 2) + "/1" + jmbg.Substring(4, 3) + " 00:00:00.0", out datumJmbg) || DateTime.TryParse(jmbg.Substring(2, 2) + "/" + jmbg.Substring(0, 2) + "/2" + jmbg.Substring(4, 3) + " 00:00:00.0", out datumJmbg)) return true;
            return false;
        }
        private static bool validnostRegistracijskogPodrucjaJMBG(string jmbg)
        {
            int registracijskoPodrucje;
            if (Int32.TryParse(jmbg.Substring(7, 2), out registracijskoPodrucje) && registracijskoPodrucje >= 10 && registracijskoPodrucje <= 19) return true;
            return false;
        }
        private static bool validnostSpolaJMBG(string jmbg)
        {
            int spol;
            if (Int32.TryParse(jmbg.Substring(9, 3), out spol) && spol >= 0 && spol <= 999) return true;
            return false;
        }
        private static bool validnostKontrolnogBrojaJMBG(string jmbg)
        {
            int kontrolniBroj = 0;
            for (int i = 6; i >= 1; i--)
            {
                kontrolniBroj += (i + 1) * (Convert.ToInt32(jmbg.Substring(6 - i, 1)) + Convert.ToInt32(jmbg.Substring(12 - i, 1)));
            }
            kontrolniBroj %= 11;
            if (kontrolniBroj == 1)
            {
                return false;
            }
            else if (kontrolniBroj > 1)
            {
                kontrolniBroj = 11 - kontrolniBroj;
            }
            return Convert.ToInt32(jmbg.Substring(12, 1)) == kontrolniBroj;
        }
        public static bool validnostJMBG(string jmbg)
        {
            if (jmbg != null && Regex.IsMatch(jmbg, "[0-9]{13}") && validnostDatumaJMBG(jmbg) && validnostRegistracijskogPodrucjaJMBG(jmbg) && validnostSpolaJMBG(jmbg) && validnostKontrolnogBrojaJMBG(jmbg)) return true;
            return false;
        }
        //validnost adrese stanovanja
        public static bool validnostAdrese(string adresa)
        {
            if (adresa != null && Regex.IsMatch(adresa, "[A-Z]{1}[a-z]{2,}[0-9]")) return true;
            return false;
        }
    }
}
