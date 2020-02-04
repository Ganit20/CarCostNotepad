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
using System.Threading.Tasks;

namespace CarCostNotepad.View
{
   
     
    public partial class Card : Page 
    {
        private Frame selectedFrame ;
        private object tempFrame;
        public IMainObject MObject;
        private bool isMoveState = false;
        public List<Frame> FieldList = new List<Frame>();
        public List<IViewObject> FieldViewList = new List<IViewObject>();
        Settings Config;
        public Summary SummaryField;
        CardViewModel ViewModel;

        public Card(IMainObject car,Settings config)
        {
            
            Config = config;
            DataContext = Config;
            MObject = car;
            ViewModel=new CardViewModel();
            InitializeComponent();
            Initialize();
            
            
        }
        public async Task Initialize()
        {
            var GridProperty = await ViewModel.CreateGrid(MainGrid,Config);
            var summaryField = new Summary(Config, MObject);
            SummaryField = summaryField;
            Summary.Navigate(summaryField);
            FieldList = await ViewModel.CreateFrames();
            foreach (var frame in FieldList)
            {
                frame.MouseDown += ShowDetails;
                MainGrid.Children.Add(frame);
            }
            FieldViewList = await ViewModel.CreateFieldView(MObject, this, Config);
            await new CardViewModel().SetFrames(FieldList, FieldViewList);
            MObject.RefreshSum();
            
        }

        private void ShowDetails(object sender, MouseButtonEventArgs e)
        {
            var a = (Frame)sender;
            if (a.Content != null)
            {
                var b = (CostList)a.Content;
                SummaryField.Details.Navigate(new Details(b.List, Config));
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
                if (selectedFrame.Content != null)
                {
                    var content = (IViewObject)selectedFrame.Content;
                    content.FrameNumber = FieldList.IndexOf(frame) + 1;
                }
                frame.Navigate(selectedFrame.Content);
                if (tempFrame != null)
                {
                    var content1 = (IViewObject)tempFrame;
                    content1.FrameNumber = FieldList.IndexOf(selectedFrame) + 1;
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
                new SaveSystem().Save(MObject);
            }
            isMoveState = false;
        }

        
    }
}
