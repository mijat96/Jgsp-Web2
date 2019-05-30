using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class LinijaRepository : Repository<Linija, int>, IRepositoryLinija
    {
        public LinijaRepository(DbContext context) : base(context)
        {
        }
    }
}