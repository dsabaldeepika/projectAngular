using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.MockDataAdapters
{
    //public class ResumeMockDataAdapter : IResumeAdapter
    //{
    //    public List<Resume> GetResumes()
    //    {
    //        List<Resume> Resumes = new List<Resume>()
    //        {
    //           new Resume { ResumeId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, File = "somefileurl", UserCreatedId = "1", UserId = "1", UserUpdatedId ="1" },
    //           new Resume { ResumeId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, File = "somefileurl2", UserCreatedId = "2", UserId = "2", UserUpdatedId = "2" }
    //        };
    //        return Resumes;
    //    }

    //    public Resume GetResume(int id)
    //    {
    //        Resume resume = new Resume()
    //        {
    //            ResumeId = 1,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            File = "somefileurl",
    //            UserCreatedId = "1",
    //            UserId = "1",
    //            UserUpdatedId = "1"
    //        };
    //        return resume;
    //    }

    //    public List<Resume> PostNewResume(Resume newResume)
    //    {
    //        List<Resume> mockdb = new List<Resume>()
    //        {
    //         new Resume { ResumeId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, File = "somefileurl", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1" },
    //           new Resume { ResumeId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, File = "somefileurl2", UserCreatedId = "2", UserId = "2", UserUpdatedId = "2" }
    //        };

    //        Resume resume = new Resume();
    //        resume.ResumeId = newResume.ResumeId;
    //        resume.DateCreated = newResume.DateCreated;
    //        resume.UserCreatedId = newResume.UserCreatedId;
    //        resume.UserId = newResume.UserId;
    //        resume.UserUpdatedId = newResume.UserUpdatedId;
    //        mockdb.Add(resume);


    //        return mockdb;
    //    }



    //    public Resume PutNewResume(int id, Resume newResume)
    //    {
    //        Resume resume = new Resume()
    //        {
    //            ResumeId = 3,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            File = "Test",
    //            UserCreatedId = "1",
    //            UserId="1",
    //            UserUpdatedId="1"
    //        };


    //        resume.ResumeId = newResume.ResumeId;
    //        resume.DateCreated = newResume.DateCreated;
    //        resume.UserCreatedId = newResume.UserCreatedId;
    //        resume.UserId = newResume.UserId;
    //        resume.UserUpdatedId = newResume.UserUpdatedId;
    //        return resume;
    //    }

    //    public Resume DeleteResume(int id)
    //    {
    //        Resume resume = new Resume();
    //        resume.Hidden = true;
    //        return resume;
    //    }
    //}
}