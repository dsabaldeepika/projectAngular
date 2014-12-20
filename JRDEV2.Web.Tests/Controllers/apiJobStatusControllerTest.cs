using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JRDEV2.Web.Controllers;
//using JRDEV2.Web.Adapters.MockDataAdapters;
using System.Web.Http.Results;
using System.Collections.Generic;
using JRDEVDataModels;

namespace JRDEV2.Web.Tests.Controllers
{
    //[TestClass]
    //public class apiJobStatusControllerTest
    //{
    //    apiJobStatusController _controller;

    //    //Arrange
    //    [TestInitialize]
    //    public void Init()
    //    {
    //        _controller = new apiJobStatusController(new JobStatusMockAdapter());
    //    }

    //    [TestMethod]
    //    public void GetJobStatusTestMethod()
    //    {
    //        //Act
    //        var actionResult = _controller.Get();
    //        //Assert
    //        var response = actionResult as OkNegotiatedContentResult<List<JobStatus>>;
    //        Assert.IsNotNull(response);
    //        var jobstatuses = response.Content;
    //        Assert.AreEqual(2, jobstatuses.Count);
    //    }

    //    [TestMethod]
    //    public void PutNewJobStatusTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiJobStatusController();

    //        //Act
    //        JobStatus jobstatus = new JobStatus()
    //        {
    //            JobStatusId = 1,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            Name = "Programmer",
    //            UserCreatedId = "1",
    //            UserUpdatedId = "1"
    //        };
    //        var ActionResult = _controller.Put(jobstatus.JobStatusId, jobstatus);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<JobStatus>;
    //        Assert.IsNotNull(response);
    //        var newJobStatus = response.Content;
    //        Assert.AreEqual(1, newJobStatus.JobStatusId);
    //    }

    //    [TestMethod]
    //    public void DeleteJobStatusTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiJobStatusController();

    //        //Act
    //        JobStatus jobstatus = new JobStatus()
    //        {
    //            JobStatusId = 1,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            Name = "Programmer",
    //            UserCreatedId = "1",
    //            UserUpdatedId = "1"
    //        };
    //        var ActionResult = _controller.Delete(jobstatus.JobStatusId);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<JobStatus>;
    //        Assert.IsNotNull(response);
    //        var newJobStatus = response.Content;
    //        Assert.AreEqual(1, newJobStatus.JobStatusId);
    //    }
    //}
}
