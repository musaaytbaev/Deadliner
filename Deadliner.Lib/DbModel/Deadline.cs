using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public Priority Priority { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Notification> Notifications { get; set; }
    }
}
