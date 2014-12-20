using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface IApplicationAdapter
    {
        List<Application> GetApplication();
        Application GetApplication(int id);
        Application PostNewApplication(ApplyForJobVM newApplication, string userid);
        Application PutApplication(int id, Application newApplication);
        Application DeleteApplication(int id);
        bool PostAllApplications(List<ApplyToAllJobsVM> newApplications, string userid);
    }

}
