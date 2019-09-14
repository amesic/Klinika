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
            for (int i = 0; i <Klinika.listaPacijenata.Count; i++)
            {
                if (textBox1.Text == Klinika.listaPacijenata[i].MaticniBroj)
                {
                    ListViewItem l = new ListViewItem(Klinika.listaPacijenata[i].DajKartonPacijenta.Zdravstvenostanjeporodice);
                    for (int j = 0; j < Klinika.listaPacijenata[i].DajKartonPacijenta.Ranijebolesti.Count; j++)
                        l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.Ranijebolesti[j]);
                    for (int j = 0; j <Klinika.listaPacijenata[i].DajKartonPacijenta.Ranijealergije.Count; j++)
                        l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.Ranijealergije[j]);
                    for (int j = 0; j <Klinika.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti.Count; j++)
                        l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti[j]);
                    for (int j = 0; j < Klinika.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti.Count; j++)
                        l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti[j]);
                    for (int j = 0; j < Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Dijagnoza.Count; j++)
                        l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Dijagnoza[j]);
                    for (int j = 0; j < Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Terapija.Count; j++)
                        l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Terapija[j]);
                    l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.DatumTerapije);
                    for (int j = 0; j <Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Misljenjedoktora.Count; j++)
                        l.SubItems.Add(Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Misljenjedoktora[j]);

                    listView1.Items.Add(l);
                    return;

                }
            }
            toolStripStatusLabel1.Text = "Pacijent nije pronadjen.";

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
            for (int i = 0; i < Klinika.listaPacijenata.Count; i++)
            {
                if (textBox2.Text == Klinika.listaPacijenata[i].MaticniBroj)
                {
                    Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.dodajDijagnozu(textBox3.Text);
                    Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.dodajTerapiju(textBox4.Text);
                    Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.dodajDatumTerapije(dateTimePicker1.Text);
                    Klinika.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.dodajMisljenje(textBox5.Text);
                    toolStripStatusLabel2.Text = "Uneseno u karton.";
                    return;
                }
            }
            toolStripStatusLabel2.Text = "Pacijent nije pronadjen.";

        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
