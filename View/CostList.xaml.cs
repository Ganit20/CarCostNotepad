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

    public partial class CostList : Page
    {
        Model.CostList List;
        private Card ParentPage;
        public CostList(Model.CostList list, Card parentPage)
        {
            ParentPage = parentPage;
            List = list;
            InitializeComponent();
            CostListField.ItemsSource = list.List;
            Title.DataContext = list;
            list.List.Add(new Cost { Name = "AAAAAAAAA", Date = DateTime.Now, Price = 10000 });
        }


        private void DeleteField(object sender, RoutedEventArgs e)
        {
            var selected = (Button)e.OriginalSource;
            var row = selected.DataContext;
            List.List.Remove((Cost)row);
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
            Add addWindow = new Add(List.List);
            addWindow.ShowDialog();


        }


    }
}
