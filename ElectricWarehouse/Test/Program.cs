using EWDb;
using System;
using System.Configuration;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            EWRepository rep = EWRepository.Instance;
            rep.AddCategory2(1, "");

            using (var db = new EWContext(EWContext.connStr))
            {

                Console.WriteLine("所有设备分类2名称:");
                foreach (var d in db.Devices.Include(nameof(Category2)))
                {
                    Console.WriteLine($"{d.NO}\t{d.Category2.Name}\t{d.Status}");
                }
            }

            if (rep.ReturnDevice("111", "ly", "sub"))
                using (var db = new EWContext(EWContext.connStr))
                {

                    Console.WriteLine("所有设备分类2名称:");
                    foreach (var d in db.Devices.Include(nameof(Category2)))
                    {
                        Console.WriteLine($"{d.NO}\t{d.Category2.Name}\t{d.Status}");
                    }
                }



            //Console.WriteLine("所有员工:");
            //foreach (var em in db.Employees)
            //{
            //    Console.WriteLine(em.Name);
            //}

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
