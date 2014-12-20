using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Migrations;
using JRDEV2.Web.Models;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class SavedJobDataAdapter : ISavedJobAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<SavedJobVM> GetSavedJobs(string userid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            
            var q = db.SavedJobs.Where(s => s.UserId == userid)
               .Select(s => new SavedJobVM {
                   JobTitle = s.Job.JobTitle,
                   Description = s.Job.Description,
                   SavedJobId = s.SavedJobId,
                   JobId = s.JobId
               });
            List<SavedJobVM> savedJobsList = q.ToList();   
            return savedJobsList;

        }
        public SavedJob GetSavedJob(int id)
        {
            SavedJob model = new SavedJob();

            model = db.SavedJobs
                           .Where(j => j.SavedJobId == id)
                //.Where(j=>j.Hidden == false)
                           .FirstOrDefault();
            return model;
        }

        public SavedJob PostNewSavedJob(int id, string userid)
        {
            SavedJob savedJob = new SavedJob();

            //set variables
            db.SavedJobs.AddOrUpdate(s => new { s.JobId, s.UserId },
               new SavedJob
               {
                   JobId = id,
                   UserId = userid

               });
            db.SaveChanges();

            return savedJob;
        }

        public SavedJob PutSavedJob(int id, SavedJob newSavedJob)
        {
            db.SavedJobs.Where(j => j.SavedJobId == id)
                //.Where(j=>j.Hidden == false)
                        .FirstOrDefault();
            SavedJob savedJob = new SavedJob();
            //Set Variables
            db.SaveChanges();
            return newSavedJob;
        }

        public bool DeleteSavedJob(int id, string userid)
        {
            SavedJob savedJob = new SavedJob();
            savedJob = db.SavedJobs.Where(s=> s.UserId == userid)
                                 .FirstOrDefault(s=> s.SavedJobId ==id);
           
            db.SavedJobs.Remove(savedJob);
            int rowcount = db.SaveChanges();
            return (rowcount ==1);
        }
   
    }
}