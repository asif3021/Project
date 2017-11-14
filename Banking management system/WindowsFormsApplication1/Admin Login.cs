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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
//        SqlConnection con = new SqlConnection("Data Source=DESKTOP-OM6BV6P\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        
            

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Admin where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Administrator fm = new Administrator();
                fm.Show();
            }
            else
            {
                MessageBox.Show("Please check your username or password");
                textBox1.Clear();
                textBox2.Clear();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form2 fm = new Form2();
            fm.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Admin where Username='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Administrator fm = new Administrator();
                fm.Show();
            }
            else
            {
                MessageBox.Show("Please check your username or password");
                textBox1.Clear();
                textBox2.Clear();
            }
        }
    }
}
