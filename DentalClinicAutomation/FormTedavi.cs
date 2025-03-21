using DentalClinicAutomation.DAL;
using DentalClinicAutomation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinicAutomation
{
    public partial class FormTedavi : Form
    {
        public FormTedavi()
        {
            InitializeComponent();
        }

        void TedavileriYenile()
        {
            TedaviServis ts = new TedaviServis();

            DataSet ds = ts.TedavileriGetir();
            TedaviDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            TedaviServis ts = new TedaviServis();

            DataSet ds = ts.TedaviAra(ARATB.Text);
            TedaviDGV.DataSource = ds.Tables[0];
        }

        void Reset()
        {
            TedaviAdiTb.Text = "";
            TedaviTutarTb.Text = "";
            AciklamaTb.Text = "";
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            TedaviServis ts = new TedaviServis();
            Tedavi t = new Tedavi();
            t.TedaviAdi = TedaviAdiTb.Text;
            t.TedaviUcret = decimal.Parse(TedaviTutarTb.Text);
            t.TedaviAciklama = AciklamaTb.Text;
            t.Aktif = true;
            t.Silindi = false;
            t.OlusturmaTarihi = DateTime.Now;
            t.GuncellemeTarihi = DateTime.Now;
          
            try
            {
                if (ts.TedaviEkle(t))
                {


                    MessageBox.Show("Tedavi Başarıyla Eklendi");
                    TedavileriYenile();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Tedavi Hatalı Eklenmedi");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        int key = 0;



        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
     
            if (key == 0)
            {
                MessageBox.Show("Güncellenecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {
                    TedaviServis ts = new TedaviServis();
                    Tedavi t = new Tedavi();
                    t.TedaviId = key;
                    t.TedaviAdi = TedaviAdiTb.Text;
                    t.TedaviUcret = decimal.Parse(TedaviTutarTb.Text);
                    t.TedaviAciklama = AciklamaTb.Text;
                    t.Aktif = true;
                    t.Silindi = false;
                    t.OlusturmaTarihi = DateTime.Now;
                    t.GuncellemeTarihi = DateTime.Now;
                    if (ts.TedaviGuncelle(t))
                    {
                        MessageBox.Show("Tedavi Başarıyla Güncellendi");
                        TedavileriYenile();
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Tedavi Hatalı Güncellenmedi");
                    }
                    
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            
            if (key == 0)
            {
                MessageBox.Show("Silinecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {
                    TedaviServis ts = new TedaviServis();
                   
                    if (ts.TedaviSil(key))
                    {
                        MessageBox.Show("Tedavi Başarıyla Silimdi");
                        TedavileriYenile();
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Tedavi Hatalı Silinemedi");
                    }
       
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tedavi_Load(object sender, EventArgs e)
        {
            TedavileriYenile();
            Reset();
        }

        private void TedaviDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TedaviAdiTb.Text = TedaviDGV.SelectedRows[0].Cells[1].Value.ToString();
            TedaviTutarTb.Text = TedaviDGV.SelectedRows[0].Cells[2].Value.ToString();
            AciklamaTb.Text = TedaviDGV.SelectedRows[0].Cells[3].Value.ToString();
           
            if (TedaviAdiTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(TedaviDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HastaGiris ana = new HastaGiris();
            ana.Show();
            this.Hide();
        }

        private void ARATB_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            TedaviServis ts = new TedaviServis();
            DataSet ds = ts.TedavileriGetir();
            TedaviDGV.DataSource = ds.Tables[0];
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            FormHasta hst = new FormHasta();
            hst.Show();
            this.Hide();
        }

        private void guna2GradientButton11_Click(object sender, EventArgs e)
        {
            FormRandevu rnd = new FormRandevu();
            rnd.Show();
            this.Hide();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {

            FormRecete rctlr = new FormRecete();
            rctlr.Show();
            this.Hide();
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            FormKullanici kKayit = new FormKullanici();
            kKayit.Show();
            this.Hide();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {

        }

        private void TedaviDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
