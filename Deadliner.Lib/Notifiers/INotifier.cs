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
        /// <summary>
        /// поле Дедлайн
        /// </summary>
        Deadline Deadline { get; set; }
        /// <summary>
        /// Метод для запуска уведомления
        /// </summary>
        void Notify();
    }
}
