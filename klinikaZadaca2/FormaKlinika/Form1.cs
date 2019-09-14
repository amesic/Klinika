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
        public Form1(klinika k)
        {
            Klinika1 = new klinika(k);
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
            for(int i=0; i<Klinika1.listaPacijenata.Count; i++)
            {
                if(textBox1.Text== Klinika1.listaPacijenata[i].Korisnicko)
                {
                    if(textBox2.Text== Klinika1.listaPacijenata[i].Sifra)
                    {
                        forma4 = new Form4(Klinika1);
                        forma4.Show();
                        ukloniUnosSifreKorisnickog();
                            return;
                    }
                }
            }
                for (int i = 0; i < Klinika1.listaDoktora.Count; i++)
            {
                if (textBox1.Text == Klinika1.listaDoktora[i].Korisnicko)
                {
                    if (textBox2.Text == Klinika1.listaDoktora[i].Sifra)
                    {
                        forma3 = new Form3(Klinika1);
                        forma3.Show();
                        for (int j = 0; j < forma3.Klinika1.listaPacijenata.Count; j++)
                        {
                            Klinika1.listaPacijenata[j] = forma3.Klinika1.listaPacijenata[j];

                        }

                        ukloniUnosSifreKorisnickog();
                            return;
                    }
                }
            }
                for (int i = 0; i < Klinika1.listaUposlenika.Count; i++)
            {
                if (textBox1.Text == Klinika1.listaUposlenika[i].Korisnicko)
                {
                    if (textBox2.Text == Klinika1.listaUposlenika[i].Sifra)
                    {
                        forma2 = new Form2(Klinika1);
                        forma2.Show();
                        for (int j = 0; j < forma2.Klinika1.listaPacijenata.Count; j++)
                        {
                            Klinika1.listaPacijenata[j] = forma2.Klinika1.listaPacijenata[j];

                        }
                            ukloniUnosSifreKorisnickog();
                            return;
                    }
                }
            }
            toolStripStatusLabel1.Text = "Korisnik ne postoji.";

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
                for (int i = 0; i < Klinika1.listaPacijenata.Count; i++)
                {
                    if (Klinika1.listaPacijenata[i].Korisnicko == textBox3.Text)
                    {
                        toolStripStatusLabel2.Text = "Korisnicko vec postoji";
                        return;
                    }
                }


                for (int i = 0; i < Klinika1.listaDoktora.Count; i++)
                {
                    if (Klinika1.listaDoktora[i].Korisnicko == textBox3.Text)
                    {
                        toolStripStatusLabel2.Text = "Korisnicko vec postoji";
                        return;
                    }
                }
                for (int i = 0; i < Klinika1.listaUposlenika.Count; i++)
                {

                    if (Klinika1.listaUposlenika[i].Korisnicko == textBox3.Text)
                    {
                        toolStripStatusLabel2.Text = "Korisnicko vec postoji";
                        return;
                    }
                }
                int pomocna;
            if (textBox5.Text == "pacijent")
            {
                pomocna = 0;
                for (int i = 0; i < Klinika1.listaPacijenata.Count; i++)
                {
                    if (Klinika1.listaPacijenata[i].MaticniBroj == textBox6.Text)
                    {
                        Klinika1.listaPacijenata[i].dodajSifru(textBox4.Text);
                        Klinika1.listaPacijenata[i].dodajKorisnicko(textBox3.Text);
                        toolStripStatusLabel2.Text = "Uspjesno registrovano";
                        ukloniRegistraciju();
                        pomocna = 1;
                        return;
                    }

                }
                if (pomocna == 0)
                {
                    toolStripStatusLabel2.Text = "Niste registrovani u kliniku (provjeriti JMBG usput)";
                    return;
                }
            }

            if (textBox5.Text == "doktor")
            {
                pomocna = 0;
                for (int i = 0; i < Klinika1.listaDoktora.Count; i++)
                {
                    if (Klinika1.listaDoktora[i].MaticniBroj == textBox6.Text)
                    {
                        Klinika1.listaDoktora[i].dodajSifru(textBox4.Text);
                        Klinika1.listaDoktora[i].dodajKorisnicko(textBox3.Text);
                        toolStripStatusLabel2.Text = "Uspjesno registrovano";
                        ukloniRegistraciju();
                        pomocna = 1;
                        return;
                    }
                }
                if (pomocna == 0) {
                    toolStripStatusLabel2.Text = "Niste registrovani u kliniku (provjeriti JMBG usput)";
                    return;
                }

            }
            if (textBox5.Text == "osoblje")
            {
                pomocna = 0;
                for (int i = 0; i < Klinika1.listaUposlenika.Count; i++)
                {
                    if (Klinika1.listaUposlenika[i].MaticniBroj == textBox6.Text)
                    {
                        Klinika1.listaUposlenika[i].dodajSifru(textBox4.Text);
                        Klinika1.listaUposlenika[i].dodajKorisnicko(textBox3.Text);
                        toolStripStatusLabel2.Text = "Uspjesno registrovano";
                        ukloniRegistraciju();
                        pomocna = 1;
                        return;
                    }
                }
                if (pomocna == 0)
                {
                    toolStripStatusLabel2.Text = "Niste registrovani u kliniku (provjeriti JMBG usput)";
                    return;
                }

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
            int pomocna=0,jeste;
            for(int i=0; i<Klinika1.listaPacijenata.Count; i++)
            {
                if (textBox7.Text == Klinika1.listaPacijenata[i].Korisnicko)
                {
                    pomocna = 1;
                    if (textBox8.Text == Klinika1.listaPacijenata[i].Sifra)
                    {
                        Klinika1.listaPacijenata[i].dodajSifru(textBox9.Text);
                        toolStripStatusLabel3.Text = "Sifra promijenjena!";
                        ukloniUnosPromjeneSifre();
                        return;
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = "Stara sifra pogresna!";
                        return;
                    }
                   
                }
            }
            for (int i = 0; i < Klinika1.listaDoktora.Count; i++)
            {
                if (textBox7.Text == Klinika1.listaDoktora[i].Korisnicko)
                {
                    pomocna = 1;
                    if (textBox8.Text == Klinika1.listaDoktora[i].Sifra)
                    {
                        Klinika1.listaDoktora[i].dodajSifru(textBox9.Text);
                        toolStripStatusLabel3.Text = "Sifra promijenjena!";
                        ukloniUnosPromjeneSifre();
                        return;
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = "Stara sifra pogresna!";
                        return;
                    }

                }
            }
            for (int i = 0; i < Klinika1.listaUposlenika.Count; i++)
            {
                if (textBox7.Text == Klinika1.listaUposlenika[i].Korisnicko)
                {
                    pomocna = 1;
                    if (textBox8.Text == Klinika1.listaUposlenika[i].Sifra)
                    {
                        Klinika1.listaUposlenika[i].dodajSifru(textBox9.Text);
                        toolStripStatusLabel3.Text = "Sifra promijenjena!";
                        ukloniUnosPromjeneSifre();
                        return;
                    }
                    else
                    {
                        toolStripStatusLabel3.Text = "Stara sifra pogresna!";
                        return;
                    }

                }
            }
            if (pomocna == 0)
            {
                toolStripStatusLabel3.Text = "Korisnicko ne postoji!";
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
