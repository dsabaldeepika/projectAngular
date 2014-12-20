using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JRDEV2.Web.Controllers;
using JRDEVDataModels;
using System.Collections.Generic;
using System.Web.Http.Results;
//using JRDEV2.Web.Adapters.MockDataAdapters;

namespace JRDEV2.Web.Tests.Controllers
{
    //[TestClass]
    //public class apiCompanyControllerTest
    //{
    //    apiCompanyController _controller;
    //    [TestInitialize]
    //    public void Init()
    //    {
    //        _controller = new apiCompanyController(new CompanyMockAdapter());
    //    }
    //    [TestMethod]
    //    public void GetCompaniesTestMethod()
    //    {
    //        //Act
    //        var result = _controller.Get();

    //        //Assert
    //        var response = result as OkNegotiatedContentResult<List<Company>>;
    //        Assert.IsNotNull(response);

    //        var Companies = response.Content;
    //        Assert.AreEqual(2, Companies.Count);
    //    }

    //    [TestMethod]
    //    public void PostNewCompanyTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiCompanyController();

    //        //Act
    //        var ActionResult = _controller.Post(new Company 
    //        {
    //            CompanyId = 3,
    //            City = "new City",
    //            CompanyName = "new Company Name",
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            PaymentInfo = "new Payment Info",
    //            EmailAddress = "new Email",
    //            PhoneNumber = "new Phone Number",
    //            State = "new State",
    //            StreetAddress = "new Address",
    //            UserCreatedId = "1",
    //            UserUpdatedId = "1",
    //            ZipCode = "new Zip"
    //        });

    //        //Assert
    //        var response = ActionResult as CreatedAtRouteNegotiatedContentResult<Company>;

    //        Assert.IsNotNull(response);
    //        Assert.AreEqual(response.Content.CompanyId, response.RouteValues["CompanyId"]);
    //    }
    //    [TestMethod]
    //    public void PutNewCompanyTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiCompanyController();

    //        //Act
    //        Company company = new Company()
    //        {
    //            CompanyId = 3,
    //            City = "new City",
    //            CompanyName = "new Company Name",
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            PaymentInfo = "new Payment Info",
    //            EmailAddress = "new Email",
    //            PhoneNumber = "new Phone Number",
    //            State = "new State",
    //            StreetAddress = "new Address",
    //            UserCreatedId = "1",
    //            UserUpdatedId = "1",
    //            ZipCode = "new Zip"
    //        };
    //        var ActionResult = _controller.Put(company.CompanyId, company);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Company>;
    //        Assert.IsNotNull(response);
    //        var newCompany = response.Content;
    //        Assert.AreEqual(3, newCompany.CompanyId);
    //    }

    //    [TestMethod]
    //    public void DeleteCompanyTestMethod()
    //    {
    //        //Arrange
    //        var controller = new apiCompanyController();

    //        //Act
    //        Company company = new Company()
    //        {
    //            CompanyId = 2,
    //            City = "new City",
    //            CompanyName = "new Company Name",
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            Hidden = true,
    //            PaymentInfo = "new Payment Info",
    //            EmailAddress = "new Email",
    //            PhoneNumber = "new Phone Number",
    //            State = "new State",
    //            StreetAddress = "new Address",
    //            UserCreatedId = "1",
    //            UserUpdatedId = "1",
    //            ZipCode = "new Zip"
    //        };
    //        var ActionResult = _controller.Delete(company.CompanyId);

    //        //Assert
    //        var response = ActionResult as OkNegotiatedContentResult<Company>;
    //        Assert.IsNotNull(response);
    //        var newCompany = response.Content;
    //        Assert.AreEqual(true, newCompany.Hidden);
    //    }
        
    //}
}
