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

namespace CarCostNotepad.View
{
    /// <summary>
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : Page
    {
        public Car CarO;
        public Card(Car car)
        {
            CarO = car;
            InitializeComponent();
            //AA.Navigate(new CostList(car.Costs.Checked[0]));
            //BA.Navigate(new CostList(car.Costs.Checked[1]));
            //AC.Navigate(new CostList(car.Costs.Checked[2]));
            //BC.Navigate(new CostList(car.Costs.Checked[3]));
            //BB.Navigate(new Char());
        }
    }
}
