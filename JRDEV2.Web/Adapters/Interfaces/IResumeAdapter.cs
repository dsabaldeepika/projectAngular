using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
   public interface IResumeAdapter
    {
        List<Resume> GetResumes(string userid);
        Resume GetResume(int id);
        Resume PostNewResume(string userID, ResumeVM newResume); //Changed by GeorgeW. 5/1/14
        Resume PATCHResumeVM(int id, string userID, ResumeVM newResumeVM);//Created by GeorgeW. 5/2/14
        //Resume PutNewResume(int id, Resume newResume); Commented out by GeorgeW. 5/5/14
        Resume DeleteResume(int id, string userID); //Edited by George W. 5/5/14
    }
}
