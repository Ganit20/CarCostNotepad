using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarCostNotepad.Model
{
   public class GroupCost
    {
        public static ObservableCollection<Cost> RepairCost = new ObservableCollection<Cost>();
        public static ObservableCollection<Cost> FixedCost = new ObservableCollection<Cost>();
        public static ObservableCollection<Cost> FuelCost = new ObservableCollection<Cost>();
        public static ObservableCollection<Cost> OtherCost = new ObservableCollection<Cost>();
    }
}
