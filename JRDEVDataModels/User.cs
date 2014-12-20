using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVDataModels
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public DateTime DateCreated { get; set; }
        public DateTime DateUpdated { get; set; }
        
        public string UserCreatedId { get; set; }
        public string UserUpdatedId { get; set; }
        public bool IsDeleted { get; set; }

        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public virtual Company Company { get; set; }
    //foreign key

        //TODO: Link these together correctly with the appropriate foreign keys, inverse, attributes, etc.
        [InverseProperty("User")]
        public virtual List<Message> Messages { get; set; }
        [InverseProperty("User")]
        public virtual List<Resume> Resumes { get; set; }
        [InverseProperty("User")]
        public virtual List<Application> Applications { get; set; }
        [InverseProperty("User")]
        public virtual List<SavedJob> SavedJobs { get; set; }
        public virtual List<UserSkill> UserSkills { get; set; }
        [InverseProperty("User")]
        public virtual List<Note> Notes { get; set; }
        [InverseProperty("User")]
        public virtual List<Job> PostedJobs { get; set; }
    }
}
