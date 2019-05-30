using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.Models;

namespace WebApp.Persistence.Repository
{
    public class TipKorisnikaRepository : Repository<TipKorisnika, int>, IRepositoryTipKorisnika
    {
        public TipKorisnikaRepository(DbContext context) : base(context)
        {
        }
    }
}