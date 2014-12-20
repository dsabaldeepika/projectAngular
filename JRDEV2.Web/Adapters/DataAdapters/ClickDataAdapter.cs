using JRDEV2.Web.Adapters.Interfaces;
using JRDEVData;
using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Adapters.DataAdapters
{
    public class ClickDataAdapter : IClickAdapter
    { 
        ApplicationDbContext db = new ApplicationDbContext();

        public List<Click> GetClicks()
        {
            List<Click> clicks = new List<Click>();
            clicks = db.Clicks.ToList();
                //.Where(c => c.Hidden == false)
            return clicks;
        }

        public Click GetClick(int id)
        {
            Click click = new Click();
            click = db.Clicks
                                //.Where(c => c.Hidden == false)
                                .Where(c=>c.ClickId == id)
                                .FirstOrDefault();
                                
            return click;
        }

        public Click PostNewClick(Click newClick)
        {
            Click click = new Click();
            click.ClickId = newClick.ClickId;
            //click.NumOfClicks = newClick.NumOfClicks;
            click.IpAddress = newClick.IpAddress;
            click.JobId = newClick.JobId;
            click.DateCreated = DateTime.Now;
            click.UserCreatedId = newClick.UserCreatedId;
            db.Clicks.Add(click);
            db.SaveChanges();          
            return click;
        }

        public Click PutClick(int id, Click newClick)
        {
            Click click = new Click();
            click = db.Clicks
                        //.Where(c => c.Hidden == false)
                        .Where(c => c.ClickId == id)
                        .FirstOrDefault();
            //click.NumOfClicks = 1 + click.NumOfClicks;
            click.IpAddress = newClick.IpAddress;
            click.JobId = newClick.JobId;
            click.DateUpdated = DateTime.Now;
            click.UserUpdatedId = newClick.UserUpdatedId;
            db.SaveChanges();
            return click;
        }

        public Click DeleteClick(int id)
        {
            Click click = new Click();
            click = db.Clicks
                        //.Where(c=>c.Hidden == false)
                        .Where(c => c.ClickId == id)
                        .FirstOrDefault();
            click.IsDeleted = true;
            db.SaveChanges();
            return click;
        }

    }
}