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
        public ILanguage languageSet { get; set; }
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

        public List<ILanguage> LanguageList = new List<ILanguage>();

        


        Visibility showChart;
        public Visibility ShowChart { get { return showChart; } set {  showChart = value; NotifyPropertyChanged("ShowChart"); } }
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
            LanguageList.Add(new PLStrings());
            LanguageList.Add(new EngStrings());
            LanguageSet = new EngStrings();
            ChartLegendPosition = LegendLocation.Left;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
