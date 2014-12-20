using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.MockDataAdapters
{
    //public class CompanyMockAdapter : ICompanyAdapter
    //{
    //    public List<JRDEVDataModels.Company> GetCompanies()
    //    {
    //        List<Company> Companies = new List<Company>()
    //        {
    //            new Company { CompanyId = 1, City = "Pearland", CompanyName = "Coder For Rent", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, EmailAddress = "coderforrent@coderforrent.com", PaymentInfo = "It's a lot", PhoneNumber = "1234567", State = "Texas", StreetAddress = "123 Broadway St", UserCreatedId = "1", UserUpdatedId = "1", ZipCode = "77583" },
    //            new Company { CompanyId = 2, City = "Houston", CompanyName = "Walmart", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, EmailAddress = "walmart@walmart.com", PaymentInfo = "It's not lot", PhoneNumber = "5653456", State = "Texas", StreetAddress = "321 Broadway St", UserCreatedId = "2", UserUpdatedId = "2", ZipCode = "77583" }
    //        };
    //        return Companies;
    //    }

    //    public JRDEVDataModels.Company GetCompany(int id)
    //    {
    //        Company company = new Company()
    //        {
    //            CompanyId = 1,
    //            City = "Pearland",
    //            CompanyName = "Coder For Rent",
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            EmailAddress = "coderforrent@coderforrent.com",
    //            PaymentInfo = "It's a lot",
    //            PhoneNumber = "1234567",
    //            State = "Texas",
    //            StreetAddress = "123 Broadway St",
    //            UserCreatedId = "1",
    //            UserUpdatedId = "1",
    //            ZipCode = "77583"
    //        };
    //        return company;
    //    }

    //    public List<JRDEVDataModels.Company> PostNewCompany(JRDEVDataModels.Company newCompany)
    //    {
    //        List<Company> mockdb = new List<Company>()
    //        {
    //            new Company { CompanyId = 1, City = "Pearland", CompanyName = "Coder For Rent", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, EmailAddress = "coderforrent@coderforrent.com", PaymentInfo = "It's a lot", PhoneNumber = "1234567", State = "Texas", StreetAddress = "123 Broadway St", UserCreatedId = "1", UserUpdatedId = "1", ZipCode = "77583" },
    //            new Company { CompanyId = 2, City = "Houston", CompanyName = "Walmart", DateCreated = DateTime.Now, DateUpdated = DateTime.Now, EmailAddress = "walmart@walmart.com", PaymentInfo = "It's not lot", PhoneNumber = "5653456", State = "Texas", StreetAddress = "321 Broadway St", UserCreatedId = "2", UserUpdatedId = "2", ZipCode = "77583" }
    //        };
    //        Company company = new Company();
    //        company.CompanyId = newCompany.CompanyId;
    //        company.City = newCompany.City;
    //        company.CompanyName = newCompany.CompanyName;
    //        company.DateCreated = newCompany.DateCreated;
    //        company.DateUpdated = newCompany.DateUpdated;
    //        company.DateCreated = newCompany.DateCreated;
    //        company.EmailAddress = newCompany.EmailAddress;
    //        company.PaymentInfo = newCompany.PaymentInfo;
    //        company.PhoneNumber = newCompany.PhoneNumber;
    //        company.State = newCompany.State;
    //        company.StreetAddress = newCompany.StreetAddress;
    //        company.UserCreatedId = newCompany.UserCreatedId;
    //        company.UserUpdatedId = newCompany.UserUpdatedId;
    //        company.ZipCode = newCompany.ZipCode;

    //        return mockdb;
    //    }

    //    public JRDEVDataModels.Company PutNewCompany(int id, JRDEVDataModels.Company newCompany)
    //    {
    //        Company company = new Company()
    //        {
    //            CompanyId = 1,
    //            City = "Pearland",
    //            CompanyName = "Coder For Rent",
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            EmailAddress = "coderforrent@coderforrent.com",
    //            PaymentInfo = "It's a lot",
    //            PhoneNumber = "1234567",
    //            State = "Texas",
    //            StreetAddress = "123 Broadway St",
    //            UserCreatedId = "1",
    //            UserUpdatedId = "1",
    //            ZipCode = "77583"
    //        };
    //        company.CompanyId = newCompany.CompanyId;
    //        company.City = newCompany.City;
    //        company.CompanyName = newCompany.CompanyName;
    //        company.DateCreated = newCompany.DateCreated;
    //        company.DateUpdated = newCompany.DateUpdated;
    //        company.EmailAddress = newCompany.EmailAddress;
    //        company.PaymentInfo = newCompany.PaymentInfo;
    //        company.PhoneNumber = newCompany.PhoneNumber;
    //        company.State = newCompany.State;
    //        company.StreetAddress = newCompany.StreetAddress;
    //        company.UserCreatedId = newCompany.UserCreatedId;
    //        company.UserUpdatedId = newCompany.UserUpdatedId;
    //        company.ZipCode = newCompany.ZipCode;
    //        return company;
    //    }

    //    public JRDEVDataModels.Company DeleteCompany(int id)
    //    {
    //        Company company = new Company();
    //        company.Hidden = true;
    //        return company;
    //    }
    //}
}