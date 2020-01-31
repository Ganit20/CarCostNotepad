using CarCostNotepad.Model;
using CarCostNotepad.ViewModel;
using LiveCharts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarCostNotepad.View.SettingsWindows
{
    /// <summary>
    /// Interaction logic for ChartSettings.xaml
    /// </summary>
    public partial class ChartSettings : Page
    {
        Settings Config;
        public ChartSettings(Settings config)
        {
            Config = config;
            InitializeComponent();
            this.DataContext = Config.LanguageSet;
            ShowChartCheckBox.DataContext = Config;
            if (config.ShowChart == Visibility.Visible)
                ShowChartCheckBox.IsChecked = true;
            if (config.ShowCartesianChart == Visibility.Visible)
                ShowCartesianChartCheckBox.IsChecked = true;
        }
        private void Check(object sender, RoutedEventArgs e)
        {
            Config.ShowChart = Visibility.Visible;
            new SaveSystem().SaveSettings(Config);
        }
        private void Uncheck(object sender, RoutedEventArgs e)
        {
            Config.ShowChart = Visibility.Hidden;

        }
        private void None_Checked(object sender, RoutedEventArgs e)
        {
            Config.ChartLegendPosition = LegendLocation.None;
        }
        private void Left_Checked(object sender, RoutedEventArgs e)
        {
            Config.ChartLegendPosition = LegendLocation.Left;
        }

        private void Right_Checked(object sender, RoutedEventArgs e)
        {
            Config.ChartLegendPosition = LegendLocation.Right;
        }

        private void Bottom_Checked(object sender, RoutedEventArgs e)
        {
            Config.ChartLegendPosition = LegendLocation.Bottom;
        }

        private void Top_Checked(object sender, RoutedEventArgs e)
        {
            Config.ChartLegendPosition = LegendLocation.Top;
        }

        private void CheckCartesian(object sender, RoutedEventArgs e)
        {
            Config.ShowCartesianChart = Visibility.Visible;
            new SaveSystem().SaveSettings(Config);
        }

        private void UncheckCartesian(object sender, RoutedEventArgs e)
        {
            Config.ShowCartesianChart = Visibility.Hidden;
        }

        
        private void CartesianNone_Checked(object sender, RoutedEventArgs e)
        {
            Config.CartesianChartLegendPosition = LegendLocation.None;
        }
        private void CartesianLeft_Checked(object sender, RoutedEventArgs e)
        {
            Config.CartesianChartLegendPosition = LegendLocation.Left;
        }

        private void CartesianRight_Checked(object sender, RoutedEventArgs e)
        {
            Config.CartesianChartLegendPosition = LegendLocation.Right;
        }

        private void CartesianBottom_Checked(object sender, RoutedEventArgs e)
        {
            Config.CartesianChartLegendPosition = LegendLocation.Bottom;
        }

        private void CartesianTop_Checked(object sender, RoutedEventArgs e)
        {
            Config.CartesianChartLegendPosition = LegendLocation.Top;
        }
    }
}
