using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.Model
{
    public class Tedavi
    {
        public int TedaviId { get; set; }
        public string TedaviAdi { get; set; }
        public decimal TedaviUcret { get; set; }
        public string TedaviAciklama { get; set; }
        public bool Aktif { get; set; }
        public bool Silindi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
    }
}
