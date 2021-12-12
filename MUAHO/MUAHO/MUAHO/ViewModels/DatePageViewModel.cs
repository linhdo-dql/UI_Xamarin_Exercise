using MUAHO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class DatePageViewModel : BaseViewModel
    {
        public DatePageViewModel(ItemCart item, Page page, CalendarProduct calendarProduct)
        {
            PriceItem = item.Total + " Vnđ";
            DynamicCalendarProduct = new Command(() =>
            {
                calendarProduct.Schedule = "";
                calendarProduct.ScheduleDay = "";

                page.DisplayAlert("x", calendarProduct.ToString(), "ok");
            });
            StaticCalendarProduct = new Command(() =>
            {
                calendarProduct.Date = "";
                page.DisplayAlert("x", calendarProduct.ToString(), "ok");
            });
        }
        private string _priceItem;

        public string PriceItem
        {
            get { return _priceItem; }
            set { SetProperty(ref _priceItem, value); }
        }

        public Command DynamicCalendarProduct { get; }
        public Command StaticCalendarProduct { get; }

    }
}
