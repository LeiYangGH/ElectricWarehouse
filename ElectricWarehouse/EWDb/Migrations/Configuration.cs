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
            context.Devices.AddOrUpdate(x=>x.Name,
                new Device() { Category = "检测类", Name = "万用表", Status = DeviceStatus.Instore, InStoreDate = new DateTime(2017, 6, 10) }
                );
            context.Devices.AddOrUpdate(x => x.Name,
    new Device() { Category = "工具类", Name = "电烙铁", Status = DeviceStatus.Instore, InStoreDate = new DateTime(2017, 6, 10) }
    );
            context.Devices.AddOrUpdate(x => x.Name,
    new Device() { Category = "元件类", Name = "二极管", Status = DeviceStatus.Instore, InStoreDate = new DateTime(2017, 6, 10) }
    );
            context.Employees.AddOrUpdate(new Employee() { NO = "10001", Name = "张总" });
            context.Employees.AddOrUpdate(new Employee() { NO = "10002", Name = "王工" });

          
        }
    }
}
