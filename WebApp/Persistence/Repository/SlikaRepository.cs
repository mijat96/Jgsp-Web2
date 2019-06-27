using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class SlikaRepository : Repository<Slika, int>, IRepositorySlika
    {
        public SlikaRepository(DbContext context) : base(context)
        {
        }
    }
}