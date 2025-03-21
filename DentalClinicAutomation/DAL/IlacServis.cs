using System;
using System.Data;
using System.Data.SqlClient;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    public class IlacServis : IIlacServis
    {
        SqlConnection _baglanti = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DentalDb"].ToString());

        public bool IlacEkle(Ilac _Ilac)
        {
            string query = @"INSERT INTO IlacTbl 
                             (IlacAdi,  IlacAciklama, Aktif, Silindi, OlusturmaTarihi, GuncellemeTarihi) 
                             VALUES 
                             (@IlacAdi,  @IlacAciklama, @Aktif, @Silindi, @OlusturmaTarihi, @GuncellemeTarihi)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                  
                    command.Parameters.AddWithValue("@IlacAdi", _Ilac.IlacAdi);

                    command.Parameters.AddWithValue("@IlacAciklama", _Ilac.IlacAciklama);
                    command.Parameters.AddWithValue("@Aktif", _Ilac.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _Ilac.Silindi);
                    command.Parameters.AddWithValue("@OlusturmaTarihi", _Ilac.OlusturmaTarihi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _Ilac.GuncellemeTarihi);
                    
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
        
        public DataSet IlacGetir(int _IlacId)
        {
            string query = "SELECT * FROM IlacTbl WHERE IlacId = @IlacId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@IlacId", _IlacId);

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
        public DataSet IlaclariGetir()
        {
            string query = "SELECT * FROM IlacTbl WHERE Aktif=1 and Silindi=0";

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
        public bool IlacSil(int _IlacId)
        {
            string query = "UPDATE  IlacTbl SET Silindi = 1, GüncellemeTarihi = getdate() Where IlacId = @IlacId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@IlacId", _IlacId);

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
        
        public bool IlacGuncelle(Ilac _Ilac)
        {
            string query = @"UPDATE IlacTbl 
                             SET   IlacAdi = @IlacAdi,   IlacAciklama = @IlacAciklama,
                                    Aktif = @Aktif,
                                Silindi = @Silindi, GuncellemeTarihi = @GuncellemeTarihi 
                             WHERE IlacId = @IlacId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                   
                    command.Parameters.AddWithValue("@IlacAdi", _Ilac.IlacAdi);
                    command.Parameters.AddWithValue("@IlacAciklama", _Ilac.IlacAciklama);
                 
                    command.Parameters.AddWithValue("@Aktif", _Ilac.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _Ilac.Silindi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _Ilac.GuncellemeTarihi);
                    command.Parameters.AddWithValue("@IlacId", _Ilac.IlacId);
                    
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
        public DataSet IlacAra(string _IlacAdi)
        {
            string query = "SELECT * FROM IlacTbl  WHERE IlacAdi Like '%'+@IlacAdi+'%'";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@IlacAdi", _IlacAdi);
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
