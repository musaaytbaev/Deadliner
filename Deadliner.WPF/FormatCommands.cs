using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Deadliner.WPF
{
    public static class FormatCommands
    {
        static RoutedUICommand finishDeadline = new RoutedUICommand("Завершить дедлайн",
            "FinishDeadline", typeof(FormatCommands));

        public static RoutedUICommand FinishDeadline { get { return finishDeadline; } }

        static RoutedUICommand editDeadline = new RoutedUICommand("Изменить дедлайн",
            "EditDeadline", typeof(FormatCommands));

        public static RoutedUICommand EditDeadline { get { return editDeadline; } }
    }
}

// Источник: https://www.youtube.com/watch?v=mG4l0AaYBTM