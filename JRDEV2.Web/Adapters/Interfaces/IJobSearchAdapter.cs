using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface IJobSearchAdapter
    {
        List<Job> GetJobs(int itemsPerPage, int currentPage, string searchText);
    }
}