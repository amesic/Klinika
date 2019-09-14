using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace osobe
{
    public class doktor //jos klasa plata 
    {
        string ime { get; set; }
        string prezime { get; set; }
        string maticniBroj { get; set; }
        public doktor()
        {
            ime = "\0";
            prezime = "\0";
        }
        public doktor(string i, string p,string mb)
        {
            ime = i;
            prezime = p;
            maticniBroj = mb;

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

    }
}
