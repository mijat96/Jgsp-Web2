using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Unity;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public class DemoUnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
      
        public DemoUnitOfWork(DbContext context)
        {
            _context = context;
        }

        //[Dependency]
        //instanca interfejsa
        [Dependency]
        IRepositoryCenaKarte CenaKarte { get; set; }
        [Dependency]
        IRepositoryCenovnik Cenovnik { get; set; }
        [Dependency]
        IRepositoryKarta Karta { get; set; }
        [Dependency]
        IRepositoryLinija Linija { get; set; }
        [Dependency]
        IRepositoryRedVoznje RedVoznje { get; set; }
        [Dependency]
        IRepositoryStanica Stanica { get; set; }
        [Dependency]
        IRepositoryTipKorisnika TipKorisnika { get; set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}