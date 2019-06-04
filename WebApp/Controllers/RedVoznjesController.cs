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
    public class RedVoznjesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IUnitOfWork Db { get; set; }

        public RedVoznjesController(IUnitOfWork db)
        {
            Db = db;
        }

        // GET: api/RedVoznjes
        public IQueryable<RedVoznje> GetRedoviVoznje()
        {
            return Db.RedVoznje.GetAll().AsQueryable();
        }

        // GET: api/RedVoznjes/5
        [ResponseType(typeof(string))]
        public IHttpActionResult GetRedVoznje(int id)
        {
            Linija linija = new Linija();
            RedVoznje redVoznje = Db.RedVoznje.Get(id);

            linija = Db.Linija.Get(redVoznje.LinijaId);

            if (redVoznje == null)
            {
                return NotFound();
            }

            return Ok(linija.Polasci);
        }

        // PUT: api/RedVoznjes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRedVoznje(int id, RedVoznje redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != redVoznje.Id)
            {
                return BadRequest();
            }

            db.Entry(redVoznje).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RedVoznjeExists(id))
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

        // POST: api/RedVoznjes
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult PostRedVoznje(RedVoznje redVoznje)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RedoviVoznje.Add(redVoznje);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = redVoznje.Id }, redVoznje);
        }

        // DELETE: api/RedVoznjes/5
        [ResponseType(typeof(RedVoznje))]
        public IHttpActionResult DeleteRedVoznje(int id)
        {
            RedVoznje redVoznje = db.RedoviVoznje.Find(id);
            if (redVoznje == null)
            {
                return NotFound();
            }

            db.RedoviVoznje.Remove(redVoznje);
            db.SaveChanges();

            return Ok(redVoznje);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RedVoznjeExists(int id)
        {
            return db.RedoviVoznje.Count(e => e.Id == id) > 0;
        }
    }
}