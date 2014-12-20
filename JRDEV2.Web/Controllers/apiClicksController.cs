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
    [Authorize]
    public class apiClicksController : ApiController
    {
        IClickAdapter _adapter;
        public apiClicksController()
        {
            _adapter = new ClickDataAdapter();
        }

        public apiClicksController(IClickAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        [Authorize(Roles=UserRoles.TALENTUSER_COMPANYADMIN_SITEADMIN)]
        public IHttpActionResult Get()
        {
            var clicks = _adapter.GetClicks();
            return Ok(clicks);
        }

        // GET api/<controller>/5
        [Authorize(Roles = UserRoles.TALENTUSER_SITEADMIN)]
        public IHttpActionResult Get(int id)
        {
            Click click = new Click();
            click = _adapter.GetClick(id);
            if (click == null)
            {
                return NotFound();
            }
            return Ok(click);
        }

        // POST api/<controller>
        [Authorize(Roles = UserRoles.COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        public IHttpActionResult Post([FromBody]Click newClick)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewClick(newClick);
            
           //return CreatedAtRoute("apiClicks", new { newClick.ClickId }, newClick);

            return Ok(model);
        }

        // PUT api/<controller>/5
        [Authorize(Roles = UserRoles.COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        public IHttpActionResult Put(int id, [FromBody]Click newClick)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutClick(id, newClick));
        }

        [Authorize(Roles = UserRoles.SITEADMIN)]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.DeleteClick(id));
        }
    }
}