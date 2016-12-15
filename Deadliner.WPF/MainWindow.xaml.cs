using Deadliner.Lib;
using Deadliner.Lib.DbModel;
using Deadliner.Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Deadliner.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DeadlineRepository repo = new DeadlineRepository();
        bool[,] cells = new bool[5, 4];

        public MainWindow()
        {
            InitializeComponent();

            repo.OnAdding += MyItems_Insert;
            repo.OnRemoving += d => MyItems.Items.Remove(d);
            stackPanelInput.DataContext = new DeadlineViewModel();
        }

        private void MyItems_Insert(Deadline d)
        {
            int i = 0, j = 0;
            for (i = 0; i < cells.GetLength(0) - 1; i++)
            {
                for (j = 0; j < cells.GetLength(1) - 1; j++)
                {
                    if (!cells[i, j])
                        break;
                }
                if (!cells[i, j])
                    break;
            }

            DeadlineViewModel dvm = new DeadlineViewModel()
            {
                Name = d.Name,
                Time = d.Time,
                Description = d.Description,
                Priority = d.Priority,
                Row = j,
                Column = i
            };

            MyItems.Items.Add(dvm);
            cells[i, j] = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var d = stackPanelInput.DataContext as DeadlineViewModel;
            repo.Add(new Deadline
            {
                Name = d.Name,
                Description = d.Description,
                Priority = d.Priority,
                Time = d.Time
            });
        }
    }
}
