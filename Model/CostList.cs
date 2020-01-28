using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CarCostNotepad.Model
{
    public class CostList
    {
        public CostList()
        { 
            List.Add(new Cost()
            {
                Name = "No Costs",
                Date = DateTime.Now,
                Price = 42
            }) ;
        }
        public int ChoosedField { get; set; }
        public string Name { get; set; }
        public ObservableCollection<Cost> List = new ObservableCollection<Cost>();
    }
}
