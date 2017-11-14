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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fm = new Form2();
            fm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from Account where Account_Number='" + textBox1.Text + "' and Password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Home fm = new Home(textBox1.Text);
                fm.Show();
            }
            else
            {
                MessageBox.Show("Please check your username or password");
                textBox1.Clear();
                textBox2.Clear();


            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
