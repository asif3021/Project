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
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form6 : Form
    {
        string aaa;
        public Form6(string value)
        {
            InitializeComponent();
            timer2.Start();
            //label2.Text=value;
            textBox1.Text= value;
            //textBox7.Text = "select Balance from Account where Account_Number=value";
            //vlu = value;
            aaa = value;


            con.Open();

            MemoryStream stream = new MemoryStream();
            SqlCommand command = new SqlCommand("select Photo from Account where Account_Number='" + textBox1.Text + "'", con);
            byte[] image = (byte[])command.ExecuteScalar();
            stream.Write(image, 0, image.Length);
            con.Close();
            Bitmap bitmap = new Bitmap(stream);
            pb1.Image = bitmap;
            con.Close();




        }

        public Form6()
        {
            // TODO: Complete member initialization
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        //private string vlu;
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int a = rnd.Next(0, 255);
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            label1.ForeColor = Color.FromArgb(a, r, g, b);
        }

        private void Form6_Load(object sender, EventArgs e)
        {

            timer1.Start();
            timer1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select Account_ID, Account_Number,Password,Name,Mobile,City,Balance from Account where Account_Number like('" + textBox1.Text + "')";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            //label2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox4.Text == "" || textBox8.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please enter correct information. !!!");
            }
            else
            {

                con.Open();
                int i = 0;
                SqlDataAdapter ssdda = new SqlDataAdapter("delete from Account where Account_Number='" + textBox1.Text + "'", con);
                ssdda.SelectCommand.ExecuteNonQuery();
                SqlCommand cmd = new SqlCommand("insert into Account (Account_ID, Account_Number,Password,Name,Mobile,City,Balance,Photo) values ('" + textBox8.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "',@pb1)", con);
                MemoryStream stream = new MemoryStream();
                pb1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@pb1", pic);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    //MessageBox.Show("Completed !!!" + i);
                }
                con.Close();
                MessageBox.Show("Updated Sucessfully !!!");
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            DateTime dati = DateTime.Now;
            this.label11.Text = dati.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form7 fm = new Form7(textBox1.Text);
            fm.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Home fm = new Home(textBox1.Text);
            fm.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form4 fm = new Form4(textBox1.Text);
            fm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transection1 fm = new Transection1(textBox1.Text);
            fm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            opd1.Filter = "jpg|*.jpg";
            DialogResult res = opd1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pb1.Image = Image.FromFile(opd1.FileName);



            }
        }

        private void pb1_Click(object sender, EventArgs e)
        {

        }
    }
}
