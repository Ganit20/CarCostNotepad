using CarCostNotepad.Model;
using CarCostNotepad.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        HomeScreenViewModel ViewModel;
        Settings Config;
        MainWindow main;
        public HomeScreen(Settings config, MainWindow main)
        {
            InitializeComponent();
            ViewModel = new HomeScreenViewModel(this);
            
            Config = config;
            this.DataContext = Config;
            this.main = main;
        }

        private void Calendar(object sender, RoutedEventArgs e)
        {
            main.MainFrame.Navigate(new Calendar(Config));
        }
    }
}
