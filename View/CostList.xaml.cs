﻿using CarCostNotepad.Model;
using CarCostNotepad.View;
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
using CarCostNotepad.ViewModel;
using CarCostNotepad.View.PopupWindows;

namespace CarCostNotepad
{

    public partial class CostList : Page, IViewObject
        
    {
        public Model.CostList List;
        private IMainObject MObject;
        private Card ParentPage;
        Settings Config;
        int frameNumber;
        public int FrameNumber { get { return frameNumber; } set {
                frameNumber = value;
                var a = MObject.Costs.Checked.IndexOf(List);
                MObject.Costs.Checked[a].ChoosedField = value;
            } }
        public CostList(IMainObject mObject, Model.CostList list, Card parentPage, Settings config)
        {
           
            Config = config;
            DataContext = Config.LanguageSet;
            MObject = mObject;
            List = list;
            FrameNumber = list.ChoosedField;
            List.Sum = 0;
            ParentPage = parentPage;
            List = list;
            InitializeComponent();
            CostListField.ItemsSource = list.List;
            Title.DataContext = list;
            Sum.DataContext = list;
        }


        private void DeleteField(object sender, RoutedEventArgs e)
        {
            var selected = (Button)e.OriginalSource;
            var row = selected.DataContext;
            List.List.Remove((Cost)row);
            List.Sum = 0;
            new SaveSystem().Save(MObject);
            MObject.RefreshSum();
            var chart = (Charts)ParentPage.FieldViewList[0];
            chart.UpdateChar(MObject.Costs.Checked);
        }

        private void EditField(object sender, MouseButtonEventArgs e)
        {
            var box = (TextBox)sender;
            box.IsReadOnly = false;
            box.Background = new SolidColorBrush(Colors.White);
            box.Foreground = new SolidColorBrush(Colors.Black);
            var chart = (Charts)ParentPage.FieldViewList[0];
            chart.UpdateChar(MObject.Costs.Checked);
        }

        private void Block(object sender, RoutedEventArgs e)
        {
            var box = (TextBox)sender;
            box.IsReadOnly = true;
            box.Background = new SolidColorBrush(Colors.Gray);
            box.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Add addWindow = new Add(List.List,Config);
            addWindow.ShowDialog();
            List.Sum = 0;
            new SaveSystem().Save(MObject);
            MObject.RefreshSum();
            var chart = (Charts)ParentPage.FieldViewList[0];
            chart.UpdateChar(MObject.Costs.Checked);
        }

        private void ShowChart(object sender, RoutedEventArgs e)
        {
            var popupChar = new PopUpChar(List,Config);
            popupChar.ShowDialog();
        }
    }
}
