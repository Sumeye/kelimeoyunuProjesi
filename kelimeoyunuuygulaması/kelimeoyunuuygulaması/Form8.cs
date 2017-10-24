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
    public partial class Form8 : Form
    {
        //aynı kodlar buradada var tamam mı buda tebrıkler yazdgında gelıcek puan ve ısım ıcın 
        public string adi;
        public int F5puan = 0;
        SqlConnection conn = new SqlConnection("Data Source=SENTURK;Initial Catalog=kelimeoyunu;Integrated Security=True");
        public Form8()
        {
            InitializeComponent();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            label2.Text = string.Empty;
            lblAdi.Text = string.Empty;
            label2.Text = F5puan.ToString();
            lblAdi.Text = adi;
            //connection ıslemleri puanı ve adı yazdırıyoruz.
            SqlCommand sorgu = new SqlCommand("insert into tbl_Skor values('" + adi + "','" + Convert.ToString(F5puan) + "')", conn);       
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            sorgu.ExecuteNonQuery();
            conn.Close();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Close();
            f4.Show();
        }
    }
}
