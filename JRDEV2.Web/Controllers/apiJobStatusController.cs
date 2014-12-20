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

namespace JRDEV2.Web.Controllers
{
    //public class apiJobStatusController : ApiController
    //{
    //    IJobStatusAdapter _adapter;
    //    public apiJobStatusController()
    //    {
    //        _adapter = new JobStatusDataAdapter();
    //    }

    //    public apiJobStatusController(IJobStatusAdapter adapter)
    //    {
    //        _adapter = adapter;
    //    }

    //    // GET api/<controller>
    //    public IHttpActionResult Get()
    //    {
    //        var jobstatuses = _adapter.GetJobStatuses();
    //        return Ok(jobstatuses);
    //    }

    //    // GET api/<controller>/5
    //    public IHttpActionResult Get(int id)
    //    {
    //        JobStatus jobstatus = new JobStatus();
    //        jobstatus = _adapter.GetJobStatus(id);
    //        if (jobstatus == null)
    //        {
    //              return NotFound();
    //        }
    //              return Ok(jobstatus);
    //    }

    //    // POST api/<controller>
    //    public void Post([FromBody]JobStatus newJobStatus)
    //    {
    //        //if (!ModelState.IsValid)
    //        //{

    //        //    return BadRequest(ModelState);
    //        //}
    //        //var model = _adapter.PostNewStatus(JobVM newJobVM);

    //        //return CreatedAtRoute("apiJobStatus", new { newJobStatus.JobStatusId }, newJobStatus);
    //    }

    //    // PUT api/<controller>/5
    //   public IHttpActionResult Put(int id, [FromBody]JobStatus newJobStatus)
    //    {
    //        if (!ModelState.IsValid)
    //        {
    //            return BadRequest(ModelState);
    //        }
    //        return Ok(_adapter.PutJobStatus(id, newJobStatus));
    //    }

    //    // DELETE api/<controller>/5
    //    public IHttpActionResult Delete(int id)
    //    {
    //        ApplicationDbContext db = new ApplicationDbContext();
    //        JobStatus jobstatus = new JobStatus();
    //        jobstatus = db.JobStatuses.Find(id);
    //        jobstatus.Hidden = true;

    //        db.SaveChanges();
    //        return Ok(jobstatus);
    //    }
    //}
}