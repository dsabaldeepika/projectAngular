using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class JobFilterByCompanyDataAdapter : IJobFilterByCompanyAdapter
    {
        //For searching by companyId associated with job
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Job> GetJobs(int itemsPerPage, int currentPage, int searchNum)
        {
            List<Job> model = new List<Job>();
            var q = db.Jobs.Where(c => c.CompanyId==(searchNum));
            model = q.
                Take(itemsPerPage)
                .OrderBy(j => j.JobTitle)
                .Skip(itemsPerPage * currentPage)
                .ToList();
            return model;
        }
    }
}