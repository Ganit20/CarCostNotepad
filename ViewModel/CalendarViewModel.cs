using CarCostNotepad.Model;
using CarCostNotepad.View;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;

namespace CarCostNotepad.ViewModel
{
    class CalendarViewModel
    {
        public DateTime choosedDate;
        View.Calendar calendarView;
        List<CalendarDays> listDays= new List<CalendarDays>();
        Settings Config;
        public CalendarViewModel(View.Calendar calendarView,Settings Config)
        {
            choosedDate = DateTime.Now;
            this.calendarView = calendarView;
            this.Config = Config;
            GenerateCalendar();
           
        }
        public void GenerateCalendar()
        {
            calendarView.MainGrid.Children.Clear();
            listDays.Clear();
            calendarView.Year.Text = choosedDate.Year.ToString();
            calendarView.Month.Text = Config.LanguageSet.Month[choosedDate.Month];
            var Days = DateTime.DaysInMonth(choosedDate.Year, choosedDate.Month);
            GetBeforeDays();

            for (int i = 1; i <= Days; i++)
            {
                var date = new DateTime(choosedDate.Year, choosedDate.Month, i);

                var dto = new DateTime(choosedDate.Year, choosedDate.Month, i);
                var Day = new CalendarDays()
                {
                    DayNumber = i,
                    DayOfTheWeek = (int)date.DayOfWeek,
                    DayNote = "",
                    DateTimeObject = dto,
                    IsToday = dto.Date == DateTime.Now.Date ? true : false
                };
                listDays.Add(Day);
            }
            GetAfterDays();
            AddDaysToCalendar();
        }
        void GetBeforeDays()
        { var date = new DateTime(choosedDate.Year, choosedDate.Month, 1);
            var BeforeDays = DateTime.DaysInMonth(choosedDate.Month == 1 ? choosedDate.Year - 1 : choosedDate.Year, choosedDate.Month == 1 ? 12 : choosedDate.Month - 1);
            if ((int)date.DayOfWeek != 1)
            {
                for (int f = BeforeDays - ((int)date.DayOfWeek - 1); f <= BeforeDays; f++)
                {
                    var datebefore = new DateTime(choosedDate.Month == 1 ? choosedDate.Year - 1 : choosedDate.Year, choosedDate.Month == 1 ? 12 : choosedDate.Month - 1, f);
                    var DayBefore = new CalendarDays()
                    {
                        DayNumber = f,
                        DayOfTheWeek = (int)datebefore.DayOfWeek,
                        DayNote = "",
                        DateTimeObject = new DateTime((int)datebefore.Year, datebefore.Month, f),
                        IsBeforeOrAfter = true
                    };
                    listDays.Add(DayBefore);
                }
            }
        }
        void GetAfterDays()
        {
            var AfterDays = DateTime.DaysInMonth(choosedDate.Month == 12 ? choosedDate.Year + 1 : choosedDate.Year, choosedDate.Month == 12 ? 1 : choosedDate.Month + 1);
            var date = new DateTime(choosedDate.Year, choosedDate.Month, 1);
            if ((int)date.DayOfWeek !=1)
            {
                for (int f = ((int)date.DayOfWeek==0?7: (int)date.DayOfWeek); f <= 6; f++)
                {
                    int i = 1;
                    var datebefore = new DateTime(choosedDate.Month == 12 ? choosedDate.Year + 1 : choosedDate.Year, choosedDate.Month ==12 ? 1 : choosedDate.Month + 1, i);
                    var DayBefore = new CalendarDays()
                    {
                        DayNumber = i,
                        DayOfTheWeek = (int)datebefore.DayOfWeek,
                        DayNote = "",
                        DateTimeObject = new DateTime((int)datebefore.Year, datebefore.Month, i),
                        IsBeforeOrAfter = true
                    };
                    listDays.Add(DayBefore);
                    i++;
                }
            }
        }
        
        void AddDaysToCalendar()
        {
            int RowNum = 2;
            foreach (var day in listDays)
            {
                var dayObject = new CalendarDay()

                {
                    WeekDay = Config.LanguageSet.WeekDays[day.DayOfTheWeek],
                    DayNumber = day.DayNumber,
                    Color = new SolidColorBrush(Colors.White),
                    Notes = "",
                    Foreground = day.IsBeforeOrAfter == true ? new SolidColorBrush(Colors.DimGray) : new SolidColorBrush(Colors.White),
                    Background = day.IsToday == true ? new SolidColorBrush(Colors.Blue) : new SolidColorBrush(Colors.Transparent)
                };
                Grid.SetColumn(dayObject, day.DayOfTheWeek == 0 ? day.DayOfTheWeek = 7 : day.DayOfTheWeek = day.DayOfTheWeek);
                if (day.DayOfTheWeek == 1 && day.IsBeforeOrAfter == false)
                {
                    RowNum++;
                }
                Grid.SetRow(dayObject, RowNum);
                calendarView.MainGrid.Children.Add(dayObject);
            }
        }

        public DateTime EditDateTime(DateTime date,int setYear,int setMonth)
        {
            var editeddate = new DateTime(setYear, setMonth, date.Day);
            return editeddate;
        }
    }
}
