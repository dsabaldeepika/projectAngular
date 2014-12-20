using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class JobTimeStampDataAdapter : IJobTimeStampAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<JobTimeStamp> GetJobTimeStamp()
        {
            List<JobTimeStamp> model = new List<JobTimeStamp>();
            model = db.JobTimeStamp
                            //.Where(j=>j.Hidden == false)
                            .ToList();
            return model;

        }
        public JobTimeStamp GetJobTimeStamp(int id)
        {
            JobTimeStamp model = new JobTimeStamp();

            model = db.JobTimeStamp
                           .Where(j => j.JobTimeStampId == id)
                           //.Where(j=>j.Hidden == false)
                           .FirstOrDefault();
            return model;
        }

        public JobTimeStamp PostNewJobTimeStamp(JobTimeStamp newjobTimeStamp)
        {
            JobTimeStamp jobTimeStamp = new JobTimeStamp();
            //set variables
            db.JobTimeStamp.Add(jobTimeStamp);
            db.SaveChanges();

            return newjobTimeStamp; 
        }

        public JobTimeStamp PutJobTimeStamp(int id, JobTimeStamp newJobTimeStamp)
        {
            db.JobTimeStamp.Where(j=>j.JobTimeStampId == id)
                        //.Where(j=>j.Hidden == false)
                        .FirstOrDefault();
            JobTimeStamp jobTimeStamp = new JobTimeStamp();
            //Set Variables
            db.SaveChanges();
            return newJobTimeStamp;
        }

        public JobTimeStamp DeleteJobTimeStamp(int id)
        {           
            JobTimeStamp jobTimeStamp = new JobTimeStamp();
            jobTimeStamp = db.JobTimeStamp
                            .Where(j => j.JobTimeStampId == id)
                            //.Where(j=>j.Hidden == false)
                            .FirstOrDefault();
            jobTimeStamp.IsDeleted = true;
            db.SaveChanges();
            return db.JobTimeStamp.FirstOrDefault();
        }
    }
}