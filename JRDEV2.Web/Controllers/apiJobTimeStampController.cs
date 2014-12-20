using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JRDEV2.Web.Controllers
{
    [Authorize(Roles=UserRoles.COMPANYADMIN_COMPANYUSER_SITEADMIN)]
    public class apiJobTimeStampController : ApiController
    {
        IJobTimeStampAdapter _adapter;
        public apiJobTimeStampController()
        {
            _adapter = new JobTimeStampDataAdapter();
        }

        public apiJobTimeStampController(IJobTimeStampAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var jobTimeStamps = _adapter.GetJobTimeStamp();
            return Ok(jobTimeStamps);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            JobTimeStamp jobTimeStamp = new JobTimeStamp();
            jobTimeStamp = _adapter.GetJobTimeStamp(id);
            if (jobTimeStamp == null)
            {
                return NotFound();
            }
            return Ok(jobTimeStamp);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]JobTimeStamp newJobTimeStamp)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewJobTimeStamp(newJobTimeStamp);

            return CreatedAtRoute("apiJobTimeStamp", new { newJobTimeStamp.JobTimeStampId }, newJobTimeStamp);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]JobTimeStamp newJobTimeStamp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutJobTimeStamp(id, newJobTimeStamp));
        }

        [Authorize(Roles = UserRoles.SITEADMIN)]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.DeleteJobTimeStamp(id));
        }
    }
}