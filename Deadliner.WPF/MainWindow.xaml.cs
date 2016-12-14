using Deadliner.Lib.DbModel;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        int i = 1;
        int j = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScrollViewer scrollViewer = new ScrollViewer()
            {
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Background = Brushes.Red,
                Margin = new Thickness(5)
            };
            StackPanel spDeadline = new StackPanel();
            TextBlock header = new TextBlock
            {
                Text = "New deadline",
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 18,
                FontWeight = FontWeights.Bold
            };
            spDeadline.Children.Add(header);
            scrollViewer.Content = spDeadline;

            gridDeadlines.ColumnDefinitions.Add(new ColumnDefinition()
            {
                Width = new GridLength(250)
            });

            gridDeadlines.Children.Add(scrollViewer);
            Grid.SetColumn(scrollViewer, i);
            Grid.SetRow(scrollViewer, j);

            i++;
            if (i == 5)
            {
                i = 0;
                j++;
                gridDeadlines.RowDefinitions.Add(new RowDefinition()
                {
                    Height = new GridLength(250)
                });
            }
        }
    }
}
