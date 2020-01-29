using CarCostNotepad.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
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
        public Add(ObservableCollection<Cost> list, Settings config)
        {
            List = list;
            InitializeComponent();
            DataContext = config.LanguageSet;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void AddObject(object sender, RoutedEventArgs e)
        {
            if(Name.Text!="" && Date.SelectedDate!=null && Price.Text != "")
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
