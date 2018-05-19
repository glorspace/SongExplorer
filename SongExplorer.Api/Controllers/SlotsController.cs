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
    public class SlotsController : ApiController
    {
        private SongExplorerEntities db = new SongExplorerEntities();

        // GET: api/Slots
        public IQueryable<Slot> GetSlots()
        {
            var currentUserId = User.Identity.GetUserId();
            return db.Slots.Where(slot => slot.UserId == currentUserId);
        }

        // GET: api/Slots/5
        [ResponseType(typeof(Slot))]
        public IHttpActionResult GetSlot(int id)
        {
            Slot slot = db.Slots.SingleOrDefault(s => s.Id == id && s.UserId == User.Identity.GetUserId());
            if (slot == null)
            {
                return NotFound();
            }

            return Ok(slot);
        }

        // PUT: api/Slots/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSlot(int id, Slot slot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != slot.Id)
            {
                return BadRequest();
            }

            var originalSlot = db.Slots.Find(id);
            if (originalSlot.UserId != User.Identity.GetUserId())
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            db.Entry(slot).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SlotExists(id))
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

        // POST: api/Slots
        [ResponseType(typeof(Slot))]
        public IHttpActionResult PostSlot(Slot slot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            slot.UserId = User.Identity.GetUserId();

            db.Slots.Add(slot);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = slot.Id }, slot);
        }

        // DELETE: api/Slots/5
        [ResponseType(typeof(Slot))]
        public IHttpActionResult DeleteSlot(int id)
        {
            Slot slot = db.Slots.Find(id);
            if (slot == null)
            {
                return NotFound();
            }

            if (slot.UserId != User.Identity.GetUserId())
            {
                return StatusCode(HttpStatusCode.Forbidden);
            }

            db.Slots.Remove(slot);
            db.SaveChanges();

            return Ok(slot);
        }

		[HttpPost]
		[Route("api/Slots/PostDelete/{id}")]
		public IHttpActionResult PostDeleteSlot(int id)
		{
			Slot slot = db.Slots.Find(id);
			if (slot == null)
			{
				return NotFound();
			}

			if (slot.UserId != User.Identity.GetUserId())
			{
				return StatusCode(HttpStatusCode.Forbidden);
			}

			db.Slots.Remove(slot);
			db.SaveChanges();

			return Ok(slot);
		}

		protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SlotExists(int id)
        {
            return db.Slots.Count(e => e.Id == id) > 0;
        }
    }
}