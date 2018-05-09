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
    public class SetListsController : ApiController
    {
        private SongExplorerEntities db = new SongExplorerEntities();

        // GET: api/SetLists
        public IQueryable<SetList> GetSetLists()
        {
            return db.SetLists;
        }

        // GET: api/SetLists/5
        [ResponseType(typeof(SetList))]
        public IHttpActionResult GetSetList(int id)
        {
            SetList setList = db.SetLists.Find(id);
            if (setList == null)
            {
                return NotFound();
            }

            return Ok(setList);
        }

        // PUT: api/SetLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSetList(int id, SetList setList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != setList.Id)
            {
                return BadRequest();
            }

            db.Entry(setList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SetListExists(id))
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

        // POST: api/SetLists
        [ResponseType(typeof(SetList))]
        public IHttpActionResult PostSetList(SetList setList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SetLists.Add(setList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = setList.Id }, setList);
        }

        // DELETE: api/SetLists/5
        [ResponseType(typeof(SetList))]
        public IHttpActionResult DeleteSetList(int id)
        {
            SetList setList = db.SetLists.Find(id);
            if (setList == null)
            {
                return NotFound();
            }

            db.SetLists.Remove(setList);
            db.SaveChanges();

            return Ok(setList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SetListExists(int id)
        {
            return db.SetLists.Count(e => e.Id == id) > 0;
        }
    }
}