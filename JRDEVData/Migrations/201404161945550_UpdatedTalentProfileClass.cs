namespace JRDEVData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTalentProfileClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "StreetAddress2", c => c.String());
            AddColumn("dbo.Jobs", "MainUrl", c => c.String());
            AddColumn("dbo.Jobs", "FacebookUrl", c => c.String());
            AddColumn("dbo.Jobs", "LinkedinUrl", c => c.String());
            AddColumn("dbo.Jobs", "TwitterUrl", c => c.String());
            AddColumn("dbo.Jobs", "GoogleplusUrl", c => c.String());
            AddColumn("dbo.Jobs", "EmailAddress2", c => c.String());
            AddColumn("dbo.Jobs", "PhoneNumber2", c => c.String());
            AddColumn("dbo.Companies", "StreetAddress2", c => c.String());
            AddColumn("dbo.Companies", "MainUrl", c => c.String());
            AddColumn("dbo.Companies", "FacebookUrl", c => c.String());
            AddColumn("dbo.Companies", "LinkedinUrl", c => c.String());
            AddColumn("dbo.Companies", "TwitterUrl", c => c.String());
            AddColumn("dbo.Companies", "GoogleplusUrl", c => c.String());
            AddColumn("dbo.Companies", "EmailAddress2", c => c.String());
            AddColumn("dbo.Companies", "PhoneNumber2", c => c.String());
            AddColumn("dbo.TalentProfiles", "Summary", c => c.String());
            AddColumn("dbo.TalentProfiles", "Skills", c => c.String());
            AddColumn("dbo.TalentProfiles", "PicFile", c => c.String());
            AddColumn("dbo.TalentProfiles", "StreetAddress", c => c.String());
            AddColumn("dbo.TalentProfiles", "StreetAddress2", c => c.String());
            AddColumn("dbo.TalentProfiles", "City", c => c.String());
            AddColumn("dbo.TalentProfiles", "State", c => c.String());
            AddColumn("dbo.TalentProfiles", "ZipCode", c => c.String());
            AddColumn("dbo.TalentProfiles", "MainUrl", c => c.String());
            AddColumn("dbo.TalentProfiles", "FacebookUrl", c => c.String());
            AddColumn("dbo.TalentProfiles", "LinkedinUrl", c => c.String());
            AddColumn("dbo.TalentProfiles", "TwitterUrl", c => c.String());
            AddColumn("dbo.TalentProfiles", "GoogleplusUrl", c => c.String());
            AddColumn("dbo.TalentProfiles", "EmailAddress", c => c.String());
            AddColumn("dbo.TalentProfiles", "EmailAddress2", c => c.String());
            AddColumn("dbo.TalentProfiles", "PhoneNumber", c => c.String());
            AddColumn("dbo.TalentProfiles", "PhoneNumber2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TalentProfiles", "PhoneNumber2");
            DropColumn("dbo.TalentProfiles", "PhoneNumber");
            DropColumn("dbo.TalentProfiles", "EmailAddress2");
            DropColumn("dbo.TalentProfiles", "EmailAddress");
            DropColumn("dbo.TalentProfiles", "GoogleplusUrl");
            DropColumn("dbo.TalentProfiles", "TwitterUrl");
            DropColumn("dbo.TalentProfiles", "LinkedinUrl");
            DropColumn("dbo.TalentProfiles", "FacebookUrl");
            DropColumn("dbo.TalentProfiles", "MainUrl");
            DropColumn("dbo.TalentProfiles", "ZipCode");
            DropColumn("dbo.TalentProfiles", "State");
            DropColumn("dbo.TalentProfiles", "City");
            DropColumn("dbo.TalentProfiles", "StreetAddress2");
            DropColumn("dbo.TalentProfiles", "StreetAddress");
            DropColumn("dbo.TalentProfiles", "PicFile");
            DropColumn("dbo.TalentProfiles", "Skills");
            DropColumn("dbo.TalentProfiles", "Summary");
            DropColumn("dbo.Companies", "PhoneNumber2");
            DropColumn("dbo.Companies", "EmailAddress2");
            DropColumn("dbo.Companies", "GoogleplusUrl");
            DropColumn("dbo.Companies", "TwitterUrl");
            DropColumn("dbo.Companies", "LinkedinUrl");
            DropColumn("dbo.Companies", "FacebookUrl");
            DropColumn("dbo.Companies", "MainUrl");
            DropColumn("dbo.Companies", "StreetAddress2");
            DropColumn("dbo.Jobs", "PhoneNumber2");
            DropColumn("dbo.Jobs", "EmailAddress2");
            DropColumn("dbo.Jobs", "GoogleplusUrl");
            DropColumn("dbo.Jobs", "TwitterUrl");
            DropColumn("dbo.Jobs", "LinkedinUrl");
            DropColumn("dbo.Jobs", "FacebookUrl");
            DropColumn("dbo.Jobs", "MainUrl");
            DropColumn("dbo.Jobs", "StreetAddress2");
        }
    }
}
