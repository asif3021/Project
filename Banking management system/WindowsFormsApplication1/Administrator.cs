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
    public partial class Administrator : Form
    {
        //this.hide();
        //Form2 frm=new Form2();
        //frm.show();
        public Administrator()
        {
            InitializeComponent();
            timer1.Start();
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        
        
        private void button1_Click_1(object sender, EventArgs e)
        {
        
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Account_ID, Account_Number,Password,Name,Mobile,City,Balance from Account ORDER BY Account_ID ASC", con);
            DataTable data = new DataTable();
            sda.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();

        }

        private void textBox8_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Account_ID, Account_Number,Password,Name,Mobile,City,Balance from Account where Account_Number like('" + textBox8.Text + "%') ORDER BY Account_ID ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            this.label9.Text = date.ToString();
        }


        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("delete from Account where Account_Number='" + textBox2.Text + "'", con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Sucessfully !!!");
            con.Open();
            SqlDataAdapter sda0 = new SqlDataAdapter("select Account_ID, Account_Number,Password,Name,Mobile,City,Balance from Account ORDER BY Account_ID ASC", con);
            DataTable data = new DataTable();
            sda0.Fill(data);
            dataGridView1.DataSource = data;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Start();
            timer2.Enabled = true;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 255);
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            label10.ForeColor = Color.FromArgb(a, r, g, b);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Hide();
            Form2 fm = new Form2();
            fm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Status fm = new Admin_Status();
            fm.Show();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transection_details f = new Transection_details();
            f.Show();
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Account_ID, Account_Number,Password,Name,Mobile,City,Balance from Account where Account_Number like('" + textBox2.Text + "%') ORDER BY Account_ID ASC";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please select an account. !!!");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("delete from Account where Account_Number='" + textBox2.Text + "'", con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                con.Open();
                SqlDataAdapter sda0 = new SqlDataAdapter("select Account_ID, Account_Number,Password,Name,Mobile,City,Balance from Account ORDER BY Account_ID ASC", con);
                DataTable data = new DataTable();
                sda0.Fill(data);
                dataGridView1.DataSource = data;
                con.Close();
                MessageBox.Show("Deleted Sucessfully !!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration f = new Registration();
            f.Show();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please select an account. !!!");
            }
            else
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("update Account set Account_ID='" + textBox1.Text + "',Password='" + textBox3.Text + "',Name='" + textBox4.Text + "',Mobile='" + textBox5.Text + "',City='" + textBox6.Text + "',Balance='" + textBox7.Text + "' where  Account_Number='" + textBox2.Text + "'", con);
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                SqlDataAdapter sddaa = new SqlDataAdapter("select Account_ID, Account_Number,Password,Name,Mobile,City,Balance from Account ORDER BY Account_ID ASC", con);
                DataTable data = new DataTable();
                MessageBox.Show("Updated Sucessfully !!!");
                sddaa.Fill(data);
                dataGridView1.DataSource = data;
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
            }
        }
    }
}
