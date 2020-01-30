using CarCostNotepad.Model;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Interaction logic for PopUpChar.xaml
    /// </summary>
    public partial class PopUpChar : Window
    {
        Settings Config;
        public PopUpChar(Model.CostList costs,Settings config )
        {
            InitializeComponent();
            Config = config;
            this.DataContext = Config.LanguageSet;
            SAll.DataContext = costs;
            Chart.Series.Clear();
            foreach (var a in costs.List)
            {
                Chart.Series.Add(new PieSeries() { Values = new ChartValues<double>() { a.Price }, Title = a.Name });
            }
            int i = 0;

            foreach (var a in costs.List)
            {
                double[] ab = new double[11];
                ab[a.Date.Month-1] = a.Price;
                var c = new ChartValues<double>(ab);
                Cartesian.Series.Add(new StackedColumnSeries() { Values = c, Title = a.Name, DataLabels=true, });
                    
                }
          
                i++;
            }
        }

    }

