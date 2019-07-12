using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using OgrenciMVC.Models;
using System.Configuration;
using System.Web.Configuration;

namespace OgrenciMVC.Repository
{
    public class OgrRepostory : IRepostory<OgrModel>
    {
        /*
         repositoyry ler gelicek
             */
        public IEnumerable<OgrModel> GetAll()
        {
            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=123456789"))
            {//"datasource=localhost;port=3306;Database=ogrdb;username=root;password=123456789"
                //WebConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString 
                con.Open();
                var cmd = new MySqlCommand("SELECT * FROM ogrenciler ", con);

                var reader = cmd.ExecuteReader();
                List<OgrModel> ogrenciler = new List<OgrModel>();
                while (reader.Read())
                {
                    OgrModel ogrenci = new OgrModel()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString(),
                        Soyad = reader["Soyad"].ToString(),
                        Tc = reader["Tc"].ToString()

                    };
                    ogrenciler.Add(ogrenci);
                }
                con.Close();
                return ogrenciler;
            }
        }
        public OgrModel GetbyId(int Id)
        {
            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=123456789"))
            {
                con.Open();
                var cmd = new MySqlCommand("SELECT * FROM ogrenciler WHERE Id=" +Id, con);

                var reader = cmd.ExecuteReader();
                reader.Read(); 
                    OgrModel ogrenci = new OgrModel()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString(),
                        Soyad = reader["Soyad"].ToString(),
                        Tc = reader["Tc"].ToString()

                    };
                con.Close();
                return ogrenci;
            }
        }

        public void Delete(int Id)
        {
            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=123456789"))
            {
                con.Open();
                var cmd = new MySqlCommand("DELETE FROM ogrenciler WHERE Id = " + Id, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }

        }

        public void Insert(OgrModel ogrenci)
        {
            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=123456789"))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO Ogrenciler (Ad , Soyad,Tc) VALUES (@Ad,  @Soyad, @Tc)", con);
                // cmd.Parameters.AddWithValue("Id", ogrenci.Id);
                cmd.Parameters.AddWithValue("Ad", ogrenci.Ad);
                cmd.Parameters.AddWithValue("Soyad", ogrenci.Soyad);
                cmd.Parameters.AddWithValue("Tc", ogrenci.Tc);


                cmd.ExecuteNonQuery();
                con.Close();
                //return RedirectToAction("Index");
            }
        }




        
        public void
            Edit(OgrModel ogrenci)
        {
            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=123456789"))
                {
                    con.Open();
                    var cmd = new MySqlCommand("UPDATE Ogrenciler SET Ad = @Ad, Soyad =  @Soyad, Tc= @Tc WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("Id", ogrenci.Id);
                    cmd.Parameters.AddWithValue("Ad", ogrenci.Ad);
                    cmd.Parameters.AddWithValue("Soyad", ogrenci.Soyad);
                    cmd.Parameters.AddWithValue("Tc", ogrenci.Tc);


                    cmd.ExecuteNonQuery();
                    con.Close();
   
                }
        }
        
    }
}