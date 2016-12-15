using Deadliner.Lib.DbModel;
using System.Windows;

namespace Deadliner.Lib.Notifiers
{
    class WinNorifier : INotifier
    {
        public Deadline Deadline { get; set; }

        public void Notify()
        {
            MessageBox.Show(Deadline.Name);
        }
    }
}
