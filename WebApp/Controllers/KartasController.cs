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
using System.Net.Mail;
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
                    odgovor = "ovom korisniku ne vazi karta, hapsi stoku!";
                }
                if (karta.Tip == "Mesecna" && (DateTime.UtcNow < karta.VaziDo.AddMonths(1)))
                {
                    odgovor = "vazi vam karta";
                }
                else
                {
                    odgovor = "ovom korisniku ne vazi karta, hapsi stoku!";
                }
                if (karta.Tip == "Godisnja" && (DateTime.UtcNow < karta.VaziDo.AddYears(1)))
                {
                    odgovor = "vazi vam karta";
                }
                else
                {
                    odgovor = "ovom korisniku ne vazi karta, hapsi stoku!";
                }
                if (karta.Tip == "Vremenska" && (DateTime.UtcNow < karta.VaziDo.AddHours(1)))
                {
                    odgovor = "vazi vam karta";
                }
                else
                {
                    odgovor = "ovom korisniku ne vazi karta, hapsi stoku!";
                }
            }
            return Ok(odgovor);
        }
        // GET: api/Kartas/5
        [AllowAnonymous]
        [ResponseType(typeof(string))]
        [Route("GetKarta/{tipKarte}/{tipKupca}")]
        public IHttpActionResult GetKartaCena(string tipKarte,string tipKupca)
        {
            List<CenaKarte> karte = Db.CenaKarte.GetAll().ToList();

            string odg = "Cena zeljene karte je : ";
            foreach(CenaKarte k in karte)
            {
                if(k.TipKarte == tipKarte && tipKupca == k.TipKupca)
                {
                    odg += k.Cena.ToString();
                }
            }
            odg += " rsd.";
            if (karte == null)
            {
                return NotFound();
            }

            return Ok(odg);
        }
       
        [ResponseType(typeof(string))]
        [Route("GetKartaKupi2/{tipKarte}/{mejl}")]
        public IHttpActionResult GetKarta(string tipKarte, string mejl)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
     
            Karta novaKarta = new Karta();
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
      
           
            CenaKarte ck = Db.CenaKarte.GetAll().Where(t => t.TipKarte == tipKarte && t.TipKupca == tipKorisnika).FirstOrDefault();
           // novaKarta.CenaKarte = ck;
            novaKarta.CenaKarteId = ck.IdCenaKarte;

            novaKarta.Tip = tipKarte;
       
     
            //novaKarta.ApplicationUserId = User.Identity.GetUserId();
            novaKarta.VaziDo = DateTime.UtcNow;
            if (u != null)
            {
                novaKarta.ApplicationUserId = id;
               // novaKarta.ApplicationUser = u;
                //novaKarta.ApplicationUser = userManager.FindById(id);
                // u.Karte.Add(novaKarta);
            }
            else
            {
                MailMessage mail = new MailMessage("andrejs0901@gmail.com", "andrejs0901@gmail.com");
                SmtpClient client = new SmtpClient();
                client.Port = 587;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;
                client.Credentials = new NetworkCredential("andrejs0901@gmail.com", "andrej996");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
             
                mail.Subject = "Public City Transport Serbia";
                mail.Body = $"You successfully bought ticket at {DateTime.Now}. {Environment.NewLine} Your ticket id is: {novaKarta.IdKarte} {Environment.NewLine}Thank you!";
                try
                {
                    client.Send(mail);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return InternalServerError(e);
                }
            }
            cena = ck.Cena;
            povratna = "Uspesno ste kupili " + tipKarte + "-u" + " kartu, po ceni od " + cena.ToString() + " rsd, hvala vam, vas gsp!";

            
            novaKarta.Cekirana = true;
            db.Dispose();
            
            Db.Karta.Add(novaKarta);
            
            Db.Complete();
            if (ck == null)
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