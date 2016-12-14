using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadliner.Lib.DbModel
{
    public enum NotificationType
    {
        Email,
        Sound,
        Visual,
        ChatMessage
    }

    public class Notification
    {
        public int Id { get; set; }
        public virtual Deadline Deadline { get; set; }
        public NotificationType Type { get; set; }
        public TimeSpan Interval { get; set; }
        public DateTime LastCall { get; set; }
    }
}
