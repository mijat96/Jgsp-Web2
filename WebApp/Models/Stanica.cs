using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Stanica
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }

        public string Adresa { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ICollection<Linija> Linije { get; set; }
    }
}