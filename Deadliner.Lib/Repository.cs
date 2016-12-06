using Deadliner.Lib.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadliner.Lib
{
    class DeadlineRepository
    {
        Context c = new Context();

        public bool Add(Deadline deadline)
        {
            c.Deadlines.Add(deadline);
            return true;
        }
    }
}
