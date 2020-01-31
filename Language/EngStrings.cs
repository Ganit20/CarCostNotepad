using CarCostNotepad.Language;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarCostNotepad.Eng
{
    class EngStrings :ILanguage
    {
        public string LanguageName { get; set; }
        public string CNameString { get; set; }
        public string LicensePlateString { get; set; }
        public string DayOPString { get; set; }
        public string AddString { get; set; }
        public string CancelString { get; set; }
        public string SumString { get; set; }
        public string NameOfCostString { get; set; }
        public string PriceString { get; set; }
        public string DateString { get; set; }
        public string EditString { get; set; }
        public string NameString { get; set; }
        public string GeneralSettingsString { get; set; }
        public string Language { get; set; }
        public string FuelCostString { get; set; }
        public string OtherCostString { get; set; }
        public string FixedCostString { get; set; }
        public string RepairsCostString { get; set; }
        public string ShowChartSetting { get; set ; }
        public string CharLegendVisibility { get ; set; }
        public string TopString { get ; set ; }
        public string BottomString { get; set ; }
        public string LeftString { get; set ; }
        public string RightString { get; set  ; }
        public string ChartSettings { get ; set; }
        public string NoneString { get ; set; }
        public string[] Month { get ; set ; }
        public string SelectTypeString { get ; set ; }
        public string ShowCartesianChartSetting { get ; set ; }
        public string Summary { get ; set ; }
        public string TypeString { get ; set ; }
        public string YearSum { get ; set ; }


        public EngStrings()
        {
            LanguageName = "English";
            CNameString = "Car Name";
            LicensePlateString = "License Plate";
            DayOPString = "Day of Purchase";
            AddString = "Add";
            CancelString = "Cancel";
            NameOfCostString = "Cost Name";
            PriceString = "Value of Cost";
            DateString = "Date";
            EditString = "Edit";
            NameString = "Name";
            SumString = "All: ";
            GeneralSettingsString = "General";
            Language = "Language";
            FuelCostString = "Fuel";
            OtherCostString = "Other";
            FixedCostString = "Fixed Costs";
            RepairsCostString = "Repair";
            ShowChartSetting = "Show Chart";
            ShowCartesianChartSetting = "Show Cartesian Chart";
            CharLegendVisibility = "Chow Chart Legend";
            TopString = "Top";
            BottomString = "Bottom";
            LeftString = "Left";
            RightString = "Right";
            ChartSettings = "Chart Settings";
            NoneString = "None";
            Month = new string[12];
            Month[0] = "January";
            Month[1] = "February";
            Month[2] = "March";
            Month[3] = "April";
            Month[4] = "May";
            Month[5] = "June";
            Month[6] = "July";
            Month[7] = "August";
            Month[8] = "September";
            Month[9] = "October";
            Month[10] = "November";
            Month[11] = "December";
            SelectTypeString = "Select Type";
            Summary = "Summary";
            TypeString = "Type";
            YearSum = "Sum of Year";
        }
    }
}
