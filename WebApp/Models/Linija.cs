using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Linija
    {
        public int Id { get; set; }
        public string RedniBroj { get; set; }
        public virtual ICollection<Stanica> Stanice { get; set; }
        public virtual ICollection<RedVoznje> RedoviVoznje { get; set; }
        public virtual ICollection<Vozilo> Vozila { get; set; }
       
        public Linija() { }
    }
}