using Deadliner.Lib.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deadliner.Lib.Notifiers
{
    class NotyFactory
    {
        private static NotyFactory _default;

        public static NotyFactory Default
        {
            get
            {
                if (_default == null)
                    _default = new NotyFactory();
                return _default;
            }
        }

        public IEnumerable<INotifier> GetNotifier(Deadline d)
        {
            foreach (var noty in d.Notifications)
            {
                switch (noty.Type)
                {
                    case NotificationType.Email:
                        yield return new EmailNorifier() { Deadline = d };
                        break;
                    case NotificationType.Visual:
                        yield return new WinNorifier() { Deadline = d };
                        break;
                }
            }
        }
    }
}
