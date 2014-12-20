namespace JRDEVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialNewSchema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Applications",
                c => new
                    {
                        ApplicationId = c.Int(nullable: false, identity: true),
                        StatusId = c.Byte(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        JobId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        ResumeId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ApplicationId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.Resumes", t => t.ResumeId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .Index(t => t.JobId)
                .Index(t => t.User_Id)
                .Index(t => t.ResumeId)
                .Index(t => t.UserId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        StatusId = c.Byte(nullable: false),
                        NumOfApplications = c.Int(nullable: false),
                        NumOfClicks = c.Int(nullable: false),
                        JobTitle = c.String(),
                        Description = c.String(),
                        YearsExperience = c.Int(nullable: false),
                        SalaryMin = c.Int(nullable: false),
                        SalaryMax = c.Int(nullable: false),
                        JobBudget = c.Double(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        CompanyId = c.Int(nullable: false),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .Index(t => t.CompanyId)
                .Index(t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId);
            
            CreateTable(
                "dbo.Clicks",
                c => new
                    {
                        ClickId = c.Int(nullable: false, identity: true),
                        ClickeeId = c.String(maxLength: 128),
                        ClickerId = c.String(maxLength: 128),
                        JobId = c.Int(),
                        IpAddress = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ClickId)
                .ForeignKey("dbo.AspNetUsers", t => t.ClickeeId)
                .ForeignKey("dbo.AspNetUsers", t => t.ClickerId)
                .ForeignKey("dbo.Jobs", t => t.JobId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .Index(t => t.ClickeeId)
                .Index(t => t.ClickerId)
                .Index(t => t.JobId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateCreated = c.DateTime(),
                        DateUpdated = c.DateTime(),
                        UserCreatedId = c.String(),
                        UserUpdatedId = c.String(),
                        IsDeleted = c.Boolean(),
                        CompanyId = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Company_CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Companies", t => t.Company_CompanyId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.Company_CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
                        IsVerified = c.Boolean(nullable: false),
                        IsVisible = c.Boolean(nullable: false),
                        JobPostingBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerClick = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompanyName = c.String(),
                        Description = c.String(),
                        Logo = c.String(),
                        CompanyAdminId = c.String(maxLength: 128),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CompanyId)
                .ForeignKey("dbo.AspNetUsers", t => t.CompanyAdminId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .Index(t => t.CompanyAdminId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Content = c.String(),
                        IsMessageToCompany = c.Boolean(nullable: false),
                        DateRead = c.DateTime(),
                        UserId = c.String(maxLength: 128),
                        CompanyId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.CompanyId)
                .Index(t => t.UserId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        NoteId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Message = c.String(),
                        UserId = c.String(maxLength: 128),
                        ApplicationId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.NoteId)
                .ForeignKey("dbo.Applications", t => t.ApplicationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.ApplicationId)
                .Index(t => t.UserId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ResumeId = c.Int(nullable: false, identity: true),
                        Heading = c.String(),
                        Summary = c.String(),
                        WorkExperience = c.String(),
                        Education = c.String(),
                        OtherInfo = c.String(),
                        UserId = c.String(maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ResumeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.SavedJobs",
                c => new
                    {
                        SavedJobId = c.Int(nullable: false, identity: true),
                        StatusId = c.Byte(nullable: false),
                        JobId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.SavedJobId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.JobId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        SkillId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Job_JobId = c.Int(),
                    })
                .PrimaryKey(t => t.SkillId)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId)
                .Index(t => t.Job_JobId);
            
            CreateTable(
                "dbo.JobTimeStamps",
                c => new
                    {
                        JobTimeStampId = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.JobTimeStampId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .Index(t => t.JobId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId);
            
            CreateTable(
                "dbo.TalentProfiles",
                c => new
                    {
                        TalentProfileId = c.Int(nullable: false, identity: true),
                        DesiredSalary = c.Int(nullable: false),
                        WillRelocate = c.Boolean(nullable: false),
                        CurrentlyLooking = c.Boolean(nullable: false),
                        IsLookingForJob = c.Boolean(nullable: false),
                        UserId = c.String(maxLength: 128),
                        DateCreated = c.DateTime(nullable: false),
                        DateUpdated = c.DateTime(nullable: false),
                        UserCreatedId = c.String(maxLength: 128),
                        UserUpdatedId = c.String(maxLength: 128),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TalentProfileId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserCreatedId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserUpdatedId)
                .Index(t => t.UserId)
                .Index(t => t.UserCreatedId)
                .Index(t => t.UserUpdatedId);
            
            CreateTable(
                "dbo.UserSkills",
                c => new
                    {
                        UserSkillId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserSkillId)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.SkillId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.SkillUsers",
                c => new
                    {
                        Skill_SkillId = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Skill_SkillId, t.User_Id })
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Skill_SkillId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSkills", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.TalentProfiles", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TalentProfiles", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TalentProfiles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "ResumeId", "dbo.Resumes");
            DropForeignKey("dbo.Jobs", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Skills", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobTimeStamps", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobTimeStamps", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.JobTimeStamps", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Clicks", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clicks", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clicks", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Clicks", "ClickerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Clicks", "ClickeeId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SkillUsers", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.SavedJobs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavedJobs", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavedJobs", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavedJobs", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resumes", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resumes", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Companies", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "UserUpdatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Companies", "CompanyAdminId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Applications", "JobId", "dbo.Jobs");
            DropIndex("dbo.UserSkills", new[] { "UserId" });
            DropIndex("dbo.UserSkills", new[] { "SkillId" });
            DropIndex("dbo.TalentProfiles", new[] { "UserUpdatedId" });
            DropIndex("dbo.TalentProfiles", new[] { "UserCreatedId" });
            DropIndex("dbo.TalentProfiles", new[] { "UserId" });
            DropIndex("dbo.Applications", new[] { "UserUpdatedId" });
            DropIndex("dbo.Applications", new[] { "UserCreatedId" });
            DropIndex("dbo.Applications", new[] { "UserId" });
            DropIndex("dbo.Applications", new[] { "ResumeId" });
            DropIndex("dbo.Jobs", new[] { "UserUpdatedId" });
            DropIndex("dbo.Jobs", new[] { "UserCreatedId" });
            DropIndex("dbo.Skills", new[] { "Job_JobId" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropIndex("dbo.JobTimeStamps", new[] { "UserUpdatedId" });
            DropIndex("dbo.JobTimeStamps", new[] { "UserCreatedId" });
            DropIndex("dbo.JobTimeStamps", new[] { "JobId" });
            DropIndex("dbo.Clicks", new[] { "UserUpdatedId" });
            DropIndex("dbo.Clicks", new[] { "UserCreatedId" });
            DropIndex("dbo.Clicks", new[] { "JobId" });
            DropIndex("dbo.Clicks", new[] { "ClickerId" });
            DropIndex("dbo.Clicks", new[] { "ClickeeId" });
            DropIndex("dbo.SkillUsers", new[] { "User_Id" });
            DropIndex("dbo.SkillUsers", new[] { "Skill_SkillId" });
            DropIndex("dbo.SavedJobs", new[] { "User_Id" });
            DropIndex("dbo.SavedJobs", new[] { "UserUpdatedId" });
            DropIndex("dbo.SavedJobs", new[] { "UserCreatedId" });
            DropIndex("dbo.SavedJobs", new[] { "JobId" });
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            DropIndex("dbo.Resumes", new[] { "UserUpdatedId" });
            DropIndex("dbo.Resumes", new[] { "UserCreatedId" });
            DropIndex("dbo.Resumes", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropIndex("dbo.Notes", new[] { "User_Id" });
            DropIndex("dbo.Notes", new[] { "UserUpdatedId" });
            DropIndex("dbo.Notes", new[] { "UserCreatedId" });
            DropIndex("dbo.Notes", new[] { "UserId" });
            DropIndex("dbo.Notes", new[] { "ApplicationId" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "CompanyId" });
            DropIndex("dbo.Companies", new[] { "UserUpdatedId" });
            DropIndex("dbo.Companies", new[] { "UserCreatedId" });
            DropIndex("dbo.Messages", new[] { "UserUpdatedId" });
            DropIndex("dbo.Messages", new[] { "UserCreatedId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "CompanyId" });
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId" });
            DropIndex("dbo.Companies", new[] { "CompanyAdminId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Applications", new[] { "User_Id" });
            DropIndex("dbo.Applications", new[] { "JobId" });
            DropTable("dbo.SkillUsers");
            DropTable("dbo.UserSkills");
            DropTable("dbo.TalentProfiles");
            DropTable("dbo.JobTimeStamps");
            DropTable("dbo.Skills");
            DropTable("dbo.SavedJobs");
            DropTable("dbo.Resumes");
            DropTable("dbo.Notes");
            DropTable("dbo.Messages");
            DropTable("dbo.Companies");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Clicks");
            DropTable("dbo.Jobs");
            DropTable("dbo.Applications");
        }
    }
}
