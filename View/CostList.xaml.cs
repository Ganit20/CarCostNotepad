using CarCostNotepad.Model;
using CarCostNotepad.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarCostNotepad.ViewModel;

namespace CarCostNotepad
{

    public partial class CostList : Page
    {
        public Model.CostList List;
        private Car car;
        private Card ParentPage;
        Settings Config;
        public CostList(Car _car, Model.CostList list, Card parentPage, Settings config)
        {
            
            Config = config;
            DataContext = Config.LanguageSet;
            car = _car;
            List = list;
            List.Sum = 0;
            ParentPage = parentPage;
            List = list;
            InitializeComponent();
            CostListField.ItemsSource = list.List;
            Title.DataContext = list;
            Sum.DataContext = list;
        }


        private void DeleteField(object sender, RoutedEventArgs e)
        {
            var selected = (Button)e.OriginalSource;
            var row = selected.DataContext;
            List.List.Remove((Cost)row);
            List.Sum = 0;
            new SaveSystem().Save(car);
            car.RefreshSum();
            ParentPage.UpdateChar();
        }

        private void EditField(object sender, MouseButtonEventArgs e)
        {
            var box = (TextBox)sender;
            box.IsReadOnly = false;
            box.Background = new SolidColorBrush(Colors.White);
            box.Foreground = new SolidColorBrush(Colors.Black);
            ParentPage.UpdateChar();
        }

        private void Block(object sender, RoutedEventArgs e)
        {
            var box = (TextBox)sender;
            box.IsReadOnly = true;
            box.Background = new SolidColorBrush(Colors.Gray);
            box.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add(List.List,Config);
            addWindow.ShowDialog();
            List.Sum = 0;
            new SaveSystem().Save(car);
            car.RefreshSum();
            ParentPage.UpdateChar();
        }


    }
}
