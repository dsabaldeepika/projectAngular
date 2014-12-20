using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JRDEV2.Web.Controllers
{
    public class apiSearchController : ApiController
    {
        // GET api/<controller>
        [AllowAnonymous]
        public IHttpActionResult Get(string query)
        {
             ISearchAdapter _adapter = new SearchAdapter();
             SearchVM search = _adapter.search(query);

            return Ok(search);
        }
    }
}
