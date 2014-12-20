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
    //public class apiClicksControllerTest
    //{
    //    apiClicksController _controller;
    //    [TestInitialize]
    //    public void Init()
    //    {
    //        _controller = new apiClicksController(new ClickMockAdapter());

    //    }


    //    [TestMethod]
    //    public void GetClicksTestMethod()
    //    {
    //        //Act
    //        var result = _controller.Get();

    //        //Assert
    //        var response = result as OkNegotiatedContentResult<List<Click>>;
    //        Assert.IsNotNull(response);

    //        var clicks = response.Content;
    //        Assert.AreEqual(1, clicks.Count);
    //    }

    //    [TestMethod]
    //    public void PostNewClickTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiClicksController();

    //        //Act
    //        var ActionResult = _controller.Post(new Click
    //       { ClickId = 3, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, IpAddress = "111.111", NumOfClicks = 4, JobId = 1 });

    //        //Assert
    //        var response = ActionResult as CreatedAtRouteNegotiatedContentResult<Click>;

    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response.Content.ClickId, response.RouteValues["ClickId"]);
    //    }


    //    [TestMethod]
    //    public void PutClickTestMethod(int id)
    //    {
    //        //Arrange
    //        var controller = new apiClicksController();


    //        //Act
    //        Click click = new Click() { ClickId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, IpAddress = "111.111", NumOfClicks = 4, JobId = 1 };

    //        var ActionResult = _controller.Put(click.ClickId, click);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Click>;
    //        Assert.IsNotNull(response);
    //        var newClick = response.Content;
    //        Assert.AreEqual(2, newClick.ClickId);

    //    }


    //    [TestMethod]
    //    public void DeleteClickTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiClicksController();

    //        //Act
    //        Click click = new Click() { ClickId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, IpAddress = "111.111", NumOfClicks = 4, JobId = 1 };

    //        var ActionResult = _controller.Delete(click.ClickId);

           

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Click>;
    //        Assert.IsNotNull(response);
    //        var newClick = response.Content;
    //        Assert.AreEqual(true, newClick.Hidden);
    //    }





    //}
}
