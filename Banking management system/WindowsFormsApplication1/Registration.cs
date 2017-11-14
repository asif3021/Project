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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
            timer1.Start();
        }


        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-OM6BV6P\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Banking;Integrated Security=True");
        



        private void button1_Click(object sender, EventArgs e)
        {
            opd1.Filter = "jpg|*.jpg";
            DialogResult res = opd1.ShowDialog();
            if (res == DialogResult.OK)
            {
                pb1.Image = Image.FromFile(opd1.FileName);



            }
        }

        private void Registration_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Please enter correct information. !!!");
            }
            else if (pb1.Image == NULL)
            {
                MessageBox.Show("Please upload a photo !!!");
            }
            else
            {
                con.Open();
                int i = 0;
                SqlCommand cmd = new SqlCommand("insert into Account (Account_ID, Account_Number,Password,Name,Mobile,City,Balance,Photo) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'-100,@pb1)", con);
                MemoryStream stream = new MemoryStream();
                SqlDataAdapter sdaaa = new SqlDataAdapter("insert into Transection_Statement (Account_Number,Transection_Type, Amount,Date_Time) values ('" + textBox2.Text + "','Deposite','" + textBox7.Text + "','" + label8.Text + "')", con);
                sdaaa.SelectCommand.ExecuteNonQuery();
                SqlCommand ppp = new SqlCommand("insert into Profit (Customer_Account_Number,Tansaction_Type, Amount,Interest,Time_Date) values ('" + textBox2.Text + "','Deposite','" + textBox7.Text + "','100','" + label8.Text + "')", con);
                ppp.ExecuteNonQuery();
                pb1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@pb1", pic);
                i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                }

                con.Close();
                MessageBox.Show("Created Sucessfully !!!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                pb1.Image = null;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            this.label8.Text = date.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Administrator fm = new Administrator();
            fm.Show();
        }

        public Image NULL { get; set; }
    }
}
