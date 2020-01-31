using CarCostNotepad.Model;
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
    /// Interaction logic for MainObjectCreator.xaml
    /// </summary>
    public partial class MainObjectCreator : Window
    {
        public List<string> MObjectTypes = new List<string>();
        MainWindow Main;
        Settings Config;
        public MainObjectCreator(Settings config,MainWindow main)
        {
            Config = config;
            Main = main;
            MObjectTypes.Add("Car");
            MObjectTypes.Add("Home");

            InitializeComponent();
            DataContext = config.LanguageSet;
            Types.ItemsSource = MObjectTypes;
            
        }
       
        private void Types_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(Types.SelectedValue)
            {
                case "Car":
                    MainFrame.Navigate(new CreateCar(Config, this, Main));
                    break;
               case "Home":
                    break;
            }
        }
    }
}
