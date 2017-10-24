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
    public partial class Form4 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=SENTURK;Initial Catalog=kelimeoyunu;Integrated Security=True");
   
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlDataAdapter verial = new SqlDataAdapter("select top 10 Kayit_Ad,Skor  from tbl_Skor order by Skor desc", conn);
  
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            DataTable tabloyaAl = new DataTable();
            verial.Fill(tabloyaAl);
            dataGridView1.DataSource = tabloyaAl;
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
