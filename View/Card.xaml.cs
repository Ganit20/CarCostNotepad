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

namespace CarCostNotepad.View
{
   
     
    public partial class Card : Page
    {
        public Car CarO;
        public List<Frame> FieldList = new List<Frame>();
        public Card(Car car)
        {
            CarO = car;
            InitializeComponent();
            FieldList.Add(AA);
            FieldList.Add(BA);
            FieldList.Add(CA);
            FieldList.Add(AC);
            FieldList.Add(BC);
            FieldList.Add(CC);
            SetFrames();

        }
        void SetFrames()
        {
            foreach (var Checked in CarO.Costs.Checked)
            {
                if (Checked.ChoosedField != 0)
                {
                    switch (Checked.ChoosedField)
                    {
                        case 1:
                            AA.Navigate(new CostList(Checked,this));
                            break;
                        case 2:
                            BA.Navigate(new CostList(Checked, this));
                            break;
                        case 3:
                            CA.Navigate(new CostList(Checked, this));
                            break;
                        case 4:
                            AC.Navigate(new CostList(Checked, this));
                            break;
                        case 5:
                            BC.Navigate(new CostList(Checked, this));
                            break;
                        case 6:
                            CC.Navigate(new CostList(Checked, this));
                            break;

                    }
                }
            }
        }

        private void MoveState(object sender, RoutedEventArgs e)
        {
            foreach (var field in FieldList)
            {
                field.Background = new SolidColorBrush(Colors.Blue);
                field.MouseDown += new MouseButtonEventHandler(Move);
            }
        }

        void Move(object sender, MouseEventArgs e)
        {
            var frame = (Frame) sender;
            frame.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
