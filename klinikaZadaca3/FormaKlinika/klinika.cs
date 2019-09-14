using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormaKlinika
{
    public class klinika
    {
        List<pacijent> listapacijenata { get; set; }
        List<ordinacija> listaordinacija { get; set; }
        List<doktor> listadoktora { get; set; }
        List<Uposlenici> listauposlenika { get; set; }

        //konstuktor
        public klinika(klinika k)
        {
            listapacijenata = k.listapacijenata;
            listaordinacija = k.listaordinacija;
            listadoktora = k.listadoktora;
            listauposlenika = k.listauposlenika;
        }
        public klinika()
        {
            listapacijenata = new List<pacijent>();
            listaordinacija = new List<ordinacija>();
            listadoktora = new List<doktor>();
            listauposlenika = new List<Uposlenici>();
        }
        //dodaj uposlenika
        public bool dodajIposlenika(Uposlenici u)
        {
            if (listauposlenika.Count == 0)
            {
                listauposlenika.Add(u);
                return true;
            }
            else
            {
                for (int i = 0; i < listauposlenika.Count; i++)
                {
                    if (listauposlenika[i].MaticniBroj == u.MaticniBroj)
                {
                    return false;
                }
            }
            listauposlenika.Add(u);
            return true;

        }
        }
        public List<Uposlenici> listaUposlenika
        {
            get
            {
                return listauposlenika;
            }
        }
        //dodaj pacijenta u kliniku
        public bool dodajPacijenta(pacijent p)
        {
            //ako je prazna lista dodaj odmah
            if (listapacijenata.Count == 0)
            {
                listapacijenata.Add(p);
                return true;
            }
            //ako lista nije prazna, prvo treba provjeriti da li je pacijent vec prijavljen u kliniku
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
        //obrisi pacijenta iz klinike iz nekog razloga
        public bool obrisiPacijenta(pacijent p)
        {
            for (int i = 0; i < listapacijenata.Count; i++)
            {
                if (listapacijenata[i].MaticniBroj == p.MaticniBroj)
                {
                    listapacijenata.Remove(listapacijenata[i]);
                    return true;
                }
            }
            return false;
        }
        //obrisi njegov karton
        public bool obrisiKarton(pacijent p)
        {
            for (int i = 0; i < listapacijenata.Count; i++)
            {
                if (listapacijenata[i].MaticniBroj == p.MaticniBroj)
                {
                    karton k = p.DajKartonPacijenta;
                    k = null;
                    return true;
                }
            }
            return false;
        }
        //dodaj ordinaciju u kliniku
        public bool dodajOrdinaciju(ordinacija or)
        {
            if (listaordinacija.Count == 0)
            {
                listaordinacija.Add(or);
                return true;
            }
            else
            {
                for (int i = 0; i < listaordinacija.Count; i++)
                {
                    if (listaordinacija[i].NazivOrdinacije == or.NazivOrdinacije)
                    {
                        return false;
                    }
                }
                listaordinacija.Add(or);
                return true;
            }

        }
        //doktori
        public bool dodajDoktora(doktor d)
        {
            if (listadoktora.Count == 0)
            {
                listadoktora.Add(d);
                return true;
            }
            else
            {
                for (int i = 0; i < listadoktora.Count; i++)
                {
                    if (listadoktora[i].MaticniBroj == d.MaticniBroj)
                    {
                        return false;
                    }
                }
                listadoktora.Add(d);
                return true;
            }
        }
        //kada je pacijent zavrsio sa pregledom
        public bool obrisiPacijentaIzOrdinacije(pacijent p, ordinacija or)
        {
            for (int i = 0; i < p.DajKartonPacijenta.PregledPacijenta.DajOrdinacije.Count; i++)
            {
                if (p.DajKartonPacijenta.PregledPacijenta.DajOrdinacije[i].NazivOrdinacije == or.NazivOrdinacije)
                {
                    p.DajKartonPacijenta.PregledPacijenta.DajOrdinacije.Remove(p.DajKartonPacijenta.PregledPacijenta.DajOrdinacije[i]);
                    return true;
                }
            }
            return false;
        }
        // lista pacijenata
        public List<pacijent> listaPacijenata
        {
            get
            {
                return listapacijenata;
            }
        }
        // lista doktora
        public List<doktor> listaDoktora
        {
            get
            {
                return listadoktora;
            }
        }
        // lista pacijenata
        public List<ordinacija> listaOrdinacija
        {
            get
            {
                return listaordinacija;
            }
        }
        //daj mi odredjenog pacijenta
        public pacijent dajPacijenta(string matbr)
        {
            for (int i = 0; i < listapacijenata.Count; i++)
            {
                if (listapacijenata[i].MaticniBroj == matbr)
                {
                    return listapacijenata[i];
                }
            }
            return null;
        }
        //  racun pacijenta
        public void obracunaj(pacijent p)
        {
            for (int i = 0; i < listaordinacija.Count; i++)
            {
                for (int j = 0; j < listaordinacija[i].dajListuPacijenata.Count; j++)
                {
                    if (listaordinacija[i].dajListuPacijenata[j].MaticniBroj == p.MaticniBroj)
                    {
                        if (listaordinacija[i].NazivOrdinacije == "dermatoloska") p.dodajNaRacun(100);
                        if (listaordinacija[i].NazivOrdinacije == "kardioloska") p.dodajNaRacun(200);
                        if (listaordinacija[i].NazivOrdinacije == "laboratorijska") p.dodajNaRacun(50);
                        if (listaordinacija[i].NazivOrdinacije == "oftamoloska") p.dodajNaRacun(100);
                        if (listaordinacija[i].NazivOrdinacije == "otorinolaringologija") p.dodajNaRacun(20);
                        if (listaordinacija[i].NazivOrdinacije == "ortopedska") p.dodajNaRacun(30); ;
                    }
                }
            }
        }
        //daj racun
        public int dajRacun(pacijent p)
        {
            return p.Racun;
        }
    }
}
