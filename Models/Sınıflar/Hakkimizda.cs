using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelProject.Models.Sınıflar
{
    public class Hakkimizda
    {
        [Key]
        public int ID { get; set; }
        public string Aciklama { get; set; }
        public string ImageUrl { get; set; }
    }
}