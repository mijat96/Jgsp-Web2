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
        public double X { get; set; }
        public double Y { get; set; }

        public virtual ICollection<Linija> Linije { get; set; }
    }
}