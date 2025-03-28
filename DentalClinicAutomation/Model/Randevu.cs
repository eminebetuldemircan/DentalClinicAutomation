﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.Model
{
   public class Randevu
    {
        public int RandevuId { get; set; }

        public int KullaniciId { get; set; }

        public int HastaId { get; set; }
        public DateTime RandevuTarih { get; set; }
        public string RandevuSaati { get; set; }
        public bool Aktif { get; set; }
        public bool Silindi { get; set; }
        public DateTime OlusturmaTarihi { get; set; }
        public DateTime GuncellemeTarihi{ get; set; }
    }
}
