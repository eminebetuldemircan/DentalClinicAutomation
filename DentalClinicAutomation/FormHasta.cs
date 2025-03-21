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
    public partial class FormHasta : Form
    {
        public FormHasta()
        {
            InitializeComponent();
        }
        private void Hasta_Load(object sender, EventArgs e)
        {
            HastalariYenile();
            Reset();
        }
        int key = 0;
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Hasta h = new Hasta();
            h.HastaAdi = TxtAdiSoyadi.Text;
            h.HastaTelefon = TxtHTelefon.Text;
            h.HastaAdres = TxtAdres.Text;
            h.HastaDogumTarihi = CbDogumTarihi.Value.Date;
            h.HastaCinsiyetId = CbCinsiyet.SelectedIndex;
            h.AlerjiId = CbAlerji.SelectedIndex;
            long.TryParse(TxtTCkimlikNo.Text, out long result);
            h.HastaTcKimlikNo = result;
            h.Aktif = true;
            h.Silindi = false;
            h.OlusturmaTarihi = DateTime.Now;
            h.GuncellemeTarihi = DateTime.Now;

            HastaServis hs = new HastaServis();
            if (hs.HastaEkle(h))
            {
                HastalariYenile();
                MessageBox.Show("Hasta Başarıyla Kaydedildi.");
            }
            else
            {
                MessageBox.Show("Hata Oldu, Hasta Kaydedilemedi.");
            }


        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void HastalariYenile()
        {
            HastaServis hs = new HastaServis();
            DataSet ds = hs.HastalariGetir();
            HastaDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            HastaServis hs = new HastaServis();
            DataSet ds = hs.HastaAra(AraTb.Text);
            HastaDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            TxtAdiSoyadi.Text = "";
            TxtTCkimlikNo.Text = "";
            TxtHTelefon.Text = "";
            TxtAdres.Text = "";
            CbDogumTarihi.Text = "";

            key = 0;
        }
        private void HastaDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtAdiSoyadi.Text = HastaDGV.SelectedRows[0].Cells["HastaAdi"].Value.ToString();
            TxtTCkimlikNo.Text = HastaDGV.SelectedRows[0].Cells["HastaTcKimlikNo"].Value.ToString();
            TxtHTelefon.Text = HastaDGV.SelectedRows[0].Cells["HastaTelefon"].Value.ToString();
            TxtAdres.Text = HastaDGV.SelectedRows[0].Cells["HastaAdres"].Value.ToString();
            CbDogumTarihi.Value = DateTime.Parse(HastaDGV.SelectedRows[0].Cells["HastaDogumTarihi"].Value.ToString());
            CbCinsiyet.SelectedItem = HastaDGV.SelectedRows[0].Cells["HastaCinsiyetId"].Value.ToString();
            CbAlerji.SelectedItem = HastaDGV.SelectedRows[0].Cells["AlerjiId"].Value.ToString();
            if (TxtAdiSoyadi.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HastaDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Lütfen silinecek bir hasta seçin.");
                return;
            }

            HastaServis hs = new HastaServis();
            if (hs.Hastasil(key))
            {
                MessageBox.Show("Hasta başarıyla silindi.");
                HastalariYenile();
                Reset();
            }
            else
            {
                MessageBox.Show("Hata oluştu, hasta silinemedi.");
            }
        }
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Lütfen güncellenecek bir hasta seçin.");
                return;
            }

            Hasta h = new Hasta
            {
                HastaId = key,
                HastaAdi = TxtAdiSoyadi.Text,
                HastaTelefon = TxtHTelefon.Text,
                HastaAdres = TxtAdres.Text,
                HastaDogumTarihi = CbDogumTarihi.Value.Date,
                HastaCinsiyetId = CbCinsiyet.SelectedIndex,
                AlerjiId = CbAlerji.SelectedIndex,
                Aktif = true,
                Silindi = false,
                GuncellemeTarihi = DateTime.Now
            };

            long.TryParse(TxtTCkimlikNo.Text, out long tcKimlikNo);
            h.HastaTcKimlikNo = tcKimlikNo;

            HastaServis hs = new HastaServis();
            if (hs.HastaGuncelle(h))
            {
                MessageBox.Show("Hasta başarıyla güncellendi.");
                HastalariYenile();
                Reset();
            }
            else
            {
                MessageBox.Show("Hata oluştu, hasta güncellenemedi.");
            }

        }

        private void HCinsiyetCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            HastaGiris ana = new HastaGiris();
            ana.Show();
            this.Hide();
        }

        private void AraTb_TextChanged(object sender, EventArgs e)
        {
            filter();
        }



        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            FormRecete rctlr = new FormRecete();
            rctlr.Show();
            this.Hide();
        }

        private void guna2GradientButton8_Click(object sender, EventArgs e)
        {
            FormRandevu rnd = new FormRandevu();
            rnd.Show();
            this.Hide();
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            FormKullanici kkayit = new FormKullanici();
            kkayit.Show();
            this.Hide();
        }

        private void guna2GradientButton10_Click_1(object sender, EventArgs e)
        {
            FormKullanici kkayit = new FormKullanici();
            kkayit.Show();
            this.Hide();
        }

        private void guna2GradientButton9_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton7_Click(object sender, EventArgs e)
        {

            FormTedavi tdv = new FormTedavi();
            tdv.Show();
            this.Hide();
        }

        private void HastaDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            HastalariYenile();
        }

        private void CbAlerji_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
    

