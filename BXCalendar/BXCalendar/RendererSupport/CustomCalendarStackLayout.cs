using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BXCalendar.RendererSupport
{
    public class CustomCalendarStackLayout : StackLayout
    {
        public bool isWeekEndingDate = false;
        public bool currentMonth;
        public DateTime dateTime;
        public string dateType;
        public bool IsCurrentMonthsDate
        {
            get { return currentMonth; }
            set
            {
                currentMonth = value;
            }
        }
        public bool IsWeekEndingDate
        {
            get { return isWeekEndingDate; }
            set
            {
                isWeekEndingDate = value;
            }
        }
        public DateTime DateTimeInfo
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
            }
        }

        public string DateType
        {
            get { return dateType; }
            set
            {
                dateType = value;
            }
        }

    }
}
