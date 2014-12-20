using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.MockDataAdapters
{
    //public class JobStatusMockAdapter : IJobStatusAdapter

    //{
    //    public List<JobStatus> GetJobStatuses()
    //    {
    //        List<JobStatus> jobstatus = new List<JobStatus>()
    //        {
    //            new JobStatus { JobStatusId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Name = "Programmer", UserCreatedId = "1", UserUpdatedId = "1" },
    //            new JobStatus { JobStatusId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Name = "Programmer", UserCreatedId = "2", UserUpdatedId = "2" }
    //        };
    //        return jobstatus;
    //    }

    //    public JobStatus GetJobStatus(int id)
    //    {
    //        JobStatus jobstatus = new JobStatus()
    //        {
    //            JobStatusId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Name = "Programmer", UserCreatedId = "2", UserUpdatedId = "2"
    //        };

    //        return jobstatus;
    //    }

    //    public JobStatus PutJobStatus(int id, JobStatus newJobStatus)
    //    {
    //        List<JobStatus> jobstatuses = new List<JobStatus>()
    //        {
    //            new JobStatus { JobStatusId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Name = "Programmer", UserCreatedId = "1", UserUpdatedId = "1" },
    //            new JobStatus { JobStatusId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Name = "Programmer", UserCreatedId = "2", UserUpdatedId = "2" }
    //        };
    //        JobStatus jobstatus = new JobStatus();
    //        jobstatus.JobStatusId = newJobStatus.JobStatusId;
    //        jobstatus.DateCreated = newJobStatus.DateCreated;
    //        jobstatus.DateUpdated = newJobStatus.DateUpdated;
    //        jobstatus.Name = newJobStatus.Name;
    //        jobstatus.UserCreatedId = newJobStatus.UserCreatedId;
    //        jobstatus.UserUpdatedId = newJobStatus.UserUpdatedId;
           
            
    //            return jobstatuses.FirstOrDefault();
    //    }

    //    public JobStatus DeleteJobStatus(int id)
    //    {
    //        JobStatus jobstatus = new JobStatus();
    //        jobstatus.Hidden = true;
    //        return jobstatus;
    //    }
    //}
}