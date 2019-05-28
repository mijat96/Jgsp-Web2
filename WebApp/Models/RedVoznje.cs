using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class RedVoznje
    {
        public int Id { get; set; }
        public string DanUNedelji { get; set; }

        public int LinijaId { get; set; }
        public Linija Linija { get; set; }

        public RedVoznje() { }
    }
}