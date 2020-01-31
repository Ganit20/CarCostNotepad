using CarCostNotepad.Eng;
using CarCostNotepad.Language;
using LiveCharts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

namespace CarCostNotepad.Model
{
    public class Settings :INotifyPropertyChanged
    {
        ILanguage languageSet { get; set; }
        public ILanguage LanguageSet 
        { 
            get 
            { 
                return languageSet; 
            } set 
            { 
                languageSet = value; 
                NotifyPropertyChanged("LanguageSet"); 
            } 
        }
        int choosedYear { get; set; }
        public int ChoosedYear { get { return choosedYear; } set { choosedYear = value; NotifyPropertyChanged("ChoosedYear"); } }
        int choosedYearDetails { get; set; }
        public int ChoosedYearDetails { get { return choosedYearDetails; } set { choosedYearDetails = value; NotifyPropertyChanged("ChoosedYearDetails"); } }
        public List<ILanguage> LanguageList = new List<ILanguage>();

        public ObservableCollection<CostList> Unchecked = new ObservableCollection<CostList>();


        Visibility showChart;
        public Visibility ShowChart { get { return showChart; } set { showChart = value; NotifyPropertyChanged("ShowChart"); } }
       Visibility showCartesianChart;
        public Visibility ShowCartesianChart { get { return showCartesianChart; } set { showCartesianChart = value; NotifyPropertyChanged("ShowCartesianChart"); } }
        public ObservableCollection<CostList> GetDefaultCostFields
        {
            get
            {
                return DefaultCosts(LanguageSet);
            }
            set { }
        }
        LegendLocation chartLegendPosition;
        public LegendLocation ChartLegendPosition { get { return chartLegendPosition; } set { chartLegendPosition = value; NotifyPropertyChanged("ChartLegendPosition"); } }
        LegendLocation cartesianChartLegendPosition;
        public LegendLocation CartesianChartLegendPosition { get { return cartesianChartLegendPosition; } set { cartesianChartLegendPosition = value; NotifyPropertyChanged("CartesianChartLegendPosition"); } }
        private ObservableCollection<CostList> DefaultCosts(ILanguage languageSet)
        {
            ObservableCollection<CostList> def = new ObservableCollection<CostList>();
            def.Add(new CostList()
            {
                Name = languageSet.FixedCostString
            });
            def.Add(new CostList()
            {
            Name = languageSet.FuelCostString
            });
            def.Add(new CostList()
            {
                Name = languageSet.NameOfCostString
            }) ;
            def.Add(new CostList()
            {
                Name = languageSet.OtherCostString
            });
            return def;
        }
        public void LoadDefault()
        {
            ShowChart = Visibility.Visible;
            ShowCartesianChart = Visibility.Visible;
            LanguageList.Add(new PLStrings());
            LanguageList.Add(new EngStrings());
            LanguageSet = new EngStrings();
            ChartLegendPosition = LegendLocation.Bottom;
            CartesianChartLegendPosition = LegendLocation.None;
            ChoosedYear = DateTime.Now.Year;
            ChoosedYearDetails = DateTime.Now.Year;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
