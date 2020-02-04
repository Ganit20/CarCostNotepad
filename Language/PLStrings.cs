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
        public string OtherCostString { get; set; }
        public string FixedCostString { get; set; }
        public string RepairsCostString { get; set; }
        public string ShowChartSetting { get; set; }
        public string CharLegendVisibility { get; set; }
        public string TopString { get; set; }
        public string BottomString { get; set; }
        public string LeftString { get; set; }
        public string RightString { get; set; }
        public string ChartSettings { get; set; }
        public string NoneString { get; set; }
        public string[] Month { get; set; }
        public string[] WeekDays { get; set; }
        public string SelectTypeString { get; set; }
        public string ShowCartesianChartSetting { get; set; }
        public string Summary { get; set; }
        public string TypeString { get; set; }
        public string YearSum { get; set; }
        public string FontSizeString { get; set; }
        public string Details { get; set; }
        public string CardSizeString { get; set; }
        public string LoadDefault { get; set; }
        public string DeleteQuestion { get; set; }
        public string Yes { get; set; }
        public string No { get; set; }
        public string CalendarString { get; set; }
        public string Costs { get; set; }
        public string CalendarDefaultNews { get; set; }


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
            ShowChartSetting = "Pokaż Wykres Kołowy";
            ShowCartesianChartSetting = "Pokaż Wykres Kolumnowy";
            CharLegendVisibility = "Pokaż Legende Wykresu";
            TopString = "Na Górze";
            BottomString = "Na Dole";
            LeftString = "Lewo";
            RightString = "Prawo";
            ChartSettings = "Ustawienia Wykresu";
            NoneString = "Brak";
            Month = new string[12];
            Month[0] = "Styczeń";
            Month[1] = "Luty";
            Month[2] = "Marzec";
            Month[3] = "Kwiecień";
            Month[4] = "Maj";
            Month[5] = "Czerwiec";
            Month[6] = "Lipiec";
            Month[7] = "Sierpień";
            Month[8] = "Wrzesień";
            Month[9] = "Październik";
            Month[10] = "Listopad";
            Month[11] = "Grudzień";
            SelectTypeString = "Wybierz Rodzaj";
            Summary = "Podsumowanie";
            TypeString = "Typ";
            YearSum = "Suma Roczna";
            FontSizeString = "Wielkość Czcionki";
            Details = "Szczegóły";
            CardSizeString = "Wielkość Karty";
            LoadDefault = "Przywróć Domyślne";
            DeleteQuestion = "Czy na pewno chcesz usunąć ";
            Yes = "Tak";
            No = "Nie";
            CalendarString = "Kalendarz";
            CalendarDefaultNews = "Brak Zaplanowanych wydarzeń";
            Costs = "Kalkulator Kosztów";
            WeekDays = new string[7];
            WeekDays[0] = "Niedziela";
            WeekDays[1] = "Poniedziałek";
            WeekDays[2] = "Wtorek";
            WeekDays[3] = "Środa";
            WeekDays[4] = "Czwartek";
            WeekDays[5] = "Piątek";
            WeekDays[6] = "Sobota";

        }
    }
}
