using CarCostNotepad.Model;
using CarCostNotepad.View.PopupWindows;
using CarCostNotepad.ViewModel;
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
using System.Windows.Shapes;

namespace CarCostNotepad.View
{
    /// <summary>
    /// Logika interakcji dla klasy CreateCar.xaml
    /// </summary>
    public partial class CreateCar : Page
    {
        Car result = new Car();
        public Car Result
        {
            get { return result; }
        }
        Settings Config;
        MainObjectCreator Parent;
        MainWindow mainWindow;
        public CreateCar(Settings config,MainObjectCreator parent,MainWindow _mainWindow)
        {
            mainWindow = _mainWindow;
            Parent = parent;
            Config = config;
            DataContext = Config.LanguageSet;         
            InitializeComponent();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var c = new Car()
            {
                Name = CName.Text,
                LicenceNumber = CLP.Text,
                BuyDate = CDate.SelectedDate.Value,
                Costs = new CostGroups() ,
            };
            result = c;
            var Choose = new ChooseWindows(c, Config);
            Choose.ShowDialog();
            result.Costs = Choose.Result.Costs;
            new SaveSystem().Save(result);
           mainWindow.Objects.Add(c);
            Parent.DialogResult = true;
            Parent.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Parent.Close();
        }
    }
}
