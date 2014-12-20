using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JRDEV2.Web.Models;
using JRDEVDataModels;

namespace JRDEV2.Web.Adapters.Interfaces
{
    interface IJobAppliedAdapter
    {
        List<JobAppliedVM> GetJobsApplied(string userid);
    }
}