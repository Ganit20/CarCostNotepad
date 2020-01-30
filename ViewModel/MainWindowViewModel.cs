using CarCostNotepad.Model;
using CarCostNotepad.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CarCostNotepad.ViewModel
{
    class MainWindowViewModel
    {
        MainWindow main;
        Settings Config;
       public void CreateButton(MainWindow mainWindow,Settings config,Car car)
        {
            main = mainWindow;
            Config = config;
           
                mainWindow.CardList.Add(new Card(car, Config));
                Button Car = new Button();
                Car.Background = mainWindow.Background;
                Car.Foreground = mainWindow.Foreground;
                if (car.Name.Length * 15 < 50)
                    Car.Width = 50;
                else
                    Car.Width = car.Name.Length * 15;
                Car.Content = car.Name;
                Car.Click += GoToCard;
                mainWindow.Cards.Children.Add(Car);
                if (car.Costs.Unchecked.Count == 0)
                {
                    car.Costs.Unchecked = Config.GetDefaultCostFields;
                }


            }
        
        private void GoToCard(object sender, RoutedEventArgs e)
        {
            foreach (Button card in main.Cards.Children)
            {
                card.Background = main.Background;
            }
            var button = (Button)sender;
            button.Background = Brushes.Blue;
            var CardObject = main.CardList.Find(e => e.CarO.Name == button.Content);
            main.MainFrame.Navigate(new Card(CardObject.CarO, Config));
        }

    }
}
