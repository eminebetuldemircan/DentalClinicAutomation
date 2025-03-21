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
using DentalClinicAutomation.Model;
using DentalClinicAutomation.DAL;

namespace DentalClinicAutomation
{
    public partial class FormRandevu : Form
    {
        public FormRandevu()
        {
            InitializeComponent();
        }
    

        private void fillHasta()
        {
            HastaServis hs = new HastaServis();
            DataSet ds =hs.HastalariGetir();
            CbHasta.DisplayMember = "HastaAdi";
            CbHasta.ValueMember = "HastaId";
         
            CbHasta.DataSource = ds.Tables[0];
      
        }

        private void fillDoktor()
        {
            KullaniciServis ks = new KullaniciServis();
            DataSet ds = ks.KullanicilariGetir();
            cbDoktor.DisplayMember = "KullaniciAdi";
            cbDoktor.ValueMember = "KullaniciId";
            cbDoktor.DataSource = ds.Tables[0];

        }

        private void Randevu_Load(object sender, EventArgs e)
        {
            fillHasta();
            fillDoktor();


            RandevulariYenile();
            Reset();
        }
        void RandevulariYenile()
        {
            RandevuServis rs = new RandevuServis();
            DataSet ds = rs.RandevulariGetir();
            RandevuDGV.DataSource = ds.Tables[0];
        }
        void filter()
        {
            RandevuServis rs = new RandevuServis();
            DataSet ds = rs.RandevuAra(ARATb.Text);
            RandevuDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            CbHasta.SelectedItem = -1;
            CbRandevuTarih.Text = "";
            CbRandevuSaatCb.Text = "";
        }
        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Randevu r =new Randevu();
            r.KullaniciId = (int)cbDoktor.SelectedValue;
            r.HastaId = (int)CbHasta.SelectedValue;
            r.RandevuTarih = CbRandevuTarih.Value.Date;
            r.RandevuSaati = CbRandevuSaatCb.Text; 
            r.Aktif = true;
            r.Silindi = false;
            r.OlusturmaTarihi = DateTime.Now;
            r.GuncellemeTarihi = DateTime.Now;
                    

        RandevuServis rs = new RandevuServis();
            if (rs.RandevuEkle(r))
            {
                RandevulariYenile();
                MessageBox.Show("Başarılı bir şekilde eklendi");
                


            }
            else
            {
                MessageBox.Show("Hata eklenmedi");
            }
        }

        int key = 0;
        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            Randevu r = new Randevu();
            r.RandevuId = key;
            r.HastaId = (int)CbHasta.SelectedValue;
            r.KullaniciId = (int)cbDoktor.SelectedValue;
            r.RandevuTarih = CbRandevuTarih.Value.Date;
            r.RandevuSaati = CbRandevuSaatCb.Text;
            r.Aktif = true;
            r.Silindi = false;
            r.OlusturmaTarihi = DateTime.Now;
            r.GuncellemeTarihi = DateTime.Now;


            RandevuServis rs = new RandevuServis();
            if (rs.RandevuGuncelle(r))
            {
                RandevulariYenile();
                MessageBox.Show("Başarılı bir şekilde güncellendi");
              

            }
            else
            {
                MessageBox.Show("Hata güncellenmedi");
            }

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            RandevuServis rs = new RandevuServis();
            if (rs.RanndevuSil(key))
            {
                MessageBox.Show("Başarılı bir şekilde Silindi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Hata Silinmedi","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
          RandevulariYenile();
                    Reset();
         
        }

        private void RandevuDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CbHasta.SelectedValue = RandevuDGV.SelectedRows[0].Cells["HastaId"].Value.ToString();
            CbRandevuTarih.Value = DateTime.Parse(RandevuDGV.SelectedRows[0].Cells["RandevuTarih"].Value.ToString());
            CbRandevuSaatCb.Text = RandevuDGV.SelectedRows[0].Cells["RandevuSaati"].Value.ToString();

            key = Convert.ToInt32(RandevuDGV.SelectedRows[0].Cells[0].Value.ToString());
   
        }
        

        private void panel1_Paint(object sender, PaintEventArgs e)
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

        private void guna2GradientButton9_Click_1(object sender, EventArgs e)
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
            FormTedavi TedaviKayit = new FormTedavi();
            TedaviKayit.Show();
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

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RandevuServis rs = new RandevuServis();
            DataSet ds = rs.RandevuAra(guna2DateTimePicker1.Value.Date);
            RandevuDGV.DataSource = ds.Tables[0];
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            RandevuServis rs = new RandevuServis();
            DataSet ds = rs.RandevulariGetir();
            RandevuDGV.DataSource = ds.Tables[0];
        }
    }
}
