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
    [RoutePrefix("api/Stanicas")]
    public class StanicasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IUnitOfWork Db { get; set; }

        public StanicasController(IUnitOfWork db)
        {
            Db = db;
        }

        // GET: api/Stanicas
        public IQueryable<Stanica> GetStanice()
        {
            return db.Stanice;
        }

        // GET: api/Stanicas/5
        [AllowAnonymous]
        [Route("GetStanicee")]
        public List<string> GetStanica()
        {
            IQueryable<Stanica> stanice = Db.Stanica.GetAll().AsQueryable();
            List<string> imena = new List<string>();
            foreach(Stanica sta in stanice)
            {
                imena.Add(sta.Naziv);
            }
            return imena;
        }
        [AllowAnonymous]
        [Route("Spoji/{linija}/{stanica}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetStanica(string linija, string stanica)
        {
            Linija lin = Db.Linija.GetAll().Where(x => x.RedniBroj == linija).FirstOrDefault();
            Stanica sta = Db.Stanica.GetAll().Where(x => x.Naziv == stanica).FirstOrDefault();
            lin.Stanice = new List<Stanica>();
            lin.Stanice.Add(sta);
            sta.Linije = new List<Linija>();
            sta.Linije.Add(lin);
            Db.Stanica.Update(sta);
            Db.Linija.Update(lin);
            Db.Complete();
            return Ok("");
        }

        // GET: api/Linijas/5   
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        [Route("GetStanica/{linijaBroj}")]
        public IHttpActionResult GetStanica(string linijaBroj)
        {
            int idLinije;
            List<Linija> sveLinije = Db.Linija.GetAll().ToList();
            Linija izabranaLinija = null;

            foreach(var l in sveLinije)
            {
                if(l.RedniBroj == linijaBroj)
                {
                    izabranaLinija = l;
                    break;
                }
            }
            
            if (izabranaLinija == null)
            {
                return NotFound();
            }

            List<Kordinate> listaKordinata = new List<Kordinate>();
            foreach(var stanica in izabranaLinija.Stanice)
            {
                Kordinate k = new Kordinate() { x = stanica.X, y = stanica.Y, name = stanica.Naziv };
                listaKordinata.Add(k);
            }

            return Ok(listaKordinata);
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
        [ResponseType(typeof(string))]
        [AllowAnonymous]
        public IHttpActionResult PostStanica(StanicaBinding stanica)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Stanica st = new Stanica();
            st.Adresa = stanica.adresa;
            st.Naziv = stanica.naziv;
            st.X = stanica.x;
            st.Y = stanica.y;
            st.Linije = new List<Linija>();
            Db.Stanica.Add(st);
            Db.Complete();
            return Ok("uspresno ste dodali novu stanicu!");
        }
        [AllowAnonymous]
        // DELETE: api/Stanicas/5
        [Route("IzbrisiStanicu/{ime}/{nesto}/{nesto2}")]
        public IHttpActionResult GetStanica(string ime, string nesto, string nesto2)
        {
            Stanica stanica = db.Stanice.Where(x=> x.Naziv == ime).FirstOrDefault();
            if (stanica == null)
            {
                return NotFound();
            }

            db.Stanice.Remove(stanica);
            db.SaveChanges();

            return Ok();
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

    class Kordinate
    {
        public double x { get; set; }
        public double y { get; set; }
        public string name { get; set; }
    }
}