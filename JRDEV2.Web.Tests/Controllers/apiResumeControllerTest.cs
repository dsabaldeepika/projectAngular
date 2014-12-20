using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JRDEV2.Web.Controllers;
//using JRDEV2.Web.Adapters.MockDataAdapters;
using JRDEVDataModels;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace JRDEV2.Web.Tests.Controllers
{
    //[TestClass]
    //public class apiResumeControllerTest
    //{
    //    apiResumesController _controller;
    //    [TestInitialize]
    //    public void Init()
    //    {
    //        _controller = new apiResumesController(new ResumeMockDataAdapter());

    //    }
    //    [TestMethod]
    //    public void GetResumesTestMethod()
    //    {
    //        //Act
    //        var result = _controller.Get();

    //        //Assert
    //        var response = result as OkNegotiatedContentResult<List<Resume>>;
    //        Assert.IsNotNull(response);

    //        var resumes = response.Content;
    //        Assert.AreEqual(2, resumes.Count);

    //    }
    //    [TestMethod]
    //    public void PostNewResumeMethod()
    //    {
    //        //Arrange
    //        var controller = new apiResumesController();

    //        //Act
    //        var ActionResult = _controller.Post(new Resume { ResumeId = 3, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, UserCreatedId = "3", UserId = "3", UserUpdatedId = "3" });

    //        //Assert
    //        var response = ActionResult as CreatedAtRouteNegotiatedContentResult<Resume>;

    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response.Content.ResumeId, response.RouteValues["ResumeId"]);

    //    }

    //    [TestMethod]
    //    public void PutNewResumeTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiResumesController();


    //        //Act
    //        Resume resume = new Resume() { ResumeId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, File = "renamedUsingPut", UserCreatedId = "2", UserId = "2", UserUpdatedId = "2"};

    //        var ActionResult = _controller.Delete(resume.ResumeId);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Resume>;
    //        Assert.IsNotNull(response);
    //        var newResume = response.Content;
    //        Assert.AreEqual(2, newResume.ResumeId);

    //    }

    //    [TestMethod]
    //    public void DeleteResumeTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiResumesController();


    //        //Act
    //        Resume resume = new Resume() { ResumeId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Hidden=true, UserCreatedId = "2", UserId = "2", UserUpdatedId = "2" };

    //        var ActionResult = _controller.Delete(resume.ResumeId);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Resume>;
    //        Assert.IsNotNull(response);
    //        var newResume = response.Content;
    //        Assert.AreEqual(2, newResume.ResumeId);

    //    }
    //}
}
