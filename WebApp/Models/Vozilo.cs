using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models
{
    public class Vozilo
    {
        public int Id { get; set; }
        public string Tip { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public int LinijaId { get; set; }
        public Linija Linija { get; set; }
        public Vozilo() { }
    }
}