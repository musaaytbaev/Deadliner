using Deadliner.Lib;
using Deadliner.Lib.DbModel;
using Deadliner.Lib.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            repo.OnRemoving += MyItems_Remove;
            stackPanelInput.DataContext = new DeadlineViewModel() { Time = DateTime.Now + new TimeSpan(1,0,0) };

            repo.Load();
        }

        private void MyItems_Remove(Deadline d)
        {
            DeadlineViewModel dvm;
            foreach (var item in MyItems.Items)
            {
                if ((dvm = item as DeadlineViewModel).Name == d.Name && dvm.Time == d.Time)
                {
                    MyItems.Items.Remove(dvm);
                    cells[dvm.Row, dvm.Column] = false;
                    break;
                }
            }
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
                Id = d.Id,
                Name = d.Name,
                Time = d.Time,
                Description = d.Description,
                Priority = d.Priority,
                Row = i,
                Column = j
            };

            MyItems.Items.Add(dvm);
            cells[i, j] = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var d = stackPanelInput.DataContext as DeadlineViewModel;
                repo.Add(new Deadline
                {
                    Name = d.Name,
                    Description = d.Description,
                    Priority = d.Priority,
                    Time = d.Time
                });
                stackPanelInput.DataContext = new DeadlineViewModel() { Time = DateTime.Now + new TimeSpan(1,0,0) };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Deadline_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            Border grid = (Border)sender;
            DeadlineViewModel d = grid.DataContext as DeadlineViewModel;

            if (d == null)
                e.CanExecute = false;
            else
                e.CanExecute = true;
        }

        private void FinishDeadline_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Border border = (Border)sender;
            DeadlineViewModel dvm = border.DataContext as DeadlineViewModel;

            var d = repo.GetById(dvm.Id);

            if (MessageBox.Show("Правда готово?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                repo.Remove(d);
        }

        private void EditDeadline_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            Border border = (Border)sender;
            DeadlineViewModel d = border.DataContext as DeadlineViewModel;
        }

        private void EditDeadline_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            Border border = (Border)sender;
            DeadlineViewModel d = border.DataContext as DeadlineViewModel;

            stackPanelInput.DataContext = d;
            TurnEditMode(EditMode.Edit);
        }

        private enum EditMode { Add, Edit };

        private void TurnEditMode(EditMode mode)
        {
            switch (mode)
            {
                case EditMode.Add:
                    stackPanelInput.Background = Brushes.LightGray;
                    MyItems.IsEnabled = true;
                    textBlockHeader.Text = "DEADLINER";
                    ButtonChange.Visibility = Visibility.Collapsed;
                    ButtonAdd.Visibility = Visibility.Visible;
                    stackPanelInput.DataContext = new DeadlineViewModel() { Time = DateTime.Now + new TimeSpan(1, 0, 0) };
                    break;
                case EditMode.Edit:
                    stackPanelInput.Background = Brushes.GreenYellow;
                    MyItems.IsEnabled = false;
                    textBlockHeader.Text = "Редактор";
                    ButtonChange.Visibility = Visibility.Visible;
                    ButtonAdd.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void ButtonChange_Click(object sender, RoutedEventArgs e)
        {
            DeadlineViewModel dvm = stackPanelInput.DataContext as DeadlineViewModel;
            var d = repo.GetById(dvm.Id);
            d.Name = dvm.Name;
            d.Description = dvm.Description;
            d.Time = dvm.Time;
            d.Priority = dvm.Priority;

            TurnEditMode(EditMode.Add);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            repo.Save();
        }
    }
}
