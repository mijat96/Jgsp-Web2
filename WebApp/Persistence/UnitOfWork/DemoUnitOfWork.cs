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
        public IRepositoryVozlio Vozila { get; set; }
        [Dependency]
        public IRepositoryCenaKarte CenaKarte { get; set; }
        [Dependency]
        public IRepositoryCenovnik Cenovnik { get; set; }
        [Dependency]
        public IRepositoryKarta Karta { get; set; }
        [Dependency]
        public IRepositoryLinija Linija { get; set; }
        [Dependency]
        public IRepositoryRedVoznje RedVoznje { get; set; }
        [Dependency]
        public IRepositoryStanica Stanica { get; set; }
        

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