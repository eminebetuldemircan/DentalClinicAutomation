using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.Model
{
    public class Kullanici
    {
        public int KullaniciId { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciSifre { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public bool Aktif { get; set; }
        public bool Silindi { get; set; }
    }
}
