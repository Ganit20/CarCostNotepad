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

namespace CarCostNotepad.Model
{
    /// <summary>
    /// Logika interakcji dla klasy CalendarDay.xaml
    /// </summary>
    public partial class CalendarDay : UserControl
    {
        public string WeekDay { get; set; }
        public int DayNumber { get; set; }
        public SolidColorBrush Color { get; set; }
        public string Notes { get; set; }
        public CalendarDay()
        {
            InitializeComponent();
            DataContext = this;
           

        }

        private void MouseOn(object sender, MouseEventArgs e)
        {
            this.BorderBrush = new SolidColorBrush(Colors.White);
        }

        private void MouseOff(object sender, MouseEventArgs e)
        {
            this.BorderBrush = null;
        }

       
        private void Edit(object sender, MouseButtonEventArgs e)
        {
            Note.IsReadOnly = false;
            Note.Background = new SolidColorBrush(Colors.White);
            Note.Foreground= new SolidColorBrush(Colors.Black);
        }

        private void BackAfterEdit(object sender, RoutedEventArgs e)
        {
            Note.IsReadOnly = true;
            Note.Background = null;
            Note.Foreground = new SolidColorBrush(Colors.White);
        }
    }
}
