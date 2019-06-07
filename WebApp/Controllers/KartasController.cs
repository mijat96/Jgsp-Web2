﻿using Microsoft.AspNet.Identity;
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

        // GET: api/Kartas/5
        [AllowAnonymous]
        [ResponseType(typeof(float))]
        [Route("GetKarta/{tip}")]
        public IHttpActionResult GetKartaCena(string tip)
        {
            List<Karta> karte = Db.Karta.GetAll().ToList();
            CenaKarte c = new CenaKarte();
            float cena = 0;
            foreach(Karta k in karte)
            {
                if(tip == k.Tip)
                {
                    c= Db.CenaKarte.Get(k.CenaKarteId);
                    cena = c.Cena;
                }
            }

            if (karte == null)
            {
                return NotFound();
            }

            return Ok(cena);
        }
        [Authorize(Roles = "Admin")]
        [ResponseType(typeof(string))]
        [Route("GetKartaKupi2/{tipKarte}/{tipKorisnika}/{user}")]
        public IHttpActionResult GetKarta(string tipKarte, string tipKorisnika, string user)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            List<CenaKarte> ceneKarata = Db.CenaKarte.GetAll().ToList();

            var id = User.Identity.GetUserId();

            float cena;
            string povratna = "";
            foreach (CenaKarte ck in ceneKarata)
            {
                if (ck.TipKarte == tipKarte && ck.TipKupca == tipKorisnika)
                {
                    Karta novaKarta = new Karta();
                    novaKarta.CenaKarte = ck;
                    novaKarta.Tip = tipKarte;
                    novaKarta.ApplicationUserId = User.Identity.GetUserId();
                    novaKarta.VaziDo = DateTime.UtcNow;
                    novaKarta.ApplicationUser = userManager.FindById(id);
                    novaKarta.ApplicationUserId = id;
                    cena = ck.Cena;
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