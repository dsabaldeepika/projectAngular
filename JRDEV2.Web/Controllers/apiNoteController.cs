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
    public class apiNoteController : ApiController
    {
        INoteAdapter _adapter;
        public apiNoteController()
        {
            _adapter = new NoteDataAdapter();
        }

        public apiNoteController(INoteAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var note = _adapter.GetNote();
            return Ok(note);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            Note note = new Note();
            note = _adapter.GetNote(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Note newNote)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewNote(newNote);

            return CreatedAtRoute("apiNote", new { newNote.NoteId }, newNote);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Note newNote)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutNote(id, newNote));
        }

        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.DeleteNote(id));
        }
    }
}
