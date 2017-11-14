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

namespace WindowsFormsApplication1
{
    public partial class Transection1 : Form
    {
        public Transection1(string value)
        {
            InitializeComponent();
            label2.Text = value;
            timer1.Start();

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Transection_Type, Amount,Date_Time from Transection_Statement where Account_Number = ('" + label2.Text + "') ORDER BY Date_Time DESC", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();



            con.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select Balance from Account where Account_Number='" + label2.Text + "'", con);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                label4.Text = (myReader["Balance"].ToString());
            }
            con.Close();















        }

        public Transection1(string p1, char p2)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
        }


        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        private string p1;
        private char p2;
      
        

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home frmm = new Home(label2.Text);
            frmm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            DateTime date = DateTime.Now;
            this.label5.Text = date.ToString();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
