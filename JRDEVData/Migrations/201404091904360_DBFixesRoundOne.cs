namespace JRDEVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBFixesRoundOne : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SkillJobs", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.SkillUsers", "Skill_SkillId", "dbo.Skills");
            DropForeignKey("dbo.SkillUsers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SkillJobs", new[] { "Skill_SkillId" });
            DropIndex("dbo.SkillJobs", new[] { "Job_JobId" });
            DropIndex("dbo.SkillUsers", new[] { "Skill_SkillId" });
            DropIndex("dbo.SkillUsers", new[] { "User_Id" });
            DropIndex("dbo.Jobs", new[] { "UserId" });

            DropForeignKey("dbo.Applications", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Company_CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resumes", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavedJobs", "User_Id", "dbo.AspNetUsers");

            DropIndex("dbo.Applications", new[] { "User_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Company_CompanyId" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Notes", new[] { "User_Id" });
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropIndex("dbo.Resumes", new[] { "User_Id" });
            DropIndex("dbo.SavedJobs", new[] { "User_Id" });

            DropColumn("dbo.Applications", "User_Id");
            DropColumn("dbo.AspNetUsers", "Company_CompanyId");
            DropColumn("dbo.Messages", "User_Id");
            DropColumn("dbo.Notes", "User_Id");
            DropColumn("dbo.Jobs", "User_Id");
            DropColumn("dbo.Resumes", "User_Id");
            //RenameColumn(table: "dbo.Applications", name: "User_Id", newName: "UserId");
            //RenameColumn(table: "dbo.AspNetUsers", name: "Company_CompanyId", newName: "CompanyId");
            //RenameColumn(table: "dbo.Messages", name: "User_Id", newName: "UserId");
            //RenameColumn(table: "dbo.Notes", name: "User_Id", newName: "UserId");
            //RenameColumn(table: "dbo.Jobs", name: "User_Id", newName: "UserId");
            //RenameColumn(table: "dbo.Resumes", name: "User_Id", newName: "UserId");
            RenameColumn(table: "dbo.SavedJobs", name: "User_Id", newName: "UserId");
            CreateIndex("dbo.SavedJobs", "UserId");
            AddForeignKey("dbo.SavedJobs", "UserId", "dbo.AspNetUsers", "Id");
            AddColumn("dbo.JobTimeStamps", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.JobTimeStamps", "UserId");
            AddForeignKey("dbo.JobTimeStamps", "UserId", "dbo.AspNetUsers", "Id");
            DropTable("dbo.SkillJobs");
            DropTable("dbo.SkillUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SkillUsers",
                c => new
                    {
                        Skill_SkillId = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Skill_SkillId, t.User_Id });
            
            CreateTable(
                "dbo.SkillJobs",
                c => new
                    {
                        Skill_SkillId = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_SkillId, t.Job_JobId });
            
            DropForeignKey("dbo.JobTimeStamps", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.JobTimeStamps", new[] { "UserId" });
            DropColumn("dbo.JobTimeStamps", "UserId");
            RenameColumn(table: "dbo.SavedJobs", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Resumes", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Jobs", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Notes", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.Messages", name: "UserId", newName: "User_Id");
            RenameColumn(table: "dbo.AspNetUsers", name: "CompanyId", newName: "Company_CompanyId");
            RenameColumn(table: "dbo.Applications", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Resumes", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Jobs", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Notes", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.Messages", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.AspNetUsers", "CompanyId", c => c.Int());
            AddColumn("dbo.Applications", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Jobs", "UserId");
            CreateIndex("dbo.SkillUsers", "User_Id");
            CreateIndex("dbo.SkillUsers", "Skill_SkillId");
            CreateIndex("dbo.SkillJobs", "Job_JobId");
            CreateIndex("dbo.SkillJobs", "Skill_SkillId");
            AddForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.SkillUsers", "User_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SkillUsers", "Skill_SkillId", "dbo.Skills", "SkillId", cascadeDelete: true);
            AddForeignKey("dbo.SkillJobs", "Job_JobId", "dbo.Jobs", "JobId", cascadeDelete: true);
            AddForeignKey("dbo.SkillJobs", "Skill_SkillId", "dbo.Skills", "SkillId", cascadeDelete: true);
        }
    }
}
