namespace EWDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deviceid2no : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Category2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category1Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category1", t => t.Category1Id, cascadeDelete: true)
                .Index(t => t.Category1Id);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        NO = c.String(nullable: false, maxLength: 128),
                        Category2Id = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        InStoreDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NO)
                .ForeignKey("dbo.Category2", t => t.Category2Id, cascadeDelete: true)
                .Index(t => t.Category2Id);
            
            CreateTable(
                "dbo.DeviceBorrows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceNO = c.String(maxLength: 128),
                        BorrowBy = c.String(),
                        Submitter = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceNO)
                .Index(t => t.DeviceNO);
            
            CreateTable(
                "dbo.DeviceReturns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceNO = c.String(maxLength: 128),
                        ReturnBy = c.String(),
                        Submitter = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceNO)
                .Index(t => t.DeviceNO);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        NO = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.NO);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DeviceReturns", "DeviceNO", "dbo.Devices");
            DropForeignKey("dbo.DeviceBorrows", "DeviceNO", "dbo.Devices");
            DropForeignKey("dbo.Devices", "Category2Id", "dbo.Category2");
            DropForeignKey("dbo.Category2", "Category1Id", "dbo.Category1");
            DropIndex("dbo.DeviceReturns", new[] { "DeviceNO" });
            DropIndex("dbo.DeviceBorrows", new[] { "DeviceNO" });
            DropIndex("dbo.Devices", new[] { "Category2Id" });
            DropIndex("dbo.Category2", new[] { "Category1Id" });
            DropTable("dbo.Employees");
            DropTable("dbo.DeviceReturns");
            DropTable("dbo.DeviceBorrows");
            DropTable("dbo.Devices");
            DropTable("dbo.Category2");
            DropTable("dbo.Category1");
        }
    }
}
