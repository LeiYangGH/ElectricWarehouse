namespace EWDb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class virt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceBorrows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceNO = c.Int(nullable: false),
                        BorrowBy = c.String(),
                        Submitter = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceNO, cascadeDelete: true)
                .Index(t => t.DeviceNO);
            
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        NO = c.Int(nullable: false, identity: true),
                        Category2Id = c.Int(nullable: false),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                        InStoreDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NO)
                .ForeignKey("dbo.Category2", t => t.Category2Id, cascadeDelete: true)
                .Index(t => t.Category2Id);
            
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
                "dbo.Category1",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeviceReturns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeviceNO = c.Int(nullable: false),
                        ReturnBy = c.String(),
                        Submitter = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Devices", t => t.DeviceNO, cascadeDelete: true)
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
            DropIndex("dbo.Category2", new[] { "Category1Id" });
            DropIndex("dbo.Devices", new[] { "Category2Id" });
            DropIndex("dbo.DeviceBorrows", new[] { "DeviceNO" });
            DropTable("dbo.Employees");
            DropTable("dbo.DeviceReturns");
            DropTable("dbo.Category1");
            DropTable("dbo.Category2");
            DropTable("dbo.Devices");
            DropTable("dbo.DeviceBorrows");
        }
    }
}
