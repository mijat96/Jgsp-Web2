using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class VoziloRepository : Repository<Vozilo, int>, IRepositoryVozlio
    {
        public VoziloRepository(DbContext context) : base(context)
        {
        }
    }
}