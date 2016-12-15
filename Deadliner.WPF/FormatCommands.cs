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
    }
}

// Источник: https://www.youtube.com/watch?v=mG4l0AaYBTM