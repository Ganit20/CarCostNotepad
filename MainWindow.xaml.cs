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

namespace CarCostNotepad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Card> CardList = new List<Card>();
        public MainWindow()
        {

            InitializeComponent();
            var a = new SaveSystem().Load();
            if (a.Count == 0)
            {
                var Create = new CreateCar();
                Create.ShowDialog();
                if (Create.DialogResult == true)
                    a.Add(Create.Result);
            }
            foreach (var car in a)
            {
                CardList.Add(new Card(car));
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

                
            }

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
            MainFrame.Navigate(CardObject);
        }
    }
}
