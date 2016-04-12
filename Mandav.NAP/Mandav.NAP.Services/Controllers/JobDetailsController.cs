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
    public class JobDetailsController : ApiController
    {
        private NAPEntities db = new NAPEntities();

        // GET: api/JobDetails
        public IQueryable<JobDetail> GetJobDetails()
        {
            return db.JobDetails;
        }

        // GET: api/JobDetails/5
        [ResponseType(typeof(JobDetail))]
        public async Task<IHttpActionResult> GetJobDetail(int id)
        {
            JobDetail jobDetail = await db.JobDetails.FindAsync(id);
            if (jobDetail == null)
            {
                return NotFound();
            }

            return Ok(jobDetail);
        }

        // PUT: api/JobDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutJobDetail(int id, JobDetail jobDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != jobDetail.JobDetailId)
            {
                return BadRequest();
            }

            db.Entry(jobDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobDetailExists(id))
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

        // POST: api/JobDetails
        [ResponseType(typeof(JobDetail))]
        public async Task<IHttpActionResult> PostJobDetail(JobDetail jobDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.JobDetails.Add(jobDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (JobDetailExists(jobDetail.JobDetailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = jobDetail.JobDetailId }, jobDetail);
        }

        // DELETE: api/JobDetails/5
        [ResponseType(typeof(JobDetail))]
        public async Task<IHttpActionResult> DeleteJobDetail(int id)
        {
            JobDetail jobDetail = await db.JobDetails.FindAsync(id);
            if (jobDetail == null)
            {
                return NotFound();
            }

            db.JobDetails.Remove(jobDetail);
            await db.SaveChangesAsync();

            return Ok(jobDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool JobDetailExists(int id)
        {
            return db.JobDetails.Count(e => e.JobDetailId == id) > 0;
        }
    }
}