using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JRDEV2.Web.Models;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class UserDataAdapter : IUserAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public List<JRDEVDataModels.User> GetUsers()
        {
            List<User> model = new List<User>();
            model = db.Users
                            //.Where(u=>u.Hidden == false)
                            .ToList();
            return model;
        }

        public JRDEVDataModels.User GetUser(string id)
        {
            User user = new User();
            user = db.Users
                            .Where(u => u.Id == id)
                            //.Where(u=>u.Hidden == false)
                            .FirstOrDefault();


            return user;
        }

        public LoggedInUserViewModel GetLoggedInUserModel(string id)
        {
            LoggedInUserViewModel model = new LoggedInUserViewModel();
            var user = db.Users
                            .Where(u => u.Id == id)
                            .Include(u => u.Roles.Select(r => r.Role))
                //.Where(u=>u.Hidden == false)
                            .FirstOrDefault();

            

            model.UserId = user.Id;
            model.UserName = user.UserName;
            model.RoleName = user.Roles.FirstOrDefault().Role.Name;
            if (model.RoleName == "CompanyAdmin")
            {
                var user1 = db.Companies
                            .Where(u => u.CompanyAdminId == id)
                            .FirstOrDefault().CompanyId;
                model.CompanyId = user1;
            }
            else if (model.RoleName == "CompanyUser")
            {
                //var user1 = db.TalentProfiles
                //            .Where(u => u.UserId == id)
                //            .FirstOrDefault().TalentProfileId;
                model.CompanyId = 1;
            }
            else if (model.RoleName == "TalentUser")
            {
                var user1 = db.TalentProfiles
                            .Where(u => u.UserId == id)
                            .FirstOrDefault().TalentProfileId;
                model.CompanyId = user1; 
            }
            //model.CompanyId = 2;
            //int cid = user.CompanyId;

            //model.RoleName = user.Roles.FirstOrDefault().Role.Name;


            return model;
        }

        public JRDEVDataModels.User PostNewUser(JRDEVDataModels.User newUser)
        {
            User user = new User();
            user.Id = newUser.Id;
            //user.CurrentlyLooking = newUser.CurrentlyLooking;
            user.DateCreated = DateTime.Now;
            user.DateUpdated = DateTime.Now;
            //user.DesiredSalary = newUser.DesiredSalary;
            user.FirstName = newUser.FirstName;
            
            user.LastName = newUser.LastName;
            user.UserCreatedId = newUser.UserCreatedId;
            
            //user.UserUpdatedId = newUser.UserUpdatedId;
            //user.WillRelocate = newUser.WillRelocate;
            db.Users.Add(user);
            db.SaveChanges();
            return db.Users.FirstOrDefault();
        }

        public JRDEVDataModels.User PutNewUser(string id, JRDEVDataModels.User newUser)
        {
            User user = new User();
            user = db.Users
                            .Where(u => u.Id == id)
                            //.Where(u=>u.Hidden == false)
                            .FirstOrDefault();
            user.Id = newUser.Id;
            //user.CurrentlyLooking = newUser.CurrentlyLooking;
            //user.DateCreated = newUser.DateCreated;
            user.DateUpdated = DateTime.Now;
            //user.DesiredSalary = newUser.DesiredSalary;
            user.FirstName = newUser.FirstName;
         
            user.LastName = newUser.LastName;
            //user.UserCreatedId = newUser.UserCreatedId;
          
            user.UserUpdatedId = newUser.UserUpdatedId;
            //user.WillRelocate = newUser.WillRelocate;
            db.SaveChanges();

            return user;
        }

        public JRDEVDataModels.User DeleteUser(string id)
        {
            User user = new User();
            user = db.Users
                            .Where(u => u.Id == id)
                            //.Where(u=>u.Hidden == false)
                            .FirstOrDefault();
            user.IsDeleted = true;
            //user.Hidden = true;
            return db.Users.FirstOrDefault();
        }
    }
}