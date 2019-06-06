using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Cenovnik
    {
        [Key]
        public int IdCenovnik { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime VaziOd { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime VaziDo { get; set; }

        public virtual ICollection<CenaKarte> CeneKarti { get; set; }

        public Cenovnik() { }
    }
}