using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class CenaKarte
    {
        [Key]
        public int IdCenaKarte { get; set; }
        public float Cena { get; set; }
        public string TipKarte { get; set; }
        public string TipKupca { get; set; }
        [ForeignKey("Cenovnik")]
        public int CenovnikId { get; set; }
        public Cenovnik Cenovnik {get; set;}
       

        public virtual ICollection<Karta> Karte { get; set; }
        public CenaKarte() { }

    }
}