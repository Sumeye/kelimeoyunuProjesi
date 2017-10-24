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

namespace kelimeoyunuuygulaması
{
    public partial class Form6 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=SENTURK;Initial Catalog=kelimeoyunu;Integrated Security=True");
        public Form6()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Form1 f1 = new Form1();
            this.Close();
            f1.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }
    }
}

