using EWDb.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDb
{
    //https://msdn.microsoft.com/en-us/library/jj193542(v=vs.113).aspx
    public class EWContext : DbContext
    {
        string connStr = ConfigurationManager.ConnectionStrings["EWDbConnectionString"].ConnectionString;
        public EWContext()
        {

        }

        public EWContext(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
            Update();
        }
        void Update()
        {
            var cfg = new EWDb.Migrations.Configuration();
            cfg.TargetDatabase = new DbConnectionInfo(
                connStr,
                "System.Data.SqlClient");

            var migrator = new DbMigrator(cfg);
            migrator.Update();
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category1> Category1s { get; set; }
        public DbSet<Category2> Category2s { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceBorrow> DeviceBorrows { get; set; }
        public DbSet<DeviceReturn> DeviceReturns { get; set; }
    }
}
