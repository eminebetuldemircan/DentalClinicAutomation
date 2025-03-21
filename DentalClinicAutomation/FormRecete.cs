using DentalClinicAutomation.DAL;
using DentalClinicAutomation.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalClinicAutomation
{
    public partial class FormRecete : Form
    {
        public FormRecete()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void ReceteleriYenile()
        {
            ReceteServis rs = new ReceteServis();
            DataSet ds = rs.ReceteleriGetir();
            if (ds!=null)
            {
                ReceteDGV.DataSource = ds.Tables[0];
            }
            
        }
        private void fillHasta()
        {
            HastaServis hs = new HastaServis();
            DataSet ds = hs.HastalariGetir();
  
            DataTable dt = ds.Tables[0];
            CbHasta.ValueMember = "HastaAdi";
            CbHasta.ValueMember = "HastaId";
            CbHasta.DataSource = dt;
      
        }
        private void fillIlac()
        {
            IlacServis ilacs = new IlacServis();
            DataSet ds = ilacs.IlaclariGetir();

            DataTable dt = ds.Tables[0];
            CbIlac.DisplayMember = "IlacAdi";
            CbIlac.ValueMember = "IlacId";
            CbIlac.DataSource = dt;

        }
        private void Receteler_Load(object sender, EventArgs e)
        {

            fillHasta();
            fillIlac();
            ReceteleriYenile(); 
            Reset(); 
        }

        private void HastaAdSoyadCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }
        void filter()
        {
            ReceteServis rs = new ReceteServis();
            DataSet ds = rs.ReceteAra(AraTB.Text);
            ReceteDGV.DataSource = ds.Tables[0];
        }
        void Reset()
        {
            CbHasta.SelectedItem = "";
            CbIlac.SelectedItem = "";
            MiktarTb.Text = "";
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            ReceteServis rs = new ReceteServis();
            Recete r = new Recete();
            r.HastaId = (int)CbHasta.SelectedValue;
            r.IlacId = (int)CbIlac.SelectedValue;
            r.IlacMiktar = int.Parse(MiktarTb.Text);
            r.Aktif = true;
            r.Silindi = false;
            r.OlusturmaTarihi = DateTime.Now;
            r.GuncellemeTarihi = DateTime.Now;

            try
            {
                if (rs.ReceteEkle(r))
                {


                    MessageBox.Show("Recete Başarıyla Eklendi");
                    ReceteleriYenile();
                    Reset();
                }
                else
                {
                    MessageBox.Show("Recete Hatalı Eklenmedi");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {
            HastaGiris ana = new HastaGiris();
            ana.Show();
            this.Hide();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        int key = 0;
        private Bitmap bitmap;

        private void RecetelerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CbHasta.SelectedItem = ReceteDGV.SelectedRows[0].Cells[1].Value.ToString();
            
            CbIlac.SelectedItem = ReceteDGV.SelectedRows[0].Cells[2].Value.ToString();
            MiktarTb.Text = ReceteDGV.SelectedRows[0].Cells[3].Value.ToString();
            if (CbHasta.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(ReceteDGV.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
        
            if (key == 0)
            {
                MessageBox.Show("Silinecek Reçeteyi Seçiniz");
            }
            else
            {
                try
                {

                    ReceteServis rs = new ReceteServis();

                    if (rs.Recetesil(key))
                    {
                        MessageBox.Show("Recete Başarıyla Silindi");
                        ReceteleriYenile();
                        Reset();
                    }
                    else
                    {
                        MessageBox.Show("Recete Hatalı Silinemedi");
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }


        }

        private void AraTB_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            int height = ReceteDGV.Height;
            ReceteDGV.Height = ReceteDGV.RowCount * ReceteDGV.RowTemplate.Height * 2;
            bitmap = new Bitmap(ReceteDGV.Width, ReceteDGV.Height);
            ReceteDGV.DrawToBitmap(bitmap, new Rectangle(0, 10,ReceteDGV.Width, ReceteDGV.Height));
            ReceteDGV.Height = height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {

        }

        private void CbHasta_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            FormKullanici kKayit = new FormKullanici();
            kKayit.Show();
            this.Hide();
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {

        }

        private void MiktarTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            ReceteServis rs = new ReceteServis();
            DataSet ds = rs.ReceteleriGetir();
            ReceteDGV.DataSource = ds.Tables[0];
        }
    }
}
