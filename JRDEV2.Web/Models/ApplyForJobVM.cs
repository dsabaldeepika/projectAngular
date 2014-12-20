using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class ApplyForJobVM
    {
        public int JobId { get; set; }
        public int ResumeId { get; set; }
        public string Content { get; set; }
        public string Title { get; set; }

    }
}