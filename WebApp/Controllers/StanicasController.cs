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

namespace WebApp.Controllers
{
    public class StanicasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Stanicas
        public IQueryable<Stanica> GetStanice()
        {
            return db.Stanice;
        }

        // GET: api/Stanicas/5
        [ResponseType(typeof(Stanica))]
        public IHttpActionResult GetStanica(int id)
        {
            Stanica stanica = db.Stanice.Find(id);
            if (stanica == null)
            {
                return NotFound();
            }

            return Ok(stanica);
        }

        // GET: api/Linijas/5   
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        [Route("GetLinija/{linija}")]
        public IHttpActionResult GetStanica(string linija)
        {
            

            string retvalue = "n";

            if (retvalue == "n")
            {
                return NotFound();
            }


            return Ok(retvalue);
        }

        // PUT: api/Stanicas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStanica(int id, Stanica stanica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stanica.Id)
            {
                return BadRequest();
            }

            db.Entry(stanica).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StanicaExists(id))
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

        // POST: api/Stanicas
        [ResponseType(typeof(Stanica))]
        public IHttpActionResult PostStanica(Stanica stanica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stanice.Add(stanica);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stanica.Id }, stanica);
        }

        // DELETE: api/Stanicas/5
        [ResponseType(typeof(Stanica))]
        public IHttpActionResult DeleteStanica(int id)
        {
            Stanica stanica = db.Stanice.Find(id);
            if (stanica == null)
            {
                return NotFound();
            }

            db.Stanice.Remove(stanica);
            db.SaveChanges();

            return Ok(stanica);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StanicaExists(int id)
        {
            return db.Stanice.Count(e => e.Id == id) > 0;
        }
    }
}