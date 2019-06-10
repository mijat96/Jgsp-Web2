using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
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
        public List<string> GetLinije()
        {
            IQueryable<Linija> linije = Db.Linija.GetAll().AsQueryable();
            List<string> BrojeviLinija = new List<string>();
            foreach (Linija l in linije) {
                BrojeviLinija.Add(l.RedniBroj);
            }
            return BrojeviLinija;
        }

        // GET: api/Linijas/5
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        [Route("GetLinija/{id}/{dan}")]
        public IHttpActionResult GetLinija(string id, string dan)
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

        // GET: api/Linijas/5   
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        [Route("GetLinija/{id}/{dan}/{p}")]
        public IHttpActionResult GetLinija(int id, string dan, string p)
        {
            using (StreamReader r = new StreamReader("C:/Users/MIJAT/Desktop/JGSP stanice/1a.json"))
            {   
                string json = "", linijaPodela = "";
                string[] linije, linijaNiz;
                Stanica s = new Stanica();
                //Linija l = new Linija();

                while (r.ReadLine() != null)
                {
                    json = r.ReadLine();
                    linijaPodela = json.Split('|')[0];
                    linijaNiz = linijaPodela.Split(',', '[', ']');
                    s.Adresa = json.Split('|')[3];
                    s.X = double.Parse(json.Split('|')[1]);
                    s.Y = double.Parse(json.Split('|')[2]);
                    s.Naziv = s.Adresa = json.Split('|')[3];
                    List<Linija> stanLinije = new List<Linija>();
                    foreach (var lin in linijaNiz)
                    {
                        if (lin != "" && lin != "    \"")
                        {
                            List<Stanica> stan = new List<Stanica>();
                            stan.Add(s);
                            Linija l = new Linija() { RedniBroj = lin, Stanice = stan };
                            stanLinije.Add(l);
                            List<Linija> sveLinije = Db.Linija.GetAll().ToList();
                            if (!sveLinije.Contains(l))
                            {
                                Db.Linija.Add(l);
                            }
                        }
                    }
                    List<Stanica> sveStanice = Db.Stanica.GetAll().ToList();
                    if (!sveStanice.Contains(s))
                    {
                        Db.Stanica.Add(s);
                    }
                }
                Db.Complete();
                
                
            }

            string retvalue = "n";
            
            if (retvalue == "n")
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