using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using WebApp.Models;
using WebApp.Persistence;
using WebApp.Persistence.UnitOfWork;

namespace WebApp.Controllers
{
    [Authorize]
    [RoutePrefix("api/Slikas")]
    public class SlikasController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IUnitOfWork Db { get; set; }

        public SlikasController(IUnitOfWork db)
        {
            Db = db;
        }
        // GET: api/Slikas
        public IQueryable<Slika> GetSlike()
        {
            return db.Slike;
        }

        [HttpPost]
        [Route("UploadImage/{username}")]
        [AllowAnonymous]
        public IHttpActionResult UploadImage(string username)
        {
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                foreach (string file in httpRequest.Files)
                {
                    //var user = UserManager.FindByName(username);
                    var userStore = new UserStore<ApplicationUser>(db);
                    var userManager = new UserManager<ApplicationUser>(userStore);
                    ApplicationUser user = userManager.FindByName(username);
                    //Sacuvati sliku u bazi i povezati je sa registrovanim userom


                    //Passenger passenger = UnitOfWork.PassengerRepository.Get(id);

                    //if (passenger == null)
                    //{
                    //    return BadRequest("User does not exists.");
                    //}

                    //if (passenger.ImageUrl != null)
                    //{
                    //    File.Delete(HttpContext.Current.Server.MapPath("~/UploadFile/" + passenger.ImageUrl));
                    //}



                    var postedFile = httpRequest.Files[file];
                    string fileName = postedFile.FileName;
                    var filePath = HttpContext.Current.Server.MapPath("~/SlikeKorisnika/" + fileName);

                    Slika slika = null;
                    IEnumerable<Slika> sveSlike = null;
                    try
                    {
                        sveSlike = Db.Slika.GetAll();
                    }
                    catch (Exception e)
                    {

                    }

                    bool korisnikImaSliku = false;

                    if (sveSlike != null)
                    {
                        foreach (var s in sveSlike)
                        {
                            if (s.Korisnik == user.Id)
                            {
                                korisnikImaSliku = true;
                                slika = s;
                                break;
                            }
                        }

                        if (korisnikImaSliku)
                        {
                            Db.Slika.Update(slika);
                            Db.Complete();
                        }
                        else
                        {
                            slika = new Slika() { ImageUrl = filePath, Korisnik = user.Id };
                            Db.Slika.Add(slika);
                            Db.Complete();
                        }
                    }
                    else
                    {
                        slika = new Slika() { Id = 1, ImageUrl = filePath, Korisnik = user.Id };
                        try
                        {

                            Db.Slika.Add(slika);
                            Db.Complete();
                        }
                        catch (Exception e) { }
                    }


                    //UnitOfWork.PassengerRepository.Update(passenger);
                    //UnitOfWork.Complete();


                    postedFile.SaveAs(filePath);
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/Slikas/5
        [HttpGet]
        [Route("GetSlika/{username}")]
        [AllowAnonymous]
        [ResponseType(typeof(Slika))]
        public IHttpActionResult GetSlika(string username)
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            ApplicationUser user = userManager.FindByName(username);
            Slika slikaKorisnika = null;

            IEnumerable<Slika> slike = Db.Slika.GetAll();

            foreach(var s in slike)
            {
                if(s.Korisnik == user.Id)
                {
                    slikaKorisnika = s;
                    break;
                }
            }

            if (slikaKorisnika == null)
            {
                return BadRequest("Korisnik nije dostavio sliku!");
            }

            string fileName = slikaKorisnika.ImageUrl.Split('\\')[8];

            var filePath = HttpContext.Current.Server.MapPath("~/SlikeKorisnika/" + fileName);
            FileInfo fileInfo = new FileInfo(filePath);
            string type = fileInfo.Extension.Split('.')[1];
            byte[] data = new byte[fileInfo.Length];

            HttpResponseMessage response = new HttpResponseMessage();
            using (FileStream fs = fileInfo.OpenRead())
            {
                fs.Read(data, 0, data.Length);
                response.StatusCode = HttpStatusCode.OK;
                response.Content = new ByteArrayContent(data);
                response.Content.Headers.ContentLength = data.Length;

            }

            response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/png");

            return Ok(data);
        }

        // PUT: api/Slikas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSlika(int id, Slika slika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != slika.Id)
            {
                return BadRequest();
            }

            db.Entry(slika).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlikaExists(id))
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

        // POST: api/Slikas
        [ResponseType(typeof(Slika))]
        public IHttpActionResult PostSlika(Slika slika)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Slike.Add(slika);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = slika.Id }, slika);
        }

        // DELETE: api/Slikas/5
        [ResponseType(typeof(Slika))]
        public IHttpActionResult DeleteSlika(int id)
        {
            Slika slika = db.Slike.Find(id);
            if (slika == null)
            {
                return NotFound();
            }

            db.Slike.Remove(slika);
            db.SaveChanges();

            return Ok(slika);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SlikaExists(int id)
        {
            return db.Slike.Count(e => e.Id == id) > 0;
        }
    }
}