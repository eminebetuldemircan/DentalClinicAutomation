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
    public partial class FormKullanici : Form
    {
        public FormKullanici()
        {
            InitializeComponent();
        }

        private void FormKullanici_Load(object sender, EventArgs e)
        {
            fillKullanici();
        }
        int key = 0;
        private void KullaniciDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
        }

        

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (KullaniciDGV.SelectedRows.Count > 0)
            {
                int kullaniciId = Convert.ToInt32(KullaniciDGV.SelectedRows[0].Cells["KullaniciId"].Value);
            
                Kullanici k = new Kullanici();
                k.KullaniciAdi = txtAd.Text;
                k.KullaniciSifre = txtSifre.Text;
                k.Aktif = true;
                k.Silindi = false;
                k.OlusturmaTarihi = DateTime.Now;
                k.GuncellemeTarihi = DateTime.Now;
                KullaniciServis ks = new KullaniciServis();
                if (ks.KullaniciGuncelle(k)) 
                {
                    MessageBox.Show("Kullanıcı durumu başarıyla güncellendi.");
                    BtnKullanicilariListele_Click(null, null); 
                }
                else
                {
                    MessageBox.Show("Kullanıcı durumu güncellenemedi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (KullaniciDGV.SelectedRows.Count > 0)
            {
                int kullaniciId = Convert.ToInt32(KullaniciDGV.SelectedRows[0].Cells["KullaniciId"].Value);

                KullaniciServis ks = new KullaniciServis();
                if (ks.KullaniciSil(kullaniciId)) 
                {
                    MessageBox.Show("Kullanıcı başarıyla silindi.");
                   BtnKullanicilariListele_Click(null, null); 
                }
                else
                {
                    MessageBox.Show("Kullanıcı silinemedi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }
        }

        private void BtnKullanicilariListele_Click(object sender, EventArgs e)
        {
            fillKullanici();
        }
        private void fillKullanici()
        {
            KullaniciServis ks = new KullaniciServis();
            DataTable dt = ks.KullanicilariGetir().Tables[0];
            KullaniciDGV.DataSource = dt;
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            if (KullaniciDGV.SelectedRows.Count > 0)
            {
                int kullaniciId = Convert.ToInt32(KullaniciDGV.SelectedRows[0].Cells["KullaniciId"].Value);
            
                Kullanici k = new Kullanici();
                k.KullaniciAdi = txtAd.Text;
                k.KullaniciSifre = txtSifre.Text;
                k.Aktif = true;
                k.Silindi = false;
                k.OlusturmaTarihi = DateTime.Now;
                k.GuncellemeTarihi = DateTime.Now;
                KullaniciServis ks = new KullaniciServis();
                if (ks.KullaniciEkle(k))
                {
                    MessageBox.Show("Kullanıcı eklendi.");
                    BtnKullanicilariListele_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Kullanıcı hata oldu eklenmedi.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir kullanıcı seçin.");
            }
        }

        private void KullaniciDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
  
        }

        private void KullaniciDGV_Click(object sender, EventArgs e)
        {
            txtAd.Text = KullaniciDGV.SelectedRows[0].Cells["KullaniciAdi"].Value.ToString();
            txtSifre.Text = KullaniciDGV.SelectedRows[0].Cells["KullaniciSifre"].Value.ToString();
        }

        private void AraTB_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
        private void filter()
        {

            KullaniciServis ks = new KullaniciServis();
            DataSet ds = ks.KullaniciAra(AraTB.Text);
            KullaniciDGV.DataSource = ds.Tables[0];
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {
            FormHasta hst = new FormHasta();
            hst.Show();
            this.Hide();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {

            FormRandevu rnd = new FormRandevu();
            rnd.Show();
            this.Hide();
        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {

            FormTedavi tdv = new FormTedavi();
            tdv.Show();
            this.Hide();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            FormRecete rctlr = new FormRecete();
            rctlr.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            HastaGiris ana = new HastaGiris();
            ana.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            KullaniciServis ks = new KullaniciServis();
            DataSet ds = ks.KullanicilariGetir();
            KullaniciDGV.DataSource = ds.Tables[0];
        }
    }
}
