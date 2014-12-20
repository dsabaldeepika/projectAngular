using JRDEV2.Web.Adapters.DataAdapters;
using JRDEV2.Web.Adapters.Interfaces;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.MockDataAdapters
{
    //public class MessagesMockDataAdapter : IMessagesAdapter
    //{
    //    public List<Message> GetMessages()
    //    {
    //        List<Message> Messages = new List<Message>()
    //        {
    //            new Message { MessageId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "Ayyy", MsgSubject = "U want a job lol", UserCreatedId = "1", UserId = "1", UserUpdatedId = "1" },
    //            new Message { MessageId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "ur not hired", MsgSubject = "sucks 2 suck", UserUpdatedId = "2", UserId = "2", UserCreatedId = "2" }
    //        };
    //        return Messages;
    //    }

    //    public Message GetMessage(int id)
    //    {
    //        Message model = new Message()
    //        {
    //            MessageId = 1,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            MsgBody = "Ayyy",
    //            MsgSubject = "U want a job lol",
    //            UserCreatedId = "1",
    //            UserId = "1",
    //            UserUpdatedId = "1"
    //        };
    //        return model;
    //    }

    //    public Message PutNewMessage(int id, Message newMessage)
    //    {
    //        Message message = new Message()
    //        {
    //            MessageId = 1,
    //            DateCreated = DateTime.Now,
    //            DateUpdated = DateTime.Now,
    //            MsgBody = "Ayyy",
    //            MsgSubject = "U want a job lol",
    //            UserCreatedId = "1",
    //            UserId = "1",
    //            UserUpdatedId = "1"

    //        };
    //        message.DateCreated = newMessage.DateCreated;
    //        message.DateUpdated = newMessage.DateUpdated;
    //        message.Hidden = newMessage.Hidden;
    //        message.MessageId = newMessage.MessageId;
    //        message.MsgBody = newMessage.MsgBody;
    //        message.MsgSubject = newMessage.MsgSubject;
    //        message.UserCreatedId = newMessage.UserCreatedId;
    //        message.UserId = newMessage.UserId;
    //        message.UserUpdatedId = newMessage.UserUpdatedId;

    //        return message;

    //    }

    //    public List<Message> PostNewMessage(Message newMessage)
    //    {
    //        List<Message> Messages = new List<Message>()
    //        {
    //            new Message { MessageId = 1, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "Ayyy", MsgSubject = "U want a job lol", UserCreatedId ="1", UserId = "1", UserUpdatedId = "1" },
    //            new Message { MessageId = 2, DateCreated = DateTime.Now, DateUpdated = DateTime.Now, MsgBody = "ur not hired", MsgSubject = "sucks 2 suck", UserUpdatedId = "2", UserId = "2", UserCreatedId = "2" }
    //        };
    //        Message message = new Message();
    //        message.DateCreated = newMessage.DateCreated;
    //        message.DateUpdated = newMessage.DateUpdated;
    //        message.Hidden = newMessage.Hidden;
    //        message.MessageId = newMessage.MessageId;
    //        message.MsgBody = newMessage.MsgBody;
    //        message.MsgSubject = newMessage.MsgSubject;
    //        message.UserCreatedId = newMessage.UserCreatedId;
    //        message.UserId = newMessage.UserId;
    //        message.UserUpdatedId = newMessage.UserUpdatedId;
    //        Messages.Add(message);

    //        return Messages;
    //    }

    //    public Message deleteMessage(int id)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}