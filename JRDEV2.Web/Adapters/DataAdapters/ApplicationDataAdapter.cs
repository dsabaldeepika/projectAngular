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
    public class ApplicationDataAdapter : IApplicationAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Application> GetApplication()
        {
            List<Application> application = new List<Application>();
            application = db.Applications.ToList();
            //.Where(c => c.Hidden == false)
            return application;
        }

        public Application GetApplication(int id)
        {
            Application application = new Application();
            application = db.Applications
                //.Where(c => c.Hidden == false)
                                .Where(c => c.ApplicationId == id)
                                .FirstOrDefault();

            return application;
        }

        public Application PostNewApplication(ApplyForJobVM newApplication, string userid)
        {
            Application application = new Application();
            User user = db.Users.Where(u => u.Id == userid).FirstOrDefault();
            Job job = new Job();
            Resume resume = new Resume();
            job = db.Jobs.Where(j => j.JobId == newApplication.JobId).FirstOrDefault();
            resume = db.Resumes.Where(r => r.ResumeId == newApplication.ResumeId).FirstOrDefault();
            application.UserId = userid;
            application.UserCreatedId = userid;
            application.UserUpdatedId = userid;
            application.ResumeId = newApplication.ResumeId;
            application.JobId = newApplication.JobId;
            application.Content = newApplication.Content;
            application.Title = user.FirstName + " " + user.LastName;
            application.DateCreated = DateTime.Now;
            application.DateUpdated = DateTime.Now;
            db.Applications.Add(application);
            db.SavedJobs.Remove(db.SavedJobs.Find(newApplication.JobId));
            db.SaveChanges();

            return application;
        }
        public bool PostAllApplications(List<ApplyToAllJobsVM> newApplications, string userid)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //  List<ApplyToAllJobsVM> model = new List<ApplyToAllJobsVM>();
            User user = db.Users.Where(u => u.Id == userid).FirstOrDefault();
            //set variables
            foreach (ApplyToAllJobsVM application in newApplications)
            {
                Job job = new Job();
                Resume resume = new Resume();
                job = db.Jobs.Where(j => j.JobId == application.JobId).FirstOrDefault();
                resume = db.Resumes.Where(r => r.ResumeId == application.ResumeId).FirstOrDefault();

                Application app = new Application();
                app.UserId = userid;
                app.UserCreatedId = userid;
                app.UserUpdatedId = userid;
                app.ResumeId = application.ResumeId;
                app.JobId = application.JobId;
                app.Content = "";
                app.Title = user.FirstName + " " + user.LastName;
                app.DateCreated = DateTime.Now;
                app.DateUpdated = DateTime.Now;
                db.Applications.Add(app);


                db.SavedJobs.Remove(db.SavedJobs.Find(application.SavedJobId));

            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public Application PutApplication(int id, Application newApplication)
        {
            Application application = new Application();
            application = db.Applications
                //.Where(c => c.Hidden == false)
                        .Where(c => c.ApplicationId == id)
                        .FirstOrDefault();
            //set variables
            db.SaveChanges();
            return application;
        }

        public Application DeleteApplication(int id)
        {
            Application application = new Application();
            application = db.Applications
                //.Where(c=>c.Hidden == false)
                        .Where(c => c.ApplicationId == id)
                        .FirstOrDefault();
            application.IsDeleted = true;
            db.SaveChanges();
            return application;
        }
    }
}