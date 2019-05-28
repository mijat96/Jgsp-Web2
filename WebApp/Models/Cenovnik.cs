using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Cenovnik
    {
        [Key]
        public int IdCenovnik { get; set; }
        public DateTime VaziOd { get; set; }
        public DateTime VaziDo { get; set; }

        public ICollection<CenaKarte> CeneKarti { get; set; }

        public Cenovnik() { }
    }
}