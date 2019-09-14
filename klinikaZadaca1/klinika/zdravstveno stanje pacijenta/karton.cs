using osobe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zdravstveno_stanje_pacijenta
{
    public class karton  
    {
        //atributi za karton
        private static long brojackartona;
        public long brojkartona { get; set; }
        private pregled Pregled { get; set; }
        private List<string> ranijebolesti { get; set; }
        private List<string> ranijealergije { get; set; }
        private List<string> trenutnebolesti { get; set; }
        private List<string> trenutnealergije { get; set; }
        private string zdravstvenostanjeporodice { get; set; }
        //konstruktor bez parametra
        public karton()
        {
            Pregled = new pregled();
            ranijebolesti = new List<string>();
            ranijealergije = new List<string>();
            trenutnealergije = new List<string>();
            trenutnebolesti = new List<string>();
            zdravstvenostanjeporodice = "\0";
            brojkartona = brojackartona;
            brojackartona++;
        }
        //konstruktor sa parametrima
        public karton(string zp)
        {
            Pregled = new pregled();
            zdravstvenostanjeporodice = zp;

        }
        //daj pregled
        public pregled PregledPacijenta
        {
            get
            {
                return Pregled;
            }
        }
        
        //pregled
        public void dodajPregledUKarton(pregled p)
        {
            Pregled = p;
        }
        public List<string> Ranijebolesti {
            get
            {
                return ranijebolesti;
            }
        }
        public List<string> Ranijealergije {
            get
            {
                return ranijealergije;
            }
        }
        public List<string> Trenutnebolesti
        {
            get
            {
                return trenutnebolesti;
            }
        }
        public List<string> Trenutnealergije
        {
            get
            {
                return trenutnealergije;
            }
        }
        public string Zdravstvenostanjeporodice
        {
            get
            {
                return zdravstvenostanjeporodice;
            }
        }
        public void dodajRanu(string rb)
        {

            ranijebolesti.Add(rb);
        }
        public void dodajRanuAl(string ra)
        {
            ranijealergije.Add(ra);
        }
        public void dodajSadasnju(string sb)
        {
            trenutnebolesti.Add(sb);
        }
        public void dodajSadasnjuAl(string sa)
        {
            trenutnealergije.Add(sa);
        }
        public void dodajzdravlje(string sa)
        {
            zdravstvenostanjeporodice = sa;
        }




    }
}
