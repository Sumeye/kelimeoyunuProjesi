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
    public partial class Form7 : Form
    {
     
        public Form7()
        {
    
            InitializeComponent();
        }


        private void Form7_Load(object sender, EventArgs e)
        {

         //SqlConnection baglan = new SqlConnection("Data Source=SENTURK;Initial Catalog=kelimeoyunu;Integrated Security=True");
         //   SqlCommand komut = new SqlCommand("insert into tbl_Skor values('" + girilenad + "','" + Gelen_p + "')", baglan);
         // baglan.Open();
         //   komut.ExecuteNonQuery();
         //   baglan.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            this.Hide();
            f3.Show();

        }
    }
}
