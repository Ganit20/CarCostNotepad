﻿using CarCostNotepad.Model;
using CarCostNotepad.ViewModel;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Charts : Page, IViewObject
    { 


        Settings Config;
        IMainObject MObject;
        public int FrameNumber
        {
            get { return MObject.Costs.SummaryPosition; }
            set
            {
                MObject.Costs.SummaryPosition = value;
            }
        }
        public Charts(Settings config, IMainObject mObject)
        {
            MObject = mObject;
            if(FrameNumber==0)
            {
                FrameNumber = 3;
            }
            Config = config;
            InitializeComponent();
            Chart.DataContext = config;
            this.DataContext = config.LanguageSet;
            SAll.DataContext = mObject;
            
        }
        public void UpdateChar(ObservableCollection<Model.CostList> Checked)
        {
            Chart.Series.Clear();
            foreach (var a in Checked)
            {
                Chart.Series.Add(new PieSeries() { Values = new ChartValues<double>() { a.Sum }, Title = a.Name });
            }
        }
    }
}
