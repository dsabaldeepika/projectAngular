using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JRDEV2.Web.Models
{
    public class JobVM
    {
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int YearsExperience { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public double JobBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumOfApplicants { get; set; }
        public int NumOfClicks { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}