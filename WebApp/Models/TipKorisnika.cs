using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class TipKorisnika
    {
        public int Id { get; set; }
        public string Tip { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public TipKorisnika() { }
    }
}