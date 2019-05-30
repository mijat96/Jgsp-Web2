using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class RedVoznjeRepository : Repository<RedVoznje, int>, IRepositoryRedVoznje
    {
        public RedVoznjeRepository(DbContext context) : base(context)
        {
        }
    }
}