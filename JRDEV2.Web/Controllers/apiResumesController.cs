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
using Microsoft.AspNet.Identity;
using JRDEV2.Web.Models;

namespace JRDEV2.Web.Controllers
{
    [Authorize(Roles=UserRoles.TALENTUSER)]
    public class apiResumesController : ApiController
    {
        IResumeAdapter _adapter;
        public apiResumesController()
        {
            _adapter = new ResumeDataAdapter();
        }

        public apiResumesController(IResumeAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var userid = User.Identity.GetUserId();

            var resumes = _adapter.GetResumes(userid);
            return Ok(resumes);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Resume resume = new Resume();
            resume = _adapter.GetResume(id);
            if (resume == null)
            {
                  return NotFound();
            }
                  return Ok(resume);
        }

        // POST api/<controller>
        [Authorize(Roles=UserRoles.TALENTUSER_SITEADMIN)]
        public IHttpActionResult Post( [FromBody]ResumeVM newResume)
        {
            var userID = User.Identity.GetUserId(); //Added by GeorgeW. 5/1/14
            
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewResume(userID, newResume);

            return Ok();
        }

        //Created by GeorgeW. 5/2/14
        //=============================================================================
        [Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]
        public IHttpActionResult Patch(int id, [FromBody]ResumeVM newResumeVM)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.PATCHResumeVM(id, userID, newResumeVM);
            return Ok();
        }

        //=============================================================================

        // PUT api/<controller>/5
       // [Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]                            Commented out by George W. 5/5/14
       //public IHttpActionResult Put(int id, [FromBody]Resume newResume)
       // {
       //     if (!ModelState.IsValid)
       //     {
       //         return BadRequest(ModelState);
       //     }
       //     return Ok(_adapter.PutNewResume(id, newResume));
       // }

        // DELETE api/<controller>/5
        //Edited by George W. 5/5/14
        [Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]
        public IHttpActionResult Delete(int id)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.DeleteResume(id, userID);
            return Ok();
        }
    }
}