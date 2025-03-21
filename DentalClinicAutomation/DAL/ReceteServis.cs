using System;
using System.Data;
using System.Data.SqlClient;
using DentalClinicAutomation.Model;

namespace DentalClinicAutomation.DAL
{
    public class ReceteServis : IReceteServis
    {
        SqlConnection _baglanti = new SqlConnection(System.Configuration.ConfigurationSettings.AppSettings["DentalDb"].ToString());

        public bool ReceteEkle(Recete _recete)
        {
            string query = @"INSERT INTO ReceteTbl 
                             (HastaId, IlacId, IlacMiktar, Aktif, Silindi, OlusturmaTarihi, GuncellemeTarihi) 
                             VALUES 
                             (@HastaId, @IlacId, @IlacMiktar, @Aktif, @Silindi, @OlusturmaTarihi, @GuncellemeTarihi)";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaId", _recete.HastaId);
                    command.Parameters.AddWithValue("@IlacId", _recete.IlacId);
                    command.Parameters.AddWithValue("@IlacMiktar", _recete.IlacMiktar);
                    command.Parameters.AddWithValue("@Aktif", _recete.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _recete.Silindi);
                    command.Parameters.AddWithValue("@OlusturmaTarihi", _recete.OlusturmaTarihi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _recete.GuncellemeTarihi);

                 
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
        
        public DataSet ReceteGetir(int _ReceteId)
        {
            string query = "SELECT * FROM ReceteTbl WHERE ReceteId = @ReceteId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@ReceteId", _ReceteId);

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
        
        public DataSet ReceteleriGetir()
        {
            string query = @"SELECT r.ReceteId, h.HastaAdi, i.IlacAdi, r.IlacMiktar, r.OlusturmaTarihi 
                     FROM ReceteTbl r
                     INNER JOIN HastaTbl h ON r.HastaId = h.HastaId
                     INNER JOIN IlacTbl i ON r.IlacId = i.IlacId
                     WHERE r.Aktif = 1 AND r.Silindi = 0";

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

        public bool Recetesil(int _ReceteId)
        {
            string query = "UPDATE  ReceteTbl set Silindi=1, GuncellemeTarihi=getdate()  WHERE ReceteId = @ReceteId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@ReceteId", _ReceteId);

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

        public bool ReceteGuncelle(Recete _recete)
        {
            string query = @"UPDATE ReceteTbl 
                             SET HastaId = @HastaId,  IlacId = @IlacId, 
                                 IlacMiktar = @IlacMiktar, Aktif = @Aktif, Silindi = @Silindi, 
                                 GuncellemeTarihi = @GuncellemeTarihi 
                             WHERE ReceteId = @ReceteId";

            try
            {
                using (SqlCommand command = new SqlCommand(query, _baglanti))
                {
                    command.Parameters.AddWithValue("@HastaId", _recete.HastaId);
                    command.Parameters.AddWithValue("@IlacId", _recete.IlacId);
                    command.Parameters.AddWithValue("@Ilaclar", _recete.IlacMiktar);
                    command.Parameters.AddWithValue("@Aktif", _recete.Aktif);
                    command.Parameters.AddWithValue("@Silindi", _recete.Silindi);
                    command.Parameters.AddWithValue("@GuncellemeTarihi", _recete.GuncellemeTarihi);
                    command.Parameters.AddWithValue("@ReceteId", _recete.ReceteId);

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

        public DataSet ReceteAra(string HastaAdi)
        {
            string query = @"SELECT r.ReceteId, h.HastaAdi, i.IlacAdi, r.IlacMiktar, r.OlusturmaTarihi
                     FROM ReceteTbl r
                     INNER JOIN HastaTbl h ON r.HastaId = h.HastaId
                     INNER JOIN IlacTbl i ON r.IlacId = i.IlacId
                     WHERE h.HastaAdi LIKE '%' + @HastaAdi + '%' AND r.Aktif = 1 AND r.Silindi = 0";

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
