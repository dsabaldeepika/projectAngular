using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.MockDataAdapters
{
    //public class JobMockDataAdapter : IJobsAdapter
    //{

    //    public List<Job> GetJobs()
    //    {
    //        List<Job> jobs = new List<Job>(){
    //          new Job { JobId = 1, City = "Houston", ClickId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Description = "Good Job", EmailAddress = "Test@Test.com", JobBudget = 1000.99, JobTitle = "Programmer", PhoneNumber = "1234567", RequiredEducationSkills = "A lot", RequiredProgrammingSkills = "A lot", SalaryMin = 100000, SalaryMax = 500000, StartDate = DateTime.Now.AddDays(200), EndDate = DateTime.Now.AddDays(500), State = "Texas", JobStatusId = 1, StreetAddress = "123 Uhh Lane", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1", YearsExperience = 2, ZipCode = "77777" },
    //          new Job { JobId = 2, City = "Dallas", ClickId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Description = "Test2", EmailAddress = "Test2@Test.com", JobBudget = 1000.99, JobTitle = "Programmer", PhoneNumber = "2345678", RequiredEducationSkills = "Not lot", RequiredProgrammingSkills = "A lot", SalaryMin = 132524, SalaryMax = 928542, StartDate = DateTime.Now.AddDays(200), EndDate = DateTime.Now.AddDays(500), State = "Texas", JobStatusId=1, StreetAddress = "321 Uhh Blvd", UserCreatedId = "2", UserId = "2", UserUpdatedId = "2", YearsExperience = 2, ZipCode = "22222" }
    //        };
            

    //        return jobs;
    //    }

    //    public Job GetJob(int id)
    //    {
    //        Job job = new Job(){
    //            JobId = 1, City = "Houston", ClickId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Description = "Good Job", EmailAddress = "Test@Test.com", JobBudget = 1000.99, JobTitle = "Programmer", PhoneNumber = "1234567", RequiredEducationSkills = "A lot", RequiredProgrammingSkills = "A lot", SalaryMin = 100000, SalaryMax = 500000, StartDate = DateTime.Now.AddDays(200), EndDate = DateTime.Now.AddDays(500), State = "Texas", JobStatusId = 1, StreetAddress = "123 Uhh Lane", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1", YearsExperience = 2, ZipCode = "77777" 
    //          };
    //        return job;
    //    }

    //    public Job PostNewJob(Job newJob)
    //    {
    //        List<Job> jobs = new List<Job>(){
    //          new Job { JobId = 1, City = "Houston", ClickId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Description = "Good Job", EmailAddress = "Test@Test.com", JobBudget = 1000.99, JobTitle = "Programmer", PhoneNumber = "1234567", RequiredEducationSkills = "A lot", RequiredProgrammingSkills = "A lot", SalaryMin = 100000, SalaryMax = 500000, StartDate = DateTime.Now.AddDays(200), EndDate = DateTime.Now.AddDays(500), State = "Texas", JobStatusId = 1, StreetAddress = "123 Uhh Lane", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1", YearsExperience = 2, ZipCode = "77777" },
    //          new Job { JobId = 2, City = "Dallas", ClickId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Description = "Test2", EmailAddress = "Test2@Test.com", JobBudget = 1000.99, JobTitle = "Programmer", PhoneNumber = "2345678", RequiredEducationSkills = "Not lot", RequiredProgrammingSkills = "A lot", SalaryMin = 132524, SalaryMax = 928542, StartDate = DateTime.Now.AddDays(200), EndDate = DateTime.Now.AddDays(500), State = "Texas", JobStatusId=1, StreetAddress = "321 Uhh Blvd", UserCreatedId = "2", UserId = "2", UserUpdatedId = "2", YearsExperience = 2, ZipCode = "22222" }
    //        };
    //        Job job = new Job();
    //        job.JobId = newJob.JobId;
    //        job.City = newJob.City;
    //        job.ClickId = newJob.ClickId;
    //        job.DateCreated = newJob.DateCreated;
    //        job.DateUpdated = newJob.DateUpdated;
    //        job.Description = newJob.Description;
    //        job.EmailAddress = newJob.EmailAddress;
    //        job.JobBudget = newJob.JobBudget;
    //        job.PhoneNumber = newJob.PhoneNumber;
    //        job.RequiredEducationSkills = newJob.RequiredEducationSkills;
    //        job.RequiredProgrammingSkills = newJob.RequiredProgrammingSkills;
    //        job.SalaryMin = newJob.SalaryMin;
    //        job.SalaryMax = newJob.SalaryMax;
    //        job.StartDate = newJob.StartDate;
    //        job.EndDate = newJob.EndDate;
    //        job.JobStatusId = newJob.JobStatusId;
    //        job.StreetAddress = newJob.StreetAddress;
    //        job.State = newJob.State;
    //        job.UserCreatedId = newJob.UserCreatedId;
    //        job.UserId = newJob.UserId;
    //        job.UserUpdatedId = newJob.UserUpdatedId;
    //        job.YearsExperience = newJob.YearsExperience;
    //        job.ZipCode = newJob.ZipCode;
    //        jobs.Add(newJob);
    //        return jobs.FirstOrDefault();
    //    }

    //    public Job PutNewJob(int id, Job newJob)
    //    {
    //        Job job = new Job() {
    //            JobId = 1,
    //            City = "Houston",
    //            ClickId = 1,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            Description = "Good Job",
    //            EmailAddress = "Test@Test.com",
    //            JobBudget = 1000.99,
    //            JobTitle = "Programmer",
    //            PhoneNumber = "1234567",
    //            RequiredEducationSkills = "A lot",
    //            RequiredProgrammingSkills = "A lot",
    //            SalaryMin = 100000,
    //            SalaryMax = 500000,
    //            StartDate = DateTime.Now.AddDays(200),
    //            EndDate = DateTime.Now.AddDays(500),
    //            State = "Texas",
    //            JobStatusId = 1,
    //            StreetAddress = "123 Uhh Lane",
    //            UserCreatedId = "1",
    //            UserId = "1",
    //            UserUpdatedId = "1",
    //            YearsExperience = 2,
    //            ZipCode = "77777"
    //        };
    //        job.JobId = newJob.JobId;
    //        job.City = newJob.City;
    //        job.ClickId = newJob.ClickId;
    //        job.DateCreated = newJob.DateCreated;
    //        job.DateUpdated = newJob.DateUpdated;
    //        job.Description = newJob.Description;
    //        job.EmailAddress = newJob.EmailAddress;
    //        job.JobBudget = newJob.JobBudget;
    //        job.PhoneNumber = newJob.PhoneNumber;
    //        job.RequiredEducationSkills = newJob.RequiredEducationSkills;
    //        job.RequiredProgrammingSkills = newJob.RequiredProgrammingSkills;
    //        job.SalaryMin = newJob.SalaryMin;
    //        job.SalaryMax = newJob.SalaryMax;
    //        job.StartDate = newJob.StartDate;
    //        job.EndDate = newJob.EndDate;
    //        job.JobStatusId = newJob.JobStatusId;
    //        job.StreetAddress = newJob.StreetAddress;
    //        job.State = newJob.State;
    //        job.UserCreatedId = newJob.UserCreatedId;
    //        job.UserId = newJob.UserId;
    //        job.UserUpdatedId = newJob.UserUpdatedId;
    //        job.YearsExperience = newJob.YearsExperience;
    //        job.ZipCode = newJob.ZipCode;
    //        return job;
    //    }

    //    public Job DeleteJob(int id)
    //    {

    //        Job job = new Job();
    //        job.Hidden = true;
    //        return job;
    //    }
    //}
}