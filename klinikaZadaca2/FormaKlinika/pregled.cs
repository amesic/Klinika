using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public class pregled
    {
        private List<string> dijagnoza { get; set; }
        private List<string> terapija { get; set; }
        private List<string> misljenjeDoktora { get; set; }
        private string datumTerapije { get; set; }
        private List<ordinacija> listaordinacija { get; set; }
        public pregled()
        {
            dijagnoza = new List<string>();
            terapija = new List<string>();
            misljenjeDoktora = new List<string>();
            listaordinacija = new List<ordinacija>();
        }
        //dr dodaje dijagnozu
        public void dodajDijagnozu(string d)
        {
            dijagnoza.Add(d);
        }
        //terapija
        public void dodajTerapiju(string t)
        {
            terapija.Add(t);
        }
        //misljenje doktora
        public void dodajMisljenje(string m)
        {
            misljenjeDoktora.Add(m);
        }
        //datum terapije
        public void dodajDatumTerapije(string dt)
        {
            datumTerapije = dt;
        }
        //pregled mora imati listu ordinacija koje pacijent treba da obidje
        public void dodajOrdinacijuUPregled(ordinacija or)
        {
            listaordinacija.Add(or);
        }

        public List<ordinacija> DajOrdinacije
        {
            get
            {
                return listaordinacija;
            }
        }
        public void obrisiTerapiju()
        {
            for (int i = 0; i < terapija.Count; i++) terapija.Remove(terapija[i]);
        }
        public List<string> Dijagnoza
        {
            get
            {
                return dijagnoza;
            }
        }
        public List<string> Terapija
        {
            get
            {
                return terapija;
            }
        }
        public List<string> Misljenjedoktora
        {
            get
            {
                return misljenjeDoktora;
            }
        }
        public string DatumTerapije
        {
            get
            {
                return datumTerapije;
            }
        }
    }
}
