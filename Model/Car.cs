using CarCostNotepad.Model;
using System;

namespace CarCostNotepad.ViewModel
{
    public class Car
    {
        public CostGroups Costs = new CostGroups();
        public string Name { get; set; }
        public DateTime BuyDate = new DateTime();
        public string LicenceNumber { get; set; }
    }
}