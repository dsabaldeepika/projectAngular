using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface IJobFilterByCompanyAdapter
    {
        List<Job> GetJobs(int itemsPerPage, int currentPage, int searchNum);
    }
}
