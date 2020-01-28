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
        Car CarL= new Car();
        public ChooseWindows(Car car)
        {
            

            CarL = car;
            InitializeComponent();
            UnChecked.ItemsSource = CarL.Costs.Unchecked;
            Checked.ItemsSource = CarL.Costs.Checked;
        }

        private void ToChecked_Click(object sender, RoutedEventArgs e)
        {
            if (UnChecked.SelectedItem != null)
            {
                var a = CarL.Costs.Unchecked.Where(e => e == UnChecked.SelectedItem);
                CarL.Costs.Checked.Add(a.First());
                CarL.Costs.Unchecked.Remove(a.First());
            }
        }

        private void ToUnChecked_Click(object sender, RoutedEventArgs e)
        {
            if (Checked.SelectedItem != null)
            {
                var a = CarL.Costs.Checked.Where(e => e == Checked.SelectedItem);
            CarL.Costs.Unchecked.Add(a.First());
            CarL.Costs.Checked.Remove(a.First());
            }
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
            foreach(var Checked in CarL.Costs.Checked)
            {
                Checked.ChoosedField = CarL.Costs.Checked.IndexOf(Checked) + 1;
            }
            this.Close();
        }

        private void Checked_Double(object sender, MouseButtonEventArgs e)
        {
            if (Checked.SelectedItem != null)
            {
                var a = CarL.Costs.Checked.Where(e => e == Checked.SelectedItem);
            CarL.Costs.Unchecked.Add(a.First());
            CarL.Costs.Checked.Remove(a.First());
            }
        }

        private void unChecked_Double(object sender, MouseButtonEventArgs e)
        {
            if (UnChecked.SelectedItem != null)
            {
                var a = CarL.Costs.Unchecked.Where(e => e == UnChecked.SelectedItem);
            CarL.Costs.Checked.Add(a.First());
            CarL.Costs.Unchecked.Remove(a.First());
            }
        }
    }
}
