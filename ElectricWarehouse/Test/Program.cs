using EWDb;
using System;
using System.Configuration;
using System.Linq;

namespace Test
{
    class Program
    {
        static string connStr = ConfigurationManager.ConnectionStrings["EWDbConnectionString"].ConnectionString;
        static void Main(string[] args)
        {
            using (var db = new EWContext(connStr))
            {

                Console.WriteLine("所有设备分类2名称:");
                foreach (var d in db.Devices.Include(nameof(Category2)))
                {
                    Console.WriteLine(d.Category2.Name);
                }

                Console.WriteLine("所有员工:");
                foreach (var em in db.Employees)
                {
                    Console.WriteLine(em.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
