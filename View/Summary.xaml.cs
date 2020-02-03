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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarCostNotepad.View
{
    /// <summary>
    /// Interaction logic for Charts.xaml
    /// </summary>
    public partial class Summary : Page
    { 


        Settings Config;
        IMainObject MObject;
       
        public Summary(Settings config, IMainObject mObject)
        {
            MObject = mObject;  
            Config = config;
            InitializeComponent();
            UpdateChar(mObject.Costs.Checked);
            this.DataContext = config;
            SAll.DataContext = mObject;
            TypeB.DataContext = mObject;
            Name.DataContext = MObject;
            ChoosedYear.DataContext = MObject;
        }
        private void DataClicked(object sender, ChartPoint chartPoint)
        {
            var a = chartPoint.Key;
            Cartesian.Series.Clear();
            foreach (var cost in MObject.Costs.Checked)
            {
                var costs = cost.List.Where(e => e.Date.Month == (a + 1)&&e.Date.Year==Config.ChoosedYear);


                
                foreach (var item in costs)
                {

                    var b = new double[31];
                    b[item.Date.Day-1] = item.Price;
                    Cartesian.Series.Add(new StackedColumnSeries() { Values = new ChartValues<double>(b), Title = item.Name, DataLabels = true, });
                    
                }
            }
            List<string> ac = new List<string>();
            Cartesian.AxisX.Clear();
            for (int i = 1; i <= 31; i++)
            {
                ac.Add(i.ToString());
            }
            Cartesian.AxisX.Add(new Axis() { Labels=ac});
            Cartesian.DataClick -= DataClicked;


        }
        void UpdateCartesianChart(IMainObject mobject)
        {
            

            Cartesian.Series.Clear();
            Cartesian.DataClick += DataClicked;
            foreach (var costlist in mobject.Costs.Checked)
            {
                var months = new double[12];
                var find = costlist.List.Where(e => e.Date.Year == Config.ChoosedYear);
                foreach (var cost in find)
                {
                    months[cost.Date.Month-1] += cost.Price;
                }
                var val = new ChartValues<double>(months);
                Cartesian.Series.Add(new StackedColumnSeries() { Values = val, Title=costlist.Name });
            }
            
                       
        }
        
            
public void UpdateChar(ObservableCollection<Model.CostList> Checked)
        {
            MObject.RefreshYearSum(Config.ChoosedYear);
            Chart.Series.Clear();
            
            foreach (var a in Checked)
            {
                var b=a.List.Where(e => e.Date.Year == Config.ChoosedYear);
                double sum=0;
                foreach(var sums in b)
                {
                    sum += sums.Price;
                }
                Chart.Series.Add(new PieSeries() { Values = new ChartValues<double>() { sum }, Title = a.Name });
            }
            UpdateCartesianChart( MObject);
        }

        private void CLeftYear(object sender, RoutedEventArgs e)
        {
            Config.ChoosedYear -= 1;
            new SaveSystem().SaveSettings(Config);
            UpdateChar(MObject.Costs.Checked);
        }

        private void CRightYear(object sender, RoutedEventArgs e)
        {
            Config.ChoosedYear += 1;
            new SaveSystem().SaveSettings(Config);
            UpdateChar(MObject.Costs.Checked);
        }
    }
}
