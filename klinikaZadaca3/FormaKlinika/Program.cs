using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;

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
            OracleConnection con = new OracleConnection();
            con.ConnectionString = @"Data Source=
 (DESCRIPTION =
 (ADDRESS = (PROTOCOL = TCP)(HOST = 80.65.65.66)(PORT = 1521))
 (CONNECT_DATA =
 (SERVER = DEDICATED)
 (SERVICE_NAME = etflab.db.lab.etf.unsa.ba)
 )
 );User Id= AM17496;Password= N1tfveS8;Persist Security Info=True;";
            con.Open();
            MySqlConnection konekcija = new MySqlConnection("server=localhost;User Id=root;database=mojabazaklinika");
            MySqlCommand komanda = new MySqlCommand();
            komanda.Connection = konekcija;
            konekcija.Open();
            komanda.CommandText = "INSERT INTO klinika VALUES('nmk',null,null,null);";
            komanda.CommandText = "INSERT INTO doktor VALUES('Mujo','Mujic',12345,null,null,null,0706003171116);";
            komanda.CommandText = "UPDATE mojabazaklinika.klinika SET doktor_id=(SELECT doktor id FROM doktor WHERE doktor_id=doktor.CURRVAL);";
            komanda.CommandText = "INSERT INTO doktor VALUES('Fata','Mujic',12345,null,null,null,0101971177217);";
            komanda.CommandText = "UPDATE mojabazaklinika.klinika SET doktor_id=(SELECT doktor id FROM doktor WHERE doktor_id=doktor.CURRVAL);";
            komanda.CommandText = "INSERT INTO doktor VALUES('Suljo','Mujic',12345,null,null,null,0101971177216);";
            komanda.CommandText = "UPDATE mojabazaklinika.klinika SET doktor_id=(SELECT doktor id FROM doktor WHERE doktor_id=doktor.CURRVAL);";
            komanda.CommandText = "INSERT INTO doktor VALUES('Maja','Mujic',12345,null,null,null,0101971177215);";
            komanda.CommandText = "UPDATE mojabazaklinika.klinika SET doktor_id=(SELECT doktor id FROM doktor WHERE doktor_id=doktor.CURRVAL);";
            komanda.CommandText = "INSERT INTO aparat VALUES('ekg',true); ";
            komanda.CommandText = "INSERT INTO aparat VALUES('dermatoloski',true); ";
            komanda.CommandText = "INSERT INTO aparat VALUES('labaratorijski',true); ";
            komanda.CommandText = "INSERT INTO aparat VALUES('otorinolaringo',true); ";
            komanda.CommandText = "INSERT INTO aparat VALUES('stom',true); ";
            komanda.CommandText = "INSERT INTO aparat VALUES('orto',true); ";
            komanda.CommandText = "INSERT INTO aparat VALUES('ofta',true); ";
            komanda.CommandText = "INSERT INTO ordinacija VALUES('Karioloska ordinacija',1,null,123,1);";
            komanda.CommandText = "INSERT INTO ordinacija VALUES('Dermatoloska ordinacija',2,null,223,2);";
            komanda.CommandText = "INSERT INTO ordinacija VALUES('Laboratorijska ordinacija',3,null,323,3);";
            komanda.CommandText = "INSERT INTO ordinacija VALUES('Otorinolaringologija ordinacija',4,null,423,4);";
            komanda.CommandText = "INSERT INTO ordinacija VALUES('Stomatoloska ordinacija',1,null,523,5);";
            komanda.CommandText = "INSERT INTO ordinacija VALUES('Ortopedska ordinacija',2,null,623,6);";
            komanda.CommandText = "INSERT INTO ordinacija VALUES('Oftamoloska ordinacija',3,null,423,7);";
            komanda.CommandText = "INSERT INTO osoblje VALUES('Maja', 'Maji',0101971177218,null,null);";
            komanda.CommandText = "INSERT INTO osoblje VALUES('Ajla', 'Maji',0101971177213,null,null);";
            komanda.CommandText = "INSERT INTO osoblje VALUES('Emi', 'Maji',0101971177212,null,null);";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
