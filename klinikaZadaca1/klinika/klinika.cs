using ordinacije;
using osobe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zdravstveno_stanje_pacijenta;

namespace ZADACArpr
{
    public partial class klinika
    {
        List<pacijent> listapacijenata { get; set; }
        List<ordinacija> listaordinacija { get; set; }
        List<doktor> listadoktora { get; set; }
        private string naziv;
        //konstuktor
        public klinika(string naz)
        {
            naziv = naz;
            listapacijenata = new List<pacijent>();
            //listakartona = new List<karton>();
            listaordinacija = new List<ordinacija>();
            listadoktora = new List<doktor>();
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
                        Console.WriteLine("Pacijent {0} {1} je vec evidentiran!",p.Ime, p.Prezime);
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
            Console.WriteLine("Pacijent vec obrisan ili nije nikako evidentiran");
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
                    Console.WriteLine("Karton izbrisan!");
                    return true;
                }
            }
            Console.WriteLine("Pacijent {0} {1} nema kartona!",p.Ime,p.Prezime);
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
                        Console.WriteLine("Ordinacija {0} vec postoji",or.NazivOrdinacije);
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
                for(int i=0; i<listadoktora.Count; i++)
                {
                    if (listadoktora[i].MaticniBroj == d.MaticniBroj)
                    {
                        Console.WriteLine("Doktor {0} {1} je vec evidentiran u sistem ili ste pogrijesili maticni broj!",d.Ime,d.Prezime);
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
            Console.WriteLine("Pacijent je vec odjavljen iz {0} ordinacije ili nije bio ni prijavljen u redu za cekanje", or.NazivOrdinacije);
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
            for(int i=0; i<listapacijenata.Count; i++)
            {
                if (listapacijenata[i].MaticniBroj == matbr)
                {
                    return listapacijenata[i];
                }
            }
            Console.WriteLine("Pacijent ne postoji u arhivi");
             return null;
        }
        //  racun pacijenta
        public void obracunaj( pacijent p)
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
