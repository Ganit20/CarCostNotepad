using CarCostNotepad.Model;
using CarCostNotepad.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarCostNotepad
{
    /// <summary>
    /// Interaction logic for Repair.xaml
    /// </summary>
    public partial class CostList : Page
    {
        ObservableCollection<Cost> List;
        public CostList(ObservableCollection<Cost> list)
        {
            List = list;
            InitializeComponent();
            CostListField.ItemsSource = list;
            GroupCost.RepairCost.Add(new Cost { CategoryName = "Repair", Name = "AAAAAAAAA", Date = DateTime.Now, Price = 10000 });
        }


        private void DeleteField(object sender, RoutedEventArgs e)
        {
            var selected = (Button)e.OriginalSource;
            var row = selected.DataContext;
            List.Remove((Cost)row);
        }

        private void EditField(object sender, MouseButtonEventArgs e)
        {
            var box = (TextBox)sender;
            box.IsReadOnly = false;
            box.Background = new SolidColorBrush(Colors.White);
            box.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void Block(object sender, RoutedEventArgs e)
        {
            var box = (TextBox)sender;
            box.IsReadOnly = true;
            box.Background = new SolidColorBrush(Colors.Gray);
            box.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add();
            addWindow.ShowDialog();
        }
    }
}
