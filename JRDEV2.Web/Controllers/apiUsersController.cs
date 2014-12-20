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
using System.Web.Http.Description;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using JRDEV2.Web.Models;

namespace JRDEV2.Web.Controllers
{
    [Authorize]
    public class apiUsersController : ApiController
    {
        // GET api/<controller>
        IUserAdapter _adapter;
        public apiUsersController()
        {
            _adapter = new UserDataAdapter();
        }

        public apiUsersController(IUserAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            User user = new User();
            var userId = User.Identity.GetUserId();
            user = _adapter.GetUser(userId);

            //user.Roles.FirstOrDefault
            //if(User.IsInRole("Administrator"))
            //{
            //    user = _adapter.GetUser(userId);
            //} else if (User.IsInRole("Employer"))
            //{
            //    user = _adapter.GetUser(userId);
            //} else if (User.IsInRole("Employee"))
            //{
            //    user = _adapter.GetUser(userId);
            //}
            //else
            //{
            //    user = _adapter.GetUser(userId);
            //}
            return Ok(user.Id);
        }

        // GET api/<controller>/5       //  Nick's code
        [Authorize(Roles = UserRoles.TALENTUSER_COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        public IHttpActionResult Get(string id)
        {
            //if (User.IsInRole("siteAdmin") || User.Identity.GetUserId() == id)
            //{
            User user = new User();
            LoggedInUserViewModel loggedInUser = new LoggedInUserViewModel();

            if (id != "Login")
            {

                user = _adapter.GetUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            else
            {
                var userId = User.Identity.GetUserId();

                loggedInUser = _adapter.GetLoggedInUserModel(userId);
                string roleName = loggedInUser.RoleName;


                if (roleName == "CompanyAdmin")
                {
                    loggedInUser.path = "companydashboard";
                }
                else if (roleName == "TalentUser")
                {
                    loggedInUser.path = "talentdashboard";
                }
                else if (roleName == "SiteAdmin")
                {
                    loggedInUser.path = "";
                }

                else if (roleName == "CompanyUser")
                {
                    loggedInUser.path = "companydashboard";
                }

                return Ok(loggedInUser);//return a variable that contains role and Id
            }
           //}
           // return Unauthorized();
        }

        // POST api/<controller>
        [Authorize(Roles = UserRoles.SITEADMIN)]
        public IHttpActionResult Post([FromBody]User newUser)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewUser(newUser);

            return CreatedAtRoute("apiUsers", new { newUser.Id }, newUser);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(string id, [FromBody]User newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.PutNewUser(id, newUser));
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = UserRoles.SITEADMIN)]
        public IHttpActionResult Delete(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = new User();
            user = db.Users.Find(id);
            user.IsDeleted = true;

            db.SaveChanges();
            return Ok(user);
        }
    }
}