using System;
using System.Data;
using System.Data.SqlClient;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    public class TedaviServis : ITedaviServis
    {
        SqlConnection _baglanti = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DentalDb"].ToString());

        public bool TedaviEkle(Tedavi _tedavi)
        {
            string query = @"INSERT INTO TedaviTbl 
                             (TedaviAdi, TedaviUcret, TedaviAciklama, Aktif, Silindi, OlusturmaTarihi, GuncellemeTarihi) 
                             VALUES 
                             (@TedaviAdi, @TedaviUcret, @TedaviAciklama, @Aktif, @Silindi, @OlusturmaTarihi, @GuncellemeTarihi)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                  
                    command.Parameters.AddWithValue("@TedaviAdi", _tedavi.TedaviAdi);
                    command.Parameters.AddWithValue("@TedaviUcret", _tedavi.TedaviUcret);
                    command.Parameters.AddWithValue("@TedaviAciklama", _tedavi.TedaviAciklama);
                    command.Parameters.AddWithValue("@Aktif", _tedavi.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _tedavi.Silindi);
                    command.Parameters.AddWithValue("@OlusturmaTarihi", _tedavi.OlusturmaTarihi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _tedavi.GuncellemeTarihi);
                    
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
        
        public DataSet TedaviGetir(int _TedaviId)
        {
            string query = "SELECT * FROM TedaviTbl WHERE TedaviId = @TedaviId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@RandevuId", _TedaviId);

                    _baglanti.Open();


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
        public DataSet TedavileriGetir()
        {
            string query = "SELECT * FROM TedaviTbl WHERE Aktif=1 and Silindi=0";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    

                    _baglanti.Open();


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
        public bool TedaviSil(int _TedaviId)
        {
             string query = "UPDATE  TedaviTbl SET Silindi = 1, GuncellemeTarihi = getdate() Where TedaviId = @TedaviId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@TedaviId", _TedaviId);

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
        
        public bool TedaviGuncelle(Tedavi _tedavi)
        {
            string query = @"UPDATE TedaviTbl 
                             SET   TedaviAdi = @TedaviAdi,   TedaviAciklama = @TedaviAciklama,
                                  TedaviUcret = @TedaviUcret , Aktif = @Aktif,
                                Silindi = @Silindi, GuncellemeTarihi = @GuncellemeTarihi 
                             WHERE TedaviId = @TedaviId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                   
                    command.Parameters.AddWithValue("@TedaviAdi", _tedavi.TedaviAdi);
                    command.Parameters.AddWithValue("@TedaviAciklama", _tedavi.TedaviAciklama);
                    command.Parameters.AddWithValue("@TedaviUcret", _tedavi.TedaviUcret);
                    command.Parameters.AddWithValue("@Aktif", _tedavi.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _tedavi.Silindi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _tedavi.GuncellemeTarihi);
                    command.Parameters.AddWithValue("@TedaviId", _tedavi.TedaviId);
                    
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
        public DataSet TedaviAra(string _tedaviAdi)
        {
            string query = "SELECT * FROM TedaviTbl  WHERE TedaviAdi Like '%'+@TedaviAdi+'%'";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@TedaviAdi", _tedaviAdi);
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
