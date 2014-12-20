using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
     interface ISavedJobAdapter
    {
        List<SavedJobVM> GetSavedJobs(string userid);
        SavedJob GetSavedJob(int id);
        SavedJob PostNewSavedJob(int id, string userid);//DLR
        SavedJob PutSavedJob(int id, SavedJob newSavedJob);
        Boolean DeleteSavedJob(int id, string userid);

    }
}
