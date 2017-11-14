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
    public partial class Semester2 : Form
    {
        public Semester2()
        {
            InitializeComponent();
            String st = "asif ahmed";
            value.Text = st;
        }
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-VL661MN\\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
        static int total, count, count2, count3, count4, count5, cat_count, xyz, box_int;
        static string s, box1, cat, cat_s1, s2, cat_hsc, cat_mw, cat_ew;
        static double box_double, r0, r1, r2, r3, r4, r5, result, value01, value02, value03, value04;
        static double x1,x2,x3,x4,x5,x6;





        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home fm = new Home();
            fm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            con.Open();
            SqlDataReader myReader = null;
           // SqlCommand myCommand = new SqlCommand("select Name from Account where Account_Number='" + label3.Text + "'", con);
            SqlCommand myCommand = new SqlCommand("select count(ID) from Result", con);

            myReader = myCommand.ExecuteReader();

            while (myReader.Read())
            {
                total = Convert.ToInt32((myReader[""].ToString()));
//                s = Convert.ToString(total);
//                value.Text = s;
            }
            con.Close();
            for (int i = 0; i < 4; i++)             //loop start
            {
                if (i == 0)
                {
                    cat = "VG";
                }
                else if (i == 1)
                {
                    cat = "AA";
                }
                else if (i == 2)
                {
                    cat = "P";
                }
                else if (i == 3)
                {
                    cat = "F";
                }
                con.Open();
                SqlDataReader reader0 = null;
                SqlCommand my0 = new SqlCommand("select count(ID) from Result where s2='" + cat + "'", con);

                reader0 = my0.ExecuteReader();

                while (reader0.Read())
                {
                    count = Convert.ToInt32((reader0[""].ToString()));
                }
                con.Close();
                cat_count = count;
                r0 = (double)cat_count / (double)total;
                //s = Convert.ToString(r0);
                //textBox4.Text = s;
                
                //--------------------------------------------------------------------------------------------------------------------
                box1 = TextBox1.Text;
                box_double = Convert.ToDouble(box1);
                if (box_double >= 3.50 && box_double <= 4.00)
                {
                    cat_s1 = "VG";
                }
                else if (box_double >= 2.75 && box_double <= 3.49)
                {
                    cat_s1 = "AA";
                }
                else if (box_double >= 2.00 && box_double <= 2.74)
                {
                    cat_s1 = "P";
                }
                else
                {
                    cat_s1 = "F";
                }

                con.Open();
                SqlDataReader reader3 = null;
                SqlCommand my2 = new SqlCommand("select count(ID) from Result where s1='" + cat_s1 + "' and s2='" + cat + "'", con);
                reader3 = my2.ExecuteReader();
                while (reader3.Read())
                {
                    count2 = Convert.ToInt32((reader3[""].ToString()));
                }
                con.Close();
                r1 = (double)count2 / (double)cat_count;
                //s = Convert.ToString(r1);
                //textBox5.Text = s;


                //--------------------------------------------------------------------------------------------------------------------
                box1 = TextBox2.Text;
                box_double = Convert.ToDouble(box1);
                if (box_double >= 4.50 && box_double <= 5.00)
                {
                    cat_hsc = "OS";
                }
                else if (box_double >= 3.00 && box_double <= 4.49)
                {
                    cat_hsc = "S";
                }

                con.Open();
                SqlDataReader reader2 = null;
                SqlCommand my3 = new SqlCommand("select count(ID) from Result where HSC='" + cat_hsc + "' and s2='" + cat + "'", con);
                reader2 = my3.ExecuteReader();
                while (reader2.Read())
                {
                    count3 = Convert.ToInt32((reader2[""].ToString()));
                }
                con.Close();
                r2 = (double)count3 / (double)cat_count;
                //s = Convert.ToString(r2);
                //textBox6.Text = s;


                //--------------------------------------------------------------------------------------------------------------------
                con.Open();
                SqlDataReader reader4 = null;
                SqlCommand my5 = new SqlCommand("select count(ID) from Result where Weakness_Math='" + ComboBox1.Text + "' and s2='" + cat + "'", con);
                reader4 = my5.ExecuteReader();
                while (reader4.Read())
                {
                    count4 = Convert.ToInt32((reader4[""].ToString()));
                }
                con.Close();
                r3 = (double)count4 / (double)cat_count;
                //s = Convert.ToString(r3);
                //textBox7.Text = s;


                //--------------------------------------------------------------------------------------------------------------------
                con.Open();
                SqlDataReader reader6 = null;
                SqlCommand my7 = new SqlCommand("select count(ID) from Result where Weakness_English='" + ComboBox2.Text + "' and s2='" + cat + "'", con);
                reader6 = my7.ExecuteReader();
                while (reader6.Read())
                {
                    count5 = Convert.ToInt32((reader6[""].ToString()));
                }
                con.Close();
                r4 = (double)count5 / (double)cat_count;


                result = r0 * r1 * r2 * r3 * r4;
                s = Convert.ToString(result);
                value.Text = s;
                // value.Text = s;



                if (i == 0)
                {
                    value01 = result;
                    cat = "VG";
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("update pi_value set Value = '" + result + "' where Catagory ='" + "VG" + "'", con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();



                    s = Convert.ToString(result);
                    value.Text = s;
                }
                else if (i == 1)
                {
                    value02 = result;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("update pi_value set Value = '" + result + "' where Catagory ='" + "AA" + "'", con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();



                    s = Convert.ToString(result);
                    value.Text = s;
                }
                else if (i == 2)
                {
                    value03 = result;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("update pi_value set Value = '" + result + "' where Catagory ='" + "P" + "'", con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();



                    s = Convert.ToString(result);
                    value.Text = s;
                }
                else if (i == 3)
                {
                    value04 = result;
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("update pi_value set Value = '" + result + "' where Catagory ='" + "F" + "'", con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();



                 
                    x1 = value01 + value02 + value03 + value04;
                    x2 = ((value01 * 100) / x1);
                    x3 = ((value02 * 100) / x1);
                    x4 = ((value03 * 100) / x1);
                    x5 = ((value04 * 100) / x1);


                    con.Open();
                    SqlDataAdapter sda001 = new SqlDataAdapter("update pi_value set Value = '" + x2 + "' where Catagory ='" + "VG" + "'", con);
                    sda001.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    SqlDataAdapter sda002 = new SqlDataAdapter("update pi_value set Value = '" + x3 + "' where Catagory ='" + "AA" + "'", con);
                    sda002.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    SqlDataAdapter sda003 = new SqlDataAdapter("update pi_value set Value = '" + x4 + "' where Catagory ='" + "P" + "'", con);
                    sda003.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    con.Open();
                    SqlDataAdapter sda004 = new SqlDataAdapter("update pi_value set Value = '" + x5 + "' where Catagory ='" + "F" + "'", con);
                    sda004.SelectCommand.ExecuteNonQuery();
                    con.Close();



                    s = Convert.ToString(x2);
                    textBox4.Text = s;
                    s = Convert.ToString(x3);
                    textBox5.Text = s;
                    s = Convert.ToString(x4);
                    textBox6.Text = s;
                    s = Convert.ToString(x5);
                    textBox7.Text = s;






                    Form2 fm = new Form2();
                    fm.Show();
                }



                //con.Open();
                //SqlDataReader readerdata = null;
                //SqlCommand cmnd = new SqlCommand("select *from pi_value", con);
                //readerdata = cmnd.ExecuteReader();



                //while (readerdata.Read())
                //{
                //    this.pi_chart.Series["Result"].XValueMember = "Catagory";
                //    this.pi_chart.Series["Result"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                //    this.pi_chart.Series["Result"].YValueMembers = "Value";
                //    this.pi_chart.Series["Result"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;


                //}
                //con.Close();


                //pi_chart.DataSource=con.
                //con.Open();

                //SqlDataReader readerdata = null;
                //SqlCommand cmnd = new SqlCommand("select *from pi_value", con);
                //readerdata = cmnd.ExecuteReader();
                //pi_chart.DataSource = con..ToList();
                //pi_chart.Series["Result"].XValueMember = "Catagory";
                ////pi_chart.Series["Result"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
                //pi_chart.Series["Result"].YValueMembers = "Value";
                ////pi_chart.Series["Result"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
                //pi_chart.DataSource = dataGridView1;
                //pi_chart.DataBind();
                
                
                //con.Close();

                //pi_chart.Series["Result"].Points.AddXY("VG", value01);
                //pi_chart.Series["Result"].Points.AddXY("AA", value02);
                //pi_chart.Series["Result"].Points.AddXY("P", value03);
                //pi_chart.Series["Result"].Points.AddXY("F", value04);


                //pi_chart.Hide();
                //pi_chart.Show();




                //this.Hide();
                //Form2 fm = new Form2();
                //fm.Show();







                //while (readerdata.Read())
                //{
                //    count4 = Convert.ToInt32((readerdata[""].ToString()));
                //}
                //con.Close();






            }


















        }




        private void Semester2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testDataSet.pi_value' table. You can move, or remove it, as needed.
            this.pi_valueTableAdapter.Fill(this.testDataSet.pi_value);

        }

        private void value_TextChanged(object sender, EventArgs e)
        {

        }

        private void pi_chart_Click(object sender, EventArgs e)
        {

        }


    }
}
