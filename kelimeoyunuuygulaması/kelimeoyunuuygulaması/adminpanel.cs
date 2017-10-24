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
    public partial class adminpanel : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=SENTURK;Initial Catalog=kelimeoyunu;Integrated Security=True");
        SqlDataAdapter da = new SqlDataAdapter();
        public adminpanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
           SqlCommand komut =new SqlCommand( "INSERT INTO tbl_Kelime values(@ad)",baglan);
            komut.Parameters.AddWithValue("ad",textBox1.Text);
            komut.ExecuteNonQuery();
            label2.Text = "Kayıt eklendi";
            baglan.Close();
            dataGridView1_yukle();
        }

        public void dataGridView1_yukle()
        {
          dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
          baglan.Open();
          DataSet ds = new DataSet();
          SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM tbl_Kelime", baglan);
       da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Refresh();
            baglan.Close();
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {
            dataGridView1_yukle();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("DELETE from tbl_Kelime WHERE Kelime_Id=@ID",baglan);
            komut.Parameters.AddWithValue("@ID", dataGridView1.SelectedCells[0].Value.ToString());
            komut.ExecuteNonQuery();
            label2.Text = "Kayıt silindi";
           baglan.Close();
           dataGridView1_yukle();
          
         

        }

        private void button4_Click(object sender, EventArgs e)
        {
           Form3 f = new Form3();
            this.Hide();
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1_yukle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("UPDATE  tbl_Kelime SET kelime_Ad=@ad where Kelime_Id=@ID",baglan);
            komut.Parameters.AddWithValue("@ad", textBox1.Text);
   komut.Parameters.AddWithValue("@ID", dataGridView1.SelectedCells[0].Value.ToString());
            komut.ExecuteNonQuery();
            label2.Text = "Kayıt güncellendi";
           baglan.Close();
           dataGridView1_yukle();
        }
         



    }
}
