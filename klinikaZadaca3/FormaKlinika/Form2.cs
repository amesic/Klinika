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
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.CommandText = "INSERT INTO mojabazaklinika.pacijent(ime,prezime,datum_rodjenja,jmbg,adresa_stanovanja,spol,bracno_stanje,datum_prijave) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + Convert.ToString(dateTimePicker1.Value.Year) + "-" + Convert.ToString(dateTimePicker1.Value.Month) + "-" + Convert.ToString(dateTimePicker1.Value.Day) + "','" + textBox3.Text + "','" + comboBox1.Text+ "','"+ textBox4.Text + "','" + comboBox2.Text+ "','"+ Convert.ToString(dateTimePicker2.Value.Year) + "-" + Convert.ToString(dateTimePicker2.Value.Month) + "-" + Convert.ToString(dateTimePicker2.Value.Day)+"');";
            komanda.Connection = konekcija;
            konekcija.Open();
            try {
                int aff = komanda.ExecuteNonQuery();
                MessageBox.Show(aff + " rows were affected.");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                konekcija.Close();
                toolStripStatusLabel1.Text = "Pacijent unesen.";
                ukloniUnosPacijenta();
              }
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
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.CommandText = "SELECT jmbg FROM mojabazaklinika.pacijent WHERE jmbg="+ textBox5.Text + ";";
            komanda.Connection = konekcija;
            konekcija.Open();
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "DELETE FROM mojabazaklinika.pacijent WHERE jmbg = " + textBox5.Text + "; ";
                toolStripStatusLabel2.Text = "Pacijent obrisan.";
                ukloniBrisanjePacijenta();
                konekcija.Close();
                return;
            }

            else
            {
                toolStripStatusLabel2.Text = "Pacijent nije pronadjen.";
                konekcija.Close();
            }
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
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.CommandText = "SELECT jmbg FROM mojabazaklinika.pacijent WHERE jmbg=" + textBox6.Text + ";";
            komanda.Connection = konekcija;
            konekcija.Open();
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "INSERT INTO mojabazaklinika.karton(zdravstveno_stanje_porodice,ranije_bolesti,ranije_alergije,sadasnje_bolesti,sadasnje_alergije)  VALUES('" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "');";
                komanda.CommandText = "UPDATE mojabazaklinika.pacijent SET karton_id= (SELECT k.karton_id FROM karton k, pacijent p WHERE p.pacijent_id=k.karton_id) WHERE jmbg=" + textBox6.Text + ";";
                toolStripStatusLabel3.Text = "Karton registrovan.";
                ukloniUnosKartona();
                konekcija.Close();
                return;
            }

            else
            {
                toolStripStatusLabel3.Text = "Pacijent nije pronadjen.";
                konekcija.Close();
            }
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
            List<string> c = new List<string>();
            foreach (string s in checkedListBox1.CheckedItems) c.Add(s);
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            konekcija.Open();
            komanda.CommandText = "INSERT INTO mojabazaklinika.pregled VALUES('" + null + "','" + null + "','" + null + "','" + null + "','" + null + "');";
            for (int i=0; i < c.Count; i++)
            komanda.CommandText = "UPDATE mojabazaklinika.pregled SET ordinacija_id=(SELECT ordinacija_id FROM ordinacija WHERE naziv=" + c[i] + " ) WHERE pregled_id=pregled.CURRVAL; ";
            komanda.CommandText = "SELECT jmbg FROM mojabazaklinika.pacijent WHERE jmbg=" + textBox12.Text + ";";
            if (komanda.CommandText != null)
            {
                komanda.CommandText = "UPDATE mojabazaklinika.karton SET pregled_id=(SELECT p.pregled_id FROM pregled p, karton k WHERE p.pregled_id=k.karton_id) WHERE karton_id=(SELECT pregled_id FROM pregled WHERE pregled_id=pregled.CURRVAL);";
                komanda.CommandText= "UPDATE mojabazaklinika.ordinacija SET pacijent_id=(SELECT pacijent_id FROM pacijent WHERE jmbg=" + textBox12.Text + ";";
                toolStripStatusLabel4.Text = "Pregled pacijenta registrovan.";
                ukloniUnosPregleda();
                konekcija.Close();
                return;
            }
            else
            {
                toolStripStatusLabel4.Text = "Pacijent nije pronadjen.";
                konekcija.Close();
            }

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
