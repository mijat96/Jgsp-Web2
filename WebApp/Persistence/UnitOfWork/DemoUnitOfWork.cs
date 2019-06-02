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
        IRepositoryVozlio IUnitOfWork.Vozilo { get; set; }
        [Dependency]
        IRepositoryVozlio IUnitOfWork.Vozila { get; set; }
        [Dependency]
        IRepositoryCenaKarte IUnitOfWork.CenaKarte { get; set; }
        [Dependency]
        IRepositoryCenovnik IUnitOfWork.Cenovnik { get; set; }
        [Dependency]
        IRepositoryKarta IUnitOfWork.Karta { get; set; }
        [Dependency]
        IRepositoryLinija IUnitOfWork.Linija { get; set; }
        [Dependency]
        IRepositoryRedVoznje IUnitOfWork.RedVoznje { get; set; }
        [Dependency]
        IRepositoryStanica IUnitOfWork.Stanica { get; set; }
        

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