using DentalClinicAutomation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.DAL
{
   public  interface IRandevuServis  
    {
        bool RandevuEkle(Randevu _r);
        DataSet RandevuGetir(int _randevuId);
        DataSet RandevulariGetir();
        bool RanndevuSil(int _randevuId);
        bool RandevuGuncelle(Randevu _r);
        DataSet RandevuAra(string HastaAdi);
        DataSet RandevuAra(DateTime tarih);

    }
}
