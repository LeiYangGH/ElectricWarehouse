namespace EWDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class f4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "f4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "f4");
        }
    }
}
