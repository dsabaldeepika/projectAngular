using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using JRDEV2.Web.Models;
using System.Data.Entity.Validation;
using System.Text;


namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class MessageDataAdapter : IMessagesAdapter
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public List<MessageVM> GetMessages(string userID)
        {
            var q = db.Messages.Where(m => m.IsMessageToCompany == false)
                      .Select(m => new MessageVM
                      {
                          MessageId = m.MessageId, 
                          From = m.UserCreated.FirstName + " " + m.UserCreated.LastName,
                          FromId = m.UserCreated.Id,
                          Subject = m.Subject,
                          Body = m.Content,
                          Date = m.DateCreated,
                          DateRead = m.DateRead
                      });

            var result = q.ToList();
            var count = result.Count;
            return result;
        }
        //ray was here
        public List<MessageVM> GetCompanyMessage()
        {
            //var userCompanyId = db.Users.FirstOrDefault(u => u.Id == userID).CompanyId;
            var q = db.Messages.Where(m => m.IsMessageToCompany == true)
                      .Select(m => new MessageVM
                      {
                          MessageId = m.MessageId,
                          From = m.UserCreated.FirstName + " " + m.UserCreated.LastName,
                          FromId = m.UserCreated.Id,
                          Subject = m.Subject,
                          Body = m.Content,
                          Date = m.DateCreated,
                          DateRead = m.DateRead
                      });
            return q.ToList();
        }

        public MessageVM GetMessage(string userID, int id)
        {
            var q = db.Messages.Where(m => m.MessageId == id)
                      .Select(m => new MessageVM
                      {
                          MessageId = m.MessageId, 
                          From = m.UserCreated.FirstName + " " + m.UserCreated.LastName,
                          FromId = m.UserCreated.Id,
                          Subject = m.Subject,
                          Body = m.Content,
                          Date = m.DateCreated,
                          DateRead = m.DateRead
                      });
            
            return q.FirstOrDefault();
        }
        ////Code for updating message
        //public Message PutNewMessage(int id, Message newMessage)
        //{
        //    Message message = new Message();
        //    message = db.Messages
        //                        .Where(m=>m.MessageId == id)
        //                        //.Where(m=>m.Hidden == false)
        //                        .FirstOrDefault();
        //    //message.DateCreated = newMessage.DateCreated;
        //    message.DateUpdated = DateTime.Now;
        //    message.MessageId = newMessage.MessageId;
        //    message.Content = newMessage.Content;
        //    message.Subject = newMessage.Subject;
        //    message.UserCreatedId = newMessage.UserCreatedId;
        //    message.UserId = newMessage.UserId;
        //    message.UserUpdatedId = newMessage.UserUpdatedId;
        //    db.SaveChanges();
        //    return message;
        //}
        //Code for sending a message
        public Message PostNewMessage(MessageVM newMessage, string userID)
        {
            Message message = new Message();
            User user = db.Users.Where(u => u.Id == userID).FirstOrDefault();
            message.UserCreatedId = userID;
            message.UserUpdatedId = userID;
            
            message.Subject = newMessage.Subject;
            message.Content = newMessage.Body;
            message.UserId = newMessage.ToId;
            message.DateCreated = DateTime.Now;
            message.DateUpdated = DateTime.Now;
            if (user.CompanyId == null) //User is a TalentProfile
            {
                message.IsMessageToCompany = true;
                User user2 = db.Users.Where(u => u.Id == newMessage.ToId).FirstOrDefault();
                message.CompanyId = (int)user2.CompanyId;
            }
            else //User is from a company
            {
                message.IsMessageToCompany = false;
                message.CompanyId = (int)user.CompanyId;
            }
            db.Messages.Add(message);
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

            return message;
        }

        public Message deleteMessage(int id)
        {
            Message message = new Message();
            message = db.Messages
                                .Where(m=>m.MessageId == id)
                                //.Where(m=>m.Hidden == false)
                                .FirstOrDefault();
            message.IsDeleted = true;

            db.SaveChanges();
            return message;
        }
    }
}