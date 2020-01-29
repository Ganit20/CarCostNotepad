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
    /// Logika interakcji dla klasy AddField.xaml
    /// </summary>
    public partial class AddField : Window
    {
         string name;
        public string FieldName
        {
            get { return name;}
            set
            {
                
                name = value;
            }
        }
        public AddField(Settings config)
        {
            InitializeComponent();
            DataContext = config.LanguageSet;
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            name = Name.Text;
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
