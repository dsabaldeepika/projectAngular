namespace JRDEVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobSkillTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Skills", "Job_JobId", "dbo.Jobs");
            DropIndex("dbo.Skills", new[] { "Job_JobId" });
            CreateTable(
                "dbo.JobSkills",
                c => new
                    {
                        JobSkillId = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        SkillId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobSkillId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.SkillId);
            
            CreateTable(
                "dbo.SkillJobs",
                c => new
                    {
                        Skill_SkillId = c.Int(nullable: false),
                        Job_JobId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Skill_SkillId, t.Job_JobId })
                .ForeignKey("dbo.Skills", t => t.Skill_SkillId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_JobId, cascadeDelete: true)
                .Index(t => t.Skill_SkillId)
                .Index(t => t.Job_JobId);
            
            DropColumn("dbo.Skills", "Job_JobId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Job_JobId", c => c.Int());
            DropForeignKey("dbo.JobSkills", "SkillId", "dbo.Skills");
            DropForeignKey("dbo.JobSkills", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.SkillJobs", "Job_JobId", "dbo.Jobs");
            DropForeignKey("dbo.SkillJobs", "Skill_SkillId", "dbo.Skills");
            DropIndex("dbo.JobSkills", new[] { "SkillId" });
            DropIndex("dbo.JobSkills", new[] { "JobId" });
            DropIndex("dbo.SkillJobs", new[] { "Job_JobId" });
            DropIndex("dbo.SkillJobs", new[] { "Skill_SkillId" });
            DropTable("dbo.SkillJobs");
            DropTable("dbo.JobSkills");
            CreateIndex("dbo.Skills", "Job_JobId");
            AddForeignKey("dbo.Skills", "Job_JobId", "dbo.Jobs", "JobId");
        }
    }
}
