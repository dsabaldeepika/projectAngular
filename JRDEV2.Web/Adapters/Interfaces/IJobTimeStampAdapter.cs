using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface IJobTimeStampAdapter
    {
        List<JobTimeStamp> GetJobTimeStamp();
        JobTimeStamp GetJobTimeStamp(int id);
        JobTimeStamp PostNewJobTimeStamp(JobTimeStamp newJobTimeStamp);
        JobTimeStamp PutJobTimeStamp(int id, JobTimeStamp newJobTimeStamp);
        JobTimeStamp DeleteJobTimeStamp(int id);

    }
}