using JRDEVDataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class JobAppliedVM
    {
       // public List<JobVM> JobsApplied { get; set; }
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int JobId{get;set;}
        public int CompanyId { get; set; }
    }
}