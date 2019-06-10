using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    [RoutePrefix("api/Kartas")]
    public class KartasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IUnitOfWork Db { get; set; }

        public KartasController(IUnitOfWork db)
        {
            Db = db;
        }

        // GET: api/Kartas
        public IQueryable<Karta> GetKarte()
        {
            return db.Karte;
        }
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        [Route("GetProveri/{IdKorisnika}")]
        public IHttpActionResult GetProveri(string IdKorisnika)
        {
            Karta karta = new Karta();
            List<Karta> karte = Db.Karta.GetAll().ToList();
            string odgovor = "";
            foreach(Karta k1 in karte)
            {
                if(k1.ApplicationUserId == IdKorisnika)
                {
                    karta = k1;
                }
            }
            if (karta == null)
            {
                return NotFound();
            }
            else
            {
                if (karta.Tip == "Dnevna" && (DateTime.UtcNow < karta.VaziDo.AddDays(1)))
                {
                    odgovor = "vazi vam karta";
                }
                else
                {
                    odgovor = "ne vazi vam karta";
                }
            }
            return Ok(odgovor);
        }
        // GET: api/Kartas/5
        [AllowAnonymous]
        [ResponseType(typeof(float))]
        [Route("GetKarta/{tip}")]
        public IHttpActionResult GetKartaCena(string tip)
        {
            List<CenaKarte> karte = Db.CenaKarte.GetAll().ToList();
           
            float cena = 0;
            foreach(CenaKarte k in karte)
            {
                if(tip == k.TipKarte)
                {
                   
                    cena = k.Cena;
                }
            }

            if (karte == null)
            {
                return NotFound();
            }

            return Ok(cena);
        }
       
        [ResponseType(typeof(string))]
        [Route("GetKartaKupi2/{tipKarte}")]
        public IHttpActionResult GetKarta(string tipKarte)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            List<CenaKarte> ceneKarata = Db.CenaKarte.GetAll().ToList();
            string tipKorisnika;
            var id = User.Identity.GetUserId();
            ApplicationUser u = userManager.FindById(id);
            if (u == null)
            {
                tipKorisnika = "Obican";
            }
            else
            {
                tipKorisnika = u.Tip;
            }
            float cena;
            string povratna = "";
            foreach (CenaKarte ck in ceneKarata)
            {
                if (ck.TipKarte == tipKarte && ck.TipKupca == tipKorisnika)
                {
                    Karta novaKarta = new Karta();
                    novaKarta.CenaKarte = ck;
                    novaKarta.Tip = tipKarte;
                    //novaKarta.ApplicationUserId = User.Identity.GetUserId();
                    novaKarta.VaziDo = DateTime.UtcNow;
                    if (u != null)
                    {
                        novaKarta.ApplicationUserId = id;
                        novaKarta.ApplicationUser = u;
                        //novaKarta.ApplicationUser = userManager.FindById(id);
                       // u.Karte.Add(novaKarta);
                    }
                    cena = ck.Cena;
                    //Dodavanje novih karata
                    //CenaKarte cenaKarte = new CenaKarte();

                    //cenaKarte.Karte = new List<Karta>();
                    //cenaKarte.Cena = 60;
                    //cenaKarte.Cenovnik = Db.Cenovnik.Get(1);
                    //cenaKarte.TipKarte = "vremenska";
                    //Karta vremenska = new Karta() { Tip = "Vremenska", CenaKarte = cenaKarte, IdKarte = 2, VaziDo = DateTime.Now };
                    //Db.CenaKarte.Add(cenaKarte);
                    //Db.Karta.Add(vremenska);
                    //Db.Complete();
                    //kraj 
                    Db.Karta.Add(novaKarta);
                    Db.Complete();


                    povratna = "Uspesno ste kupili " + tipKarte + "-u" + " kartu, po ceni od " + cena.ToString() + " rsd, hvala vam, vas gsp!";
                    break;                    
                }
            }

            if (ceneKarata == null)
            {
                return NotFound();
            }
       
            return Ok(povratna);
        }

        // PUT: api/Kartas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKarta(int id, Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != karta.IdKarte)
            {
                return BadRequest();
            }

            db.Entry(karta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KartaExists(id))
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

        // POST: api/Kartas
        [ResponseType(typeof(Karta))]
        public IHttpActionResult PostKarta(Karta karta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Karte.Add(karta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = karta.IdKarte }, karta);
        }

        // DELETE: api/Kartas/5
        [ResponseType(typeof(Karta))]
        public IHttpActionResult DeleteKarta(int id)
        {
            Karta karta = db.Karte.Find(id);
            if (karta == null)
            {
                return NotFound();
            }

            db.Karte.Remove(karta);
            db.SaveChanges();

            return Ok(karta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KartaExists(int id)
        {
            return db.Karte.Count(e => e.IdKarte == id) > 0;
        }
    }
}