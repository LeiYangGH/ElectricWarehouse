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
            AutomaticMigrationsEnabled = false;
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
            context.Devices.AddOrUpdate(
                new Device() { Category = "�����", Name = "���ñ�", Status = DeviceStatus.Instore, InStoreDate = new DateTime(2017, 6, 10) }
                );
            context.Devices.AddOrUpdate(
    new Device() { Category = "������", Name = "������", Status = DeviceStatus.Instore, InStoreDate = new DateTime(2017, 6, 10) }
    );
            context.Devices.AddOrUpdate(
    new Device() { Category = "Ԫ����", Name = "������", Status = DeviceStatus.Instore, InStoreDate = new DateTime(2017, 6, 10) }
    );
            context.Employees.Add(new Employee() { NO = "10001", Name = "����" });
            context.Employees.Add(new Employee() { NO = "10002", Name = "����" });
        }
    }
}
