using BXCalendar.GlobalData;
using BXCalendar.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BXCalendar
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var calendarView = new CalendarView(new CalendarGlobalData()
            {
                Parent = this,
                ShowBy = CalendarGlobalData.ViewType.YearView                
            });
            calendarView.DateSelected += SetDateFromModalPage;
            await Navigation.PushModalAsync(new NavigationPage(calendarView), true);
        }

        private void SetDateFromModalPage(object sender, DateTime selectedDate)
        {
            if (selectedDate != null)
            {
                var timeInString = selectedDate.ToString("MM/dd/yyyy hh:mm tt");
                Application.Current.MainPage.DisplayAlert("Date selected", "Date selected: " + timeInString, "Ok");
            }
            
        }

    }
}
