using Deadliner.Lib.DbModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Deadliner.Lib.ViewModels
{
    public class DeadlineViewModel
    {
        Dictionary<Priority, Brush> _brushes = new Dictionary<Priority, Brush>
        {
            {Priority.VeryImportant, Brushes.Orange },
            {Priority.TheMostImportant, Brushes.Red },
            {Priority.Important, Brushes.LightYellow },
            {Priority.Facultative, Brushes.Azure }
        };

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public Priority Priority { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public Brush Background
        {
            get
            {
                return _brushes[Priority];
            }
        }
    }
}
