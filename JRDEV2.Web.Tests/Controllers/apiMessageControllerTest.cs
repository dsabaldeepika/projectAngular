using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using JRDEV2.Web.Adapters.MockDataAdapters;
using System.Web.Http.Results;
using JRDEVDataModels;
using System.Collections.Generic;
using JRDEV2.Web.Controllers;

namespace JRDEV2.Web.Tests.Controllers
{
    //[TestClass]
    //public class apiMessagesControllerTest
    //{
    //    apiMessagesController _controller;
    //    [TestInitialize]
    //    public void Init()
    //    {
    //        _controller = new apiMessagesController(new MessagesMockDataAdapter());

    //    }
    //    [TestMethod]
    //    public void GetMessagesTestMethod()
    //    {
           

    //        //Act
    //        var Result = _controller.Get();

    //        //Assert
    //        var response = Result as OkNegotiatedContentResult<List<Message>>;
    //        Assert.IsNotNull(response);

    //        var messages = response.Content;
    //        Assert.AreEqual(2, messages.Count);

    //    }

    //    [TestMethod]
    //    public void GetMessageTestMethod(int id)
    //    {
           

    //        //Act
    //        var Result = _controller.Get(id);

    //        //Assert
    //        var response = Result as OkNegotiatedContentResult<Message>;
    //        Assert.IsNotNull(response);


    //        Assert.AreEqual(1, response.Content.MessageId);

    //    }


    //    [TestMethod]
    //    public void PostNewMessageMethod()
    //    {
    //        //Arrange
    //        var controller = new apiMessagesControllerTest();

    //        //Act
    //        var ActionResult = _controller.Post(new Message { MessageId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, Content = "Ayyy", Subject = "U want a job lol", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1" });

    //        //Assert
    //        var response = ActionResult as CreatedAtRouteNegotiatedContentResult<Message>;

    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response.Content.MessageId, response.RouteValues["MessageId"]);

    //    }

    //    [TestMethod]
    //    public void PutNewMessageTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiMessagesControllerTest();


    //        //Act
    //        Message message = new Message() { MessageId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "Ayyy", MsgSubject = "U want a job lol", UserCreatedId = "1", UserId ="1", UserUpdatedId = "1" };

    //        var ActionResult = _controller.Put(message.MessageId, message);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Message>;
    //        Assert.IsNotNull(response);
    //        var newMessage = response.Content;
    //        Assert.AreEqual(1, newMessage.MessageId);

    //    }
    //    [TestMethod]
    //    public void DeleteMessageTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiMessagesControllerTest();


    //        //Act
    //        Message message = new Message() { MessageId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "Ayyy", MsgSubject = "U want a job lol", Hidden=true, UserCreatedId = "1", UserId = "1", UserUpdatedId = "1" };

    //        var ActionResult = _controller.Delete(message.MessageId);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Message>;
    //        Assert.IsNotNull(response);
    //        var newMessage = response.Content;
    //        Assert.AreEqual(1, newMessage.MessageId);

    //    }

    //}
}
