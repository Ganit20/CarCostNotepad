using System;
using System.Collections.Generic;
using System.Text;

namespace CarCostNotepad.Language
{
    public interface ILanguage
    {
        string LanguageName { get; set; }
        string CNameString { get; set; }
        string LicensePlateString { get; set; }
        string SumString { get; set; }
        string DayOPString { get; set; }
        string AddString { get; set; }
        string CancelString { get; set; }
        string NameOfCostString { get; set; }
        string PriceString { get; set; }
        string DateString { get; set; }
        string EditString { get; set; }
        string NameString { get; set; }
        string GeneralSettingsString { get; set; }
        string Language { get; set; }
        string FuelCostString { get; set; }
        string OtherCostString { get; set; }
        string FixedCostString { get; set; }
        string RepairsCostString { get; set; }
        string ShowChartSetting { get; set; }
        string CharLegendVisibility { get; set; }
        string ChartSettings { get; set; }
        string TopString { get; set; }
        string BottomString { get; set; }
        string LeftString { get; set; }
        string RightString { get; set; }
        string NoneString { get; set; }

        string[] Month {get;set;}
        string SelectTypeString { get; set; }
        string ShowCartesianChartSetting { get; set; }
        string Summary { get; set; }
        string TypeString { get; set; }
        string YearSum { get; set; }
        string FontSizeString { get; set; }
        string Details { get; set; }
        string CardSizeString { get; set; }
        string LoadDefault { get; set; }
        string DeleteQuestion { get; set; }
        string Yes { get; set; }
        string No { get; set; }
        string CalendarString { get; set; }
        string Costs { get; set; }
        public string[] WeekDays { get; set; }
    }
}
