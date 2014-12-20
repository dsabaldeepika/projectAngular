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
    public class apiJobFilterByCompanyController : ApiController
    {
        IJobFilterByCompanyAdapter _adapter;
        public apiJobFilterByCompanyController()
        {
            _adapter = new JobFilterByCompanyDataAdapter();
        }
        public apiJobFilterByCompanyController(IJobFilterByCompanyAdapter adapter)
        {
            _adapter = adapter;
        }
        public IHttpActionResult Post([FromBody]FilterOptionsModel searchObject)
        {
            var jobs = _adapter.GetJobs(searchObject.ItemsPerPage, searchObject.CurrentPage, searchObject.SearchNum);
            return Ok(jobs);
        }
    }
}
