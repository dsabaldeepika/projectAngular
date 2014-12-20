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
    public class apiSkillController : ApiController
    {
        ISkillAdapter _adapter;
        public apiSkillController()
        {
            _adapter = new SkillDataAdapter();
        }

        public apiSkillController(ISkillAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var skill = _adapter.GetSkill();
            return Ok(skill);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Skill skill = new Skill();
            skill = _adapter.GetSkill(id);
            if (skill == null)
            {
                return NotFound();
            }
            return Ok(skill);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Skill newSkill)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewSkill(newSkill);

            return CreatedAtRoute("apiSkill", new { newSkill.SkillId }, newSkill);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Skill newSkill)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutSkill(id, newSkill));
        }

        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.DeleteSkill(id));
        }
    }
}
