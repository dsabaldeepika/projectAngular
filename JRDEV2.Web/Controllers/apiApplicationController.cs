using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace JRDEV2.Web.Controllers
{
    [Authorize]
    public class apiApplicationController : ApiController
    {
        IApplicationAdapter _adapter;
        public apiApplicationController()
        {
            _adapter = new ApplicationDataAdapter();
        }

        public apiApplicationController(IApplicationAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var application = _adapter.GetApplication();
            return Ok(application);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Application application = new Application();
            application = _adapter.GetApplication(id);
            if (application == null)
            {
                return NotFound();
            }
            return Ok(application);
        }

        // POST api/<controller>
        [Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]
        public IHttpActionResult Post([FromBody]ApplyForJobVM newApplication)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var userid = User.Identity.GetUserId();
            var model = _adapter.PostNewApplication(newApplication, userid);

            return Ok();
        }
        // POST api/<controller>
        //[Authorize(Roles = UserRoles.TALENTUSER)]
        //public IHttpActionResult Put(List<ApplyToAllJobsVM> newApplications)
        //{
        //    if (!ModelState.IsValid)
        //    {

        //        return BadRequest(ModelState);
        //    }

        //    var userid = User.Identity.GetUserId();
        //    var model = _adapter.PostAllApplications(newApplications, userid);

        //    return Ok();
        //}
        [Authorize(Roles = UserRoles.TALENTUSER)]
        public IHttpActionResult Put(List<ApplyToAllJobsVM> newApplications)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }

            var userid = User.Identity.GetUserId();
            var model = _adapter.PostAllApplications(newApplications, userid);

            return Ok();
        }
        //// PUT api/<controller>/5
        //[Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]
        //public IHttpActionResult Put(int id, [FromBody]Application newApplication)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return Ok(_adapter.PutApplication(id, newApplication));
        //}

        [Authorize(Roles = UserRoles.SITEADMIN)]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.DeleteApplication(id));
        }
    }
}
