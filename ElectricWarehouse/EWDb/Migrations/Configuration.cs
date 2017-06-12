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
            context.Employees.AddOrUpdate(new Employee() { NO = "10001", Name = "����" });
            context.Employees.AddOrUpdate(new Employee() { NO = "10002", Name = "����" });

            context.Category1s.AddOrUpdate(p => p.Name, new Category1() { Name = "���������ֹ�����" });
            context.Category1s.AddOrUpdate(p => p.Name, new Category1() { Name = "�������޲����豸" });
            context.Category1s.AddOrUpdate(p => p.Name, new Category1() { Name = "�������ް�ȫ�þ�" });
            //return;

            context.Database.ExecuteSqlCommand("DBCC CHECKIDENT ('[Category2]', RESEED, 0)");

            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 1, Name = "ǯ��" });

            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 2, Name = "���ñ�" });
            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 2, Name = "������ӵص��������" });

            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 3, Name = "��ȫñ" });
            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 3, Name = "����" });
            context.Category2s.AddOrUpdate(p => p.Name, new Category2()
            { Category1Id = 3, Name = "�Ǹ߹�����" });
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
