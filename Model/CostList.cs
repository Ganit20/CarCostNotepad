using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace CarCostNotepad.Model
{
    public class CostList :INotifyPropertyChanged
    {
        public CostList()
        { 
            
            Sum = 0;
        }
        public int ChoosedField { get; set; }
        double sum ;
        public double Sum
        {
            get { return sum;}
            set
            {
                sum = 0;
                foreach (var Element in List)
                {
                   sum+= Element.Price;
                }

                NotifyPropertyChanged("Sum");
                
            }
        }

        public string Name { get; set; }
         ObservableCollection<Cost> list = new ObservableCollection<Cost>();

         public ObservableCollection<Cost> List
         {
             get { return list; }
             set
             {
                 NotifyPropertyChanged("list");
                 Sum = 0;
             }
         }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}
