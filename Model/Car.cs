using CarCostNotepad.Model;
using System;

namespace CarCostNotepad.ViewModel
{
    public class Car
    {
        public CostGroups Costs { get; set; }
        public string Name { get; set; }
        public DateTime BuyDate { get; set; }
        public string LicenceNumber { get; set; }
    }
}