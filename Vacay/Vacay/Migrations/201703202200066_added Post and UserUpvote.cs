namespace Vacay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPostandUserUpvote : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JournalPosts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Location = c.String(),
                        Date = c.String(),
                        Username = c.String(),
                        Post = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserUpvotes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        JournalPostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.JournalPosts", t => t.JournalPostId, cascadeDelete: true)
                .Index(t => t.JournalPostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserUpvotes", "JournalPostId", "dbo.JournalPosts");
            DropIndex("dbo.UserUpvotes", new[] { "JournalPostId" });
            DropTable("dbo.UserUpvotes");
            DropTable("dbo.JournalPosts");
        }
    }
}
