using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class CenovnikRepository : Repository<Cenovnik, int>, IRepositoryCenovnik
    {
        public CenovnikRepository(DbContext context) : base(context)
        {
        }
    }
}