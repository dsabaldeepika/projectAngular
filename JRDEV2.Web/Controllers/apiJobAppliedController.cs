using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using JRDEVDataModels;

namespace JRDEV2.Web.Controllers
{
    public class apiJobAppliedController : ApiController
    {
        // GET api/<controller>
        [AllowAnonymous]
        public IHttpActionResult Get()
        {
            IJobAppliedAdapter _adapter = new JobAppliedAdapter();
            var userid = User.Identity.GetUserId();
            List<JobAppliedVM> jobappliedList = _adapter.GetJobsApplied(userid);

            return Ok(jobappliedList);
        }
    }
}
