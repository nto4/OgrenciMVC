using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace OgrenciMVC.Models
{
    public class OgrModel : Entity
    {
        //cons
        //public int Id { get; set; }
        [MaxLength(15)]
        public string Ad { get; set; }
        [MaxLength(15)]
        public string Soyad { get; set; }

        [MaxLength(11)]
        public string Tc { get; set; }
    }
}