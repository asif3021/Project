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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Semester1 fm = new Semester1();
            fm.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Semester2 fm = new Semester2();
            fm.Show();
        }
    }
}
