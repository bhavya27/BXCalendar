using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BXCalendar.GlobalData
{
   public class GlobalVar
    {
       #region calendar
        public const string Prev = "prev";
        public const string Next = "next";

        public static string[] WeekDays = { "sunday", "monday", "tuesday", "wednesday", "thursday", "friday", "saturday" };
        public static string[] WeekDaysLabel = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        public static string[] MonthsLabel = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        public const string MonthView = "monthview";
        public const string YearView = "yearview";
        public const string DecadeView = "decadeview";
        #endregion

        public enum ViewType
        {
            Month, Week
        }
    }
}
