using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class ApplyToAllJobsVM
    {
    
        public int JobId { get; set; }
        public int ResumeId { get; set; }
        public int SavedJobId { get; set; }

    }
}