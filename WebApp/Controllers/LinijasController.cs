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
    [Authorize]
    [RoutePrefix("api/Linijas")]
    public class LinijasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IUnitOfWork Db { get; set; }
       
        public LinijasController(IUnitOfWork db)
        {
            Db = db;
        }
        // GET: api/Linijas
        [AllowAnonymous]
        public List<int> GetLinije()
        {
            IQueryable<Linija> linije = Db.Linija.GetAll().AsQueryable();
            List<int> BrojeviLinija = new List<int>();
            foreach (Linija l in linije) {
                BrojeviLinija.Add(l.RedniBroj);
            }
            return BrojeviLinija;
        }

        // GET: api/Linijas/5
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        [Route("GetLinija/{id}/{dan}")]
        public IHttpActionResult GetLinija(int id, string dan)
        {
            IQueryable<Linija> linije = Db.Linija.GetAll().AsQueryable();
           
            string retvalue = "n";
          foreach(Linija l in linije)
            {
                if(l.RedniBroj==id)
                {
                    foreach (RedVoznje red in l.RedoviVoznje)
                    {
                        if (red.DanUNedelji == dan)
                        {
                            retvalue = red.Polasci;
                        }
                    }
                }
            }
          if(retvalue == "n")
            {
                return NotFound();
            }
         
        
            return Ok(retvalue);
        }

        // PUT: api/Linijas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLinija(int id, Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != linija.Id)
            {
                return BadRequest();
            }

            db.Entry(linija).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinijaExists(id))
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

        // POST: api/Linijas
        [ResponseType(typeof(Linija))]
        public IHttpActionResult PostLinija(Linija linija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Linije.Add(linija);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = linija.Id }, linija);
        }

        // DELETE: api/Linijas/5
        [ResponseType(typeof(Linija))]
        public IHttpActionResult DeleteLinija(int id)
        {
            Linija linija = db.Linije.Find(id);
            if (linija == null)
            {
                return NotFound();
            }

            db.Linije.Remove(linija);
            db.SaveChanges();

            return Ok(linija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LinijaExists(int id)
        {
            return db.Linije.Count(e => e.Id == id) > 0;
        }
    }
}