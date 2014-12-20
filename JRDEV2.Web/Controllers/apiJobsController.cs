using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using JRDEV2.Web.Models;
using Microsoft.AspNet.Identity;

namespace JRDEV2.Web.Controllers
{
    [Authorize]
    public class apiJobsController : ApiController
    {
        IJobsAdapter _adapter;
        public apiJobsController()
        {
            _adapter = new JobDataAdapter();
        }

        public apiJobsController(IJobsAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        //[Authorize(Roles = UserRoles.TALENTUSER_COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        public IHttpActionResult Get(int? companyId)
        {
            var userID = User.Identity.GetUserId();
            var jobs = _adapter.GetJobs(companyId, userID);
            return Ok(jobs);
        }
        // GET api/<controller>/5
        //[Authorize(Roles = UserRoles.TALENTUSER_COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        
        //public IHttpActionResult Get(int id)
        //{
        //    Job job = new Job();
        //    job = _adapter.GetJob(id);
        //    if (job == null)
        //    {
        //          return NotFound();
        //    }
        //          return Ok(job);
        //}

        // GET api/<controller>
        public IHttpActionResult Get(int id)
        {

            var model = _adapter.GetJob(id);
            return Ok(model);
        }

        // POST api/<controller>
        [Authorize(Roles = UserRoles.COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        public IHttpActionResult Post([FromBody]JobVM newJob)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var user = User.Identity.GetUserId();
            var model = _adapter.PostNewJob(user, newJob);

            //return CreatedAtRoute("JobsApi", new { model.JobId }, newJob);
            return Ok();
        }

        // PUT api/<controller>/5
        [Authorize(Roles = UserRoles.COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        public IHttpActionResult Put(int id, [FromBody]Job newJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutNewJob(id, newJob));
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = UserRoles.COMPANYADMIN_SITEADMIN)]
        public IHttpActionResult Delete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Job job = new Job();
            job = db.Jobs.Find(id);
            job.IsDeleted = true;

            db.SaveChanges();
            return Ok(job);
        }
    }
}