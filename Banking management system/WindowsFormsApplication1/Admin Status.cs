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
    public partial class Admin_Status : Form
    {
        public Admin_Status()
        {
            InitializeComponent();

            con.Open();
            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand("select capital=sum(capital) from Admin", con);
            myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                label4.Text = (myReader["capital"].ToString());
            }
            con.Close();

            con.Open();
            SqlCommand Command = new SqlCommand("select Interest=SUM(Interest) from Profit", con);
            myReader = Command.ExecuteReader();
            while (myReader.Read())
            {
                label5.Text = (myReader["Interest"].ToString());
            }
            con.Close();


            con.Open();
            SqlCommand CCommand = new SqlCommand("select capital=SUM(capital)+(select Interest=SUM(Interest) from Profit) from Admin", con);
            myReader = CCommand.ExecuteReader();
            while (myReader.Read())
            {
                label6.Text = (myReader["capital"].ToString());
            }
            con.Close();
        }









        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-OM6BV6P\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        

        private void Asmin_Status_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select *from Admin ORDER BY username ASC", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please enter sufficient information. !!!");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Admin (admin_id, username,Password) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlDataAdapter sdda = new SqlDataAdapter("select *from Admin", con);
                DataTable data = new DataTable();
                sdda.Fill(data);
                dataGridView1.DataSource = data;
                con.Close();
                MessageBox.Show("Admin added Sucessfully !!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "1")
            {
                MessageBox.Show("This admin can't be deleted. !!!");
            }

            else if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please select an account. !!!");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("delete from Admin where admin_id='" + textBox1.Text + "'", con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlDataAdapter sdda = new SqlDataAdapter("select *from Admin", con);
                DataTable data = new DataTable();
                sdda.Fill(data);
                dataGridView1.DataSource = data;
                con.Close();
                MessageBox.Show("Admin removed successfully. !!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please select an admin. !!!");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("update Admin set username='" + textBox2.Text + "',Password='" + textBox3.Text + "'where  admin_id='" + textBox1.Text + "'", con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlDataAdapter sdda = new SqlDataAdapter("select *from Admin", con);
                DataTable data = new DataTable();
                sdda.Fill(data);
                dataGridView1.DataSource = data;
                con.Close();
                MessageBox.Show("Updated Sucessfully !!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator fm = new Administrator();
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select *from Profit ORDER BY Time_Date DESC", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }
    }
}