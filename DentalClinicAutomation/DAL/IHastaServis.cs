using DentalClinicAutomation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.DAL
{
    public interface IHastaServis
    {
        bool HastaEkle (Hasta _hasta);
        DataSet HastaGetir(int _hastaId);
        DataSet HastalariGetir();
        bool Hastasil(int _hastaId);
        bool HastaGuncelle(Hasta _hasta);

        DataSet HastaAra(string HastaAdi);
    }
}
