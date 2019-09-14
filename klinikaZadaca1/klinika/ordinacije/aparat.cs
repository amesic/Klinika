using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordinacije
{
    public class aparat
    {
        private string naziv { get; set; }
        private bool daliradi { get; set; }
        //kontruktor koji postavlja naziv aparata
        public aparat(string naz)
        {
            naziv = naz;
            daliradi = true;
        }
        //kontruktor koji postavlja funkcionalnost aparata
        public aparat(string naz, bool radi)
        {
            naziv = naz;
            daliradi = radi;
        }
        //kontruktor kopije
        public aparat(aparat a)
        {
            naziv = a.naziv;
            daliradi = a.daliradi;
        }
        public bool Daliradi
        {
            get
            {
                return daliradi;
            }
        }
        public string DajNazivAparata
        {
            get
            {
                return naziv;
            }
        }
    }
}
