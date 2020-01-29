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
    }
}
