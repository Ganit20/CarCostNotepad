using System;
using System.Collections.Generic;
using System.Text;

namespace CarCostNotepad.Model
{
    public interface IMainObject
    {
        public CostGroups Costs { get; set; }
        public double[] MonthSummary { get; set; }
        public void RefreshMonthSum();
        public double Sum { get; set; }
        public double YearSum { get; set; }
        public void RefreshYearSum(int ChoosedYear);
        public void RefreshSum();
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
