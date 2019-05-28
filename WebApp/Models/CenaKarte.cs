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

        [ForeignKey("Cenovnik")]
        public int CenovnikId { get; set; }
        public Cenovnik Cenovnik {get; set;}
        [ForeignKey("Karta")]
        public int KartaId { get; set; }
        public Karta Karta { get; set; }

        public CenaKarte() { }

    }
}