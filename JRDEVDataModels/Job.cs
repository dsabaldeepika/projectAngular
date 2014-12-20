using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class Job : ContactInfo
    {
        public int JobId { get; set; }
        public byte StatusId { get; set; }
        public int NumOfApplications { get; set; }
        public int NumOfClicks { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public int YearsExperience { get; set; }
        public int SalaryMin { get; set; }
        public int SalaryMax { get; set; }
        public double JobBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual List<JobSkill> JobSkills { get; set; }
        [InverseProperty("Job")]
        public virtual List<Application> Applications { get; set; }
        [InverseProperty("Job")]
        public virtual List<JobTimeStamp> JobTimeStamps { get; set; }
        
        public virtual List<Click> Clicks { get; set; }
        
        //foreign key
        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    }
}
