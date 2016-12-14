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

        public void Notify()
        {
            
        }


        public void Add(Deadline d)
        {
            if (string.IsNullOrWhiteSpace(d.Name))
                throw new ArgumentException("Имя дедлайна не может быть пустым или состоять только из пробелов");
            if (d.Time < DateTime.Now + new TimeSpan(1, 0, 0))
                throw new ArgumentException("Время дедлайна не может быть раньше текущего времени, дедлайн должен наступить хотябы через час");
            
            c.Deadlines.Add(d);
            c.SaveChanges();
        }

        public List<Deadline> GetAllActual()
        {
            return (from d in c.Deadlines
                    where d.Time > DateTime.Now
                    select d).ToList();
        }

        public List<Deadline> FilterByPriorityActual(Priority p)
        {
            return (from d in c.Deadlines
                    where d.Priority == p
                    where d.Time > DateTime.Now
                    select d).ToList();
        }

    }
}
