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
    public partial class Form2 : Form
    {
        private klinika Klinika { get; set; }
        //konstuktor
        public Form2(klinika k)
        {
            Klinika = new klinika(k);
            InitializeComponent();
        }
        public Form2()
        {
            InitializeComponent();
        }
        public klinika Klinika1
        {
            get
            {
                return Klinika;
            }
        }
        //validnost pacijenta
        private bool validnostImenaPacijenta(string ime)
        {
            if (pacijentValidator.validnostImena(ime) == false)
            {
                toolStripStatusLabel1.Text = "Ime nije validno";
                return false;
            }
            return true;
        }
        private bool validnostPrezimenaPacijenta(string prezime)
        {
            if (pacijentValidator.validnostPrezimena(prezime) == false)
            {
                toolStripStatusLabel1.Text = "Prezime nije validno";
                return false;
            }
            return true;
        }
        private bool validnostJMBGPacijenta(string jmbg)
        {
            if (pacijentValidator.validnostJMBG(jmbg) == false) return false;

            return true;
        }
        private void ukloniUnosPacijenta()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            comboBox1.Refresh();
            comboBox2.Refresh();
        }

        //unos pacijenta
        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Items.Count == 0 || comboBox2.Items.Count == 0 || dateTimePicker2.Text == "")
            {
                toolStripStatusLabel1.Text = "Popunite sva polja!";
                return;
            }
            if (validnostImenaPacijenta(textBox1.Text) == false || validnostPrezimenaPacijenta(textBox2.Text) == false) { return; }
            if (validnostJMBGPacijenta(textBox3.Text) == false) { toolStripStatusLabel1.Text = "JMBG nije validan"; return; }
            if (pacijentValidator.validnostAdrese(textBox4.Text) == false)
            {
                toolStripStatusLabel1.Text = "Pogresna adresa. Format: adresabroj";
                return;
            }


            Klinika.dodajPacijenta(new pacijent(textBox1.Text, textBox2.Text, dateTimePicker1.Text, textBox3.Text, comboBox1.Text, textBox4.Text, comboBox2.Text, dateTimePicker2.Text));
            toolStripStatusLabel1.Text = "Pacijent unesen.";
            ukloniUnosPacijenta();

        }
        //slika
        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Image image = Image.FromFile(op.FileName);
                pictureBox1.Image = image;
            }

        }
        //brisanje pacijenta
        private void ukloniBrisanjePacijenta()
        {
            textBox5.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            if (validnostJMBGPacijenta(textBox5.Text) == false) { toolStripStatusLabel2.Text = "JMBG nije validan"; return; }
            for (int i = 0; i < Klinika.listaPacijenata.Count; i++)
            {
                if (textBox5.Text == Klinika.listaPacijenata[i].MaticniBroj)
                {
                    Klinika.obrisiPacijenta(Klinika.listaPacijenata[i]);
                    toolStripStatusLabel2.Text = "Pacijent obrisan.";
                    ukloniBrisanjePacijenta();
                    return;
                }
            }
            toolStripStatusLabel2.Text = "Pacijent nije pronadjen.";
        }
        //unos kartona
        private void ukloniUnosKartona()
        {
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "";
            if (textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "")
            {
                toolStripStatusLabel3.Text = "Popunite sva polja.";
                return;
            }
            if (validnostJMBGPacijenta(textBox6.Text) == false) { toolStripStatusLabel3.Text = "JMBG nije validan"; return; }
            for (int i = 0; i < Klinika.listaPacijenata.Count; i++)
            {
                if (textBox6.Text == Klinika.listaPacijenata[i].MaticniBroj)
                {
                    karton k = new karton();
                    k.dodajRanu(textBox8.Text);
                    k.dodajRanuAl(textBox9.Text);
                    k.dodajSadasnju(textBox10.Text);
                    k.dodajSadasnjuAl(textBox11.Text);
                    k.dodajzdravlje(textBox7.Text);
                    Klinika.listaPacijenata[i].DodajKartonPacijentu(k);
                    toolStripStatusLabel3.Text = "Karton registrovan.";
                    ukloniUnosKartona();
                    return;
                }
            }
            toolStripStatusLabel3.Text = "Pacijent nije pronadjen.";
        }
        //registracija pregleda
        private void ukloniUnosPregleda()
        {
            textBox12.Clear();
            checkedListBox1.ClearSelected();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel4.Text = "";
            if (textBox12.Text == "" || checkedListBox1.Items.Count == 0)
            {
                toolStripStatusLabel4.Text = "Popunite sva polja.";
                return;
            }
            if (validnostJMBGPacijenta(textBox12.Text) == false) { toolStripStatusLabel4.Text = "JMBG nije validan"; return; }
            pregled p = new pregled();
            List<string> c = new List<string>();
            foreach (string s in checkedListBox1.CheckedItems) c.Add(s);
            for(int i=0; i < c.Count; i++)
            {
                for(int j=0; j<Klinika1.listaOrdinacija.Count; j++)
                {
                    if (c[i] == Klinika1.listaOrdinacija[j].NazivOrdinacije)
                    {
                        p.dodajOrdinacijuUPregled(Klinika1.listaOrdinacija[j]);
                    }
                }
            }
            for (int i = 0; i < Klinika.listaPacijenata.Count; i++)
            {
                if (textBox12.Text == Klinika.listaPacijenata[i].MaticniBroj)
                {
                    Klinika.listaPacijenata[i].DajKartonPacijenta.dodajPregledUKarton(p);
                    toolStripStatusLabel4.Text = "Pregled pacijenta registrovan.";
                    ukloniUnosPregleda();
                    return;
                }
            }
            toolStripStatusLabel4.Text = "Pacijent nije pronadjen.";

        }

        private void Form2_Load(object sender, EventArgs e)
        { }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                errorProvider1.SetError(textBox1, "Unesite ime");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (textBox2.Text == "")
            {
                errorProvider1.SetError(textBox2, "Unesite prezime");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (textBox3.Text == "")
            {
                errorProvider1.SetError(textBox3, "Unesite JMBG");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (textBox4.Text == "")
            {
                errorProvider1.SetError(textBox4, "Unesite adresu stanovanja");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (comboBox1.Text == "")
            {
                errorProvider1.SetError(comboBox1, "Unesite spol");
            }
            else
            {
                errorProvider1.Clear();
            }
            if (comboBox2.Text == "")
            {
                errorProvider1.SetError(comboBox2, "Unesite bracni status");
            }
            else
            {
                errorProvider1.Clear();
            }


        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                errorProvider2.SetError(textBox5, "Unesite JMBG");
            }
            else
            {
                errorProvider2.Clear();

            }
        }

    }
}
