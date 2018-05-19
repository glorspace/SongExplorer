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

namespace SongExplorer.Api.Controllers
{
    [Authorize]
    public class KeysController : ApiController
    {
        private SongExplorerEntities db = new SongExplorerEntities();

        // GET: api/Keys
        public IQueryable<Key> GetKeys()
        {
            return db.Keys;
        }

        // GET: api/Keys/5
        [ResponseType(typeof(Key))]
        public IHttpActionResult GetKey(int id)
        {
            Key key = db.Keys.Find(id);
            if (key == null)
            {
                return NotFound();
            }

            return Ok(key);
        }

        // PUT: api/Keys/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKey(int id, Key key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != key.Id)
            {
                return BadRequest();
            }

            db.Entry(key).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeyExists(id))
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

        // POST: api/Keys
        [ResponseType(typeof(Key))]
        public IHttpActionResult PostKey(Key key)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Keys.Add(key);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = key.Id }, key);
        }

        // DELETE: api/Keys/5
        [ResponseType(typeof(Key))]
        public IHttpActionResult DeleteKey(int id)
        {
            Key key = db.Keys.Find(id);
            if (key == null)
            {
                return NotFound();
            }

            db.Keys.Remove(key);
            db.SaveChanges();

            return Ok(key);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeyExists(int id)
        {
            return db.Keys.Count(e => e.Id == id) > 0;
        }
    }
}