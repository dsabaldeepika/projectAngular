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
    public class apiJobSearchController : ApiController
    {
        IJobSearchAdapter _adapter;
        public apiJobSearchController()
        {
            _adapter = new JobSearchAdapter();
        }

        public apiJobSearchController(IJobSearchAdapter adapter)
        {
            _adapter = adapter;
        }

        public IHttpActionResult Post([FromBody]SearchOptionsModel searchObject)
        {
            var jobs = _adapter.GetJobs(searchObject.ItemsPerPage, searchObject.CurrentPage, searchObject.SearchText);
            return Ok(jobs);
        }
    }
}
