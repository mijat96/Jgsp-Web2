using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Karta
    {
        [Key]
        public int IdKarte { get; set; }
        public TipKarte Tip { get; set; }
        public DateTime VaziDo { get; set; }

        public ICollection<CenaKarte> CeneKarti { get; set; }

        public Karta() { }

    }

    public enum TipKarte
    {
        Vremenska,
        Dnevna,
        Mesecna,
        Godisnja
    }
}