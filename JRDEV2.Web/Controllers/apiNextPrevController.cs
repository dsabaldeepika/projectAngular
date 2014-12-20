using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JRDEV2.Web.Controllers
{
    public class apiNextPrevController : ApiController
    {
        // GET api/apinextprev
        public IHttpActionResult Get()
        {
            Application app = new Application();
            CompanyVM model = new CompanyVM();
            var skip10 = model.Companies.OrderBy(x =>x.CompanyId).Skip(10).ToList();
            return Ok(skip10);
        }

         public IHttpActionResult Post([FromBody]ApplyForJobVM newApplication)
        {
        
            return Ok();
        }
    }
}
