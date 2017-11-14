using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Home : Form
    {

        public Home(string value)
        {
            InitializeComponent();
            label3.Text = value;
            timer1.Start();

            con.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select Name from Account where Account_Number='" + label3.Text + "'", con);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                label4.Text = (myReader["Name"].ToString());
            }
            con.Close();

            con.Open();
            MemoryStream stream = new MemoryStream();
            //con.Open();
            SqlCommand command = new SqlCommand("select Photo from Account where Account_Number='" + label3.Text + "'", con);
            byte[] image = (byte[])command.ExecuteScalar();
            stream.Write(image, 0, image.Length);
            con.Close();
            Bitmap bitmap = new Bitmap(stream);
            pb1.Image = bitmap;
            con.Close();



        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
       

        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime dati = DateTime.Now;
            this.label1.Text = dati.ToString();
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 fm = new Form6(label3.Text);
            fm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 fm = new Form7(label3.Text);
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 fm = new Form4(label3.Text);
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transection1 fm = new Transection1(label3.Text);
            fm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fm = new Form3();
            fm.Show();
        }
    }
}
