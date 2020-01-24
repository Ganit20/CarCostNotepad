using CarCostNotepad.Model;
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
        public MainWindow()
        {
            InitializeComponent();
            AA.Navigate(new CostList(GroupCost.RepairCost));
            BA.Navigate(new CostList(GroupCost.FixedCost));
            AC.Navigate(new CostList(GroupCost.FuelCost));
            BC.Navigate(new CostList(GroupCost.OtherCost));

        }
    }
}
