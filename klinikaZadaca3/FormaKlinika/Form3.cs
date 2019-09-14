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
    public partial class Form3 : Form
    {
        private klinika Klinika { get; set;}

        public Form3()
        {
            InitializeComponent();
        }
        public Form3(klinika k)
        {
            Klinika = new klinika(k);
            InitializeComponent();
        }
        public klinika Klinika1
        {
            get
            {
                return Klinika;
            }
        }
        private bool validnostJMBGPacijenta(string jmbg)
        {
            if (pacijentValidator.validnostJMBG(jmbg) == false) return false;

            return true;
        }

        //prikaz kartona
        private void ukloniUnosUPrikazKartona()
        {
            textBox1.Clear();
            listView1.Items.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            if (validnostJMBGPacijenta(textBox1.Text) == false) { toolStripStatusLabel1.Text = "JMBG nije validan"; return; }
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            konekcija.Open();
            komanda.CommandText= "SELECT pacijent_id FROM pacijent WHERE jmbg=" + textBox1.Text + ";";
            if (komanda.CommandText != null)
            {
                ListViewItem l = new ListViewItem(komanda.CommandText = "SELECT k.zdravstveno_stanje FROM karton k, pacijent p WHERE p.karton_id=k.karton_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT k.ranije_bolesti FROM karton k, pacijent p WHERE p.karton_id=k.karton_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT k.ranije_alergije FROM karton k, pacijent p WHERE p.karton_id=k.karton_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT k.sadasnje_bolesti FROM karton k, pacijent p WHERE p.karton_id=k.karton_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT k.sadasnje_alergije FROM karton k, pacijent p WHERE p.karton_id=k.karton_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT p1.dijagnoza FROM karton k, pacijent p ,pregled p1 WHERE p.karton_id=k.karton_id AND k.pregled_id=p1.pregled_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT p1.terapija FROM karton k, pacijent p ,pregled p1 WHERE p.karton_id=k.karton_id AND k.pregled_id=p1.pregled_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT p1.datum_terapije FROM karton k, pacijent p ,pregled p1 WHERE p.karton_id=k.karton_id AND k.pregled_id=p1.pregled_id AND p.jmbg=" + textBox1.Text + ";");
                l.SubItems.Add(komanda.CommandText = "SELECT p1.misljenje_doktora FROM karton k, pacijent p ,pregled p1 WHERE p.karton_id=k.karton_id AND k.pregled_id=p1.pregled_id AND p.jmbg=" + textBox1.Text + ";");
                listView1.Items.Add(l);
                konekcija.Close();
                return;
            }
            else
            {
                toolStripStatusLabel1.Text = "Pacijent nije pronadjen.";
                konekcija.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ukloniUnosUPrikazKartona();
        }
        //unos dodatnih info u karton
        private void ukloniUnosUKarton()
        {
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            if (textBox2.Text =="" ||textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                toolStripStatusLabel2.Text = "Popunite sva polja";
                return;
            }
            if (validnostJMBGPacijenta(textBox2.Text) == false) { toolStripStatusLabel2.Text = "JMBG nije validan"; return; }
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            konekcija.Open();
            komanda.CommandText = "SELECT pacijent_id FROM pacijent WHERE jmbg=" + textBox2.Text + ";";
            if (komanda.CommandText != null)
            {
             komanda.CommandText="UPDATE mojabazaklinika.pregled SET dijagnoza="+ textBox3.Text +" WHERE pregled_id=(SELECT p.pregled_id FROM karton k, pregled p, pacijent p1 WHERE p1.karton_id=k.karton_id AND k.pregled_id=p.pregled_id AND p1.jmbg=" + textBox2.Text + ");";
             komanda.CommandText = "UPDATE mojabazaklinika.pregled SET terapija=" + textBox4.Text + " WHERE pregled_id=(SELECT p.pregled_id FROM karton k, pregled p, pacijent p1 WHERE p1.karton_id=k.karton_id AND k.pregled_id=p.pregled_id AND p1.jmbg=" + textBox2.Text + ");";
             komanda.CommandText = "UPDATE mojabazaklinika.pregled SET datum_terapije=" + Convert.ToString(dateTimePicker1.Value.Year) + "-" + Convert.ToString(dateTimePicker1.Value.Month) + "-" + Convert.ToString(dateTimePicker1.Value.Day) + " WHERE pregled_id=(SELECT p.pregled_id FROM karton k, pregled p, pacijent p1 WHERE p1.karton_id=k.karton_id AND k.pregled_id=p.pregled_id AND p1.jmbg=" + textBox2.Text + ");";
             komanda.CommandText = "UPDATE mojabazaklinika.pregled SET misljenje_doktora=" + textBox5.Text + " WHERE pregled_id=(SELECT p.pregled_id FROM karton k, pregled p, pacijent p1 WHERE p1.karton_id=k.karton_id AND k.pregled_id=p.pregled_id AND p1.jmbg=" + textBox2.Text + ");";
             toolStripStatusLabel2.Text = "Uneseno u karton.";
             konekcija.Close();
             return;
            }
            else
            {
                toolStripStatusLabel2.Text = "Pacijent nije pronadjen.";
                konekcija.Close();

            }

        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
