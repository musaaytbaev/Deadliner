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

        int counter = 0;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var deadlineName = textBoxName.Text;

            gridCards.Children.Add(new MaterialDesignThemes.Wpf.Card
            {
                Content = new TextBlock()
                {
                    Text = deadlineName,
                    Foreground = Brushes.Red,
                    HorizontalAlignment = HorizontalAlignment.Center
                },
                Width = 250,
                Height = 180,
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(counter*250 + 5, 5,5,5)    
            });

            counter++;
        }
    }
}
