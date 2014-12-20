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
    public class TalentProfileDataAdapter : ITalentProfileAdapter
    {     
        
           //Commented out byte George W. 4/29/30
        //public TalentProfile GetTalentProfile(string id)
        //{
        //    ApplicationDbContext db = new ApplicationDbContext();            

        //    TalentProfile model = new TalentProfile();
        //    model = db.TalentProfiles
        //        //.Where(j=>j.Hidden == false)
        //                    .Where(t => t.UserId == id)
        //                    .FirstOrDefault();
        //    return model;

        //}
        public TalentVM GetTalentVM(string id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            TalentProfile talentProfile = new TalentProfile();
            talentProfile = db.TalentProfiles
                           .Where(j => j.UserId == id && j.IsDeleted == false)
                //.Where(j=>j.Hidden == false)
                .FirstOrDefault();

            User user = new User();
            user = db.Users.Where(u => u.Id == id).FirstOrDefault();

            TalentVM talentVM = new TalentVM();
            talentVM.FirstName = user.FirstName;
            talentVM.LastName = user.LastName;
            talentVM.UserName = user.UserName; //Added by George W. 5/6/14
            talentVM.StreetAddress = talentProfile.StreetAddress;
            talentVM.StreetAddress2 = talentProfile.StreetAddress2;
            talentVM.City = talentProfile.City;
            talentVM.State = talentProfile.State;
            talentVM.ZipCode = talentProfile.ZipCode;
            talentVM.Summary = talentProfile.Summary;
            talentVM.Skills = talentProfile.Skills;
            talentVM.DesiredSalary = talentProfile.DesiredSalary;
            talentVM.WillRelocate = talentProfile.WillRelocate;
            talentVM.CurrentlyLooking = talentProfile.CurrentlyLooking;
            talentVM.MainUrl = talentProfile.MainUrl;
            talentVM.FacebookUrl = talentProfile.FacebookUrl;
            talentVM.LinkedinUrl = talentProfile.LinkedinUrl;
            talentVM.TwitterUrl = talentProfile.TwitterUrl;
            talentVM.GoogleplusUrl = talentProfile.GoogleplusUrl;
            talentVM.PicFile = talentProfile.PicFile;
            talentVM.EmailAddress = talentProfile.EmailAddress;
            talentVM.EmailAddress2 = talentProfile.EmailAddress2;
            talentVM.PhoneNumber = talentProfile.PhoneNumber;
            talentVM.PhoneNumber2 = talentProfile.PhoneNumber2;

            return talentVM;
        }

        public TalentProfile PostNewTalentProfile(TalentVM newTalent)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            var userManager = Startup.UserManagerFactoryWithDb(db);

            User user = new User();
            user.FirstName = newTalent.FirstName;
            user.LastName = newTalent.LastName;
            user.UserName = newTalent.UserName;
            user.DateCreated = DateTime.Now;
            user.DateUpdated = DateTime.Now;

            TalentProfile talentProfile = new TalentProfile();
            talentProfile.StreetAddress = newTalent.StreetAddress;
            talentProfile.StreetAddress2 = newTalent.StreetAddress2;
            talentProfile.City = newTalent.City;
            talentProfile.State = newTalent.State;
            talentProfile.ZipCode = newTalent.ZipCode;
            talentProfile.Summary = newTalent.Summary;
            talentProfile.Skills = newTalent.Skills;
            //Uncommented by George W. 5/1/14
            //===========================================================
            talentProfile.DesiredSalary = newTalent.DesiredSalary;
            talentProfile.WillRelocate = newTalent.WillRelocate;
            //===========================================================
            talentProfile.MainUrl = newTalent.MainUrl;
            talentProfile.FacebookUrl = newTalent.FacebookUrl;
            talentProfile.LinkedinUrl = newTalent.LinkedinUrl;
            talentProfile.TwitterUrl = newTalent.TwitterUrl;
            talentProfile.GoogleplusUrl = newTalent.GoogleplusUrl;
            talentProfile.PicFile = newTalent.PicFile;
            talentProfile.EmailAddress = newTalent.EmailAddress;
            talentProfile.EmailAddress2 = newTalent.EmailAddress2;
            talentProfile.PhoneNumber = newTalent.PhoneNumber;
            talentProfile.PhoneNumber2 = newTalent.PhoneNumber2;
            talentProfile.DateCreated = talentProfile.DateUpdated = DateTime.Now;

            var userCreateResult = userManager.Create(user, newTalent.Password);

            if (!userCreateResult.Succeeded)
                return talentProfile;

            var roleAddResult = userManager.AddToRole(user.Id, UserRoles.TALENTUSER);

            if (!roleAddResult.Succeeded)
                return talentProfile;
                       
            db.TalentProfiles.Add(talentProfile);            

            talentProfile.User = user;
            talentProfile.UserCreated = user;
            talentProfile.UserUpdated = user;            

            // May need to be in apiTalentProfileController.cs
            // AccountController.cs has definition and use of UserManager (really UserManager<User>)
            // The Create method exists only as part of an extension to Identity Entity
            // May need to add check for bad result
            // This statement forces a database save
            // When uncommented, the db.SaveChanges statement below can be removed
            //var result = UserManager.Create(user, newTalent.Password);

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

            //var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //var identity = userManager.CreateIdentity(user, OAuthDefaults.AuthenticationType);
            //var cookieIdentity = userManager.CreateIdentity(user, CookieAuthenticationDefaults.AuthenticationType);
            //AuthenticationProperties properties = ApplicationOAuthProvider.CreateProperties(user.UserName);
            //authenticationManager.SignIn(properties, identity, cookieIdentity);
            
            return talentProfile;
        }

        public TalentProfile PATCHTalentVM(string userID, TalentVM newTalentVM)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            
            TalentProfile talentProfile = new TalentProfile();
            talentProfile = db.TalentProfiles.Where(j => j.UserId == userID)
                //.Where(j=>j.Hidden == false)
                        .FirstOrDefault();
            
            //George W. 5/7/12
            //======================================================================
            user.UserName = newTalentVM.UserName;
            user.FirstName = newTalentVM.FirstName;
            user.LastName = newTalentVM.LastName;
            talentProfile.WillRelocate = newTalentVM.WillRelocate;
            talentProfile.CurrentlyLooking = newTalentVM.CurrentlyLooking;
            //======================================================================
            talentProfile.StreetAddress = newTalentVM.StreetAddress;
            talentProfile.StreetAddress2 = newTalentVM.StreetAddress2;
            talentProfile.City = newTalentVM.City;
            talentProfile.State = newTalentVM.State;
            talentProfile.ZipCode = newTalentVM.ZipCode;
            talentProfile.MainUrl = newTalentVM.MainUrl;
            talentProfile.FacebookUrl = newTalentVM.FacebookUrl;
            talentProfile.LinkedinUrl = newTalentVM.LinkedinUrl;
            talentProfile.TwitterUrl = newTalentVM.TwitterUrl;
            talentProfile.GoogleplusUrl = newTalentVM.GoogleplusUrl;
            talentProfile.EmailAddress = newTalentVM.EmailAddress;
            talentProfile.EmailAddress2 = newTalentVM.EmailAddress2;
            talentProfile.PhoneNumber = newTalentVM.PhoneNumber;
            talentProfile.PhoneNumber2 = newTalentVM.PhoneNumber2;
            talentProfile.DesiredSalary = newTalentVM.DesiredSalary;
            talentProfile.Summary = newTalentVM.Summary;
            talentProfile.Skills = newTalentVM.Skills;

            //Set Variables
            db.SaveChanges();
            return talentProfile;
        }

        //Created by George W. 5/6/14
        //============================================================================
        public TalentProfile PATCHTalentSettings(int id, string userID, TalentVM newTalentVM)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();

            TalentProfile talentProfile = new TalentProfile();
            talentProfile = db.TalentProfiles.Where(j => j.UserId == userID)
                //.Where(j=>j.Hidden == false)
                        .FirstOrDefault();

            user.UserName = newTalentVM.UserName;
            user.FirstName = newTalentVM.FirstName;
            user.LastName = newTalentVM.LastName;
            talentProfile.WillRelocate = newTalentVM.WillRelocate;
            talentProfile.CurrentlyLooking = newTalentVM.CurrentlyLooking;
            

           
            db.SaveChanges();
            return talentProfile;
        }
        //============================================================================
        public TalentProfile DeleteTalentProfile(int id)
        {
            ApplicationDbContext db = new ApplicationDbContext();

            TalentProfile talentProfile = new TalentProfile();
            talentProfile = db.TalentProfiles
                            .Where(j => j.TalentProfileId == id)
                //.Where(j=>j.Hidden == false)
                            .FirstOrDefault();
            talentProfile.IsDeleted = true;
            db.SaveChanges();
            return talentProfile;
        }
    }
}