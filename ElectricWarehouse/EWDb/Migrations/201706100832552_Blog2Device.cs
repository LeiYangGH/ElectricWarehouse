namespace EWDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog2Device : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "BlogId", "dbo.Blogs");
            DropIndex("dbo.Posts", new[] { "BlogId" });
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        InStoreDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        NO = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.NO);
            
            DropTable("dbo.Blogs");
            DropTable("dbo.Posts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        BlogId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        BlogId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        f4 = c.String(),
                    })
                .PrimaryKey(t => t.BlogId);
            
            DropTable("dbo.Employees");
            DropTable("dbo.Devices");
            CreateIndex("dbo.Posts", "BlogId");
            AddForeignKey("dbo.Posts", "BlogId", "dbo.Blogs", "BlogId", cascadeDelete: true);
        }
    }
}
