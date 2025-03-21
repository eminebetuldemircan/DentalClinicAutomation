using DentalClinicAutomation.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentalClinicAutomation.DAL
{
    public interface IKullaniciServis
    {
        bool KullaniciEkle(Kullanici _k);
        DataSet KullaniciGetir(int _KId);
        DataSet KullanicilariGetir();
        bool KullaniciSil(int _KId);
        bool KullaniciGuncelle(Kullanici _k);
        bool KullaniciDogrula(string _kullaniciAdi,String _kullaniciSifre);
        DataSet KullaniciAra(string KullaniciAdi);

    }
}
