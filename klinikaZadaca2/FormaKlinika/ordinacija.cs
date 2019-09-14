using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public class ordinacija
    {
        private doktor d { get; set; }
        private List<pacijent> listapacijenata { get; set; }
        private List<aparat> listaAparata { get; set; }
        private string nazivordinacije { get; set; }
        //kontruktor ako unesemo samo ime ordinacije
        public ordinacija(string naziv)
        {
            nazivordinacije = naziv;
            listapacijenata = new List<pacijent>();
            listaAparata = new List<aparat>();
        }
        //kopirajuci kontruktor
        public ordinacija(ordinacija or)
        {
            d = or.d;
            nazivordinacije = or.nazivordinacije;
            for (int i = 0; i < or.listapacijenata.Count; i++)
            {
                listapacijenata[i] = or.listapacijenata[i];
            }
            for (int i = 0; i < or.listaAparata.Count; i++)
            {
                listaAparata[i] = or.listaAparata[i];
            }
        }
        public void dodajDoktoraUord(doktor dr)
        {
            d = new doktor(dr);
        }
        //ako ordinacija sadrzi aparat dodaj ga
        public void dodajAparat(aparat a)
        {
            listaAparata.Add(a);
        }
        //funkcionalnost aparata
        public bool funkcionalnostAparata(string naziv, bool radi)
        {
            for (int i = 0; i < listaAparata.Count; i++)
            {
                if (listaAparata[i].DajNazivAparata == naziv)
                {
                    listaAparata.Remove(listaAparata[i]);
                    aparat a = new aparat(naziv, radi);
                    listaAparata.Add(a);
                    return true;
                }
            }
            return false;
        }
        //daj naziv ordinacije
        public string NazivOrdinacije
        {
            get
            {
                return nazivordinacije;
            }
        }
        //dodaj pacijenta koji ceka na pregled u odredjenoj ordinaciji
        public bool dodajPacijentaUOrd(pacijent p)
        {
            if (listapacijenata.Count == 0)
            {
                listapacijenata.Add(p);
                return true;
            }
            else
            {
                for (int i = 0; i < listapacijenata.Count; i++)
                {
                    if (listapacijenata[i].MaticniBroj == p.MaticniBroj)
                    {
                        return false;
                    }
                }
                listapacijenata.Add(p);
                return true;
            }
        }
        public void dodajDoktora(doktor dr)
        {
            d = dr;
        }
        public doktor Doktor
        {
            get
            {
                return d;
            }
        }
        public List<aparat> Aparati
        {
            get
            {
                return listaAparata;
            }
        }
        public List<pacijent> dajListuPacijenata
        {
            get
            {
                return listapacijenata;
            }
        }
    }
}
