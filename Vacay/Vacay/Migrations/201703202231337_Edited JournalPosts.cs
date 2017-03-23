namespace Vacay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditedJournalPosts : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.JournalPosts", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.JournalPosts", "Date", c => c.String());
        }
    }
}
