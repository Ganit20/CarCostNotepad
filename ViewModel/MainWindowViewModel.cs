using CarCostNotepad.Model;
using CarCostNotepad.View;
using CarCostNotepad.View.PopupWindows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CarCostNotepad.ViewModel
{
    class MainWindowViewModel
    {
        MainWindow main;
        Settings Config;
       public async Task CreateButton(MainWindow mainWindow,Settings config, IMainObject obj)
        {
            main = mainWindow;
            Config = config;
           
                mainWindow.CardList.Add(new Card(obj, Config));
                Button Car = new Button();
                Car.Background = mainWindow.Background;
                Car.Foreground = mainWindow.Foreground;
                if (obj.Name.Length * 15 < 50)
                    Car.Width = 50;
                else
                    Car.Width = obj.Name.Length * 15;
                Car.Content = obj.Name;
                Car.Click += GoToCard;
                mainWindow.Cards.Children.Add(Car);
                if (config.Unchecked.Count == 0)
                {
                config.Unchecked = Config.GetDefaultCostFields;
                }


            }
      public async Task LoadObjects(MainWindow main,Settings config)
        {
            main.Cards.Children.Clear();
            main.Objects.Clear();
            var a = new SaveSystem().Load();
            main.Objects = a;
            if (a.Count == 0)
            {
                var Create = new MainObjectCreator(config, main);
                Create.ShowDialog();
            }
            foreach (var car in a)
            {
               await new MainWindowViewModel().CreateButton(main, config, car);
            }
            //if(config.LastOpen==null || config.LastOpen> main.Cards.Children.Count)
            //{
            //    main.Cards.Children[0].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //}
            //else if (main.Cards.Children.Count - 1 >= config.LastOpen)
            //{
            //    main.Cards.Children[config.LastOpen].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //}
            
        }
        private void GoToCard(object sender, RoutedEventArgs e)
        {
            foreach (Button card in main.Cards.Children)
            {
                card.Background = main.Background;
            }
            var button = (Button)sender;
            button.Background = Brushes.Blue;
            var CardObject = main.CardList.Find(e => e.MObject.Name == button.Content);
            main.MainFrame.Navigate(new Card(CardObject.MObject, Config));
            Config.LastOpen = main.Cards.Children.IndexOf(button);

        }

    }
}
