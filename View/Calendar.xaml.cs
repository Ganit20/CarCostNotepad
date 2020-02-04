using CarCostNotepad.Model;
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
using System.Windows.Shapes;

namespace CarCostNotepad.View
{
    /// <summary>
    /// Logika interakcji dla klasy Calendar.xaml
    /// </summary>
    public partial class Calendar : Page
    {
        CalendarViewModel ViewModel;
        public Calendar(Settings Config)
        {
            InitializeComponent();
             ViewModel = new CalendarViewModel(this,Config);
        }

        private void MoreYear(object sender, RoutedEventArgs e)
        {
            ViewModel.choosedDate.AddYears(1);
            ViewModel.GenerateCalendar();
        }

        private void LessYear(object sender, RoutedEventArgs e)
        {
            
        }

        private void MoreMonth(object sender, RoutedEventArgs e)
        {
            ViewModel.choosedDate.AddMonths(1);
            ViewModel.GenerateCalendar();
        }

        private void LessMonth(object sender, RoutedEventArgs e)
        {

        }
    }
}
