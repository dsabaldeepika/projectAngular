using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class SearchAdapter : ISearchAdapter
    {
        public SearchVM search(string query)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            
            SearchVM search = new SearchVM();

            var qJobs = db.Jobs
                .Where(j => j.JobTitle.Contains(query)
                            || j.Description.Contains(query)
                            || j.Company.CompanyName.Contains(query))
                .Select(j => new JobVM()
                {
                    JobId = j.JobId,
                    CompanyName = j.Company.CompanyName,
                    JobTitle = j.JobTitle,
                    Description = j.Description,
                    YearsExperience = j.YearsExperience

                });

            var qCompanies = db.Companies
                .Where(c => c.CompanyName.Contains(query))
                .Select(c => new CompanyVM()
                {
                   CompanyId = c.CompanyId,
                    CompanyName = c.CompanyName,
                    Description = c.Description,
                    EmailAddress = c.EmailAddress
                })
                ;

            search.CompanyVM = qCompanies.ToList();
            search.JobVM = qJobs.ToList();

            return search;
        }
    }
}