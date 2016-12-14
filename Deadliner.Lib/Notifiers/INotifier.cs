using Deadliner.Lib.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadliner.Lib.Notifiers
{
    interface INotifier
    {
        Deadline Deadline { get; set; }
        void Notify();
    }
}
