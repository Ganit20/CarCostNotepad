using CarCostNotepad.Model;
using CarCostNotepad.View;
using CarCostNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarCostNotepad.View.PopupWindows;
using CarCostNotepad.View.SettingsWindows;

namespace CarCostNotepad
{

    public partial class MainWindow : Window
    {
        List<Card> CardList = new List<Card>();
        Settings Config;
        public MainWindow()
        {

            InitializeComponent();
            Settings config = new SaveSystem().LoadSettings();
            Config = config;
            
            var a = new SaveSystem().Load();
            if (a.Count == 0)
            {
                var Create = new CreateCar(Config);
                Create.ShowDialog();
                if (Create.DialogResult == true)
                    a.Add(Create.Result);
            }
            foreach (var car in a)
            {
                CardList.Add(new Card(car,Config));
                Button Car = new Button();
                Car.Background = this.Background;
                Car.Foreground = this.Foreground;
                if (car.Name.Length * 15 < 50)
                    Car.Width = 50;
                else
                    Car.Width = car.Name.Length * 15;
                Car.Content = car.Name;
                Car.Click += GoToCard;
                Cards.Children.Add(Car);
                if(car.Costs.Unchecked.Count==0)
                {
                    car.Costs.Unchecked = Config.GetDefaultCostFields;
                }
                

            }
            Cards.Children[0].RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
           

        }

        private void GoToCard(object sender, RoutedEventArgs e)
        {
            foreach (Button card in Cards.Children)
            {
                card.Background = this.Background;
            }
            var button = (Button)sender;
            button.Background = Brushes.Blue;
            var CardObject = CardList.Find(e => e.CarO.Name ==button.Content);
            MainFrame.Navigate(new Card(CardObject.CarO,Config));
        }

        private void MoveState(object sender, RoutedEventArgs e)
        {
            var card = (Card)MainFrame.Content;
            card.MoveState();
        }

        private void Choose(object sender, RoutedEventArgs e)
        {
            var card = (Card) MainFrame.Content;
            var choose = new ChooseWindows(card.CarO,Config);
            choose.ShowDialog();
            MainFrame.Navigate(new Card(choose.Result,Config));
            var CardObject = CardList.IndexOf(CardList.Find(e => e.CarO.Name == choose.Result.Name));
            CardList[CardObject].CarO = choose.Result;
            new SaveSystem().Save(choose.Result);
        }

        private void AddC(object sender, RoutedEventArgs e)
        {
            var create = new CreateCar(Config);
            create.ShowDialog();
            if (create.DialogResult == true)
            {
                CardList.Add(new Card(create.Result,Config));
                Button Car = new Button();
                Car.Background = this.Background;
                Car.Foreground = this.Foreground;
                if (create.Result.Name.Length * 15 < 50)
                    Car.Width = 50;
                else
                    Car.Width = create.Result.Name.Length * 15;
                Car.Content = create.Result.Name;
                Car.Click += GoToCard;
                Cards.Children.Add(Car);
            }
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            var set = new SettingsWindow(Config) ;
            set.ShowDialog();
        }
    }
}
