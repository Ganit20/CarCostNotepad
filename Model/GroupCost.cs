using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarCostNotepad.Model
{
   public class GroupCost
    {
        public ObservableCollection<Cost> RepairCost = new ObservableCollection<Cost>();
        public ObservableCollection<Cost> FixedCost = new ObservableCollection<Cost>();
        public ObservableCollection<Cost> FuelCost = new ObservableCollection<Cost>();
        public ObservableCollection<Cost> OtherCost = new ObservableCollection<Cost>();

    }
}
