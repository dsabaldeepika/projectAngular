using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface IJobsAdapter
    {
        
        List<JobVM> GetJobs(int? companyId, string userID);
        List<ApplicantVm> GetApplicant(int id);
        JobVM GetJob(int id); //rm
        List<Job> GetJobs(int itemsPerPage, int currentPage, string searchText);
        Job PostNewJob(string userid, JobVM newJob);//dlr added to support userid on adapter
        Job PutNewJob(int id, Job newJob);
        Job DeleteJob(int id);
    }
}
