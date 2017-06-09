namespace AJWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Blogs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Date = c.DateTime(nullable: false),
                        Image = c.Int(nullable: false),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
        }
    }
}
