using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SongExplorer.Model;
using Microsoft.AspNet.Identity;

namespace SongExplorer.Api.Controllers
{
    [Authorize]
    public class SongsController : ApiController
    {
        private SongExplorerEntities db = new SongExplorerEntities();

        // GET: api/Songs
        public IQueryable<Song> GetSongs()
        {
            var currentUserId = User.Identity.GetUserId();
            return db.Songs.Where(song => song.UserId == currentUserId);
        }

        // GET: api/Songs/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult GetSong(int id)
        {
            Song song = db.Songs.Where(s => s.Id == id && s.UserId == User.Identity.GetUserId()).FirstOrDefault();
            if (song == null)
            {
                return NotFound();
            }

            return Ok(song);
        }

        // PUT: api/Songs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != song.Id)
            {
                return BadRequest();
            }

            var originalSong = db.Songs.Find(id);
            if (originalSong.UserId != User.Identity.GetUserId())
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(id))
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

        // POST: api/Songs
        [ResponseType(typeof(Song))]
        public IHttpActionResult PostSong(Song song)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            song.UserId = User.Identity.GetUserId();

            db.Songs.Add(song);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = song.Id }, song);
        }

        // DELETE: api/Songs/5
        [ResponseType(typeof(Song))]
        public IHttpActionResult DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return NotFound();
            }

            if (song.UserId != User.Identity.GetUserId())
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            db.Songs.Remove(song);
            db.SaveChanges();

            return Ok(song);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SongExists(int id)
        {
            return db.Songs.Count(e => e.Id == id) > 0;
        }
    }
}