using JRDEV2.Web.Adapters.Interfaces;
using JRDEV2.Web.Models;
using JRDEV2.Web.Providers;
using JRDEVData;
using JRDEVDataModels;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class CompanyDataAdapter : ICompanyAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Company> GetCompanies()
        {
            List<Company> companies = new List<Company>();
            companies = db.Companies.ToList();
                //.Where(c=>c.Hidden == false)
            return companies;
        }

        public CompanyVM GetCompany(int id, string userID)
        {
            Company company = new Company();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            //User user = db.Users.Find(userId);
            if (id == -1) //Used if no companyID is specified, and you want to grab the company associated with the user.
            {
                company = db.Companies.Where(i => i.CompanyId == user.CompanyId).FirstOrDefault();
            }
            else 
            { 
                company = db.Companies.Where(i => i.CompanyId == id).FirstOrDefault();
                                    //.Where(c=>c.Hidden == false)
            }
            CompanyVM companyVM = new CompanyVM();
            company.CompanyAdmin = db.Users.Where(u => u.Id == company.CompanyAdminId).FirstOrDefault();
            companyVM.CompanyName = company.CompanyName;
            companyVM.FirstName = company.CompanyAdmin.FirstName;
            companyVM.LastName = company.CompanyAdmin.LastName;
            companyVM.StreetAddress = company.StreetAddress;
            companyVM.StreetAddress2 = company.StreetAddress2;
            companyVM.City = company.City;
            companyVM.State = company.State;
            companyVM.ZipCode = company.ZipCode;
            companyVM.PhoneNumber = company.PhoneNumber;
            companyVM.EmailAddress = company.EmailAddress;
            companyVM.Description = company.Description;
            companyVM.MainUrl = company.MainUrl;
            companyVM.FacebookUrl = company.FacebookUrl;
            companyVM.LinkedinUrl = company.LinkedinUrl;
            companyVM.TwitterUrl = company.TwitterUrl;
            companyVM.GoogleplusUrl = company.GoogleplusUrl;
            companyVM.Logo = company.Logo;
            companyVM.IsVerified = company.IsVerified;
            companyVM.IsVisible = company.IsVisible;
            companyVM.IsDeleted = company.IsDeleted;
            return companyVM;
        }

        public Company PostNewCompany(CompanyVM newCompany)
        {
            User user = new User();
            user.FirstName = newCompany.FirstName;
            user.LastName = newCompany.LastName;
            user.UserName = newCompany.UserName;
            user.DateCreated = DateTime.Now;
            user.DateUpdated = DateTime.Now;
            user.IsDeleted = false;
            //db.Users.Add(user);

            //TODO: Should NOT be saving any changes until EVERYTHING has been done.  We never want to create a situation where we have successfully created a user but not have assigned a company to them
            //This path is to create company users - it should be ALL or NOTHING.  See TalentProfileDataAdapter for how this should be done.
            var userManager = Startup.UserManagerFactoryWithDb(db);
            var userCreateResult = userManager.Create(user, newCompany.Password);
            if (userCreateResult.Succeeded)
            {
                db.SaveChanges();
            }
            
            Company company = new Company();
            company.CompanyName = newCompany.CompanyName;
            company.IsVerified = false;
            company.IsVisible = false;
            company.IsDeleted = false;
            company.JobPostingBudget = 0.00m;
            company.CostPerClick = 0.00m;
            company.StreetAddress = newCompany.StreetAddress;
            company.StreetAddress2 = newCompany.StreetAddress2;
            company.City = newCompany.City;
            company.State = newCompany.State;
            company.ZipCode = newCompany.ZipCode;
            company.Description = newCompany.Description;
            company.PhoneNumber = newCompany.PhoneNumber;
            company.EmailAddress = newCompany.EmailAddress;
            company.MainUrl = newCompany.MainUrl;
            company.FacebookUrl = newCompany.FacebookUrl;
            company.LinkedinUrl = newCompany.LinkedinUrl;
            company.TwitterUrl = newCompany.TwitterUrl;
            company.GoogleplusUrl = newCompany.GoogleplusUrl;
            company.Logo = newCompany.Logo;
            company.CompanyAdminId = user.Id;
            company.UserCreatedId = user.Id;
            company.UserUpdatedId = user.Id;
            company.DateCreated = DateTime.Now;
            company.DateUpdated = DateTime.Now;
            db.Companies.Add(company);

            // May need to be in apiCompanyController.cs
            // AccountController.cs has definition and use of UserManager (really UserManager<User>)
            // The Create method exists only as part of an extension to Identity Entity
            // May need to add check for bad result
            // This statement forces a database save
            // When uncommented, the db.SaveChanges statement below can be removed

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder errorSb = new StringBuilder();
                ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).ToList().ForEach(e => errorSb.AppendLine(string.Format("{0} | {1}", e.PropertyName, e.ErrorMessage)));
                string errorString = errorSb.ToString();
            }                      

            return company;
        }

        public Company PatchCompany(int id, string userID, CompanyVM newCompany)
        {  
            Company company = new Company();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            if (id == -1)
            {
                company = db.Companies.Where(c => c.CompanyId == user.CompanyId).FirstOrDefault();
            }
            else
            {
                company = db.Companies.Where(c => c.CompanyId == id).FirstOrDefault();
            }
            company.City = newCompany.City;
            if (newCompany.CompanyName != null)
            company.CompanyName = newCompany.CompanyName;
            //company.DateCreated = newCompany.DateCreated;
            company.DateUpdated = DateTime.Now;
            //company.PaymentInfo = newCompany.PaymentInfo;
            company.State = newCompany.State;
            company.StreetAddress = newCompany.StreetAddress;
            company.StreetAddress2 = newCompany.StreetAddress2;
            company.UserCreatedId = user.Id;
            company.UserUpdatedId = user.Id;
            company.ZipCode = newCompany.ZipCode;
            company.PhoneNumber = newCompany.PhoneNumber;
            company.EmailAddress = newCompany.EmailAddress;
            company.CompanyName = newCompany.CompanyName;
            company.Logo = newCompany.Logo;
            company.IsDeleted = newCompany.IsDeleted;
            company.IsVisible = newCompany.IsVisible;
            db.SaveChanges();

            return company;
        }

        public bool PutNewCompanyUser(CompanyVM existingCompany)
        {
            //Jared - this is where we will add the new user to the database and associate to the pre-existing company as a CompanyUser (not a CompanyAdmin)
            User user = new User();
            user.FirstName = existingCompany.FirstName;
            user.LastName = existingCompany.LastName;
            user.UserName = existingCompany.UserName;
            user.DateCreated = DateTime.Now;
            user.DateUpdated = DateTime.Now;
            user.IsDeleted = false;            
            
            var userManager = Startup.UserManagerFactoryWithDb(db);
            var userCreateResult = userManager.Create(user, existingCompany.Password);

            if (!userCreateResult.Succeeded)
                return false;

            var roleAddResult = userManager.AddToRole(user.Id, UserRoles.COMPANYUSER);

            if (!roleAddResult.Succeeded)
                return false;

            //We're not adding a company here just a user and pointing him/her to the existing company
            //Be sure to look up the existing company by ID (should have passed that back in the view model object) and associate to the user created above
            //Company company = new Company();
            //company.CompanyName = existingCompany.CompanyName;
            //company.IsVerified = false;
            //company.IsVisible = false;
            //company.IsDeleted = false;
            //company.JobPostingBudget = 0.00m;
            //company.CostPerClick = 0.00m;
            //company.StreetAddress = existingCompany.StreetAddress;
            //company.StreetAddress2 = existingCompany.StreetAddress2;
            //company.City = existingCompany.City;
            //company.State = existingCompany.State;
            //company.ZipCode = existingCompany.ZipCode;
            //company.Description = existingCompany.Description;
            //company.PhoneNumber = existingCompany.PhoneNumber;
            //company.EmailAddress = existingCompany.EmailAddress;
            //company.MainUrl = existingCompany.MainUrl;
            //company.FacebookUrl = existingCompany.FacebookUrl;
            //company.LinkedinUrl = existingCompany.LinkedinUrl;
            //company.TwitterUrl = existingCompany.TwitterUrl;
            //company.GoogleplusUrl = existingCompany.GoogleplusUrl;
            //company.Logo = existingCompany.Logo;
            //company.CompanyAdminId = user.Id;
            //company.UserCreatedId = user.Id;
            //company.UserUpdatedId = user.Id;
            //company.DateCreated = DateTime.Now;
            //company.DateUpdated = DateTime.Now;
            //db.Companies.Add(company);

            int rowsChanged = 0;

            try
            {
                rowsChanged = db.SaveChanges();

                //TODO: Send an email                

            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder errorSb = new StringBuilder();
                ex.EntityValidationErrors.SelectMany(e => e.ValidationErrors).ToList().ForEach(e => errorSb.AppendLine(string.Format("{0} | {1}", e.PropertyName, e.ErrorMessage)));
                string errorString = errorSb.ToString();
            }

            return rowsChanged == 1;
        }

        public Company DeleteCompany(int id)
        {
            Company company = new Company();
            company = db.Companies
                                    .Where(c => c.CompanyId == id)
                                    //.Where(c=>c.Hidden == false)
                                    .FirstOrDefault();
            company.IsDeleted = true;
            db.SaveChanges();
            return db.Companies.FirstOrDefault();
        }        
    }
}