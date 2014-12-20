using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using JRDEVDataModels;
using JRDEVData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{

    public class JobAppliedAdapter : IJobAppliedAdapter
    {
        public List<JobAppliedVM> GetJobsApplied(string userid)
        {
            ApplicationDbContext db = new ApplicationDbContext();            
            
            var q = db.Applications.Where(a => a.UserId == userid)
                .Select(a => new JobAppliedVM{
                    JobTitle = a.Job.JobTitle,
                    Description = a.Job.Description,
                    DateSubmitted = a.DateCreated,
                    JobId = a.JobId,
                    CompanyId = a.Job.CompanyId,
                    CompanyName = a.Job.Company.CompanyName
                });

            //var j = db.Jobs.Where(a => a.JobId == q.JobId).ToList;

            //var c = db.Companies.Where(w => w.CompanyId == );
                        
            List<JobAppliedVM> jobsappliedList = q.ToList();            
            return jobsappliedList;
        }
    }
}