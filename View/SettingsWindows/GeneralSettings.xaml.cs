using CarCostNotepad.Language;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarCostNotepad.View.SettingsWindows
{
    /// <summary>
    /// Interaction logic for GeneralSettings.xaml
    /// </summary>
    public partial class GeneralSettings : Page
    {
        Settings Config;
        public GeneralSettings(Settings config)
        {
            InitializeComponent();
            Config = config;
            Lng.Items.Clear();
            Lng.ItemsSource = Config.LanguageList;
            DataContext = Config.LanguageSet;
            
            Lng.SelectedIndex = Config.LanguageList.IndexOf(Config.LanguageList.Find(e=> e.LanguageName == Config.LanguageSet.LanguageName));
        }

        private void LngChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Lng.SelectedItem != null)
            {
                Config.LanguageSet = (ILanguage)Lng.SelectedItem;
                new SaveSystem().SaveSettings(Config);
            }
        }

      
    }
}
