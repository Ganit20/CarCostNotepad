using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarCostNotepad.Model
{
    public class CostGroups
    {
        public ObservableCollection<CostList> Unchecked = new ObservableCollection<CostList>();
        public ObservableCollection<CostList> Checked = new ObservableCollection<CostList>();

        


    }
}
