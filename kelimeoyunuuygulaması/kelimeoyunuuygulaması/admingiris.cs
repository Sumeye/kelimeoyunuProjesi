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
    public partial class admingiris : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=SENTURK;Initial Catalog=kelimeoyunu;Integrated Security=True");
        public admingiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Giriş Başarısız! Eksik Bilgi Girdiniz.", "..:: HATA ::..", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("select * from uyeler where kullaniciAd=@uye AND parola=@Asifre", baglan);
                komut.Parameters.AddWithValue("@uye", textBox1.Text);
                komut.Parameters.AddWithValue("@Asifre", textBox2.Text);
                DataSet dt = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(komut);
                da.Fill(dt);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Tables[0].Rows.Count; i++)
                    {
                        if (dt.Tables[0].Rows[i][3].ToString() == "user")
                        {
                            MessageBox.Show("HOŞGELDİN " + textBox1.Text);
                        adminpanel form2 = new adminpanel();
                            this.Hide();
                            form2.Show();
                       
                        }
                        else
                        {
                            MessageBox.Show("HOŞGELDİN " + textBox1.Text);
                            Form1 form2 = new Form1();
                            this.Hide();
                            form2.Show();
                     
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Veritabınında böyle bir kullanıcı bulunmadı");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            baglan.Close();
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
