using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace CarCostNotepad.Model
{
    class CalendarDays
    {
        public int DayOfTheWeek { get; set; }
        public int DayNumber { get; set; }
        public string DayNote { get; set; }
        public bool IsToday { get; set; }
        public bool IsBeforeOrAfter { get; set; }
        public DateTime DateTimeObject { get; set; }
    }
}
