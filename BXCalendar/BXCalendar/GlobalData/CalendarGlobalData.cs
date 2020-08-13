using BXCalendar.GlobalData;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace BXCalendar.GlobalData
{
    public class CalendarGlobalData
    {
        public object Parent { get; set; }
        public Color SelectedDateColor { get; set; } = (Color)Application.Current.Resources["accent"];
        public Color DisabledColor { get; set; } = Color.LightGray;
        public Color OldMonthDatesColor { get; set; } = Color.DarkGray;
        public Color ActivatedColor { get; set; } = (Color)Application.Current.Resources["lightAccentBackground"];
        public Color TextColor { get; set; } = Color.Black;
        public string BorderType { get; set; } = BorderType_Border;
        public string WeekEndingDay { get; set; } ="Friday";
        public string SelectedFillType { get; set; } = FillType_Fill;
        public DateTime MinDateRange { get; set; } = DateTime.MinValue;
        //public string DateFormat { get; set; } = (GlobalVar.Getkey(GlobalVar.DateFormat) == "MDY") ? "{0:MM/dd/yyyy}" : "{0:dd/MM/yyyy}";
        public string DateFormat { get; set; } = "{0:MM/dd/yyyy}";
        public DateTime CalendarUI_DT { get; set; } = DateTime.Now;
        public DateTime MaxDateRange { get; set; } = DateTime.MaxValue;
        public ViewType ShowBy { get; set; } = ViewType.MonthView;


        public const string FillType_Fill = "fillbox";
        public const string FillType_Circle = "circle";
        public const string BorderType_Collapsed = "collapsed";
        public const string BorderType_Border = "border";

        public enum ViewType
        {
            MonthView, YearView
        }
    }
}
