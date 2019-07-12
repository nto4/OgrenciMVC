using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using OgrenciMVC.Models;
namespace OgrenciMVC.Repository
{
    public interface IRepostory<T> where T :Entity
    {
        //create substruc
        IEnumerable<T> GetAll();
        T GetbyId(int Id);
        void Delete(int Id);
        void Edit(T ogrenci);
        void Insert(T ogrenci);
    }
    
}