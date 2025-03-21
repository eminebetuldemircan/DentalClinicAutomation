using System;
using System.Data;
using System.Data.SqlClient;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    public class KullaniciServis : IKullaniciServis
    {

        SqlConnection _baglanti = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DentalDb"].ToString());

        public bool KullaniciEkle(Kullanici _k)
        {
            string query = @"INSERT INTO KullaniciTbl 
                             (KullaniciAdi, KullaniciSifre, Aktif, Silindi, OlusturmaTarihi, GuncellemeTarihi) 
                             VALUES 
                             (@KullaniciAdi, @KullaniciSifre, @Aktif, @Silindi, @OlusturmaTarihi, @GuncellemeTarihi)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", _k.KullaniciAdi);
                    command.Parameters.AddWithValue("@KullaniciSifre", _k.KullaniciSifre);
                    command.Parameters.AddWithValue("@Aktif", _k.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _k.Silindi);
                    command.Parameters.AddWithValue("@OlusturmaTarihi", _k.OlusturmaTarihi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _k.GuncellemeTarihi);
                    
                    _baglanti.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                _baglanti.Close();
            }
        }


        public DataSet KullaniciGetir(int _KId)
        {
            string query = "SELECT * FROM KullaniciTbl WHERE KullaniciId = @KullaniciId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@KullaniciId", _KId);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    return ds;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return null;
            }
            finally
            {
                _baglanti.Close();
            }
        }

        public DataSet KullanicilariGetir()
        {
            string query = "SELECT * FROM KullaniciTbl Where Aktif=1 and Silindi=0";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataSet dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return null;
            }
        }
        
        public bool KullaniciSil(int _KId)
        {
            string query = "Update  KullaniciTbl set Silindi=1, GuncellemeTarihi=getdate()  WHERE KullaniciId = @KullaniciId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@KullaniciId", _KId);

                    _baglanti.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                _baglanti.Close();
            }
        }

        public bool KullaniciGuncelle(Kullanici _k)
        {
            string query = @"UPDATE KullaniciTbl 
                             SET KullaniciAdi = @KullaniciAdi, Sifre = @Sifre,  
                                 Aktif = @Aktif, Silindi = @Silindi, GuncellemeTarihi = @GuncellemeTarihi 
                             WHERE KullaniciId = @KullaniciId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", _k.KullaniciAdi);
                    command.Parameters.AddWithValue("@Aktif", _k.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _k.Silindi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _k.GuncellemeTarihi);
                    command.Parameters.AddWithValue("@KullaniciId", _k.KullaniciId);

                    _baglanti.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                _baglanti.Close();
            }
        }

        public bool KullaniciDogrula(string _kullaniciAdi, string _kullaniciSifre)
        {
            string query = "SELECT * FROM KullaniciTbl WHERE KullaniciAdi = @KullaniciAdi and KullaniciSifre=@KullaniciSifre ";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", _kullaniciAdi);
                    command.Parameters.AddWithValue("@KullaniciSifre", _kullaniciSifre);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
            finally
            {
                _baglanti.Close();
            }
        }
        public DataSet KullaniciAra(string KullaniciAdi)
        {
            string query = "SELECT * FROM KullaniciTbl WHERE KullaniciAdi Like '%'+@KullaniciAdi+'%'";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi);
                    SqlDataAdapter sda = new SqlDataAdapter(command);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);

                    return ds;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return null;
            }
            finally
            {
                _baglanti.Close();
            }
        }
    }
}
