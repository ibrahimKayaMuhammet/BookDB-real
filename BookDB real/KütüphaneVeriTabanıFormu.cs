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

namespace BookDB_real
{
    public partial class KütüphaneVeriTabanıFormu : Form
    {
        public KütüphaneVeriTabanıFormu()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void KayıtEkranıFormu_Load(object sender, EventArgs e)
        {
            //whe are writing this code in order to show the databse in datagridview when this form has opened
            //creating sql connection first
            string connection = "Server=localhost;user id=root;password=7456;database=uskudarkutuphanesi;";
            //Creating query FOR UPDATING OUR DATA
            string query = "SELECT *FROM kitap;";
                
            //In order to get mysql conncetion at the windows app and also for using predefined methods, I require to create new object for mysql conncetion  
            MySqlConnection conn = new MySqlConnection(connection);
            //In order to give commend to  mysql database at the windows app and also for using predefined methods, I require to create new object for mysql command
            MySqlCommand cmd = new MySqlCommand(query, conn);
            //In order to show my database from datagridwiew at the windows app and also for using predefined methods, I require to create new object for mysql MySqlAdapter
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand= cmd;
            //in order to fill  data grid wiew with data table I require to create new object for mysql Datatable
            DataTable dt =new DataTable();
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //being sure that the users will input all the value so there won't be any null value 
            if ((!(kitapAdıtextbox.Text == "") && !(baskıSayısımaskedTextbox.Text == "") && !(yayıneviTextBox.Text == "") && !(yazarAdıTextBox.Text == "") && !(yazarSoyadıTextBox.Text == "") && !(ödünçAlanİsimTextBox.Text == "") && !(ödünçAlanİSoyadTextBox.Text == "")))
            {
                //creating sql connection first
                string connection = "Server=localhost;user id=root;password=7456;database=uskudarkutuphanesi;";
                //Creating query FOR UPDATING OUR DATA
                string query = "UPDATE kitap SET KitapAdı ='" + kitapAdıtextbox.Text + "',BaskıSayısı='" + baskıSayısımaskedTextbox.Text + "',Yayınevi='" + yayıneviTextBox.Text + "'," +
                    "YazarAdı='" + yazarAdıTextBox.Text + "'," + "YazarSoyadı='" + yazarSoyadıTextBox.Text + "'," + "ÖdünçAlanAdı='" + ödünçAlanİsimTextBox.Text + "'," +
                    "ÖdünçAlanSoyadı='" + ödünçAlanİSoyadTextBox.Text + "'WHERE KitapNumarası='" + KitapNumarası.Text + "'";
                //In order to get mysql conncetion at the windows app and also for using predefined methods, I require to create new object for mysql conncetion  
                MySqlConnection conn = new MySqlConnection(connection);
                //In order to give commend to  mysql database at the windows app and also for using predefined methods, I require to create new object for mysql command
                MySqlCommand cmd = new MySqlCommand(query, conn);
                // in order to  let my sql service read it ı should create object for mysqldatareader class
                MySqlDataReader dataReader;
                //open the mysql connection
                conn.Open();
                dataReader = cmd.ExecuteReader();
                //success messsage for users who succesfully downloaded
                MessageBox.Show("Bilgileriniz Güncellenmiştir");
                //close connection
                conn.Close();
            }
            else
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //creating sql connection first
            string connection = "Server=localhost;user id=root;password=7456;database=uskudarkutuphanesi;";
            //Creating query FOR UPDATING OUR DATA
            string query = "DELETE FROM kitap WHERE KitapNumarası ='"+KitapNumarası.Text+"'";
            //In order to get mysql conncetion at the windows app and also for using predefined methods, I require to create new object for mysql conncetion  
            MySqlConnection conn = new MySqlConnection(connection);
            //In order to give commend to  mysql database at the windows app and also for using predefined methods, I require to create new object for mysql command
            MySqlCommand cmd = new MySqlCommand(query, conn);
            // in order to  let my sql service read it ı should create object for mysqldatareader class
            MySqlDataReader dataReader;
            //open the mysql connection
            conn.Open();
            dataReader = cmd.ExecuteReader();
            MessageBox.Show("Bilgi Silinmiştir");
            conn.Close();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //creating an if statement for when user double clickk on any of rows ,then all the rows of the respective book will be written into textboxes
            if (dataGridView1.CurrentRow.Index != -1)
            {

                KitapNumarası.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                kitapAdıtextbox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                baskıSayısımaskedTextbox.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                yayıneviTextBox.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                yazarAdıTextBox.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
               yazarSoyadıTextBox.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                ödünçAlanİsimTextBox.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                ödünçAlanİSoyadTextBox.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
