using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.MockDataAdapters
{
    //public class UserMockDataAdapter : IUserAdapter
    //{
    //    public List<JRDEVDataModels.User> GetUsers()
    //    {
    //        List<User> users = new List<User>()
    //        {
    //        new User { CurrentlyLooking = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, DesiredSalary = 80000, FirstName = "Cody", Hidden = false,  LastName = "Shipley", UserCreatedId = "1", Id = "1",  UserUpdatedId = "1", WillRelocate = true },
    //        new User { CurrentlyLooking = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, DesiredSalary = 10000, FirstName = "Yoon", Hidden = false,  LastName = "Koo", UserCreatedId = "2", Id = "2",  UserUpdatedId = "2", WillRelocate = true }
    //        };
    //        return users ;
    //    }

    //    public JRDEVDataModels.User GetUser(string id)
    //    {
    //        User user = new User
    //        {
    //            CurrentlyLooking = true,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            DesiredSalary = 80000,
    //            FirstName = "Cody",
    //            Hidden = false,
               
    //            LastName = "Shipley",
    //            UserCreatedId = "1",
    //            Id = "1",
               
    //            UserUpdatedId = "1",
    //            WillRelocate = true
    //        };
    //        return user;

    //    }

    //    public JRDEVDataModels.User PostNewUser(JRDEVDataModels.User newUser)
    //    {
    //        List<User> users = new List<User>()
    //        {
    //        new User { CurrentlyLooking = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, DesiredSalary = 80000, FirstName = "Cody", Hidden = false, LastName = "Shipley", UserCreatedId ="1", Id = "1", UserUpdatedId = "1", WillRelocate = true },
    //        new User { CurrentlyLooking = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, DesiredSalary = 10000, FirstName = "Yoon", Hidden = false,  LastName = "Koo", UserCreatedId = "2", Id = "2", UserUpdatedId = "2", WillRelocate = true }
    //        };
    //        User user = new User();
    //        user.Id = newUser.Id;
    //        user.CurrentlyLooking = newUser.CurrentlyLooking;
    //        user.DateCreated = DateTime.Now;
    //        user.DateUpdated = DateTime.Now;
    //        user.DesiredSalary = newUser.DesiredSalary;
    //        user.FirstName = newUser.FirstName;
           
    //        user.LastName = newUser.LastName;
    //        user.UserCreatedId = newUser.UserCreatedId;
          
    //        user.UserUpdatedId = newUser.UserUpdatedId;
    //        user.WillRelocate = newUser.WillRelocate;
    //        users.Add(user);
    //        return users.FirstOrDefault();
    //    }

    //    public JRDEVDataModels.User PutNewUser(string id, JRDEVDataModels.User newUser)
    //    {
    //        List<User> users = new List<User>()
    //        {
    //        new User { CurrentlyLooking = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, DesiredSalary = 80000, FirstName = "Cody", Hidden = false,  LastName = "Shipley", UserCreatedId = "1", Id = "1", UserUpdatedId = "1", WillRelocate = true },
    //        new User { CurrentlyLooking = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, DesiredSalary = 10000, FirstName = "Yoon", Hidden = false,  LastName = "Koo", UserCreatedId = "2", Id = "2",  UserUpdatedId = "2", WillRelocate = true }
    //        };
    //        User user = new User() 
    //        { 
    //           CurrentlyLooking = true, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, DesiredSalary = 80000, FirstName = "Cody", Hidden = false,  LastName = "Shipley", UserCreatedId = "1", Id = "1", UserUpdatedId = "1", WillRelocate = true
    //        };
    //        user.Id = newUser.Id;
    //        user.CurrentlyLooking = newUser.CurrentlyLooking;
    //        user.DateCreated = DateTime.Now;
    //        user.DateUpdated = DateTime.Now;
    //        user.DesiredSalary = newUser.DesiredSalary;
    //        user.FirstName = newUser.FirstName;
            
    //        user.LastName = newUser.LastName;
    //        user.UserCreatedId = newUser.UserCreatedId;
            
    //        user.UserUpdatedId = newUser.UserUpdatedId;
    //        user.WillRelocate = newUser.WillRelocate;
    //        return user;
    //    }

    //    public JRDEVDataModels.User DeleteUser(string id)
    //    {
    //        User user = new User();
    //        user.Hidden = true;

    //        return user;
    //    }
    //}
}