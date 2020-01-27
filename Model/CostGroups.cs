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

            Unchecked.Add(
                new CostList()
            {
                Name = "FixedCost"
            });
            Checked.Add(new CostList()
            {
                Name = "FuelCost"
            });
            Unchecked.Add(new CostList()
            {
                Name = "OtherCost"
            });
            Unchecked.Add(new CostList()
            {
                Name = "RepairCost"
            });
            }
        public ObservableCollection<CostList> Unchecked = new ObservableCollection<CostList>();
        public ObservableCollection<CostList> Checked = new ObservableCollection<CostList>();
    }
}
