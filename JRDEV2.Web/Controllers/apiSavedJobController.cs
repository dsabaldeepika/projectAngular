using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using JRDEV2.Web.Models;

namespace JRDEV2.Web.Controllers
{
    public class apiSavedJobController : ApiController
    {
        ISavedJobAdapter _adapter = new SavedJobDataAdapter();
        //public apiSavedJobController()
        //{
        //    _adapter = new SavedJobDataAdapter();
        //}

        //public apiSavedJobController(ISavedJobAdapter adapter)
        //{
        //    _adapter = adapter;
        //}

        // GET api/<controller>
        //public IHttpActionResult Get()
        //{
        //    var savedJob = _adapter.GetSavedJob();
        //    return Ok(savedJob);
        //}

        // GET api/<controller>/5
        //public IHttpActionResult Get(int id)
        //{
        //    SavedJob savedJob = new SavedJob();
        //    savedJob = _adapter.GetSavedJob(id);
        //    if (savedJob == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(savedJob);
        //}
        public IHttpActionResult Get()
        {
  

          //  SavedJob savedJob = new SavedJob();
            var userID = User.Identity.GetUserId();
            List<SavedJobVM> savedJobs = _adapter.GetSavedJobs(userID);
          //  savedJob = _adapter.GetSavedJob(id);
            if (savedJobs == null)
            {
                return NotFound();
            }
            return Ok(savedJobs);
        }
        // POST api/<controller>
        public IHttpActionResult Post(int id)
        {
            var userid = User.Identity.GetUserId();//DLR get id from token
            var model = _adapter.PostNewSavedJob(id, userid);

            return Ok();
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]SavedJob newSavedJob)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutSavedJob(id, newSavedJob));
        }

        public IHttpActionResult Delete(int id)
        {
            var userID = User.Identity.GetUserId();
            return Ok(_adapter.DeleteSavedJob(id,userID));
        }
    }
}
