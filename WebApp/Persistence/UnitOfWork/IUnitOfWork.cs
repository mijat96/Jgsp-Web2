using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Persistence.Repository;

namespace WebApp.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        //IProductRepository Products;
        IRepositoryVozlio Vozila { get; set; }
        IRepositoryCenaKarte CenaKarte { get; set; }
        IRepositoryCenovnik Cenovnik { get; set; }
        IRepositoryKarta Karta { get; set; }
        IRepositoryLinija Linija { get; set; }
        IRepositoryRedVoznje RedVoznje { get; set; }
        IRepositoryStanica Stanica { get; set; }
        IRepositoryTipKorisnika TipKorisnika { get; set; }
        int Complete();
    }
}
