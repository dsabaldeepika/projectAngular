using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class SavedJobVM
    {
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public DateTime DateSubmitted { get; set; }
        public int JobId{get;set;}
        public int SavedJobId { get; set; }
    }
}