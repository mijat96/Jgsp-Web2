using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Linija
    {
        public int Id { get; set; }
        public int RedniBroj { get; set; }
        public ICollection<Stanica> Stanice { get; set; }
        public ICollection<RedVoznje> RedoviVoznje { get; set; }
        public ICollection<Vozilo> Vozila { get; set; }

        public Linija() { }
    }
}