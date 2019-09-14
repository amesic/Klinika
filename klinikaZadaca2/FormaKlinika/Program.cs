using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaKlinika
{
    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            klinika Klinika = new klinika();
            ordinacija or = new ordinacija("Kardioloska ordinacija");
            ordinacija or1 = new ordinacija("Dermatoloska ordinacija");
            ordinacija or2 = new ordinacija("Laboratorijska");
            ordinacija or3 = new ordinacija("Otorinolaringologija ordinacija");
            ordinacija or4 = new ordinacija("Stomatoloska ordinacija");
            ordinacija or5 = new ordinacija("Ortopedska ordinacija");
            ordinacija or6 = new ordinacija("Oftamoloska ordinacija");
            Klinika.dodajOrdinaciju(or);
            Klinika.dodajOrdinaciju(or1);
            Klinika.dodajOrdinaciju(or2);
            Klinika.dodajOrdinaciju(or3);
            Klinika.dodajOrdinaciju(or4);
            Klinika.dodajOrdinaciju(or5);
            Klinika.dodajOrdinaciju(or6);
            aparat a = new aparat("ekg", true);
            aparat a1 = new aparat("dermatoloski", true);
            aparat a2 = new aparat("labaratorijski", true);
            aparat a3 = new aparat("otorinolaringologiski", true);
            aparat a4 = new aparat("stomatoloski", true);
            aparat a5 = new aparat("ortopedski", true);
            aparat a6 = new aparat("oftamoloski", false);
            Klinika.listaOrdinacija[0].dodajAparat(a);
            Klinika.listaOrdinacija[1].dodajAparat(a1);
            Klinika.listaOrdinacija[2].dodajAparat(a2);
            Klinika.listaOrdinacija[3].dodajAparat(a3);
            Klinika.listaOrdinacija[4].dodajAparat(a4);
            Klinika.listaOrdinacija[5].dodajAparat(a5);
            Klinika.listaOrdinacija[6].dodajAparat(a6);
            doktor dr = new doktor("Mujo", "Mujic", "19.04.1981", "0706003171116", "musko", "olimpijska 8", "ozenjen");
            doktor dr1 = new doktor("Fata", "Mujic", "10.04.1991", "0101971177217", "zensko", "olimpijska 8", "udata");
            doktor dr2 = new doktor("Suljo", "Mujic", "09.01.1981", "0101971177216", "musko", "olimpijska 40", "ozenjen");
            doktor dr3 = new doktor("Maja", "Majic", "03.04.1981", "0101971177215", "zensko", "olimpijska 50", "slobodna");
            Klinika.dodajDoktora(dr);
            Klinika.dodajDoktora(dr1);
            Klinika.dodajDoktora(dr2);
            Klinika.dodajDoktora(dr3);
            Uposlenici u = new Uposlenici("Maja", "Maji", "05.05.1981", "0101971177218", "zensko", "olimpijska 20", "slobodna");
            Uposlenici u1 = new Uposlenici("Ajla", "Maji", "06.06.1981", "0101971177213", "zensko", "olimpijska 20", "slobodna");
            Uposlenici u2 = new Uposlenici("Emi", "Maji", "07.07.1981", "0101971177212", "zensko", "olimpijska 20", "slobodna");
            Klinika.dodajIposlenika(u);
            Klinika.dodajIposlenika(u1);
            Klinika.dodajIposlenika(u2);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(Klinika));
        }
    }
}
