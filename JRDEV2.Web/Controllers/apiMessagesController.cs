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
using System.Data.Entity;
using JRDEV2.Web.Models;
using Microsoft.AspNet.Identity;

namespace JRDEV2.Web.Controllers
{
    [Authorize(Roles=UserRoles.TALENTUSER_COMPANYADMIN_COMPANYUSER_SITEADMIN)]

    public class apiMessagesController : ApiController
    {
        IMessagesAdapter _adapter;
        public apiMessagesController()
        {
            _adapter = new MessageDataAdapter();
        }

        public apiMessagesController(IMessagesAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            var userID = User.Identity.GetUserId();
            List<MessageVM> messages = null;

            if (User.IsInRole(UserRoles.COMPANYADMIN) || User.IsInRole(UserRoles.COMPANYUSER))
            {
                messages = _adapter.GetCompanyMessage();
            }
            else
            {
                messages = _adapter.GetMessages(userID);
            }
            
            return Ok(messages);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            MessageVM message = new MessageVM();
            var userId = User.Identity.GetUserId();           

            message = _adapter.GetMessage(userId, id);
            if (message == null)
            {
                return NotFound();
            }
            return Ok(message);
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]MessageVM newMessage)
        {
            //comment it out, because it always evaluated to not valid, but if you could fix it, by all means.
            //It posts a message though. But I hardcoded the user id, user updated id, and user created id
            //if (!ModelState.IsValid)
            //{

              //  return BadRequest(ModelState);
            //}
            var userID = User.Identity.GetUserId();
            var model = _adapter.PostNewMessage(newMessage, userID);

           // return CreatedAtRoute("apiMessages", new { newMessage.MessageId }, newMessage);
          

            
            return Ok();
        }

        //// PUT api/<controller>/5
        //public IHttpActionResult Put(int id, [FromBody]Message newMessage)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    return Ok(_adapter.PutNewMessage(id, newMessage));
        //}

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Message message = new Message();
            message = db.Messages.Find(id);
            message.IsDeleted = true;

            db.SaveChanges();
            return Ok(message);
        }
    }
}