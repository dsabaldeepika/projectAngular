using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface IUserAdapter
    {
        List<User> GetUsers();
        User GetUser(string id);
        User PostNewUser(User newUser);
        User PutNewUser(string id, User newUser);
        User DeleteUser(string id);
        LoggedInUserViewModel GetLoggedInUserModel(string id);
    }
}
