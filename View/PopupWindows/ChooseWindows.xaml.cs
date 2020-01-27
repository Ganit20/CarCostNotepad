using CarCostNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarCostNotepad.View.PopupWindows
{
    /// <summary>
    /// Logika interakcji dla klasy ChooseWindows.xaml
    /// </summary>
    public partial class ChooseWindows : Window
    {
        
        public Car Result
        {
            get { return CarL; }
        }
        Car CarL;
        public ChooseWindows(Car car)
        {
            CarL = car;
            Checked.ItemsSource = car.Costs.Checked;
            UnChecked.ItemsSource = car.Costs.Unchecked;
            InitializeComponent();
        }

        private void ToChecked_Click(object sender, RoutedEventArgs e)
        {
            var a =CarL.Costs.Unchecked.Where(e => e == UnChecked.SelectedItem);
            CarL.Costs.Checked.Add(a.First());
            CarL.Costs.Unchecked.Remove(a.First());
        }

        private void ToUnChecked_Click(object sender, RoutedEventArgs e)
        {
            var a = CarL.Costs.Checked.Where(e => e == UnChecked.SelectedItem);
            CarL.Costs.Unchecked.Add(a.First());
            CarL.Costs.Checked.Remove(a.First());
        }

        private void UnChecked_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((ListView)sender != null)
            {
                ToChecked.IsEnabled = true;
            }
            else
            {
                ToChecked.IsEnabled = false;
            }
        }

        private void Checked_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if((ListView)sender!=null)
            {
                ToUnChecked.IsEnabled = true;
            }else
            {
                ToUnChecked.IsEnabled = false;
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
