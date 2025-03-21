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
    public partial class HastaGiris : Form
    {
        public HastaGiris()
        {
            InitializeComponent();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            FormRandevu rnd = new FormRandevu();
            rnd.Show();
            this.Hide();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            FormHasta hst = new FormHasta();
            hst.Show();
            this.Hide();
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            FormTedavi tdv = new FormTedavi();
            tdv.Show();
            this.Hide();
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            FormRecete rctlr = new FormRecete();
            rctlr.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            FrmKullaniciGiris frm = new FrmKullaniciGiris();
            frm.Show();
            this.Hide();
        }

        private void guna2GradientButton10_Click(object sender, EventArgs e)
        {
            FormKullanici kkayit = new FormKullanici();
            kkayit.Show();
            this.Hide();
        }
    }
}
