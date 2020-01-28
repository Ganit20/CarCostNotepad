using CarCostNotepad.Model;
using System;
using System.ComponentModel;

namespace CarCostNotepad.ViewModel
{
    public class Car : INotifyPropertyChanged
    {
       
        public CostGroups Costs = new CostGroups();
        public double sum;

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
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }
    }
}