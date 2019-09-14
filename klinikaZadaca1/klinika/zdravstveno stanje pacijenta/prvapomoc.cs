using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klinika.zdravstveno_stanje_pacijenta
{
    class prvapomoc
    {
        public enum Stanje {stabilan, nestabilan, umro}
        private string protokolprvepomoci;
        private string razlogprotokola;
        private Stanje stanje;
        public prvapomoc(string protokol, string razlog, Stanje st)
        {
            protokolprvepomoci = protokol;
            razlogprotokola = razlog;
            stanje = st;
        }


    }
}
