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
    //public class apiUserControllerTest
    //{
    //    apiUsersController _controller;
    //    [TestInitialize]
    //    public void Init()
    //    {
    //        _controller = new apiUsersController(new UserMockDataAdapter());
    //    }
    //    [TestMethod]
    //    public void GetUsersTestMethod()
    //    {
    //        //Act
    //        var result = _controller.Get();

    //        //Assert
    //        var response = result as OkNegotiatedContentResult<List<User>>;
    //        Assert.IsNotNull(response);

    //        var Users = response.Content;
    //        Assert.AreEqual(2, Users.Count);
    //    }

    //    [TestMethod]
    //    public void PostNewUserTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiUsersController();

    //        //Act
    //        var ActionResult = _controller.Post(new User
    //        {
    //           // CurrentlyLooking = true,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            //DesiredSalary = 80000,
    //            FirstName = "Cody",
    //            //Hidden = false,
               
    //            LastName = "Shipley",
    //            UserCreatedId = "1",
    //            Id = "1",
               
    //            UserUpdatedId = "1",
    //            //WillRelocate = true
    //        });

    //        //Assert
    //        var response = ActionResult as CreatedAtRouteNegotiatedContentResult<User>;

    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response.Content.Id, response.RouteValues["Id"]);
    //    }
    //    [TestMethod]
    //    public void PutNewUserTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiUsersController();

    //        //Act
    //        User user = new User()
    //        {
    //            Id = "1",
    //            CurrentlyLooking = true,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            DesiredSalary = 80000,
    //            FirstName = "Cody",
    //            Hidden = false,
         
    //            LastName = "Shipley",
    //            UserCreatedId = "1",
               
    //            UserUpdatedId ="1",
    //            WillRelocate = true
    //        };
    //        var ActionResult = _controller.Put(user.Id, user);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<User>;
    //        Assert.IsNotNull(response);
    //        var newUser = response.Content;
    //        Assert.AreEqual(1, newUser.Id);
    //    }
    //    [TestMethod]
    //    public void DeleteUserTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiUsersController();


    //        //Act
    //        User user = new User()
    //        {
    //            Id = "1",
    //            CurrentlyLooking = true,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            DesiredSalary = 80000,
    //            FirstName = "Cody",
    //            Hidden = false,
            
    //            LastName = "Shipley",
    //            UserCreatedId = "1",
             
    //            UserUpdatedId = "1",
    //            WillRelocate = true
    //        };

    //        var ActionResult = _controller.Delete(user.Id);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<User>;
    //        Assert.IsNotNull(response);
    //        var newUser = response.Content;
    //        Assert.AreEqual("1", newUser.Id);

    //    }
    //}
}
