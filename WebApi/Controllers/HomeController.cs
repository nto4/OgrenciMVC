using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OgrenciMVC.Models;
using OgrenciMVC.Repository;


namespace WebApi.Controllers
{
    public class HomeController : ApiController
    {
        // IRepostory<OgrModel> _Repostory = new OgrRepostory();
        // GET: api/Home
       readonly IRepostory<OgrModel> _Repostory;
        public HomeController(IRepostory<OgrModel> ogrenci)
        {
            //_Repostory = new OgrRepostory();

            _Repostory = ogrenci;
        }
        public IEnumerable<OgrModel> Get()
        {
            return _Repostory.GetAll();
        }

        // GET: api/Home/5
        public OgrModel Get(int id)
        {
            return _Repostory.GetbyId(id);
        }

        // POST: api/Home
        public bool Post([FromBody]OgrModel ogrenci)
        {
            if (ModelState.IsValid)
            {
                _Repostory.Insert(ogrenci);
                return true;
            }
            else
            {
                return false;
                throw new HttpResponseException(HttpStatusCode.BadRequest);// how return status cood with booleans 
                
            }
            /*
            try
            {
                _Repostory.Insert(ogrenci);
                return true;
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);

                return false;
            }
            */
       
            
        }

        // PUT: api/Home/5
        public void Put([FromBody]OgrModel ogrenci)
        {
            _Repostory.Edit(ogrenci);
        }

        // DELETE: api/Home/5
        public void Delete(int id)
        {
            _Repostory.Delete(id);
        }
    }
}
