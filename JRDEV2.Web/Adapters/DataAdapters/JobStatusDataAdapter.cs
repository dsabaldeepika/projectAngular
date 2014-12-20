using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    //public class JobStatusDataAdapter : IJobStatusAdapter
    //{
    //    ApplicationDbContext db = new ApplicationDbContext();
    //    public List<JRDEVDataModels.JobStatus> GetJobStatuses()
    //    {
    //        List<JobStatus> model = new List<JobStatus>();
    //        //model = db.JobStatuses
    //        //                //.Where(j=>j.Hidden == false)
    //        //                .ToList();
    //        return model;
    //    }

    //    public JRDEVDataModels.JobStatus GetJobStatus(int id)
    //    {
    //        JobStatus jobStatus = new JobStatus();
    //        //jobStatus = db.JobStatuses
    //        //                        .Where(j=>j.JobStatusId == id)
    //        //                        //.Where(j=>j.Hidden == false)
    //        //                        .FirstOrDefault();
    //        return jobStatus;
    //    }

    //    public JRDEVDataModels.JobStatus PutJobStatus(int id, JRDEVDataModels.JobStatus newJobStatus)
    //    {
    //        JobStatus jobStatus = new JobStatus();
    //        //jobStatus = db.JobStatuses
    //        //                        .Where(j => j.JobStatusId == id)
    //        //                        //.Where(j => j.Hidden == false)
    //        //                        .FirstOrDefault();
    //        //jobStatus.JobStatusId = newJobStatus.JobStatusId;
    //        //jobStatus.Name = newJobStatus.Name;
    //        ////jobStatus.DateCreated = DateTime.Now;
    //        //jobStatus.DateUpdated = DateTime.Now;
    //        ////jobStatus.UserCreatedId = newJobStatus.UserCreatedId;
    //        //jobStatus.UserUpdatedId = newJobStatus.UserUpdatedId;
    //        //db.SaveChanges();
    //        return jobStatus;
    //    }

    //    public JRDEVDataModels.JobStatus DeleteJobStatus(int id)
    //    {
    //        JobStatus jobStatus = new JobStatus();
    //        //jobStatus = db.JobStatuses
    //        //                        .Where(j=>j.JobStatusId == id)
    //        //                        //.Where(j=>j.Hidden == false)
    //        //                        .FirstOrDefault();
    //        //jobStatus.Hidden = true;
    //        //db.SaveChanges();
    //        return jobStatus;
    //    }
    //}
}