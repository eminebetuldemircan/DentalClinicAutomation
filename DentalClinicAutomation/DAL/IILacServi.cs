using DentalClinicAutomation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    interface IIlacServis
    {
        bool IlacEkle(Ilac _i);
        DataSet IlacGetir(int _IlacId);
        DataSet IlaclariGetir();
        bool IlacSil(int _IlacId);
        bool IlacGuncelle(Ilac _i);

    }
}
