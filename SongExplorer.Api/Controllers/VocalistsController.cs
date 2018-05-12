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
using SongExplorer.Model;
using Microsoft.AspNet.Identity;

namespace SongExplorer.Api.Controllers
{
    [Authorize]
    public class VocalistsController : ApiController
    {
        private SongExplorerEntities db = new SongExplorerEntities();

        // GET: api/Vocalists
        public IQueryable<Vocalist> GetVocalists()
        {
            return db.Vocalists.Where(vocalist => vocalist.UserId == User.Identity.GetUserId());
        }

        // GET: api/Vocalists/5
        [ResponseType(typeof(Vocalist))]
        public IHttpActionResult GetVocalist(int id)
        {
            Vocalist vocalist = db.Vocalists.Where(v => v.Id == id && v.UserId == User.Identity.GetUserId()).FirstOrDefault();
            if (vocalist == null)
            {
                return NotFound();
            }

            return Ok(vocalist);
        }

        // PUT: api/Vocalists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVocalist(int id, Vocalist vocalist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vocalist.Id)
            {
                return BadRequest();
            }

            var originalVocalist = db.Vocalists.Find(id);
            if (originalVocalist.UserId != User.Identity.GetUserId())
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            db.Entry(vocalist).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VocalistExists(id))
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

        // POST: api/Vocalists
        [ResponseType(typeof(Vocalist))]
        public IHttpActionResult PostVocalist(Vocalist vocalist)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vocalist.UserId = User.Identity.GetUserId();

            db.Vocalists.Add(vocalist);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vocalist.Id }, vocalist);
        }

        // DELETE: api/Vocalists/5
        [ResponseType(typeof(Vocalist))]
        public IHttpActionResult DeleteVocalist(int id)
        {
            Vocalist vocalist = db.Vocalists.Find(id);
            if (vocalist == null)
            {
                return NotFound();
            }

            if (vocalist.UserId != User.Identity.GetUserId())
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            db.Vocalists.Remove(vocalist);
            db.SaveChanges();

            return Ok(vocalist);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VocalistExists(int id)
        {
            return db.Vocalists.Count(e => e.Id == id) > 0;
        }
    }
}