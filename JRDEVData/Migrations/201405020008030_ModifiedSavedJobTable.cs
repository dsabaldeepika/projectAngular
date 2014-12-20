namespace JRDEVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedSavedJobTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SavedJobs", "UserCreatedId", "dbo.AspNetUsers");
            DropForeignKey("dbo.SavedJobs", "UserUpdatedId", "dbo.AspNetUsers");
            DropIndex("dbo.SavedJobs", new[] { "UserCreatedId" });
            DropIndex("dbo.SavedJobs", new[] { "UserUpdatedId" });
            DropColumn("dbo.SavedJobs", "StatusId");
            DropColumn("dbo.SavedJobs", "DateCreated");
            DropColumn("dbo.SavedJobs", "DateUpdated");
            DropColumn("dbo.SavedJobs", "UserCreatedId");
            DropColumn("dbo.SavedJobs", "UserUpdatedId");
            DropColumn("dbo.SavedJobs", "IsDeleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SavedJobs", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.SavedJobs", "UserUpdatedId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SavedJobs", "UserCreatedId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.SavedJobs", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SavedJobs", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.SavedJobs", "StatusId", c => c.Byte(nullable: false));
            CreateIndex("dbo.SavedJobs", "UserUpdatedId");
            CreateIndex("dbo.SavedJobs", "UserCreatedId");
            AddForeignKey("dbo.SavedJobs", "UserUpdatedId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SavedJobs", "UserCreatedId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
