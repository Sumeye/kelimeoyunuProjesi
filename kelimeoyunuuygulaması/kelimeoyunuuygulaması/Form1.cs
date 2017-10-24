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
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int tutulan = 0;
        int kez = 0;
        int dogru = 0;
        int sayac = 0;
        int puan = 0;
        int baraj = 0;
        int say = 0;
        SqlConnection baglan = new SqlConnection("Data Source=SENTURK;Initial Catalog=kelimeoyunu;Integrated Security=True");
        public string karistir(string girdi)
        {
            List<char> str = girdi.ToList();
            string karisik = "";
            Random rand = new Random();
            int t = str.Count - 1;
            for (int i = 0; i <= t; i++)
            {
                int p = rand.Next(str.Count);
                karisik += Convert.ToString(str[p]);
                str.RemoveAt(p);
            }
            return karisik;
        }

        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            say = say - 1;
            label3.Text = Convert.ToString(say);
            if (say == 0)
            {
                timer1.Stop();
                MessageBox.Show("SÜRE DOLDU");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            baraj = 50;
            timer1.Interval = 1000;
            say = 300;
            timer1.Enabled = true;
            timer1.Start();
            tutulan = rnd.Next(1, 30);
            baglan.Open();

            SqlCommand komut = new SqlCommand("SELECT * FROM tbl_Kelime where  Kelime_Id='" + tutulan + "'", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                label1.Text = karistir(dr[1].ToString());
            }
            baglan.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM tbl_Kelime where  Kelime_Id='" + tutulan + "'", baglan);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
                if (textBox1.Text == dr[1].ToString())
                {
                    dogru = dogru + 1;
                    label4.Text = Convert.ToString(dogru);
                    puan = puan + 10;
                    label2.Text = Convert.ToString(puan);
                    textBox1.Text = "";
                    label1.Text = karistir(dr[1].ToString());
                }
                else
                {
                    label6.Text = dr[1].ToString();
                    kez = kez + 1;
                    label5.Text = Convert.ToString(kez);
                    textBox1.Text = "";
                    if ((kez == 1))
                    {
                        pictureBox1.ImageLocation = "kalpyanls.jpg";
                        pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                    }
                    if ((kez == 2))
                    {
                        pictureBox2.ImageLocation = "kalpyanls.jpg";
                        pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                    }
                    if ((kez == 3))
                    {
                        pictureBox3.ImageLocation = "kalpyanls.jpg";
                        pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
                    }

                    if (((kez >= 3) && (puan > baraj)))
                    {
                        timer1.Stop();
                        kez = 0;
                        puan = 0;
                        sayac = 0;
                        say = 10;
                        textBox1.Enabled = false;
                        pictureBox1.Enabled = false;
                    }
                    else if (((kez >= 3) && (puan < baraj)))
                    {
                        timer1.Stop();
                        kez = 0;
                        puan = 0;
                        sayac = 0;
                        say = 10;
                        textBox1.Enabled = false;
                        pictureBox1.Enabled = false;
                        button1.Enabled = false;
                        Form7 f = new Form7();
                        this.Hide();
                        f.Show();
                    }
                    else if ((kez >= 3))
                    {
                        timer1.Stop();
                        kez = 0;
                        puan = 0;
                        sayac = 0;
                        say = 10;
                        textBox1.Enabled = false;
                        pictureBox1.Enabled = false;
                        Form7 f = new Form7();
                        this.Hide();
                        f.Show();
                    }
                }
            baglan.Close();

            if (puan >= 0 && puan <= 50)
            {
                tutulan = rnd.Next(1, 10);
            }
            else if (puan > 50)
            {
                tutulan = rnd.Next(11, 20);
                label8.Text = "6 harfli kelime grupları";
            }
            SqlCommand komutt = new SqlCommand("SELECT * FROM tbl_Kelime where  Kelime_Id='" + tutulan + "'", baglan);
            baglan.Open();
            SqlDataReader drr = komutt.ExecuteReader();
            if (drr.Read())
            {
                label1.Text = karistir(drr[1].ToString());
            }
            baglan.Close();
            }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        }
    }

