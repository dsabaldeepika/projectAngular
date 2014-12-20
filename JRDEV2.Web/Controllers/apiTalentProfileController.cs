using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using JRDEVDataModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JRDEV2.Web.Controllers
{
    //[Authorize(Roles=UserRoles.TALENTUSER)]
    public class apiTalentProfileController : ApiController
    {
        private ITalentProfileAdapter _adapter;
        
        public apiTalentProfileController()
        {
            _adapter = new TalentProfileDataAdapter();
        }

        public apiTalentProfileController(ITalentProfileAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var TalentID = User.Identity.GetUserId();
            var talentVM = _adapter.GetTalentVM(TalentID);
            return Ok(talentVM);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(string id)
        {
            TalentVM talentVM = new TalentVM();
            talentVM = _adapter.GetTalentVM(id);
            if (talentVM == null)
            {
                return NotFound();
            }
            return Ok(talentVM);
        }

        // POST api/<controller>
        [AllowAnonymous]
        public IHttpActionResult Post([FromBody]TalentVM newTalent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewTalentProfile(newTalent);

            return Ok();
        }

        //PATCH api/<controller>/5
        [Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]
        public IHttpActionResult Patch([FromBody]TalentVM newTalentVM)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.PATCHTalentVM(userID, newTalentVM);
            return Ok();
        }
        //Created by GeorgeW. 5/5/14
        //=============================================================================
        //[Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]
        //public IHttpActionResult Patch(int id, [FromBody]TalentVM newTalentVM)
        //{
        //    var userID = User.Identity.GetUserId();
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var model = _adapter.PATCHTalentSettings(id, userID, newTalentVM);
        //    return Ok();
        //}

        //=============================================================================

        
        public IHttpActionResult Delete(int id)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.DeleteTalentProfile(id);
            return Ok();
        }
    }
}
