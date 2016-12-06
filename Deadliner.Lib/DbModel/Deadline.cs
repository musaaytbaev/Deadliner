using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadliner.Lib.DbModel
{
    public enum Priority
    {
        TheMostImportant,
        VeryImportant,
        Important,
        Facultative
    }

    public class Deadline
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public Priority Priority { get; set; }
        public virtual List<Task> Tasks { get; set; }
        public virtual List<Notification> Notifications { get; set; }
    }
}
