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
    public partial class Form4 : Form
    {
        private klinika Klinika1;
        public Form4()
        {
            InitializeComponent();
        }
        public Form4(klinika k)
        {
            Klinika1 = new klinika(k);
            InitializeComponent();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            if (validnostJMBGPacijenta(textBox1.Text) == false) { toolStripStatusLabel1.Text = "JMBG nije validan"; return; }
            for (int i = 0; i < Klinika1.listaPacijenata.Count; i++)
            {
                if (textBox1.Text == Klinika1.listaPacijenata[i].MaticniBroj)
                {
                    ListViewItem l = new ListViewItem(Klinika1.listaPacijenata[i].DajKartonPacijenta.Zdravstvenostanjeporodice);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.Ranijebolesti.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.Ranijebolesti[j]);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.Ranijealergije.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.Ranijealergije[j]);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti[j]);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.Trenutnebolesti[j]);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Dijagnoza.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Dijagnoza[j]);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Terapija.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Terapija[j]);
                    l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.DatumTerapije);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Dijagnoza.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Dijagnoza[j]);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Terapija.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Terapija[j]);
                    for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Misljenjedoktora.Count; j++)
                        l.SubItems.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.Misljenjedoktora[j]);


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
        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        //prikaz pregleda
        private void ukloniUnosUPrikazPregleda()
        {
            textBox2.Clear();
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = "";
            if (validnostJMBGPacijenta(textBox2.Text) == false) { toolStripStatusLabel2.Text = "JMBG nije validan"; return; }
            ListViewItem l = new ListViewItem();
            for (int i = 0; i < Klinika1.listaPacijenata.Count; i++)
            {
                if (textBox2.Text == Klinika1.listaPacijenata[i].MaticniBroj)
                {

                 for (int j = 0; j < Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.DajOrdinacije.Count; j++)
                    {
                        listBox1.Items.Add(Klinika1.listaPacijenata[i].DajKartonPacijenta.PregledPacijenta.DajOrdinacije[j].NazivOrdinacije);
                    }
                    return;
                }
            }
            toolStripStatusLabel2.Text = "Pacijent nije pronadjen.";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ukloniUnosUPrikazPregleda();
        }
    }
}
