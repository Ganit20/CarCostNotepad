using CarCostNotepad.Model;
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
using System.Windows.Shapes;

namespace CarCostNotepad.View.PopupWindows
{
    /// <summary>
    /// Interaction logic for MainObjectCreator.xaml
    /// </summary>
    public partial class MainObjectCreator : Window
    {
        public MainObjectCreator(Settings Config,MainWindow main)
        {
            InitializeComponent();
            Types.ItemsSource = new MainObjectsList().mainObjects;
            MainFrame.Navigate(new CreateCar(Config,this,main));
        }
    }
}
