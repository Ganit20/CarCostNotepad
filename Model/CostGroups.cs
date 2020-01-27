using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarCostNotepad.Model
{
    public class CostGroups
    {
        public CostGroups()
        {
            Unchecked.Add(new GroupCost().FixedCost);
            Checked.Add(new GroupCost().FuelCost);
            Unchecked.Add(new GroupCost().OtherCost);
            Unchecked.Add(new GroupCost().RepairCost);
        }
        public ObservableCollection<ObservableCollection<Cost>> Unchecked = new ObservableCollection<ObservableCollection<Cost>>();
        public ObservableCollection<ObservableCollection<Cost>> Checked = new ObservableCollection<ObservableCollection<Cost>>();
    }
}
