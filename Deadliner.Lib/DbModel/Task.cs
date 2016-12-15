using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadliner.Lib.DbModel
{
    public class Task
    {
        public int Id { get; set; }
        public Deadline Deadline { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan TimeToDo { get; set; }
    }
}
