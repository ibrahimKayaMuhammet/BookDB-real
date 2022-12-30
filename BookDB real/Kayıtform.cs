using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace BookDB_real
{
    
    public partial class Kayıtform : Form
    {
        
        //creating a method for clearing all the texts on the textboxes
        public void clear()
        {
            kitapAdıtextbox.Clear();
            yayıneviTextBox.Clear();
            baskıSayısımaskedTextbox.Clear();
            yazarAdıTextBox.Clear();
            yazarSoyadıTextBox.Clear();
            ödünçAlanİsimTextBox.Clear();
            ödünçAlanİSoyadTextBox.Clear();
            dateTimePicker1.Value= DateTime.Now;

        }

        public Kayıtform()
        {
            
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string getirmeTarihi = dateTimePicker1.Value.AddDays(15).ToShortDateString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void YayıneviTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void KAYDETbutton_Click(object sender, EventArgs e)
        {
            //initializing local variable getirmetarihi and ödünçalmatarihi
            DateTime getirmeTarihi = dateTimePicker1.Value.AddDays(15);
            DateTime ÖdünçTarihi = dateTimePicker1.Value;
            //being sure that the users will input all the value so there won't be any null value 
            if ((!(kitapAdıtextbox.Text == "") &&!(baskıSayısımaskedTextbox.Text=="") && !(yayıneviTextBox.Text == "") && !(yazarAdıTextBox.Text == "") && !(yazarSoyadıTextBox.Text == "") && !(ödünçAlanİsimTextBox.Text == "") && !(ödünçAlanİSoyadTextBox.Text == "")))
            {
                //creating sql connection first
                string connection = "Server=localhost;user id=root;password=7456;database=uskudarkutuphanesi;";
                //creating query which we want to make in our MySqlDataBase
                string query = "INSERT INTO kitap(KitapAdı,BaskıSayısı,Yayınevi,YazarAdı,YazarSoyadı,ÖdünçAlanAdı,ÖdünçAlanSoyadı,ÖdünçAlmaTarihi,GeriGetirmeTarihi)VALUES('" +
                    kitapAdıtextbox.Text+"','"+baskıSayısımaskedTextbox.Text +
                    "','"+yayıneviTextBox.Text+"','"+yazarAdıTextBox.Text+"','"+yazarSoyadıTextBox.Text+"','"+ödünçAlanİsimTextBox.Text+"','"+ödünçAlanİSoyadTextBox.Text+
                                    "','"+ÖdünçTarihi.ToShortDateString()+"','"+getirmeTarihi.ToShortDateString()+"')";
                //In order to get mysql conncetion at the windows app and also for using predefined methods, I require to create new object for mysql conncetion  
                MySqlConnection conn = new MySqlConnection(connection);
                //In order to give commend to  mysql database at the windows app and also for using predefined methods, I require to create new object for mysql command
                MySqlCommand cmd = new  MySqlCommand(query, conn);
                //using method from mysql command class . in order to  let my sql service read it ı should create object for mysqldatareader class
                MySqlDataReader dataReader; 
                //open the mysql connection
                conn.Open();
                dataReader = cmd.ExecuteReader();
               //success messsage for users who succesfully downloaded
                MessageBox.Show("Bilgileriniz Kaydedilmiştir");
                //close connection
                conn.Close();














            }
            else
            {
                //warning message for users who'm did't put the input right
                MessageBox.Show("Lütfen tüm alanları doldurunuz ");
            }





        }

        private void Temizlebutton_Click(object sender, EventArgs e)
        {
         //using clear methhod for clearing textboxes
            clear();
            //refocusing the cursor for textbox
            kitapAdıtextbox.Focus();
           
        }

        private void panelKitapbilgileri_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Görüntülebutton_Click(object sender, EventArgs e)
        {
            //creating class from the form that we want to open and then use it's method to open 
            KütüphaneVeriTabanıFormu kayıtEkranıFormu=new KütüphaneVeriTabanıFormu();
            kayıtEkranıFormu.Show();
        }
    }
}
