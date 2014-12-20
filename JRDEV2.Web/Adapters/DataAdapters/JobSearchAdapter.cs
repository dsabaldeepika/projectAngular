using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class JobSearchAdapter : IJobSearchAdapter
    {
        //For searching by text in several fields       

        public List<Job> GetJobs(int itemsPerPage, int currentPage, string searchText)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            List<Job> model = new List<Job>();

            var q = db.Jobs.Where(c => c.JobTitle.Contains(searchText));
            q = db.Jobs.Where(c => c.Company.CompanyName.Contains(searchText)).Union(q);
            q = db.Jobs.Where(c => c.Description.Contains(searchText)).Union(q);
            q = q.OrderByDescending(j => j.DateCreated)
                .Skip(itemsPerPage * currentPage)
                .Take(itemsPerPage);

            model = q.ToList();                

            return model;
        }
    }
}