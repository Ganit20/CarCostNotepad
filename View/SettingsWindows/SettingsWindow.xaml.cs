using CarCostNotepad.Model;
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

namespace CarCostNotepad.View.SettingsWindows
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        Settings Config;
        public SettingsWindow(Settings config)
        {
            Config=config;
            DataContext = Config.LanguageSet;
            InitializeComponent();
        }

        private void GeneralCategory(object sender, RoutedEventArgs e)
        {
            OptionsFrame.Navigate(new GeneralSettings(Config));
        }
    }
}
