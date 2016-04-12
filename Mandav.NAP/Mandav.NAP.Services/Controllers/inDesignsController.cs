using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Mandav.NAP.Services;

namespace Mandav.NAP.Services.Controllers
{
    public class inDesignsController : ApiController
    {
        private NAPEntities db = new NAPEntities();

        // GET: api/inDesigns
        public IQueryable<inDesign> GetinDesigns()
        {
            return db.inDesigns;
        }

        // GET: api/inDesigns/5
        [ResponseType(typeof(inDesign))]
        public async Task<IHttpActionResult> GetinDesign(int id)
        {
            inDesign inDesign = await db.inDesigns.FindAsync(id);
            if (inDesign == null)
            {
                return NotFound();
            }

            return Ok(inDesign);
        }

        // GET: api/inDesigns/5
        [ResponseType(typeof(inDesign))]
        public async Task<IHttpActionResult> GetinDesignByUser(int userID)
        {
            List<inDesign> inDesign =  db.inDesigns.Where(x => x.AssignedTo == userID).ToList();
            if (inDesign == null)
            {
                return NotFound();
            }

            return Ok(inDesign);
        }


        // PUT: api/inDesigns/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutinDesign(int id, inDesign inDesign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != inDesign.JobID)
            {
                return BadRequest();
            }

            db.Entry(inDesign).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!inDesignExists(id))
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

        // POST: api/inDesigns
        [ResponseType(typeof(inDesign))]
        public async Task<IHttpActionResult> PostinDesign(inDesign inDesign)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.inDesigns.Add(inDesign);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (inDesignExists(inDesign.JobID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = inDesign.JobID }, inDesign);
        }

        // DELETE: api/inDesigns/5
        [ResponseType(typeof(inDesign))]
        public async Task<IHttpActionResult> DeleteinDesign(int id)
        {
            inDesign inDesign = await db.inDesigns.FindAsync(id);
            if (inDesign == null)
            {
                return NotFound();
            }

            db.inDesigns.Remove(inDesign);
            await db.SaveChangesAsync();

            return Ok(inDesign);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool inDesignExists(int id)
        {
            return db.inDesigns.Count(e => e.JobID == id) > 0;
        }
    }
}