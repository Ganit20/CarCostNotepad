using CarCostNotepad.Model;
using CarCostNotepad.View.PopupWindows;
using CarCostNotepad.ViewModel;
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
using System.Windows.Shapes;

namespace CarCostNotepad.View
{
    /// <summary>
    /// Logika interakcji dla klasy CreateCar.xaml
    /// </summary>
    public partial class CreateCar : Window
    {
        Car result;
        public Car Result
        {
            get { return result; }
        }


        public CreateCar()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            result = new Car()
            {
                Name = CName.Text,
                LicenceNumber = CLP.Text,
                BuyDate = CDate.SelectedDate.Value,
                Costs = new CostGroups(){} 
            };
            var Choose = new ChooseWindows(result);
            result = Choose.Result;
            new SaveSystem().Save(result);
            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
