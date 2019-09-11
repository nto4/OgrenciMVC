using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using OgrenciMVC.Models;
using OgrenciMVC.Repository;
using System.Net;
using System.Web.Http.Cors;

namespace OgrenciMVC.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        IRepostory<OgrModel>  _Repostory;
        public HomeController(IRepostory<OgrModel> ogrenci)
        {
            _Repostory = ogrenci;
        }
        // GET: Home
       // IRepostory<OgrModel> ogrRepository = new OgrRepostory();
        public ActionResult Index()
        {
            var ogrenciler = _Repostory.GetAll();
            return View(ogrenciler);
            /*

            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=1234"))
                //try
                {
                con.Open();
                var cmd = new MySqlCommand("SELECT * FROM ogrenciler", con);

                var reader = cmd.ExecuteReader();
                List<Models.OgrModel> ogrenciler = new List<OgrModel>();
                while (reader.Read())
                {
                    Models.OgrModel ogrenci = new OgrModel()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Ad = reader["Ad"].ToString(),
                        Soyad = reader["Soyad"].ToString(),
                        Tc = reader["Tc"].ToString()

                    };
                    ogrenciler.Add(ogrenci);
                }
              //  con.Close();//using default kapatıyor
                return View(ogrenciler);
           }
           // catch (Exception ex)
            //{
             //   Console.WriteLine(ex);
              //  con.Close();
              //  throw; //preserve stacktrace
           // }*/

        }
   
        public ActionResult Delete(int Id)
        {
            _Repostory.Delete(Id);
            return RedirectToAction("Index");
            /*
            using (var con = new MySqlConnection(myConnectionString))
            {
                con.Open();
                var cmd = new MySqlCommand("DELETE FROM ogrenciler WHERE Id = "+Id, con);
                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
            */
        }
        
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            else { 
                return View(_Repostory.GetbyId(Id??0));
                }
        }
        [HttpPost]
        public ActionResult Edit(OgrModel ogrenci)
        {
            _Repostory.Edit(ogrenci);
            return RedirectToAction("Index");

            /*
            if (ModelState.IsValid)
            {
                using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=1234"))
                {
                    con.Open();
                    var cmd = new MySqlCommand("UPDATE Ogrenciler SET Ad = @Ad, Soyad =  @Soyad, Tc= @Tc WHERE Id = @Id", con);
                    cmd.Parameters.AddWithValue("Id", ogrenci.Id);
                    cmd.Parameters.AddWithValue("Ad", ogrenci.Ad);
                    cmd.Parameters.AddWithValue("Soyad", ogrenci.Soyad);
                    cmd.Parameters.AddWithValue("Tc", ogrenci.Tc);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    return RedirectToAction("Index");
                }
            }

            return View(ogrenci);
            */
        }

        /*
        public ActionResult Insert()
        {
            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=1234"))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO Ogrenciler (Ad = @Ad, Soyad =  @Soyad, Tc= @Tc) VALUES Id = @Id", con);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("Ad", Ad);
                cmd.Parameters.AddWithValue("Soyad", Soyad);
                cmd.Parameters.AddWithValue("Tc", Tc);


                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
        }
        */

        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(OgrModel ogrenci)
        {
            _Repostory.Insert(ogrenci);
            return RedirectToAction("Index");

            /*
                        using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=1234"))
            {
                con.Open();
                var cmd = new MySqlCommand("INSERT INTO Ogrenciler (Ad , Soyad,Tc) VALUES (@Ad,  @Soyad, @Tc)", con);
               // cmd.Parameters.AddWithValue("Id", ogrenci.Id);
                cmd.Parameters.AddWithValue("Ad", ogrenci.Ad);
                cmd.Parameters.AddWithValue("Soyad", ogrenci.Soyad);
                cmd.Parameters.AddWithValue("Tc", ogrenci.Tc);


                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
                        */
        }
        /*
        public ActionResult Update(int Id, string Ad, string Soyad, string Tc)
        {
            using (var con = new MySqlConnection("datasource=localhost;port=3306;Database=ogrdb;username=root;password=1234"))
            {
                con.Open();
                var cmd = new MySqlCommand("UPDATE Ogrenciler SET Ad = @Ad, Soyad =  @Soyad, Tc= @Tc WHERE Id = @Id", con);
                cmd.Parameters.AddWithValue("Id", Id);
                cmd.Parameters.AddWithValue("Ad", Ad);
                cmd.Parameters.AddWithValue("Soyad", Soyad);
                cmd.Parameters.AddWithValue("Tc", Tc);


                cmd.ExecuteNonQuery();
                con.Close();
                return RedirectToAction("Index");
            }
        }
        */
    }
}

/*
 MySqlDataAdapter adapter = new MySqlDataAdapter();
 MySqlConnection con = new MySqlConnection();
 
 // GET: Movies1
 public ViewResult Random()
 {
 // var connectionString = ConfigurationManager.ConnectionStrings["mySql"].ConnectionString;
 // var con = new MySqlConnection(connectionString);
 con = new MySqlConnection("datasource=localhost;port=3306;username=root;password=12345678");
 adapter = new MySqlDataAdapter("SELECT * FROM moviestest.new_table", con);
 //DataTable table1 = new DataTable("TestTable");
 con.Open();
 var movie = new Movies();
 adapter.Fill(movie.Name);
 con.Close();
 return View(movie);
 }      
*/


/*
 using (var con = new MySqlConnection(connectionString))
    {
        List<Book> books = new List<Book>();
        con.Open();
        var command = new MySqlCommand("SELECT * FROM books", con);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            Book book = new Book()
            {
                Id = Convert.ToInt32(reader["id"]),
                Isbn = reader["isbn"].ToString(),
                Name = reader["name"].ToString(),
                Writer = reader["writer"].ToString(),
                Publisher = reader["publisher"].ToString(),
                CreatedAt = Convert.ToDateTime(reader["createdat"])
            };
            books.Add(book);
        }
        con.Close();
        return books;
    }


 */





