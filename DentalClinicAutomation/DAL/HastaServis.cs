using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    public class HastaServis : IHastaServis
    {
        SqlConnection _baglanti = new SqlConnection( System.Configuration.ConfigurationSettings.AppSettings["DentalDb"].ToString());

        public bool HastaEkle(Hasta _h)
        {
            string query = "insert into HastaTbl values(@HastaAdi, @HastaTelefon, @HastaAdres, @HastaDogumTarih, @HastaCinsiyetId, @AlerjiId, @HastaTcKimlikNo, @Aktif, @Silindi, @OlusturmaTarihi, @GuncellemeTarihi )";
            using (SqlConnection connection = _baglanti)
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@HastaAdi", _h.HastaAdi);
                    command.Parameters.AddWithValue("@HastaTelefon", _h.HastaTelefon);
                    command.Parameters.AddWithValue("@HastaAdres", _h.HastaAdres);
                    command.Parameters.AddWithValue("@HastaDogumTarih", _h.HastaDogumTarihi);
                    command.Parameters.AddWithValue("@HastaCinsiyetId", _h.HastaCinsiyetId);
                    command.Parameters.AddWithValue("@AlerjiId", _h.AlerjiId);
                    command.Parameters.AddWithValue("@HastaTcKimlikNo", _h.HastaTcKimlikNo);
                    command.Parameters.AddWithValue("@Aktif", _h.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _h.Silindi);
                    command.Parameters.AddWithValue("@OlusturmaTarihi", _h.OlusturmaTarihi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _h.GuncellemeTarihi);


                    connection.Open();
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }
        public DataSet HastaGetir(int _hastaId)
        {
            string query = "SELECT * FROM HastaTbl WHERE HataId=@HastaId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaId", _hastaId);
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

        public bool HastaGuncelle(Hasta _h)
        {
            string query = @"UPDATE HastaTbl 
                             SET HastaAdi = @HastaAdi, HastaTelefon = @HastaTelefon, HastaAdres = @HastaAdres, 
                                 HastaDogumTarihi = @HastaDogumTarihi, HastaCinsiyetId = @HastaCinsiyetId, 
                                 AlerjiId = @AlerjiId, HastaTcKimlikNo = @HastaTcKimlikNo, Aktif = @Aktif, 
                                 Silindi = @Silindi, GuncellemeTarihi = @GuncellemeTarihi
                             WHERE HastaId = @HastaId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaAdi", _h.HastaAdi);
                    command.Parameters.AddWithValue("@HastaTelefon", _h.HastaTelefon);
                    command.Parameters.AddWithValue("@HastaAdres", _h.HastaAdres);
                    command.Parameters.AddWithValue("@HastaDogumTarihi", _h.HastaDogumTarihi);
                    command.Parameters.AddWithValue("@HastaCinsiyetId", _h.HastaCinsiyetId);
                    command.Parameters.AddWithValue("@AlerjiId", _h.AlerjiId);
                    command.Parameters.AddWithValue("@HastaTcKimlikNo", _h.HastaTcKimlikNo);
                    command.Parameters.AddWithValue("@Aktif", _h.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _h.Silindi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _h.GuncellemeTarihi);
                    command.Parameters.AddWithValue("@HastaId", _h.HastaId);

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
        public bool Hastasil(int _hastaId)
        {
            string query = "Update  HastaTbl set Silindi=1, GuncellemeTarihi=getdate() WHERE HastaId = @HastaId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaId", _hastaId);

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
        public DataSet HastalariGetir()
        {
            string query = "SELECT * FROM HastaTbl WHERE Aktif=1 and Silindi=0";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {                   
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

        public DataSet HastaAra(string HastaAdi)
        {
            string query = "SELECT * FROM HastaTbl WHERE HastaAdi Like '%'+@HastaAdi+'%'";

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
    }
}

        
