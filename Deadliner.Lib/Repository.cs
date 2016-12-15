using Deadliner.Lib.DbModel;
using Deadliner.Lib.Notifiers;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

namespace Deadliner.Lib
{
    public class DeadlineRepository
    {
        List<Deadline> _deadlines = new List<Deadline>();
        /// <summary>
        /// Событие происходит при добавлении дедлайна в список.
        /// </summary>
        public Action<Deadline> OnAdding { get; set; }
        /// <summary>
        /// Событие происходит при удалении дедлайна из списка.
        /// </summary>
        public Action<Deadline> OnRemoving { get; set; }

        /// <summary>
        /// Загружает данные из базы в список
        /// </summary>
        public void Load()
        {
            using (var c = new Context())
            {
                _deadlines = c.Deadlines.ToList();
            }
        }

        /// <summary>
        /// Обновляет базу новыми данными из списка
        /// </summary>
        public void Save()
        {
            using (var c = new Context())
            {
                foreach (var d in _deadlines)
                    c.Deadlines.AddOrUpdate(x => x.Name, d);
                c.SaveChanges();
            }
        }

        /// <summary>
        /// Метод вызывается с определенным интервалом.
        /// Запускает все инструменты для уведомления пользователя.
        /// </summary>
        public void Notify()
        {
            var now = DateTime.Now;

            var mustNotyList = (from d in _deadlines
                                from n in d.Notifications
                                where n.LastCall <= now
                                orderby n.Deadline.Priority
                                select n).AsEnumerable();

            foreach (var noty in mustNotyList)
            {
                foreach (var notifier in NotyFactory.Default.GetNotifier(noty.Deadline))
                {
                    notifier.Notify();
                }
            }
        }

        /// <summary>
        /// Добавляет новый дедлайн в список.
        /// </summary>
        /// <param name="d">Новый дедлайн</param>
        public void Add(Deadline d)
        {
            if (string.IsNullOrWhiteSpace(d.Name))
                throw new ArgumentException("Имя дедлайна не может быть пустым или состоять только из пробелов");
            if (d.Time < DateTime.Now + new TimeSpan(1, 0, 0))
                throw new ArgumentException("Время дедлайна не может быть раньше текущего времени, дедлайн должен наступить хотябы через час");

            _deadlines.Add(d);
            _deadlines = _deadlines.OrderBy(x => x.Time).ToList();

            OnAdding?.Invoke(d);
        }

        /// <summary>
        /// Удаляет истекший или ненужный пользователю дедлайн из списка.
        /// </summary>
        /// <param name="d">Старый дедлайн</param>
        public void Remove(Deadline d)
        {
            _deadlines.Remove(d);

            OnRemoving?.Invoke(d);
        }

        /// <summary>
        /// Возвращает список актуальных дедлайнов.
        /// </summary>
        /// <returns>Список дедлайнов</returns>
        public List<Deadline> GetAllActual()
        {
            return (from d in _deadlines
                    where d.Time > DateTime.Now
                    select d).ToList();
        }

        /// <summary>
        /// Возвращает список дедлайнов, отсортированный по приоритету.
        /// </summary>
        /// <param name="p">Приоритет</param>
        /// <returns>Список дедлайнов</returns>
        public List<Deadline> FilterByPriorityActual(Priority p)
        {
            return (from d in _deadlines
                    where d.Priority == p
                    where d.Time > DateTime.Now
                    select d).ToList();
        }
    }
}
