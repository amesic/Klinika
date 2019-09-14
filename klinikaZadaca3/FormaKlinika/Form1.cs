using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaKlinika
{
    public partial class Form1 : Form
    {
        private klinika Klinika1;
        private Form3 forma3;
        private Form2 forma2;
        private Form4 forma4;
        public Form1()
        {
            InitializeComponent();
        }
        private bool validnostJMBG(string jmbg)
        {
            if (pacijentValidator.validnostJMBG(jmbg) == false) return false;

            return true;
        }
        //unos sifre i korisnickog
        private void ukloniUnosSifreKorisnickog()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            if(textBox1.Text =="" || textBox2.Text == "")
            {
                toolStripStatusLabel1.Text = "Unesite sve podatke!";
                return;
            }
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            konekcija.Open();
            komanda.CommandText = "SELECT korisnicko FROM pacijent WHERE korisnicko=" + textBox1.Text + ";";
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "SELECT sifra FROM pacijent WHERE sifra=" + textBox2.Text + ";";
                if (komanda.CommandText != null)
                {
                    forma4 = new Form4();
                    forma4.Show();
                    ukloniUnosSifreKorisnickog();
                    konekcija.Close();
                    return;
                }

            }
            komanda.CommandText = "SELECT korisnicko FROM doktor WHERE korisnicko=" + textBox1.Text + ";";
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "SELECT sifra FROM doktor WHERE sifra=" + textBox2.Text + ";";
                if (komanda.CommandText != null)
                {
                    forma3 = new Form3();
                    forma3.Show();
                    ukloniUnosSifreKorisnickog();
                    konekcija.Close();
                    return;
                }

            }
            komanda.CommandText = "SELECT korisnicko FROM osoblje WHERE korisnicko=" + textBox1.Text + ";";
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "SELECT sifra FROM osoblje WHERE sifra=" + textBox2.Text + ";";
                if (komanda.CommandText != null)
                {
                    forma2 = new Form2();
                    forma2.Show();
                    ukloniUnosSifreKorisnickog();
                    konekcija.Close();
                    return;
                }

            }
            toolStripStatusLabel1.Text = "Korisnik ne postoji.";
            konekcija.Close();

        }
        //registracija
        private void ukloniRegistraciju()
        {
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            if (textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                toolStripStatusLabel2.Text = "Sva polja treba popuniti";
                return;

            }
            if (validnostJMBG(textBox6.Text) == false)
            {
                toolStripStatusLabel2.Text = "JMBG nije validan";
                return;
            }
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            konekcija.Open();
            if (textBox5.Text == "pacijent" || textBox5.Text == "Pacijent")
            {
                komanda.CommandText = "SELECT korisnicko FROM pacijent WHERE korisnicko=" + textBox3.Text + ";";
                if (komanda.CommandText != null)
                {
                    toolStripStatusLabel2.Text = "Korisnicko vec postoji";
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel2.Text = "Pacijent nije u klinici";
                    konekcija.Close();
                    return;

                }
            }
            else if (textBox5.Text == "doktor" || textBox5.Text == "Doktor")
            {
                komanda.CommandText = "SELECT korisnicko FROM doktor WHERE korisnicko=" + textBox3.Text + ";";
                if (komanda.CommandText != null)
                {
                    toolStripStatusLabel2.Text = "Korisnicko vec postoji";
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel2.Text = "Doktor nije u klinici";
                    konekcija.Close();
                    return;

                }
            }
            else if (textBox5.Text == "osoblje" || textBox5.Text == "Osoblje")
            {

                komanda.CommandText = "SELECT korisnicko FROM osoblje WHERE korisnicko=" + textBox3.Text + ";";
                if (komanda.CommandText != null)
                {
                    toolStripStatusLabel2.Text = "Korisnicko vec postoji";
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel2.Text = "Navedeno osoblje nije u klinici";
                    konekcija.Close();
                    return;

                }
            }
            if (textBox5.Text == "pacijent" || textBox5.Text == "Pacijent")
            {
                komanda.CommandText = "SELECT jmbg FROM pacijent WHERE jmbg=" + textBox6.Text + ";";
                if (komanda.CommandText != null)
                {
                    komanda.CommandText = "UPDATE mojabazaklinika.pacijent SET korisnicko=" + textBox3.Text + " WHERE" + textBox6 + "=(SELECT jmbg FROM pacijent);";
                    komanda.CommandText = "UPDATE mojabazaklinika.pacijent SET sifra=" + textBox4.Text + " WHERE" + textBox6 + "=(SELECT jmbg FROM pacijent);";
                    toolStripStatusLabel2.Text = "Uspjesno registrovan kao pacijent";
                    ukloniRegistraciju();
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel2.Text = "Pacijent nije u klinici";
                    konekcija.Close();
                    return;

                }
            }
            else if (textBox5.Text == "doktor" || textBox5.Text == "Doktor")
            {
                komanda.CommandText = "SELECT jmbg FROM doktor WHERE jmbg=" + textBox6.Text + ";";
                if (komanda.CommandText != null)
                {
                    komanda.CommandText = "UPDATE mojabazaklinika.doktor SET korisnicko=" + textBox3.Text + " WHERE" + textBox6 + "=(SELECT jmbg FROM doktor);";
                    komanda.CommandText = "UPDATE mojabazaklinika.doktor SET sifra=" + textBox4.Text + " WHERE" + textBox6 + "=(SELECT jmbg FROM doktor);";
                    toolStripStatusLabel2.Text = "Uspjesno registrovan kao doktor";
                    ukloniRegistraciju();
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel2.Text = "Doktor nije u klinici";
                    konekcija.Close();
                    return;

                }
            }
            else if (textBox5.Text == "doktor" || textBox5.Text == "Doktor")
            {
                komanda.CommandText = "SELECT jmbg FROM osoblje WHERE jmbg=" + textBox6.Text + ";";
                if (komanda.CommandText != null)
                {
                    komanda.CommandText = "UPDATE mojabazaklinika.osoblje SET korisnicko=" + textBox3.Text + " WHERE" + textBox6 + "=(SELECT jmbg FROM osoblje);";
                    komanda.CommandText = "UPDATE mojabazaklinika.osoblje SET sifra=" + textBox4.Text + " WHERE" + textBox6 + "=(SELECT jmbg FROM osoblje);";
                    toolStripStatusLabel2.Text = "Uspjesno registrovan kao osoblje";
                    ukloniRegistraciju();
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel2.Text = "Navedeno osoblje nije u klinici";
                    konekcija.Close();
                    return;

                }
            }
            else
            {
                toolStripStatusLabel2.Text = "Uloga u klinici ne postoji!";
                konekcija.Close();
                return;
            }
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //promjena sifre
        private void ukloniUnosPromjeneSifre()
        {
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
              private void button3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
            if(textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "")
            {
                toolStripStatusLabel3.Text = "Popunite sva polja";
                return;
            }
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            konekcija.Open();
            komanda.CommandText = "SELECT korisnicko FROM pacijent WHERE korisnicko=" + textBox7 + ";";
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "SELECT sifra FROM pacijent WHERE sifra=" + textBox8 + ";";
                if (komanda.CommandText != null)
                {
                    komanda.CommandText = "UPDATE mojabazaklinika.pacijent SET sifra=" + textBox9 + "WHERE" + textBox7 + "=(SELECT korisnicko FROM pacijent);";
                    toolStripStatusLabel3.Text = "Sifra promijenjena!";
                    ukloniUnosPromjeneSifre();
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel3.Text = "Stara sifra pogresna!";
                    konekcija.Close();
                    return;
                }

            }
            komanda.CommandText = "SELECT korisnicko FROM doktor WHERE korisnicko=" + textBox7 + ";";
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "SELECT sifra FROM doktor WHERE sifra=" + textBox8 + ";";
                if (komanda.CommandText != null)
                {
                    komanda.CommandText = "UPDATE mojabazaklinika.doktor SET sifra=" + textBox9 + "WHERE" + textBox7 + "=(SELECT korisnicko FROM doktor);";
                    toolStripStatusLabel3.Text = "Sifra promijenjena!";
                    ukloniUnosPromjeneSifre();
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel3.Text = "Stara sifra pogresna!";
                    konekcija.Close();
                    return;
                }

            }
            komanda.CommandText = "SELECT korisnicko FROM osoblje WHERE korisnicko=" + textBox7 + ";";
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "SELECT sifra FROM osoblje WHERE sifra=" + textBox8 + ";";
                if (komanda.CommandText != null)
                {
                    komanda.CommandText = "UPDATE mojabazaklinika.osoblje SET sifra=" + textBox9 + "WHERE" + textBox7 + "=(SELECT korisnicko FROM osoblje);";
                    toolStripStatusLabel3.Text = "Sifra promijenjena!";
                    ukloniUnosPromjeneSifre();
                    konekcija.Close();
                    return;
                }
                else
                {
                    toolStripStatusLabel3.Text = "Stara sifra pogresna!";
                    konekcija.Close();
                    return;
                }

            }
            else
            {
                toolStripStatusLabel3.Text = "Korisnicko ime pogresno!";
                konekcija.Close();
                return;
             }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Unesite korisnicko");
            }
            else
            {
                errorProvider1.Clear();
            }
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                errorProvider2.SetError(textBox2, "Unesite sifru");
            }
            else
            {
                errorProvider2.Clear();
            }


        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                errorProvider2.SetError(textBox3, "Unesite korisnicko");
            }
            else
            {
                errorProvider3.Clear();
            }

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                errorProvider4.SetError(textBox4, "Unesite sifru");
            }
            else
            {
                errorProvider4.Clear();
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                errorProvider5.SetError(textBox5, "Unesite poziciju");
            }
            else
            {
                errorProvider5.Clear();
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text == "")
            {
                errorProvider6.SetError(textBox6, "Unesite JMBG");
            }
            else
            {
                errorProvider6.Clear();
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text == "")
            {
                errorProvider7.SetError(textBox7, "Unesite korisnicko");
            }
            else
            {
                errorProvider7.Clear();
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text == "")
            {
                errorProvider8.SetError(textBox8, "Unesite staru sifru");
            }
            else
            {
                errorProvider8.Clear();
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (textBox9.Text == "")
            {
                errorProvider9.SetError(textBox9, "Unesite novu sifru");
            }
            else
            {
                errorProvider9.Clear();
            }

        }
    }
}
