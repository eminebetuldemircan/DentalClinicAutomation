using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    public interface IReceteServis
    {
        bool ReceteEkle(Recete _recete);
        DataSet ReceteGetir(int _ReceteId);
        DataSet ReceteleriGetir();
        bool Recetesil(int _ReceteId);
        bool ReceteGuncelle(Recete _recete);
        DataSet ReceteAra(string HastaAdi);
    }
}
