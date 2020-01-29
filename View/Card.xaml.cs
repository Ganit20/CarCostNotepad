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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarCostNotepad.Model;
using CarCostNotepad.View.PopupWindows;
using LiveCharts.Definitions.Series;
using LiveCharts.Wpf;
using LiveCharts;

namespace CarCostNotepad.View
{
   
     
    public partial class Card : Page
    {
        private Frame selectedFrame ;
        private object tempFrame;
        public Car CarO;
        private bool isMoveState = false;
        public List<Frame> FieldList = new List<Frame>();
        Settings Config;

        public Card(Car car,Settings config)
        {
            Config = config;
            DataContext = Config.LanguageSet;
            CarO = car;
            InitializeComponent();
            FieldList.Add(AA);
            FieldList.Add(BA);
            FieldList.Add(CA);
            FieldList.Add(AC);
            FieldList.Add(BC);
            FieldList.Add(CC);
            new SetListPosition().SetFrames(CarO,Config,this);
            CarO.RefreshSum();
            SAll.DataContext = CarO;
            Chart.DataContext = config;
            UpdateChar();
        }
        public void UpdateChar()
        {
            Chart.Series.Clear();
            foreach (var a in CarO.Costs.Checked)
            {
                Chart.Series.Add(new PieSeries() { Values = new ChartValues<double>() { a.Sum }, Title = a.Name });
            }
        }
        
       
       
        public  void MoveState()
        {
            if (!isMoveState)
            {
                isMoveState = true;
                foreach (var field in FieldList)
                {

                    field.Background = new SolidColorBrush(Colors.Blue);
                    field.MouseDown += new MouseButtonEventHandler(Move);

                }
            }else if (isMoveState)
            {
                isMoveState = false;
                ExitMoveState();
            }
        }

        void Move(object sender, MouseEventArgs e)
        {
            var frame = (Frame) sender;
            if (selectedFrame == null)
            {
                selectedFrame = frame;
                frame.Background = new SolidColorBrush(Colors.Red);
            }
            else
            {
                tempFrame = frame.Content;
                
                var content = (CostList)selectedFrame.Content;
                content.List.ChoosedField = FieldList.IndexOf(frame)+1;
                frame.Navigate(selectedFrame.Content);
                if (tempFrame != null)
                {
                    var content1 = (CostList)tempFrame;
                    content1.List.ChoosedField = FieldList.IndexOf(selectedFrame) + 1;
                }
                
                selectedFrame.Navigate(tempFrame);
                tempFrame = null;
                selectedFrame = null;
                ExitMoveState();
            }
        }

      

        private void ExitMoveState()
        {
            foreach (var field in FieldList)
            {

                field.Background = null;
                field.MouseDown -= new MouseButtonEventHandler(Move);
                new SaveSystem().Save(CarO);
            }
        }

        private void Chart_OnDataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {

        }
    }
}
