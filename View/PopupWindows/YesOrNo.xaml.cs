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
    /// Interaction logic for YesOrNo.xaml
    /// </summary>
    public partial class YesOrNo : Window
    {
        public YesOrNo(string Question,Settings Config)
        {
            InitializeComponent();
            DataContext = Config;
            Qu.Text = Question;
        }

        private void Yes(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void No(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
