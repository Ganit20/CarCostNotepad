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
    /// Logika interakcji dla klasy ChooseWindows.xaml
    /// </summary>
    public partial class ChooseWindows : Window
    {
        
        public IMainObject Result
        {
            get { return MObject; }
        }
        IMainObject MObject;
        Settings Config;
        public ChooseWindows(IMainObject mObject, Settings config)
        {
            Config = config;
            DataContext = Config.LanguageSet;
            MObject = mObject;
            InitializeComponent();
            MObject.Costs.Unchecked = config.Unchecked;
            foreach (var item in MObject.Costs.Checked)
            {
                MObject.Costs.Unchecked.Remove(item);
            }
            UnChecked.ItemsSource = MObject.Costs.Unchecked;
            Checked.ItemsSource = MObject.Costs.Checked;
        }

        private void ToChecked_Click(object sender, RoutedEventArgs e)
        {
            if (UnChecked.SelectedItem != null && MObject.Costs.Checked.Count<Config.CardSize)
            {
                var a = MObject.Costs.Unchecked.Where(e => e == UnChecked.SelectedItem);
                MObject.Costs.Checked.Add(a.First());
                MObject.Costs.Unchecked.Remove(a.First());
            }
        }

        private void ToUnChecked_Click(object sender, RoutedEventArgs e)
        {
            if (Checked.SelectedItem != null)
            {
                var a = MObject.Costs.Checked.Where(e => e == Checked.SelectedItem);
            MObject.Costs.Unchecked.Add(a.First());
            MObject.Costs.Checked.Remove(a.First());
            }
        }

        private void UnChecked_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (((ListView)sender != null) && (MObject.Costs.Checked.Count < Config.CardSize))
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
            if((ListView)sender!=null )
            {
                ToUnChecked.IsEnabled = true;
            }else
            {
                ToUnChecked.IsEnabled = false;
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            foreach(var Checked in MObject.Costs.Checked)
            {
                Checked.ChoosedField = MObject.Costs.Checked.IndexOf(Checked) + 1;
            }
            this.Close();
        }

        private void Checked_Double(object sender, MouseButtonEventArgs e)
        {
            if (Checked.SelectedItem != null)
            {
                var a = MObject.Costs.Checked.Where(e => e == Checked.SelectedItem);
            MObject.Costs.Unchecked.Add(a.First());
            MObject.Costs.Checked.Remove(a.First());
            }
        }

        private void unChecked_Double(object sender, MouseButtonEventArgs e)
        {
            if ((UnChecked.SelectedItem != null) && (MObject.Costs.Checked.Count < Config.CardSize))
            {
                var a = MObject.Costs.Unchecked.Where(e => e == UnChecked.SelectedItem);
            MObject.Costs.Checked.Add(a.First());
            MObject.Costs.Unchecked.Remove(a.First());
            }
        }

        private void AddField(object sender, RoutedEventArgs e)
        {
            var a = new AddField(Config);
            a.ShowDialog();
            if (a.DialogResult.Value)
            {
                Config.Unchecked.Add(new Model.CostList()
                {
                    Name=a.FieldName
                });
                new SaveSystem().SaveSettings(Config) ;
            }
        }
    }
}
