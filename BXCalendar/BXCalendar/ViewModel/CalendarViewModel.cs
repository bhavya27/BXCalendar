using BXCalendar.GlobalData;
using BXCalendar.Helper;
using BXCalendar.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BXCalendar.ViewModels
{
    public class CalendarViewModel : ViewModelBase
    {
        
        public int currentYear;
        public string currentDate;
        public string currentCalendarView;
        public double prevButtonOpacity;
        public double nextButtonOpacity;


        CalendarView calendar;

        public Command<string> PreviousCalendarCommand { get; }
        public Command<string> NextCalendarCommand { get; }
        public ICommand CalendarViewCommand { get; set; }
        public string CurrentDate
        {
            get { return currentDate; }
            set
            {
                currentDate = value;
                RaisePropertyChanged();
                PreviousCalendarCommand.ChangeCanExecute();
                NextCalendarCommand.ChangeCanExecute();
            }
        }

        public string CurrentCalendarView
        {
            get { return currentCalendarView; }
            set
            {
                currentCalendarView = value;
                RaisePropertyChanged();
            }
        }

        public double PrevButtonOpacity
        {
            get { return prevButtonOpacity; }
            set
            {
                prevButtonOpacity = value;
                RaisePropertyChanged();
            }
        }
        public double NextButtonOpacity
        {
            get { return nextButtonOpacity; }
            set
            {
                nextButtonOpacity = value;
                RaisePropertyChanged();
            }
        }

        public CalendarViewModel(CalendarView calendar)
        {
            this.calendar = calendar;
            PreviousCalendarCommand = new Command<string>(UpdateCalendar, CanExecute);
            NextCalendarCommand = new Command<string>(UpdateCalendar, CanExecute);

            CalendarViewCommand = new Command(CalendarView);
            
        }

        public bool CanExecute(string arg)
        {
            bool isEnabled = true;
            //as we have to check only month and not weekday here,making new date with same day
            int maxDate = DateTime.DaysInMonth(calendar.calendarUI_DT.Year, calendar.calendarUI_DT.Month) > calendar.maxDateRange.Day ?
                calendar.maxDateRange.Day : DateTime.DaysInMonth(calendar.calendarUI_DT.Year, calendar.calendarUI_DT.Month);
            DateTime newDTToCompareMin_Month = new DateTime(calendar.calendarUI_DT.Year, calendar.calendarUI_DT.Month, calendar.minDateRange.Day);
            DateTime newDTToCompareMax_Month = new DateTime(calendar.calendarUI_DT.Year, calendar.calendarUI_DT.Month, maxDate);
            DateTime newDTToCompareMin_Year = new DateTime(calendar.calendarUI_DT.Year, calendar.minDateRange.Month, calendar.minDateRange.Day);
            DateTime newDTToCompareMax_Year = new DateTime(calendar.calendarUI_DT.Year, calendar.maxDateRange.Month, maxDate);
            switch (arg)
            {
                case GlobalVar.Prev:
                    isEnabled = false;
                    PrevButtonOpacity = 0.4;
                    if (((CurrentCalendarView == GlobalVar.MonthView) && (newDTToCompareMin_Month.AddMonths(-1) >= calendar.minDateRange)) ||
                        ((CurrentCalendarView == GlobalVar.YearView) && (newDTToCompareMin_Year.AddYears(-1) >= calendar.minDateRange)))
                    {
                        isEnabled = true;
                        PrevButtonOpacity = 1;
                    }
                    break;
                case GlobalVar.Next:
                    isEnabled = false;
                    NextButtonOpacity = 0.4;
                    if (((CurrentCalendarView == GlobalVar.MonthView) && (newDTToCompareMax_Month.AddMonths(+1) <= calendar.maxDateRange)) ||
                        ((CurrentCalendarView == GlobalVar.YearView) && (newDTToCompareMax_Year.AddYears(+1) <= calendar.maxDateRange)))
                    {
                        isEnabled = true;
                        NextButtonOpacity = 1;
                    }
                    break;
            }
            Console.WriteLine(NextButtonOpacity + " : " + PrevButtonOpacity);
            return isEnabled;
        }

        public void CalendarView()
        {
            DateTime dt = calendar.calendarUI_DT;
            switch (CurrentCalendarView)
            {
                case GlobalVar.MonthView:
                    calendar.YearLayout(dt);
                    break;
            }
        }





        public void UpdateCalendar(string changeType)
        {
            switch (changeType)
            {
                case GlobalVar.Prev:
                    if (CurrentCalendarView == GlobalVar.MonthView) calendar.MonthView(calendar.calendarUI_DT.AddMonths(-1));
                    else if (CurrentCalendarView == GlobalVar.YearView) calendar.YearView(calendar.calendarUI_DT.AddYears(-1));
                    break;
                case GlobalVar.Next:
                    if (CurrentCalendarView == GlobalVar.MonthView) calendar.MonthView(calendar.calendarUI_DT.AddMonths(+1));
                    else if (CurrentCalendarView == GlobalVar.YearView) calendar.YearView(calendar.calendarUI_DT.AddYears(+1));
                    break;
            }
        }
    }
}

