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

            Device d0 = null;
            using (var db = new EWContext(EWContext.connStr))
            {
                d0 = db.Devices.First(x => x.NO == "111");
                Console.WriteLine("所有设备:");
                foreach (var d in db.Devices.Include(nameof(Category2)))
                {
                    Console.WriteLine($"{d.NO}\t{d.Category2.Name}\t{d.Status}");
                }
            }


            bool success = false;
            if (d0.Status == DeviceStatus.Instore)
                success = rep.BorrowDevice("111", "ly", "sub");
            else if (d0.Status == DeviceStatus.Lent)
                success = rep.ReturnDevice("111", "ly", "sub");

            if (success)
                using (var db = new EWContext(EWContext.connStr))
                {

                    Console.WriteLine("所有设备:");
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
