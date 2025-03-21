using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.Model
{
   public class Recete
    {
        public int ReceteId { get; set; }
        public int HastaId { get; set; }
        public int IlacId { get; set; }
        public int IlacMiktar { get; set; }
        public bool Aktif { get; set; }
        public bool Silindi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }

        
    }
}
