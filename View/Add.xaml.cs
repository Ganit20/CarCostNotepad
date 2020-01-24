using CarCostNotepad.Model;
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

namespace CarCostNotepad.View
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        ObservableCollection<Cost> List;
        public Add(ObservableCollection<Cost> list)
        {
            List = list;
            InitializeComponent();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddObject(object sender, RoutedEventArgs e)
        {
           List.Add( new Cost()
            {
                Name = Name.Text,
                Date = Date.SelectedDate.Value,
                Price = int.Parse(Price.Text)
            });
            this.Close();
        }
    }
}
