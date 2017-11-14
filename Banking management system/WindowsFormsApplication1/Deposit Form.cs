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

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        public Form4(string value)
        {
            InitializeComponent();
            label6.Text = value;
            timer1.Start();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        

        private void button4_Click(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Account where Account_Number='" + label6.Text + "' and Password='" + textBox3.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                con.Open();
                SqlDataAdapter sdaa = new SqlDataAdapter("update Account set Balance = Balance + '" + textBox4.Text + "'-100 where Account_Number ='" + label6.Text + "'", con);
                SqlDataAdapter sdaaa = new SqlDataAdapter("insert into Transection_Statement (Account_Number,Transection_Type, Amount,Date_Time) values ('" + label6.Text + "','Deposite','" + textBox4.Text + "','" + label1.Text + "')", con);
                sdaaa.SelectCommand.ExecuteNonQuery();
                sdaa.SelectCommand.ExecuteNonQuery();
                SqlCommand ppp = new SqlCommand("insert into Profit (Customer_Account_Number,Tansaction_Type, Amount,Interest,Time_Date) values ('" + label6.Text + "','Deposite','" + textBox4.Text + "','100','" + label1.Text + "')", con);
                ppp.ExecuteNonQuery();
                MessageBox.Show("Money deposite Sucessfull !!!\nCharged 100 taka.");
                this.Hide();
                Home fm = new Home(label6.Text);
                fm.Show();
                con.Close();
            }
            else
            {
                MessageBox.Show("Please check your password");
                textBox4.Clear();
                textBox3.Clear();


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fm = new Home(label6.Text);
            fm.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer2.Start();
            timer2.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dati = DateTime.Now;
            this.label1.Text = dati.ToString();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 255);
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            label2.ForeColor = Color.FromArgb(a, r, g, b);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string dateTimePicker1 { get; set; }
    }
}
