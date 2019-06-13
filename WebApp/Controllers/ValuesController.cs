using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public IUnitOfWork Db { get; set; }
        public ValuesController(IUnitOfWork db)
        {
            Db = db;
        
        }
        public ValuesController()
        {
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [AllowAnonymous]
 
        [Route("GetZahtevi")]
        public List<string> GetValues()
        {
            IQueryable<ApplicationUser> acounti;
            acounti = db.Users.AsQueryable();
            List<string> usernameovi = new List<string>();
            foreach(ApplicationUser a in acounti)
            {
                if(!a.Odobren)
                usernameovi.Add(a.UserName);
            }
            return usernameovi;
        }
        // POST api/values
        [AllowAnonymous]

        [Route("Odobri/{mejl}")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetValues(string mejl)
        {
            IQueryable<ApplicationUser> acounti;
            acounti = db.Users.AsQueryable();
            ApplicationUser app = new ApplicationUser();
            foreach (ApplicationUser a in acounti)
            {
                if(a.UserName == mejl)
                {
                    app = a;
                }
             

            }
            app.Odobren = true;
            db.Entry(app).State = EntityState.Modified;

            db.SaveChanges();
            return Ok("Odobrili ste mu kupovinu!");
        }
    }
}
