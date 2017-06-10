using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EWDb
{
    //https://msdn.microsoft.com/en-us/library/jj193542(v=vs.113).aspx
    public class EWContext : DbContext
    {
        public EWContext()
        {

        }
        public EWContext(string connString)
        {
            this.Database.Connection.ConnectionString = connString;
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
