using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class ResumeDataAdapter : IResumeAdapter
    {
        public List<JRDEVDataModels.Resume> GetResumes(string userid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            List<Resume> resumes = new List<Resume>();
            resumes = db.Resumes.Where(r => r.UserId == userid && r.IsDeleted == false)
                                //.Where(r=>r.Hidden == false)
                                .ToList();
            return resumes;
        }

        public JRDEVDataModels.Resume GetResume(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Resume resumes = new Resume();
            resumes = db.Resumes
                                .Where(r=>r.ResumeId == id)
                                //.Where(r=>r.Hidden == false)
                                .FirstOrDefault();
            return resumes;
        }

        //Created by GeorgeW. 5/1/14
        //=========================================================================================
        public Resume PostNewResume(string userID, ResumeVM newResume)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            Resume resume = new Resume();
            
            resume.Heading = newResume.Heading;
            resume.Summary = newResume.Summary;
            resume.WorkExperience = newResume.WorkExperience;
            resume.Education = newResume.Education;
            resume.OtherInfo = newResume.OtherInfo;
            resume.UserId = user.Id;
            resume.DateCreated = DateTime.Now;
            resume.DateUpdated = DateTime.Now;
            resume.UserCreatedId = user.Id;
            resume.UserUpdatedId = user.Id;

            
            
            
            db.Resumes.Add(resume);
            db.SaveChanges();

            return resume;
        }
        //=========================================================================================

        //Created by GeorgeW. 5/2/14
        //=============================================================================

        public Resume PATCHResumeVM(int id, string userID, ResumeVM newResumeVM)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            Resume resume = new Resume();
            resume = db.Resumes.Where(r => r.UserId == userID && r.ResumeId == id).FirstOrDefault();

            resume.Heading = newResumeVM.Heading;
            resume.Summary = newResumeVM.Summary;
            resume.WorkExperience = newResumeVM.WorkExperience;
            resume.Education = newResumeVM.Education;
            resume.OtherInfo = newResumeVM.OtherInfo;
            resume.UserId = user.Id;
            resume.DateCreated = resume.DateCreated;
            //maybe datecreated needs to be be assigned?
            resume.DateUpdated = DateTime.Now;
            resume.UserCreatedId = user.Id;
            resume.UserUpdatedId = user.Id;
            db.SaveChanges();

            return resume;
        }
        //=============================================================================

        //public JRDEVDataModels.Resume PutNewResume(int id, JRDEVDataModels.Resume newResume)              Commented out by George W. 5/5/14
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();

        //    Resume resume = new Resume();

        //    resume = db.Resumes
        //                        .Where(r=>r.ResumeId == id)
        //                        //.Where(r=>r.Hidden == false)
        //                        .FirstOrDefault();
        //    resume.ResumeId = newResume.ResumeId;
        //    //resume.File = newResume.File;
        //    resume.UserId = newResume.UserId;
        //    //resume.DateCreated = newResume.DateCreated;
        //    resume.DateUpdated = DateTime.Now;
        //    resume.UserUpdatedId = newResume.UserUpdatedId;
        //    db.SaveChanges();
        //    return db.Resumes.FirstOrDefault();
        //}

        public Resume DeleteResume(int id, string userID)
        {
            //Edited by George W. 5/5/14
            ApplicationDbContext db = new ApplicationDbContext();
            Resume resume = new Resume();
            resume = db.Resumes
                                .Where(r=>r.ResumeId == id && r.UserId == userID)
                                //.Where(r=>r.Hidden == false)
                                .FirstOrDefault();
            resume.IsDeleted = true;

            db.SaveChanges();
            return resume;
        }
    }
}