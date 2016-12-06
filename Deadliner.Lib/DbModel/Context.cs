using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadliner.Lib.DbModel
{
    public class Context : DbContext
    {
        public DbSet<Deadline> Deadlines { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public Context() : base("localsql")
        {
            
        }
    }
}
