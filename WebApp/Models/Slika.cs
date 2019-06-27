using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Slika
    {
        [Key]
        public int Id { get; set; }

        public string ImageUrl { get; set; }
        public string Korisnik { get; set; }

        public Slika() { }
    }
}