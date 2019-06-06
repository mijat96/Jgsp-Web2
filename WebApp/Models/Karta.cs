using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Karta
    {
        [Key]
        public int IdKarte { get; set; }
        public bool Cekirana { get; set; }
        public string Tip { get; set; }
        [Column(TypeName ="datetime2")]
        public DateTime VaziDo { get; set; } //cekirana u trenutku
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("CenaKarte")]
        public int CenaKarteId { get; set; }
        public CenaKarte CenaKarte { get; set; }


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