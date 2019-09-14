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
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ime klinike: ");
            string naziv = Console.ReadLine();
            klinika Klinika17496_1 = new klinika(naziv);
            //DateTime d1 = new DateTime(1997, 04, 19);
            Console.WriteLine("Unesi ordinacije u funkciji u klinici: (0 za kraj, za novi unos enter)");
            string pomocna = Console.ReadLine();
            while (pomocna != "0")
            {
                ordinacija or = new ordinacija(pomocna);
                Klinika17496_1.dodajOrdinaciju(or);
                pomocna = Console.ReadLine();
            }
            Console.WriteLine("Unesi ime, prezime i maticni broj odvojenih razmakom doktore ordinacija respektivno sa prijasnjim unosom:(0 za kraj, za novi unos enter)");
            int brojac = 0;
            do
            {
                pomocna = Console.ReadLine();
                if (pomocna == "0") break;
                string[] s = pomocna.Split(' ');
                if (s.Length != 3)
                {
                    Console.WriteLine("Neispravan format unosa. Unesi opet");
                    continue;
                }
                if (s[2].Length != 13)
                {
                    Console.WriteLine("Neispravan format maticnog broja. Unesi opet");
                    continue;
                }
                doktor dr = new doktor(s[0], s[1], s[2]);
                if (Klinika17496_1.dodajDoktora(dr) == true)
                {
                    Klinika17496_1.listaOrdinacija[brojac].dodajDoktora(dr);
                }
                else continue;
                brojac++;
            } while (pomocna != "0" && Klinika17496_1.listaOrdinacija.Count != brojac);
            Console.WriteLine("Unesi aparate respektivno sa unosom ordinacija. format unosa: imeaparata funkcionalnost(0 ne radi, 1 radi)");
            brojac = 0;
            do
            {
                pomocna = Console.ReadLine();
                if (pomocna == "0") break;
                string[] s = pomocna.Split(' ');
                if (s.Length != 2)
                {
                    Console.WriteLine("Pogresan oblik unosa. Unesi opet!");
                    continue;
                }
                bool broj;
                if (s.Length==2 && s[1] == "0") broj = false;
                else if (s.Length == 2 && s[1] == "1") broj = true;
                else
                {
                    Console.WriteLine("Pogresan unos funkcionalnosti");
                    continue;
                }
                aparat a = new aparat(s[0], broj);
                Klinika17496_1.listaOrdinacija[brojac].dodajAparat(a);
                brojac++;
            } while (pomocna != "0" && Klinika17496_1.listaOrdinacija.Count!= brojac);
            for (;;) {
                ponovo:
                Console.WriteLine("Glavni meni, izaberi broj: ");
                Console.WriteLine("1. Registruj/Briši pacijenta");
                Console.WriteLine("2. Prikaži raspored pregleda pacijenta");
                Console.WriteLine("3. Kreiranje kartona pacijenta");
                Console.WriteLine("4. Pretraga kartona pacijenta");
                Console.WriteLine("5. Registruj novi pregled");
                Console.WriteLine("6. Analiza sadržaja");
                Console.WriteLine("7. Naplata");
                Console.WriteLine("8. Izlaz");
                string s = Console.ReadLine();
                if (s == "1")
                {
                    Console.WriteLine("Izaberi jednu od dvije opcije: ");
                    Console.WriteLine("a. Registruj pacijenta");
                    Console.WriteLine("b. Brisi pacijenta");
                    string s1 = Console.ReadLine();
                    if (s1 == "a")
                    {
                        Console.WriteLine("Ime pacijenta: ");
                        string ime = Console.ReadLine();
                        Console.WriteLine("Prezime pacijenta: ");
                        string prez = Console.ReadLine();
                        Console.WriteLine("Dan rodjenja: ");
                        int dan = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Mjesec rodjenja: ");
                        int mjesec = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Godina rodjenja: ");
                        int godina = Int32.Parse(Console.ReadLine());
                        DateTime datRodj = new DateTime(godina, mjesec, dan);
                        Console.WriteLine("Maticni broj pacijenta: ");
                        string mr = Console.ReadLine();
                        Console.WriteLine("Spol pacijenta: ");
                        string sp = Console.ReadLine();
                        Console.WriteLine("Adresa stanovanja pacijenta: ");
                        string adr = Console.ReadLine();
                        Console.WriteLine("Bracno stanje pacijenta: ");
                        string brac = Console.ReadLine();
                        Console.WriteLine("Dan prijave pacijenta: ");
                        int danp = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Mjesec prijave pacijenta: ");
                        int mjesecp = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Godina prijave pacijenta: ");
                        int godinap = Int32.Parse(Console.ReadLine());
                        DateTime datPri = new DateTime(godinap, mjesecp, danp);
                        pacijent p = new pacijent(ime, prez, datRodj, mr, sp, adr, brac, datPri);
                        Klinika17496_1.dodajPacijenta(p);

                        karton k = new karton();
                        p.DodajKartonPacijentu(k);
                        Console.WriteLine("Zdravstveno stanje porodice: ");
                        string zs = Console.ReadLine();
                        k.dodajzdravlje(zs);
                        Console.WriteLine("Ranije bolesti pacijenta: (0 za kraj)");
                        string rb;
                        do
                        {
                            rb = Console.ReadLine();
                            if (rb == "0") break;
                            p.DajKartonPacijenta.dodajRanu(rb);

                        } while (rb != "0");
                        Console.WriteLine("Ranije alergije pacijenta:(0 za kraj) ");
                        string ra;
                        do
                        {
                            ra = Console.ReadLine();
                            if (ra == "0") break;
                            p.DajKartonPacijenta.dodajRanuAl(ra);

                        } while (ra != "0");
                        Console.WriteLine("Sadasnje bolesti pacijenta: (0 za kraj)");
                        string sb;
                        do
                        {
                            sb = Console.ReadLine();
                            if (sb == "0") break;
                            p.DajKartonPacijenta.dodajSadasnju(sb);

                        } while (sb != "0");
                        Console.WriteLine("Sadasnje alergije pacijenta: ");
                        string sa;
                        do
                        {
                            sa = Console.ReadLine();
                            if (sa == "0") break;
                            p.DajKartonPacijenta.dodajSadasnjuAl(sa);

                        } while (sa != "0");

                        Console.WriteLine("Za ponovni ulazak u meni kliknite 1");
                        string pon = Console.ReadLine();
                        if (pon == "1") goto ponovo;
                    }
                    else if (s1 == "b")
                    {
                        Console.WriteLine("Unesite maticni broj pacijenta: ");
                        string m;
                        do
                        {
                            m = Console.ReadLine();
                            if (m.Length != 13) Console.WriteLine("Neispravan unos maticnog broja");
                        } while (m.Length != 13);
                        Klinika17496_1.obrisiPacijenta(Klinika17496_1.dajPacijenta(m));
                        Console.WriteLine("Za ponovni ulazak u meni kliknite 1");
                        string pon = Console.ReadLine();
                        if (pon == "1") goto ponovo;
                        Console.ReadLine();
                    }
                }
                else if (s == "2")
                {
                    Console.WriteLine("Unesite maticni broj pacijenta: ");
                    string m;
                    do
                    {
                        m = Console.ReadLine();
                        if (m.Length != 13) Console.WriteLine("Neispravan unos maticnog broja");
                    } while (m.Length != 13);
                    if (Klinika17496_1.dajPacijenta(m) != null)
                    {
                        Console.WriteLine("Prijasnji pregledi pacijenta su bili u ordinacijama: ");
                    
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.DajOrdinacije.Count; i++)
                        {
                            Console.WriteLine("{0}", Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.DajOrdinacije[i].NazivOrdinacije);
                        }
                    }
                    Console.WriteLine("Za ponovni ulazak u meni kliknite 1");
                    string pon = Console.ReadLine();
                    if (pon == "1") goto ponovo;
                    Console.ReadLine();
                }
                else if (s == "3")
                {
                    Console.WriteLine("Ako zelite zaustaviti terapiju kliknite 1: ");
                    string z = Console.ReadLine();
                    if (z == "1")
                    {
                        Console.WriteLine("Unesite maticni broj pacijenta: ");
                        string m = Console.ReadLine();
                        Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.obrisiTerapiju();
                    }
                    else
                    {
                        Console.WriteLine("Unesite maticni broj pacijenta: ");
                        string m;
                        do
                        {
                            m = Console.ReadLine();
                            if (m.Length != 13) Console.WriteLine("Neispravan unos maticnog broja");
                        } while (m.Length != 13);
                        Console.WriteLine("Dijagnoza pacijenta: ");
                        string di = Console.ReadLine();
                        Console.WriteLine("Terapija pacijenta: ");
                        string te = Console.ReadLine();
                        Console.WriteLine("Misljenje doktora: ");
                        string dr = Console.ReadLine();
                        Console.WriteLine("Dan propisane terapije: ");
                        int dan = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Mjesec: ");
                        int mjesec = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Godina: ");
                        int godina = Int32.Parse(Console.ReadLine());
                        DateTime datTer = new DateTime(godina, mjesec, dan);
                        Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajDijagnozu(di);
                        Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajTerapiju(te);
                        Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajMisljenje(dr);
                        Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajDatumTerapije(datTer);
                        Console.WriteLine("Za ponovni ulazak u meni kliknite 1");
                        string pon = Console.ReadLine();
                        if (pon == "1") goto ponovo;
                        Console.ReadLine();
                    }
                }
                else if (s == "4")
                {
                    Console.WriteLine("Unesite maticni broj pacijenta: ");
                    string m;
                    do
                    {
                        m = Console.ReadLine();
                        if (m.Length != 13) Console.WriteLine("Neispravan unos maticnog broja");
                    } while (m.Length != 13);
                    Console.WriteLine("Ranije bolesti: ");
                    if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Ranijebolesti.Count == 0)
                    {
                        Console.WriteLine("nema");
                    }
                    else
                    {
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Ranijebolesti.Count; i++)
                        {
                            Console.WriteLine(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Ranijebolesti[i]);
                        }
                    }
                    Console.WriteLine("Ranije alergije: ");
                    if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Ranijealergije.Count == 0)
                    {
                        Console.WriteLine("nema");
                    }
                    else
                    {
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Ranijealergije.Count; i++)
                        {
                            Console.WriteLine(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Ranijealergije[i]);
                        }
                    }
                    Console.WriteLine("Trenutne bolesti: ");
                    if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count == 0)
                    {
                        Console.WriteLine("nema");
                    }
                    else
                    {
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            Console.WriteLine(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i]);
                        }
                    }
                    Console.WriteLine("Trenutne alergije: ");
                    if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnealergije.Count == 0)
                    {
                        Console.WriteLine("nema");
                    }
                    else
                    {
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnealergije.Count; i++)
                        {
                            Console.WriteLine(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnealergije[i]);
                        }
                    }
                    Console.WriteLine("Zdravstveno stanje porodice: {0}", Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Zdravstvenostanjeporodice);
                    //DateTime dat = new DateTime(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.DatumTerapije);
                    Console.WriteLine("Dijagnoza pacijenta: ");
                    for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.Dijagnoza.Count; i++)
                    {
                        Console.WriteLine(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.Dijagnoza[i]);
                    }
                    Console.WriteLine("Terapija pacijenta: ");
                    for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.Terapija.Count; i++)
                    {
                        Console.WriteLine(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.Terapija[i]);
                    }
                    Console.WriteLine("Misljenje doktora: ");
                    for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.Misljenjedoktora.Count; i++)
                    {
                        Console.WriteLine(Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.Misljenjedoktora[i]);
                    }
                    Console.WriteLine("Za ponovni ulazak u meni kliknite 1");
                    string pon = Console.ReadLine();
                    if (pon == "1") goto ponovo;
                    Console.ReadLine();
                }
                else if (s == "5")
                {
                    Console.WriteLine("Unesite maticni broj pacijenta: ");
                    string m;
                    do
                    {
                        m = Console.ReadLine();
                        if (m.Length != 13) Console.WriteLine("Neispravan unos maticnog broja");
                    } while (m.Length != 13);
                    if (Klinika17496_1.dajPacijenta(m) != null)
                    {
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i] == "koza")
                            {
                                int jeste = 0;

                                for (int k = 0; k < Klinika17496_1.listaOrdinacija.Count; k++)
                                {
                                    if (Klinika17496_1.listaOrdinacija[k].NazivOrdinacije == "dermatoloska")
                                    {
                                        jeste = 1;
                                        int radi = 1;
                                        for (int j = 0; j < Klinika17496_1.listaOrdinacija[k].Aparati.Count; j++)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].Aparati[j].Daliradi == false)
                                            {
                                                radi = 0;
                                                break;
                                            }
                                        }
                                        if (radi == 1)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].dodajPacijentaUOrd(Klinika17496_1.dajPacijenta(m)) == true)
                                            {
                                                Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajOrdinacijuUPregled(Klinika17496_1.listaOrdinacija[k]);
                                            }
                                        }
                                        else Console.WriteLine("Ordinacija {0} nije u funkciji", Klinika17496_1.listaOrdinacija[k].NazivOrdinacije);
                                    }
                                    /* if (jeste == 0)
                                     {
                                         Console.WriteLine("Ordinacija ne postoji");
                                     }*/
                                }

                            }
                        }
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i] == "srce")
                            {
                                int jeste = 0;

                                for (int k = 0; k < Klinika17496_1.listaOrdinacija.Count; k++)
                                {
                                    if (Klinika17496_1.listaOrdinacija[k].NazivOrdinacije == "kardioloska")
                                    {
                                        jeste = 1;
                                        int radi = 1;
                                        for (int j = 0; j < Klinika17496_1.listaOrdinacija[k].Aparati.Count; j++)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].Aparati[j].Daliradi == false)
                                            {
                                                radi = 0;
                                                break;
                                            }
                                        }
                                        if (radi == 1)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].dodajPacijentaUOrd(Klinika17496_1.dajPacijenta(m)) == true)
                                            {
                                                Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajOrdinacijuUPregled(Klinika17496_1.listaOrdinacija[k]);
                                            }
                                        }
                                        else Console.WriteLine("Ordinacija {0} nije u funkciji", Klinika17496_1.listaOrdinacija[k].NazivOrdinacije);
                                    }
                                    /*if (jeste == 0)
                                    {
                                        Console.WriteLine("Ordinacija ne postoji");
                                    }*/
                                }

                            }
                        }
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i] == "ne zna se")
                            {
                                int jeste = 0;

                                for (int k = 0; k < Klinika17496_1.listaOrdinacija.Count; k++)
                                {
                                    if (Klinika17496_1.listaOrdinacija[k].NazivOrdinacije == "laboratorijska")
                                    {
                                        jeste = 1;
                                        int radi = 1;
                                        for (int j = 0; j < Klinika17496_1.listaOrdinacija[k].Aparati.Count; j++)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].Aparati[j].Daliradi == false)
                                            {
                                                radi = 0;
                                                break;
                                            }
                                        }
                                        if (radi == 1)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].dodajPacijentaUOrd(Klinika17496_1.dajPacijenta(m)) == true)
                                            {
                                                Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajOrdinacijuUPregled(Klinika17496_1.listaOrdinacija[k]);
                                            }
                                        }
                                        else Console.WriteLine("Ordinacija {0} nije u funkciji", Klinika17496_1.listaOrdinacija[k].NazivOrdinacije);
                                    }
                                    /* if (jeste == 0)
                                     {
                                         Console.WriteLine("Ordinacija ne postoji");
                                     }*/
                                }

                            }
                        }
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i] == "zubi")
                            {
                                int jeste = 0;

                                for (int k = 0; k < Klinika17496_1.listaOrdinacija.Count; k++)
                                {
                                    if (Klinika17496_1.listaOrdinacija[k].NazivOrdinacije == "stomatoloska")
                                    {
                                        jeste = 1;
                                        int radi = 1;
                                        for (int j = 0; j < Klinika17496_1.listaOrdinacija[k].Aparati.Count; j++)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].Aparati[j].Daliradi == false)
                                            {
                                                radi = 0;
                                                break;
                                            }
                                        }
                                        if (radi == 1)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].dodajPacijentaUOrd(Klinika17496_1.dajPacijenta(m)) == true)
                                            {
                                                Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajOrdinacijuUPregled(Klinika17496_1.listaOrdinacija[k]);
                                            }
                                        }
                                        else Console.WriteLine("Ordinacija {0} nije u funkciji", Klinika17496_1.listaOrdinacija[k].NazivOrdinacije);
                                    }
                                    /*if (jeste == 0)
                                    {
                                        Console.WriteLine("Ordinacija ne postoji");
                                    }*/
                                }

                            }
                        }
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i] == "stopala")
                            {
                                int jeste = 0;

                                for (int k = 0; k < Klinika17496_1.listaOrdinacija.Count; k++)
                                {
                                    if (Klinika17496_1.listaOrdinacija[k].NazivOrdinacije == "ortopedska")
                                    {
                                        jeste = 1;
                                        int radi = 1;
                                        for (int j = 0; j < Klinika17496_1.listaOrdinacija[k].Aparati.Count; j++)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].Aparati[j].Daliradi == false)
                                            {
                                                radi = 0;
                                                break;
                                            }
                                        }
                                        if (radi == 1)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].dodajPacijentaUOrd(Klinika17496_1.dajPacijenta(m)) == true)
                                            {
                                                Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajOrdinacijuUPregled(Klinika17496_1.listaOrdinacija[k]);
                                            }
                                        }
                                        else Console.WriteLine("Ordinacija {0} nije u funkciji", Klinika17496_1.listaOrdinacija[k].NazivOrdinacije);
                                    }
                                    /* if (jeste == 0)
                                     {
                                         Console.WriteLine("Ordinacija ne postoji");
                                     }*/
                                }

                            }
                        }
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i] == "oci")
                            {
                                int jeste = 0;

                                for (int k = 0; k < Klinika17496_1.listaOrdinacija.Count; k++)
                                {
                                    if (Klinika17496_1.listaOrdinacija[k].NazivOrdinacije == "oftamolog")
                                    {
                                        jeste = 1;
                                        int radi = 1;
                                        for (int j = 0; j < Klinika17496_1.listaOrdinacija[k].Aparati.Count; j++)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].Aparati[j].Daliradi == false)
                                            {
                                                radi = 0;
                                                break;
                                            }
                                        }
                                        if (radi == 1)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].dodajPacijentaUOrd(Klinika17496_1.dajPacijenta(m)) == true)
                                            {
                                                Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajOrdinacijuUPregled(Klinika17496_1.listaOrdinacija[k]);
                                            }
                                        }
                                        else Console.WriteLine("Ordinacija {0} nije u funkciji", Klinika17496_1.listaOrdinacija[k].NazivOrdinacije);
                                    }
                                    /* if (jeste == 0)
                                     {
                                         Console.WriteLine("Ordinacija ne postoji");
                                     }*/
                                }

                            }
                        }
                        for (int i = 0; i < Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti.Count; i++)
                        {
                            if (Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.Trenutnebolesti[i] == "uho nos grlo")
                            {

                                for (int k = 0; k < Klinika17496_1.listaOrdinacija.Count; k++)
                                {
                                    if (Klinika17496_1.listaOrdinacija[k].NazivOrdinacije == "otorinolaringologija")
                                    {
                                        int radi = 1;
                                        for (int j = 0; j < Klinika17496_1.listaOrdinacija[k].Aparati.Count; j++)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].Aparati[j].Daliradi == false)
                                            {
                                                radi = 0;
                                                break;
                                            }
                                        }
                                        if (radi == 1)
                                        {
                                            if (Klinika17496_1.listaOrdinacija[k].dodajPacijentaUOrd(Klinika17496_1.dajPacijenta(m)) == true)
                                            {
                                                Klinika17496_1.dajPacijenta(m).DajKartonPacijenta.PregledPacijenta.dodajOrdinacijuUPregled(Klinika17496_1.listaOrdinacija[k]);
                                            }
                                        }
                                        else Console.WriteLine("Ordinacija {0} nije u funkciji", Klinika17496_1.listaOrdinacija[k].NazivOrdinacije);
                                    }
                                }

                            }
                        }
                        Klinika17496_1.obracunaj(Klinika17496_1.dajPacijenta(m));
                    }

                    Console.WriteLine("Za ponovni ulazak u meni kliknite 1");
                    string pon = Console.ReadLine();
                    if (pon == "1") goto ponovo;
                    Console.ReadLine();

                }
                else if (s == "7")
                {
                    Console.WriteLine("Unesite maticni broj pacijenta: ");
                    string m;
                    do
                    {
                        m = Console.ReadLine();
                        if (m.Length != 13) Console.WriteLine("Neispravan unos maticnog broja");
                    } while (m.Length != 13);
                    if (Klinika17496_1.dajPacijenta(m) != null)
                    {
                        Console.WriteLine("Pacijent placa: 1. gotivnom; 2. ratom");
                        string pom = Console.ReadLine();
                        if (pom == "1")
                        {
                            Console.WriteLine("Troskovi pacijenta iznose {0}",Klinika17496_1.dajRacun(Klinika17496_1.dajPacijenta(m)));
                            int r= Klinika17496_1.dajRacun(Klinika17496_1.dajPacijenta(m));
                            Klinika17496_1.dajPacijenta(m).dodajNaRacun(-r);
                            Console.WriteLine("Dugovi pacijena iznose {0}", Klinika17496_1.dajRacun(Klinika17496_1.dajPacijenta(m)));
                           
                        }
                    }
                    Console.WriteLine("Za ponovni ulazak u meni kliknite 1");
                    string pon = Console.ReadLine();
                    if (pon == "1") goto ponovo;
                    Console.ReadLine();

                }
                else if (s == "8") break;
                Console.ReadLine();
}

        }
    }
}
