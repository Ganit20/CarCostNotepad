using CarCostNotepad.Model;
using CarCostNotepad.View;
using System;
using System.ComponentModel;
using System.Linq;

namespace CarCostNotepad.ViewModel
{
    public class Car : INotifyPropertyChanged, IMainObject
    {
       public Car()
        {
            Type = CalculationTypes.Type.Car;
        }
        public CostGroups Costs{get;set;}

        double[] monthSummary = new double[12];
        public double[] MonthSummary
        {
            get
            {
                return monthSummary;
            }
            set
            {
                monthSummary = value;
                NotifyPropertyChanged("MonthSummary");
            }
        }
        public void RefreshMonthSum()
        {
            MonthSummary = new double[12];
            for (int i=1; i<=monthSummary.Length;i++)
            {
                
                double tempSum = 0;
                foreach (var field in Costs.Checked)
                {
                    var a = field.List.Where(e => e.Date.Month == i);
                    foreach(var value in a)
                    {
                        tempSum += value.Price;
                    }
                }
                MonthSummary[i-1] = tempSum;
            }
        }
        double sum;
        public double Sum
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value; 
                NotifyPropertyChanged("Sum");
            }
        }

        public void RefreshSum()
        {
            sum = 0;
            foreach (var cost in Costs.Checked)
            {
                Sum += cost.Sum;
            }
        }
        public string Name { get; set; }
        public DateTime BuyDate = new DateTime();
        public string LicenceNumber { get; set; }
        public CalculationTypes.Type Type { get; set; }
        public double yearSum { get ; set; }
        public double YearSum {
            get
            {
                return yearSum;
            }
            set
            {
                yearSum = value;
                NotifyPropertyChanged("YearSum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        public void RefreshYearSum(int ChoosedYear)
        {
            YearSum = 0;
            foreach(var item in Costs.Checked)
            {
                var c=item.List.Where(e => e.Date.Year == ChoosedYear);
                foreach(var element in c)
                {
                    YearSum += element.Price;
                }
                   
            }
            
            }
        }
    }
