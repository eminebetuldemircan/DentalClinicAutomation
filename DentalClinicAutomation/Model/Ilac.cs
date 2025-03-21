using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.Model
{
    public class Ilac
    {
        public int IlacId { get; set; }
        public string IlacAdi { get; set; }
      
        public string IlacAciklama { get; set; }
        public bool Aktif { get; set; }
        public bool Silindi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
    }
}
