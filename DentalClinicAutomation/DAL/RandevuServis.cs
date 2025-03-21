using System;
using System.Data;
using System.Data.SqlClient;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    public class RandevuServis : IRandevuServis
    {
        SqlConnection _baglanti = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DentalDb"].ToString());

        public bool RandevuEkle(Randevu _r)
        {
            string query = @"INSERT INTO RandevuTbl 
                             (KullaniciID,HastaId, RandevuTarih, RandevuSaati, Aktif, Silindi, OlusturmaTarihi, GuncellemeTarihi) 
                             VALUES 
                             (@KullaniciId,@HastaId, @RandevuTarih, @RandevuSaati, @Aktif, @Silindi, @OlusturmaTarihi, @GuncellemeTarihi)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaId", _r.HastaId);
                    command.Parameters.AddWithValue("@KullaniciId", _r.KullaniciId);
                    command.Parameters.AddWithValue("@RandevuTarih", _r.RandevuTarih);
                    command.Parameters.AddWithValue("@RandevuSaati", _r.RandevuSaati);
                    command.Parameters.AddWithValue("@Aktif", _r.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _r.Silindi);
                    command.Parameters.AddWithValue("@OlusturmaTarihi", _r.OlusturmaTarihi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _r.GuncellemeTarihi);

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

        public DataSet RandevuGetir(int _randevuId)
        {
            string query = "SELECT * FROM RandevuTbl WHERE RandevuId = @RandevuId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@RandevuId", _randevuId);

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

        public DataSet RandevulariGetir()
        {
            string query = "SELECT * FROM RandevuTbl Where Aktif=1 and Silindi=0";

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

        public bool RanndevuSil(int _randevuId)
        {
            string query = "Update RandevuTbl set Silindi=1, GuncellemeTarihi=getdate()  WHERE RandevuId = @RandevuId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@RandevuId", _randevuId);

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


        public bool RandevuGuncelle(Randevu _r)
        {
            string query = @"UPDATE RandevuTbl 
                             SET HastaId = @HastaId, RandevuTarih = @RandevuTarih, 
                                 RandevuSaati = @RandevuSaati, Aktif = @Aktif, 
                                 Silindi = @Silindi, GuncellemeTarihi = @GuncellemeTarihi 
                             WHERE RandevuId = @RandevuId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaId", _r.HastaId);
                    command.Parameters.AddWithValue("@RandevuTarih", _r.RandevuTarih);
                    command.Parameters.AddWithValue("@RandevuSaati", _r.RandevuSaati);
                    command.Parameters.AddWithValue("@Aktif", _r.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _r.Silindi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _r.GuncellemeTarihi);
                    command.Parameters.AddWithValue("@RandevuId", _r.RandevuId);

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

        public DataSet RandevuAra(string HastaAdi)
        {
            string query = "SELECT * FROM RandevuTbl WHERE HastaAdi Like '%'+@HastaAdi+'%'";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaAdi", HastaAdi);
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
        public DataSet RandevuAra(DateTime RandevuTarih)
        {
            string query = "SELECT * FROM RandevuTbl WHERE RandevuTarih =@RandevuTarih and Aktif=1 and Silindi=0";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@RandevuTarih", RandevuTarih);
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