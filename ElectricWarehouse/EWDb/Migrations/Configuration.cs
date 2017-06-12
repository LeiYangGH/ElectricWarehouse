namespace EWDb.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EWDb.EWContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EWDb.EWContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            //return;
            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('[Category1]', RESEED, 0)");
            context.Employees.AddOrUpdate(new Employee() { NO = "10001", Name = "张总" });
            context.Employees.AddOrUpdate(new Employee() { NO = "10002", Name = "王工" });

            context.Category1s.AddOrUpdate(p => p.Name, new Category1() { Name = "电力检修手工工具" });
            context.Category1s.AddOrUpdate(p => p.Name, new Category1() { Name = "电力检修测试设备" });
            context.Category1s.AddOrUpdate(p => p.Name, new Category1() { Name = "电力检修安全用具" });
            //return;

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('[Category2]', RESEED, 0)");

            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 1, Name = "钳子" });

            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 2, Name = "万用表" });
            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 2, Name = "大地网接地电阻测试仪" });

            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 3, Name = "安全帽" });
            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 3, Name = "眼罩" });
            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 3, Name = "登高工器具" });
            context.Devices.AddOrUpdate(x => x.NO, new Device()
            {
                NO = "111",
                Category2Id = 1,
                Status = DeviceStatus.Instore,
                InStoreDate = new DateTime(2017, 6, 11)
            });
            context.Devices.AddOrUpdate(x => x.NO, new Device()
            {
                NO = "211",
                Category2Id = 2,
                Status = DeviceStatus.Instore,
                InStoreDate = new DateTime(2017, 6, 12)
            });

            context.Devices.AddOrUpdate(x => x.NO, new Device()
            {
                NO = "221",
                Category2Id = 3,
                Status = DeviceStatus.Instore,
                InStoreDate = new DateTime(2017, 6, 13)
            });

            context.Devices.AddOrUpdate(x => x.NO, new Device()
            {
                NO = "311",
                Category2Id = 4,
                Status = DeviceStatus.Instore,
                InStoreDate = new DateTime(2017, 6, 14)
            });

            context.Devices.AddOrUpdate(x => x.NO, new Device()
            {
                NO = "321",
                Category2Id = 5,
                Status = DeviceStatus.Instore,
                InStoreDate = new DateTime(2017, 6, 15)
            });

            context.Devices.AddOrUpdate(x => x.NO, new Device()
            {
                NO = "331",
                Category2Id = 6,
                Status = DeviceStatus.Instore,
                InStoreDate = new DateTime(2017, 6, 16)
            });




        }
    }
}
