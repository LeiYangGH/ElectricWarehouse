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
                // Create and save a new Blog 
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                //var blog = new Blog { Name = name };
                var blog = new Blog { f4 = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database 
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
