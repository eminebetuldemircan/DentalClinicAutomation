using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.Model
{
   public class Hasta
    {
        public int HastaId { get; set; }
        public string HastaAdi { get; set; }
        public string HastaTelefon { get; set; }
        public string HastaAdres { get; set; }
        public DateTime HastaDogumTarihi { get; set; }
        public int HastaCinsiyetId { get; set; }
        public int AlerjiId { get; set; }
        public long HastaTcKimlikNo { get; set; }
        public bool Aktif { get; set; }
        public bool Silindi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public int Id { get; internal set; }
    }
}
