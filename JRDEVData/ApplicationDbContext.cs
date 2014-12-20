using JRDEVDataModels;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRDEVData
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Company> Companies { get; set; }  
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Message> Messages { get; set; } 
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Click> Clicks { get; set; }
        //public DbSet<PaymentInfo> PaymentInfos { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UsersSkills { get; set; }
        public DbSet<JobTimeStamp> JobTimeStamp { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<SavedJob> SavedJobs { get; set; }
        public DbSet<TalentProfile> TalentProfiles { get; set; }
        public DbSet<JobSkill> JobSkills { get; set; }
    }
}
