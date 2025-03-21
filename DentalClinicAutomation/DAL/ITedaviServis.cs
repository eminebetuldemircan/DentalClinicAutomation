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
    interface ITedaviServis
    {
        bool TedaviEkle(Tedavi _t);
        DataSet TedaviGetir(int _TedaviId);
        DataSet TedavileriGetir();
        bool TedaviSil(int _TedaviId);
        bool TedaviGuncelle(Tedavi _t);
        DataSet TedaviAra(string _tedaviAdi);
    }
}
