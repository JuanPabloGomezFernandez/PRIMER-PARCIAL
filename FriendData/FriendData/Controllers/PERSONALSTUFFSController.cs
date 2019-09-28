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
using FriendData.Models;

namespace FriendData.Controllers
{
    public class PERSONALSTUFFSController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PERSONALSTUFFS
        public IQueryable<PERSONALSTUFFS> GetPERSONALSTUFFS()
        {
            return db.PERSONALSTUFFS;
        }

        // GET: api/PERSONALSTUFFS/5
        [ResponseType(typeof(PERSONALSTUFFS))]
        public IHttpActionResult GetPERSONALSTUFFS(int id)
        {
            PERSONALSTUFFS pERSONALSTUFFS = db.PERSONALSTUFFS.Find(id);
            if (pERSONALSTUFFS == null)
            {
                return NotFound();
            }

            return Ok(pERSONALSTUFFS);
        }

        // PUT: api/PERSONALSTUFFS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPERSONALSTUFFS(int id, PERSONALSTUFFS pERSONALSTUFFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pERSONALSTUFFS.FriendID)
            {
                return BadRequest();
            }

            db.Entry(pERSONALSTUFFS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PERSONALSTUFFSExists(id))
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

        // POST: api/PERSONALSTUFFS
        [ResponseType(typeof(PERSONALSTUFFS))]
        public IHttpActionResult PostPERSONALSTUFFS(PERSONALSTUFFS pERSONALSTUFFS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PERSONALSTUFFS.Add(pERSONALSTUFFS);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pERSONALSTUFFS.FriendID }, pERSONALSTUFFS);
        }

        // DELETE: api/PERSONALSTUFFS/5
        [ResponseType(typeof(PERSONALSTUFFS))]
        public IHttpActionResult DeletePERSONALSTUFFS(int id)
        {
            PERSONALSTUFFS pERSONALSTUFFS = db.PERSONALSTUFFS.Find(id);
            if (pERSONALSTUFFS == null)
            {
                return NotFound();
            }

            db.PERSONALSTUFFS.Remove(pERSONALSTUFFS);
            db.SaveChanges();

            return Ok(pERSONALSTUFFS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PERSONALSTUFFSExists(int id)
        {
            return db.PERSONALSTUFFS.Count(e => e.FriendID == id) > 0;
        }
    }
}