namespace AJWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databaseUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPostModels",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Image = c.Byte(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogPostModels");
        }
    }
}
