using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace MinApi
{
    public class Marka
    {
        public int marka_id { get; set; }
        public string? ad { get; set; } // Nullable property

        private SqlConnection baglantiAc()
        {
            string connectionString = "Data Source=DESKTOP-DURN6GF\\SQLEXPRESS;Initial Catalog=denemeDb;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public int kaydet()
        {
            try
            {
                using (SqlConnection conn = baglantiAc())
                {
                    string sql = "insert into markaa(ad) values(@a)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@a", this.ad ?? (object)DBNull.Value);
                        int sonuc = cmd.ExecuteNonQuery();
                        return sonuc;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi (loglama vs.)
                throw new Exception("Veritabanına kaydedilirken hata oluştu: " + ex.Message);
            }
        }

        public Marka? getmarkaById(int id)
        {
            try
            {
                using (SqlConnection conn = baglantiAc())
                {
                    string sql = "select * from markaa where marka_id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                Marka marka = new Marka
                                {
                                    marka_id = int.Parse(dr["marka_id"].ToString() ?? "0"),
                                    ad = dr["ad"]?.ToString()
                                };
                                return marka;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi (loglama vs.)
                throw new Exception("Veritabanından veri getirilirken hata oluştu: " + ex.Message);
            }
        }

        public int guncelle()
        {
            try
            {
                using (SqlConnection conn = baglantiAc())
                {
                    string sql = "update markaa set ad=@a where marka_id=@m";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@m", this.marka_id);
                        cmd.Parameters.AddWithValue("@a", this.ad ?? (object)DBNull.Value);
                        int sonuc = cmd.ExecuteNonQuery();
                        return sonuc;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi (loglama vs.)
                throw new Exception("Veritabanında güncelleme yapılırken hata oluştu: " + ex.Message);
            }
        }

        public Marka[] genel_liste()
        {
            try
            {
                using (SqlConnection conn = baglantiAc())
                {
                    string sql = "select * from markaa";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        List<Marka> liste = new List<Marka>();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                Marka marka = new Marka
                                {
                                    marka_id = int.Parse(dr["marka_id"].ToString() ?? "0"),
                                    ad = dr["ad"]?.ToString()
                                };
                                liste.Add(marka);
                            }
                        }
                        return liste.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi (loglama vs.)
                throw new Exception("Veritabanından genel liste getirilirken hata oluştu: " + ex.Message);
            }
        }

        public int sil()
        {
            try
            {
                using (SqlConnection conn = baglantiAc())
                {
                    string sql = "delete from markaa where marka_id = @id";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", this.marka_id);
                        int sonuc = cmd.ExecuteNonQuery();
                        return sonuc;
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi (loglama vs.)
                throw new Exception("Veritabanından silme yapılırken hata oluştu: " + ex.Message);
            }
        }
    }
}
