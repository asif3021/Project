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
    public partial class Transection_details : Form
    {
        public Transection_details()
        {
            InitializeComponent();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select *from Transection_Statement ORDER BY Date_Time DESC", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
            

        private void Transection_details_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from Transection_Statement where Account_Number like('" + textBox1.Text + "%') ORDER BY Date_Time DESC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator fm = new Administrator();
            fm.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select *from Transection_Statement ORDER BY Date_Time DESC", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please select transection.");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("delete from Transection_Statement where Account_Number='" + textBox1.Text + "' and Date_Time='" + textBox2.Text + "'", con);
                MessageBox.Show("Sucessfully Removed. !!!");
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                textBox2.Clear();
            }
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }
    }
}
