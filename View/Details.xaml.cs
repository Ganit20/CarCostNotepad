using CarCostNotepad.Model;
using CarCostNotepad.ViewModel;
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

namespace CarCostNotepad.View
{
    /// <summary>
    /// Interaction logic for PopUpChar.xaml
    /// </summary>
    public partial class Details : Page
    {
        Settings Config;
        Model.CostList Costs;
        public Details(Model.CostList costs, Settings config)
        {
            InitializeComponent();
            Costs = costs;
            Config = config;
            this.DataContext = Config.LanguageSet;
            SAll.DataContext = costs;
            Name.DataContext = costs;
            ShowYear.DataContext = Config;
            UpdateDetailChart(costs);
        }

        private void DataClicked(object sender, ChartPoint chartPoint)
        {
            var a = chartPoint.Key;
            var costs = Costs.List.Where(e => e.Date.Month == (a + 1) && e.Date.Year == Config.ChoosedYearDetails);
            Cartesian.Series.Clear();
            foreach (var item in costs)
            {

                var b = new double[31];
                b[item.Date.Day] = item.Price;
                Cartesian.Series.Add(new StackedColumnSeries() { Values = new ChartValues<double>(b), Title = item.Name, DataLabels = true, });
                Cartesian.AxisX.Clear();
                Cartesian.DataClick -= DataClicked;
            }
        }
        void UpdateDetailChart(Model.CostList costs)
        {
            Cartesian.Series.Clear();
            int i = 0;
            var cost = costs.List.Where(e => e.Date.Year == Config.ChoosedYearDetails);
            foreach (var a in cost)
            {
                double[] ab = new double[12];
                ab[a.Date.Month - 1] = a.Price;
                var c = new ChartValues<double>(ab);
                Cartesian.Series.Add(new StackedColumnSeries() { Values = c, Title = a.Name, DataLabels = true, });

            }

            i++;
        }

        private void CRightYear(object sender, RoutedEventArgs e)
        {
            Config.ChoosedYearDetails += 1;
            UpdateDetailChart(Costs);
            new SaveSystem().SaveSettings(Config);
        }

        private void CLeftYear(object sender, RoutedEventArgs e)
        {
            Config.ChoosedYearDetails -= 1;
            UpdateDetailChart(Costs);
            new SaveSystem().SaveSettings(Config);
        }
    } }

    

