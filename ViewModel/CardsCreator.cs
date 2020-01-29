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
    class CardsCreator
    {
        MainWindow Window;
        List<Card> CardList;
        Settings Config;
        public Button Create(Car car,MainWindow window,List<Card> Cards, Settings config)
        {
            Config = config;
            Button Car = new Button();
            Car.Background = window.Background;
            Car.Foreground = window.Foreground;
            if (car.Name.Length * 15 < 50)
                Car.Width = 50;
            else
                Car.Width = car.Name.Length * 15;
            Car.Content = car.Name;
            Car.Click += GoToCard;
            return Car;
        }
        private void GoToCard(object sender, RoutedEventArgs e)
        {
            foreach (Button card in Window.Cards.Children)
            {
                card.Background = Window.Background;
            }
            var button = (Button)sender;
            button.Background = Brushes.Blue;
            var CardObject = CardList.Find(e => e.CarO.Name == button.Content);
            Window.MainFrame.Navigate(new Card(CardObject.CarO, Config));
        }
    }
}
