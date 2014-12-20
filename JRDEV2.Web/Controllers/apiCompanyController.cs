using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using JRDEVData;
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
    public class apiCompanyController : ApiController
    {
        ICompanyAdapter _adapter;
        public apiCompanyController()
        {
            _adapter = new CompanyDataAdapter();
        }

        public apiCompanyController(ICompanyAdapter adapter)
        {
            _adapter = adapter;
        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            
            var companies = _adapter.GetCompanies();
            return Ok(companies);
        }

        // GET api/<controller>/5
        [Authorize(Roles = UserRoles.COMPANYADMIN_COMPANYUSER_SITEADMIN)]
        public IHttpActionResult Get(int id)
        {
            CompanyVM company = new CompanyVM();
            var userID = User.Identity.GetUserId();
            company = _adapter.GetCompany(id, userID);
            if (company == null)
            {
                return NotFound();
            }
            return Ok(company);
        }

        // POST api/<controller>
        [AllowAnonymous]
        public IHttpActionResult Post([FromBody]CompanyVM newCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.PostNewCompany(newCompany);

            return CreatedAtRoute("apiCompany", new { model.CompanyId }, model);
        }

        [Authorize(Roles = UserRoles.COMPANYADMIN_SITEADMIN)]
        public IHttpActionResult Put([FromBody]CompanyVM existingCompany)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _adapter.PutNewCompanyUser(existingCompany);

            return CreatedAtRoute("apiCompany", new { result }, result);
        }

        // PATCH api/<controller>/5
        [Authorize(Roles = UserRoles.COMPANYADMIN_SITEADMIN)]
        public IHttpActionResult PATCH(int id, [FromBody]CompanyVM newCompany)
        {
            var userID = User.Identity.GetUserId();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var model = _adapter.PatchCompany(id, userID, newCompany);
            return Ok();
        }

        // DELETE api/<controller>/5
        [Authorize(Roles = UserRoles.SITEADMIN)]
        public IHttpActionResult Delete(int id)
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //Company company = new Company();
            //company = db.Companies.Find(id);
            //company.Hidden = true;

            //db.SaveChanges();
            //return Ok(company);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_adapter.DeleteCompany(id));
        }
    }
}