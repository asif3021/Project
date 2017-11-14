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
using System.Collections;

namespace WindowsFormsApplication1
{
    public partial class Form7 : Form
    {
        public Form7(String value)
        {
            InitializeComponent();
            label1.Text = value;
            timer2.Start();

            con.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select Balance from Account where Account_Number='" + label1.Text + "'", con);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                textBox3.Text = (myReader["Balance"].ToString());
            }
            con.Close();







        }                                       
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Account where Account_Number='" + label1.Text + "' and Password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                if (Int32.Parse(textBox1.Text) > Int32.Parse(textBox3.Text))
                {
                    MessageBox.Show("Insufficient Balance !!!");
                }
                else
                {
                    con.Open();
                    int prf = Convert.ToInt32(textBox1.Text);
                    prf = prf * (5 / 100);
                    SqlDataAdapter sdaa = new SqlDataAdapter("update Account set Balance = Balance - '" + textBox1.Text + "' where Account_Number ='" + label1.Text + "'", con);
                    SqlDataAdapter sdaaa = new SqlDataAdapter("insert into Transection_Statement (Account_Number,Transection_Type, Amount,Date_Time) values ('" + label1.Text + "','Withdraw','" + textBox1.Text + "','" + label6.Text + "')", con);
                    sdaa.SelectCommand.ExecuteNonQuery();
                    sdaaa.SelectCommand.ExecuteNonQuery();
                    MessageBox.Show("Money withdraw Sucessfull !!!\n");
                    this.Hide();
                    Home fm = new Home(label1.Text);
                    fm.Show();
                    con.Close();
                }

            }
            else
            {
                MessageBox.Show("Please check your password");
                textBox1.Clear();
                textBox2.Clear();
            }


            
                  //  SqlDataAdapter sdaa = new SqlDataAdapter("update Account set Balance = Balance - ('" + textBox1.Text + "' + ('" + textBox1.Text + "'*0.05)) where Account_Number ='" + label1.Text + "'", con);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fm = new Home(label1.Text);
            fm.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 255);
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            label5.ForeColor = Color.FromArgb(a, r, g, b);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            DateTime dati = DateTime.Now;
            this.label6.Text = dati.ToString();
        }
    }
}
