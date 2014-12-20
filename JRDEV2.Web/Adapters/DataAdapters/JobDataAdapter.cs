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
    public class JobDataAdapter : IJobsAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<JobVM> GetJobs(int? companyId, string userID)
        {
            List<JobVM> model = new List<JobVM>();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            if (companyId == null) // if companyID is null then the request is just asking for ALL jobs. --Jason Cannon
            {
                List<Job> jobs = db.Jobs.ToList();
                foreach (Job job in jobs)
                {
                    JobVM vm = new JobVM();
                    vm.JobId = job.JobId;
                    vm.JobTitle = job.JobTitle;
                    vm.NumOfApplicants = job.NumOfApplications;
                    vm.NumOfClicks = job.NumOfClicks;
                    vm.JobBudget = job.JobBudget;
                    vm.City = job.City;
                    vm.State = job.State;
                    model.Add(vm);
                }
            }
            else if (companyId == -1) // -1 will never happen unless it is specifically told to. -1 is a special case, in this case meaning that the request is coming from an employee of the company.  --Jason Cannon
            {
                List<Job> jobs = db.Jobs.Where(j => j.CompanyId == user.CompanyId).ToList();
                foreach (Job job in jobs)
                {
                    JobVM vm = new JobVM();
                    vm.JobId = job.JobId;
                    vm.JobTitle = job.JobTitle;
                    vm.NumOfApplicants = job.NumOfApplications;
                    vm.NumOfClicks = job.NumOfClicks;
                    vm.JobBudget = job.JobBudget;
                    vm.City = job.City;
                    vm.State = job.State;
                    model.Add(vm);
                }
            } else // If it hits here then the request is coming from a specific company page so we will only return jobs relating to that company. --Jason Cannon
            {
                List<Job> jobs = db.Jobs.Where(j => j.CompanyId == companyId).ToList();
                foreach (Job job in jobs)
                {
                    JobVM vm = new JobVM();
                    vm.JobId = job.JobId;
                    vm.JobTitle = job.JobTitle;
                    vm.NumOfApplicants = job.NumOfApplications;
                    vm.NumOfClicks = job.NumOfClicks;
                    vm.JobBudget = job.JobBudget;
                    vm.City = job.City;
                    vm.State = job.State;
                    model.Add(vm);
                }
            }
            return model;

        }

        public JobVM GetJob(int id)
        {
            Job job = new Job();
            
            

            job = db.Jobs
                           .Where(j => j.JobId == id)
                           //.Where(j=>j.Hidden == false)
                           .FirstOrDefault();
            Company company = db.Companies.Where(c => c.CompanyId == job.CompanyId).FirstOrDefault(); //added RM

            JobVM vm = new JobVM();
            vm.CompanyName = company.CompanyName;
            vm.JobId = job.JobId;
            vm.JobTitle = job.JobTitle;
            vm.Description = job.Description;
            vm.NumOfApplicants = job.NumOfApplications;
            vm.NumOfClicks = job.NumOfClicks;
            vm.JobBudget = job.JobBudget;
            vm.City = job.City;
            vm.State = job.State;
            vm.StartDate = job.StartDate;
            vm.EndDate = job.EndDate;
            vm.SalaryMin = job.SalaryMin;
            vm.SalaryMax = job.SalaryMax;
            vm.YearsExperience = job.YearsExperience;
            

            

            return vm;
        }

        public List<Job> GetJobs(int itemsPerPage, int currentPage, string searchText)
        {
            List<Job> model = new List<Job>();
            var q = db.Jobs.Where(c => c.JobTitle.Contains(searchText));
            q = db.Jobs.Where(c => c.Company.CompanyName.Contains(searchText)).Union(q);
            q = db.Jobs.Where(c => c.Description.Contains(searchText)).Union(q);
            model = q.
                Take(itemsPerPage)
                .Skip(itemsPerPage * currentPage)
                .ToList();

            return model;
        }

        public Job PostNewJob(string userid, JobVM newjob)//dlr added string userid
        {

            Job job = new Job();
            User creator = db.Users.Where(c => c.Id == userid).FirstOrDefault();
            job.CompanyId = (int)creator.CompanyId;
            //job.JobId = newjob.JobId;
            job.JobTitle = newjob.JobTitle;
            job.Description = newjob.Description;
            job.YearsExperience = newjob.YearsExperience;
            //job.RequiredProgrammingSkills = newjob.RequiredProgrammingSkills;
            //job.RequiredEducationSkills = newjob.RequiredEducationSkills;
            job.SalaryMin = newjob.SalaryMin;
            job.SalaryMax = newjob.SalaryMax;
            job.StatusId = (byte)JobStatus.Active;
            job.StartDate = DateTime.Now;
            job.EndDate = DateTime.Now;
            job.UserId = userid;//dlr
            job.DateCreated = DateTime.Now;
            job.DateUpdated = DateTime.Now;
            job.UserCreatedId = userid;//dlr
            job.UserUpdatedId = userid;//dlr
            db.Jobs.Add(job);
            db.SaveChanges();

            return job; 
        }

        public Job PutNewJob(int id, Job newjob)
        {
            db.Jobs.Where(j=>j.JobId == id)
                        //.Where(j=>j.Hidden == false)
                        .FirstOrDefault();
            Job job = new Job();
            job.JobId = newjob.JobId;
            job.JobTitle = newjob.JobTitle;
            job.Description = newjob.Description;
            job.YearsExperience = newjob.YearsExperience;
            //job.RequiredProgrammingSkills = newjob.RequiredProgrammingSkills;
            //job.RequiredEducationSkills = newjob.RequiredEducationSkills;
            job.SalaryMin = newjob.SalaryMin;
            job.SalaryMax = newjob.SalaryMax;
            job.StatusId = (byte)JobStatus.Active;
            job.StartDate = DateTime.Now;
            job.EndDate = DateTime.Now;
            job.UserId = newjob.UserId;
            //job.DateCreated = newjob.DateCreated;
            job.DateUpdated = DateTime.Now;
            job.DateCreated = DateTime.Now;
            //job.UserCreatedId = newjob.UserCreatedId;
            job.UserUpdatedId = newjob.UserUpdatedId;
            db.SaveChanges();
            return newjob;
        }

        public Job DeleteJob(int id)
        {           
            Job job = new Job();
            job = db.Jobs
                            .Where(j => j.JobId == id)
                            //.Where(j=>j.Hidden == false)
                            .FirstOrDefault();
            job.IsDeleted = true;
            db.SaveChanges();
            return db.Jobs.FirstOrDefault();
        }


        public List<ApplicantVm> GetApplicant(int id)
        {
            List<ApplicantVm> applicants = new List<ApplicantVm>();
            applicants = db.Applications.Where(a => a.JobId == id).Select(a => new ApplicantVm
            {
                Id = a.ApplicationId,
                resume = a.Resume,
                Name = a.User.FirstName + " " + a.User.LastName

            }).ToList();

            return applicants;
        }
  
    }
}