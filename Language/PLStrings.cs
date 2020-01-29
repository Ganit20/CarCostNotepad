using System;
using System.Collections.Generic;
using System.Text;

namespace CarCostNotepad.Language
{
    class PLStrings:ILanguage
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
        public string OtherCostString { get ; set ; }
        public string FixedCostString { get; set; }
        public string RepairsCostString { get; set; }

        public PLStrings()
        {
            LanguageName = "Polski";
            CNameString = "Nazwa Samochodu";
            LicensePlateString = "Tablica Rejestracyjna";
            DayOPString = "Dzień Zakupu";
            AddString = "Dodaj";
            CancelString = "Anuluj";
            NameOfCostString = "Nazwa Kosztu";
            PriceString = "Wartość";
            DateString = "Data";
            EditString = "Edycja";
            NameString = "Nazwa";
            SumString = "Suma: ";
            GeneralSettingsString = "Ogólne";
            Language = "Język";
            FuelCostString = "Paliwo";
            OtherCostString = "Inne";
            FixedCostString = "Koszta Stałe";
            RepairsCostString = "Naprawa";
        }
    }
}
