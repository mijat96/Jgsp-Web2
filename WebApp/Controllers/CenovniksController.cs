using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Persistence;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    public class CenovniksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Cenovniks
        public IQueryable<Cenovnik> GetCenovnici()
        {
            return db.Cenovnici;
        }
        public IUnitOfWork Db { get; set; }

        public CenovniksController(IUnitOfWork db)
        {
            Db = db;
        }
        // GET: api/Cenovniks/5
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult GetCenovnik(int id)
        {
            Cenovnik cenovnik = db.Cenovnici.Find(id);
            if (cenovnik == null)
            {
                return NotFound();
            }

            return Ok(cenovnik);
        }

        // PUT: api/Cenovniks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCenovnik(int id, Cenovnik cenovnik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cenovnik.IdCenovnik)
            {
                return BadRequest();
            }

            db.Entry(cenovnik).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenovnikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Promen
        [AllowAnonymous]
      
        [Route("PromeniCenovnik")]
        public IHttpActionResult PostCenovnik(CenovnikBindingModel cenovnik)
        {
    
            Cenovnik cenNovi = new Cenovnik();
            cenNovi.VaziDo = DateTime.Parse (cenovnik.vaziDo);
            cenNovi.VaziOd = DateTime.Parse(cenovnik.vaziOd);
            cenNovi.IdCenovnik = cenovnik.id;
            CenaKarte SD = new CenaKarte();
            CenaKarte SV = new CenaKarte();
            CenaKarte SM = new CenaKarte();
            CenaKarte SG = new CenaKarte();
            CenaKarte PD = new CenaKarte();
            CenaKarte PV = new CenaKarte();
            CenaKarte PM = new CenaKarte();
            CenaKarte PG = new CenaKarte();
            CenaKarte OD = new CenaKarte();
            CenaKarte OV = new CenaKarte();
            CenaKarte OM = new CenaKarte();
            CenaKarte OG = new CenaKarte();
            SD.Cena = cenovnik.dnevna -( cenovnik.dnevna * cenovnik.popustStudent /100);
            SM.Cena = cenovnik.mesecna -( cenovnik.mesecna* cenovnik.popustStudent /100);
            SG.Cena = cenovnik.godisnja - (cenovnik.godisnja * cenovnik.popustStudent /100);
            SV.Cena = cenovnik.vremenska- (cenovnik.vremenska * cenovnik.popustStudent /100);
            PD.Cena = cenovnik.dnevna -(cenovnik.dnevna * cenovnik.popustPenzija /100);
            PM.Cena = cenovnik.mesecna - (cenovnik.dnevna * cenovnik.popustPenzija /100);
            PG.Cena = cenovnik.godisnja -(cenovnik.dnevna * cenovnik.popustPenzija /100);
            PV.Cena = cenovnik.vremenska-(cenovnik.dnevna * cenovnik.popustPenzija /100);
            OD.Cena = cenovnik.dnevna ;
            OM.Cena = cenovnik.mesecna ;
            OG.Cena = cenovnik.godisnja;
            OV.Cena = cenovnik.vremenska;
            SD.TipKupca = "Student";
            SM.TipKupca = "Student";
            SG.TipKupca = "Student";
            SV.TipKupca = "Student";
            PD.TipKupca = "Penzioner";
            PM.TipKupca = "Penzioner";
            PG.TipKupca = "Penzioner";
            PV.TipKupca = "Penzioner";
            OD.TipKupca = "Obican";
            OM.TipKupca = "Obican";
            OG.TipKupca = "Obican";
            OV.TipKupca = "Obican";
            SD.TipKarte = "Dnevna";
            SM.TipKarte = "Mesecna";
            SG.TipKarte = "Godisnja";
            SV.TipKarte = "Vremenska";
            PD.TipKarte = "Dnevna";
            PM.TipKarte = "Mesecna";
            PG.TipKarte = "Godisnja";
            PV.TipKarte = "Vremenska";
            OD.TipKarte = "Dnevna";
            OM.TipKarte = "Mesecna";
            OG.TipKarte = "Godisnja";
            OV.TipKarte = "Vremenska";
            cenNovi.CeneKarti = new List<CenaKarte>();
            cenNovi.CeneKarti.Add(SD);
            cenNovi.CeneKarti.Add(SM);
            cenNovi.CeneKarti.Add(SV);
            cenNovi.CeneKarti.Add(SG);
            cenNovi.CeneKarti.Add(OM);
            cenNovi.CeneKarti.Add(OG);
            cenNovi.CeneKarti.Add(OV);
            cenNovi.CeneKarti.Add(OD);
            cenNovi.CeneKarti.Add(PD);
            cenNovi.CeneKarti.Add(PV);
            cenNovi.CeneKarti.Add(PM);
            cenNovi.CeneKarti.Add(PG);
            SD.CenovnikId = cenNovi.IdCenovnik;
            SM.CenovnikId = cenNovi.IdCenovnik;
            SG.CenovnikId = cenNovi.IdCenovnik;
            SV.CenovnikId = cenNovi.IdCenovnik;
            PD.CenovnikId = cenNovi.IdCenovnik;
            PM.CenovnikId = cenNovi.IdCenovnik;
            PG.CenovnikId = cenNovi.IdCenovnik;
            PV.CenovnikId = cenNovi.IdCenovnik;
            OD.CenovnikId = cenNovi.IdCenovnik;
            OM.CenovnikId = cenNovi.IdCenovnik;
            OG.CenovnikId = cenNovi.IdCenovnik;
            OV.CenovnikId = cenNovi.IdCenovnik;
            Db.Cenovnik.Add((cenNovi));
            Db.CenaKarte.Add(PM);
            Db.CenaKarte.Add(PV);
            Db.CenaKarte.Add(PG);
            Db.CenaKarte.Add(PD);
            Db.CenaKarte.Add(OM);
            Db.CenaKarte.Add(OG);
            Db.CenaKarte.Add(OV);
            Db.CenaKarte.Add(OD);
            Db.CenaKarte.Add(SM);
            Db.CenaKarte.Add(SD);
            Db.CenaKarte.Add(SG);
            Db.CenaKarte.Add(SV);
            Db.Complete();
            return Ok();
        }

        // DELETE: api/Cenovniks/5
        [ResponseType(typeof(Cenovnik))]
        public IHttpActionResult DeleteCenovnik(int id)
        {
            Cenovnik cenovnik = db.Cenovnici.Find(id);
            if (cenovnik == null)
            {
                return NotFound();
            }

            db.Cenovnici.Remove(cenovnik);
            db.SaveChanges();

            return Ok(cenovnik);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CenovnikExists(int id)
        {
            return db.Cenovnici.Count(e => e.IdCenovnik == id) > 0;
        }
    }
}