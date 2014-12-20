using JRDEV2.Web.Models;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEV2.Web.Adapters.Interfaces
{
    public interface IMessagesAdapter
    {

        List<MessageVM> GetMessages(string userID);
        List<MessageVM> GetCompanyMessage();
        MessageVM GetMessage(string userID, int id);
       
        //Message PutNewMessage(int id, Message newMessage);
        Message PostNewMessage(MessageVM newMessage, string userID);
        Message deleteMessage(int id);
    }
}
