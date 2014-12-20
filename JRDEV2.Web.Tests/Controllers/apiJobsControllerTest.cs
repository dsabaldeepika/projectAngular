using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JRDEV2.Web.Controllers;
//using JRDEV2.Web.Adapters.MockDataAdapters;
using System.Web.Http.Results;
using JRDEVDataModels;
using System.Collections.Generic;

namespace JRDEV2.Web.Tests.Controllers
{
    //[TestClass]
    //public class apiJobsControllerTest
    //{
    //    apiJobsController _controller;
    //    //Arrange
    //    [TestInitialize]
    //    public void Init()
    //    {
    //        _controller = new apiJobsController(new JobMockDataAdapter());
    //    }
    //    [TestMethod]
    //    public void GetJobsTestMethod()
    //    {
    //        //Act
    //        var actionResult = _controller.Get();

    //        //Assert
    //        var response = actionResult as OkNegotiatedContentResult<List<Job>>;
    //        Assert.IsNotNull(response);
    //        var jobs = response.Content;
    //        Assert.AreEqual(2, jobs.Count);
    //    }
    //    [TestMethod]
    //    public void PostNewJobTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiJobsController();

    //        //Act
    //        var ActionResult = _controller.Post(new Job
    //        {
    //            JobId = 3,
    //            City = "Houston",
    //            //ClickId = 1,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            Description = "Good Job",
    //            EmailAddress = "Test@Test.com",
    //            JobBudget = 1000.99,
    //            JobTitle = "Programmer",
    //            PhoneNumber = "1234567",
    //            //RequiredEducationSkills = "A lot",
    //            //RequiredProgrammingSkills = "A lot",
    //            SalaryMin = 100000,
    //            SalaryMax = 500000,
    //            StartDate = DateTime.Now.AddDays(200),
    //            EndDate = DateTime.Now.AddDays(500),
    //            State = "Texas",
    //            //JobStatusId = 1,
    //            StreetAddress = "123 Uhh Lane",
    //            UserCreatedId = "1",
    //            UserId = "1",
    //            UserUpdatedId = "1",
    //            YearsExperience = 2,
    //            ZipCode = "77777" 
    //        });

    //        //Assert
    //        var response = ActionResult as CreatedAtRouteNegotiatedContentResult<Job>;

    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response.Content.JobId, response.RouteValues["JobId"]);
    //    }
    //    [TestMethod]
    //    public void PutNewJobTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiJobsController();

    //        //Act
    //        Job job = new Job()
    //        {
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
    //        var ActionResult = _controller.Put(job.JobId, job);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Job>;
    //        Assert.IsNotNull(response);
    //        var newJob = response.Content;
    //        Assert.AreEqual(1, newJob.JobId);
    //    }

    //    [TestMethod]
    //    public void DeleteJobTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiJobsController();

    //        //Act
    //        Job job = new Job()
    //        {
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
    //            ZipCode = "77777",
    //            Hidden= false
    //        };
    //        var ActionResult = _controller.Delete(job.JobId);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Job>;
    //        Assert.IsNotNull(response);
    //        var newJob = response.Content;
    //        Assert.AreEqual(1, newJob.JobId);
    //    }
    //}
}
