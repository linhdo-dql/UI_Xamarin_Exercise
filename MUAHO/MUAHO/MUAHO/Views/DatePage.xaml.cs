using Android.App;
using MUAHO.Models;
using MUAHO.ViewModels;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUAHO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatePage : ContentPage
    {
        bool checkT2 = false, checkT3 = false, checkT4 = false, checkT5 = false, checkT6 = false, checkT7 = false, checkCN = false;
        bool[] x = new bool[7];
        string[] schedule = new string[2];
        List<String> listDay = new List<string>();
        int currentMonth = DateTime.Now.Month;
        int currentYear = DateTime.Now.Year;
        CalendarProduct calendarProduct = new CalendarProduct("","","","","","","","");
        public DatePage(ItemCart item)
        {
            InitializeComponent();
            BindingContext = new DatePageViewModel(item, this, calendarProduct);
            calendarProduct.Image = item.ImageItem;
            calendarProduct.Price = item.PriceItem;
            DisplayAlert("Item", item.AmountItem.ToString(), "ok");
            //calendar.Culture = culture;
            gridDay.Children.Clear();
            DateTime date = new DateTime(currentYear, currentMonth, 1);
            int[] arr = GetCalendarOfMonth(currentMonth, currentYear);
            //DisplayAlert("x", "start: " + showArray(arr), "ok");
            int dem = 0;
            for ( int i = 0 ; i < 6 ; i++ )
            {
                for ( int j = 0 ; j < 7 ; j++ )
                {
                    Button b = new Button
                    {
                        Text = arr[dem].ToString(),
                        WidthRequest = 20,
                        HeightRequest = 35,
                        FontSize = 15,
                        Padding = -5,
                        BackgroundColor = Color.Transparent,
                        TextColor = ((dem < (getThu(date.DayOfWeek.ToString())) || dem >=
                        (getThu(date.DayOfWeek.ToString()) + DateTime.DaysInMonth(currentYear, currentMonth)))) ?
                        Color.FromHex("#929292") : Color.Black,
                        IsEnabled = ((dem < (getThu(date.DayOfWeek.ToString())) || dem >=
                        (getThu(date.DayOfWeek.ToString()) + DateTime.DaysInMonth(currentYear, currentMonth)))) ?
                        false : true

                    };
                    b.ClassId = StandartDayMonth(int.Parse(b.Text)) + StandartDayMonth(currentMonth) + currentYear;
                    b.StyleId = "0";
                    b.Clicked += B_Clicked;
                    gridDay.Children.Add(b, j, i);
                    dem++;
                }
            }
            lblTitle.Text = "Tháng " + currentMonth + ", " + currentYear;

        }

        private void btnNext_Clicked( object sender, EventArgs e )
        {
            gridDay.Children.Clear();
            
            if(currentMonth+1 <=12)
            {
                currentMonth++;
            }
            else
            {
                currentMonth = 1;
                currentYear++;
               
            }
            if(currentMonth>1 && currentYear>=DateTime.Now.Year)
            {
                btnPrev.IsEnabled = true;
            }
            DateTime date = new DateTime(currentYear, currentMonth, 1);
            int[] arr = GetCalendarOfMonth(currentMonth, currentYear);
            //DisplayAlert("x", "start: " + showArray(arr), "ok");
            int dem = 0;
            for ( int i = 0 ; i < 6 ; i++ )
            {
                for ( int j = 0 ; j < 7 ; j++ )
                {
                    Button b = new Button
                    {
                        Text = arr[dem].ToString(),
                        WidthRequest = 20,
                        HeightRequest = 35,
                        FontSize = 15,
                        Padding = -5,
                        BackgroundColor = Color.Transparent,
                        TextColor = ((dem < (getThu(date.DayOfWeek.ToString())) || dem >=
                        (getThu(date.DayOfWeek.ToString()) + DateTime.DaysInMonth(currentYear, currentMonth)))) ?
                        Color.FromHex("#929292") : Color.Black,
                        IsEnabled = ((dem < (getThu(date.DayOfWeek.ToString())) || dem >=
                        (getThu(date.DayOfWeek.ToString()) + DateTime.DaysInMonth(currentYear, currentMonth)))) ?
                        false : true

                    };
                    b.ClassId = StandartDayMonth(int.Parse(b.Text)) + StandartDayMonth(currentMonth) + currentYear;
                    b.StyleId = "0";
                    b.Clicked += B_Clicked;
                    gridDay.Children.Add(b, j, i) ;
                    dem++;
                }
            }
            lblTitle.Text = "Tháng " + currentMonth +", "+ currentYear;
        }

        private void B_Clicked( object sender, EventArgs e )
        {
            Button button = sender as Button;
               
            if (int.Parse(button.StyleId)==0)
            {
                button.BackgroundColor = Color.FromHex("#F2985A");
                button.CornerRadius = 30;
                button.TextColor = Color.White;
                button.StyleId = "1";
                listDay.Add(button.ClassId);
                calendarProduct.Date = String.Join(",", listDay);
            }
            else
            {
                button.BackgroundColor = Color.Transparent;
                button.CornerRadius = 30;
                button.TextColor = Color.Black;
                button.StyleId = "0";
                listDay.Remove(button.ClassId);
                calendarProduct.Date = String.Join(",", listDay);
            }
            DisplayAlert("x", listDay.Count.ToString(), "ok");

        }

        private void btnPrev_Clicked( object sender, EventArgs e )
        {
            gridDay.Children.Clear();
            if ( currentMonth - 1 >= 1 )
            {
                currentMonth--;
            }
            else
            {
                currentMonth = 12;
                currentYear--;
                if(currentYear-1<DateTime.Now.Year)
                {
                    btnPrev.IsEnabled = false;
                }
            }
            DateTime date = new DateTime(currentYear, currentMonth, 1);
            int[] arr = GetCalendarOfMonth(currentMonth, currentYear);
            //DisplayAlert("x", "start: " + showArray(arr), "ok");
            int dem = 0;
            for ( int i = 0 ; i < 6 ; i++ )
            {
                for ( int j = 0 ; j < 7 ; j++ )
                {
                    Button b = new Button
                    {
                        Text = arr[dem].ToString(),
                        WidthRequest = 20,
                        HeightRequest = 35,
                        FontSize = 15,
                        Padding = -5,
                        BackgroundColor = Color.Transparent,
                        TextColor = ((dem < (getThu(date.DayOfWeek.ToString())) || dem >=
                        (getThu(date.DayOfWeek.ToString()) + DateTime.DaysInMonth(currentYear, currentMonth)))) ?
                        Color.FromHex("#929292") : Color.Black,
                        IsEnabled = ((dem < (getThu(date.DayOfWeek.ToString())) || dem >=
                        (getThu(date.DayOfWeek.ToString()) + DateTime.DaysInMonth(currentYear, currentMonth)))) ?
                        false : true

                    };
                    b.ClassId = StandartDayMonth(int.Parse(b.Text)) + StandartDayMonth(currentMonth)  + currentYear;
                    b.StyleId = "0";
                    b.Clicked += B_Clicked;
                    gridDay.Children.Add(b, j, i);
                    dem++;
                }
            }
            lblTitle.Text = "Tháng " + currentMonth + ", " + currentYear;
        }
       

     

        private void ScrollView2_Scrolled( object sender, ScrolledEventArgs e )
        {
            if ( e.ScrollY < 30 )
            {
                bigFrame.IsVisible = true;
                smallFrame.IsVisible = true;
            }
            else
            {
                bigFrame.IsVisible = false;
                smallFrame.IsVisible = false;
            }
        }

      

        private void CustomDatePicker_DateSelected( object sender, DateChangedEventArgs e )
        {
            schedule[0] = datepicker2.Date.ToString();
            calendarProduct.ScheduleDay = String.Join(",", schedule);
        }

        private void TapGestureRecognizer_Tapped_1( object sender, EventArgs e )
        {
            if ( datepicker2.IsFocused )
            {
                Debug.WriteLine("Yes, datePicker is focused");
                datepicker2.Unfocus();
            }

            datepicker2.Focus();
        }

        private void TapGestureRecognizer_Tapped_2( object sender, EventArgs e )
        {
            if ( datepicker1.IsFocused )
            {
                Debug.WriteLine("Yes, datePicker is focused");
                datepicker1.Unfocus();
            }

            datepicker1.Focus();
        }

        private void TapGestureRecognizer_Tapped_3( object sender, EventArgs e )
        {
            if ( timepicker.IsFocused )
            {
                Debug.WriteLine("Yes, datePicker is focused");
                timepicker.Unfocus();
            }

            timepicker.Focus();
        }

        private void TapGestureRecognizer_Tapped_4( object sender, EventArgs e )
        {
            if ( timepicker0.IsFocused )
            {
                Debug.WriteLine("Yes, datePicker is focused");
                timepicker0.Unfocus();
            }

            timepicker0.Focus();
        }

        private void TapGestureRecognizer_Tapped_5( object sender, EventArgs e )
        {
            Navigation.PopAsync();
        }

        private void TapGestureRecognizer_Tapped_6( object sender, EventArgs e )
        {
            Navigation.PushPopupAsync(new PopupPage());
        }

        public int getThu(string WeekOfDay)
        {
           
                switch(WeekOfDay)
            {
                case "Monday": return 0;
                case "Tuesday": return 1;
                case "Wednesday": return 2;
                case "Thursday": return 3;
                case "Friday": return 4;
                case "Saturday": return 5;
                case "Sunday": return 6;
                default: return 100;

            }
        }

        private void timepicker_PropertyChanged( object sender, System.ComponentModel.PropertyChangedEventArgs e )
        {
            if ( e.PropertyName == "Time" )
            {
                calendarProduct.Time = timepicker.Time + "";

            }
        }

        private void timepicker0_PropertyChanged( object sender, System.ComponentModel.PropertyChangedEventArgs e )
        {
            if ( e.PropertyName == "Time" )
            {
                calendarProduct.Time = timepicker0.Time + "";
            }
        }

        private void datepicker1_DateSelected( object sender, DateChangedEventArgs e )
        {
            schedule[1] = datepicker1.Date.ToString("dd-MM-yyyy");
            calendarProduct.ScheduleDay = String.Join(",", schedule);
        }

        private void CustomEditor_TextChanged( object sender, TextChangedEventArgs e )
        {
            calendarProduct.Note = entry1.Text;
        }

        private void CustomEditor_TextChanged_1( object sender, TextChangedEventArgs e )
        {
            calendarProduct.Note = entry2.Text;
        }

        public int[] GetCalendarOfMonth(int month, int year)
        {
            DateTime date = new DateTime(year, month, 1);
            int startMonth = getThu(date.DayOfWeek.ToString());
            int dayOfMonth = DateTime.DaysInMonth(year, month);

            int[] arr = new int[42];
            int day = 0;
            for(int i = startMonth ; i < startMonth + dayOfMonth ; i++ )
            {
                day++;
                arr[i] = day;
            }
            month = month - 1 == 0 ? 12 : month;
            int dayOfMonth2 = DateTime.DaysInMonth(year, month - 1);
            for(int j = startMonth-1 ; j>=0 ; j-- )
            {
                arr[j] = dayOfMonth2;
                dayOfMonth2--;
            }
            int dem = 1;
            for(int k = startMonth+dayOfMonth ; k<42 ; k++ )
            {
                arr[k] = dem;
                dem++;
            }    
            return arr;
        }

        private void ScrollView_Scrolled( object sender, ScrolledEventArgs e )
        {
             if(e.ScrollY < 30)
            {
                bigFrame.IsVisible = true;
                smallFrame.IsVisible = true;
            }
             else
            {
                bigFrame.IsVisible = false;
                smallFrame.IsVisible=false;
            }
        }
        private void OnCheckedChange( object sender, CheckedChangedEventArgs e )
        {
            Color color = e.Value ? Color.White : Color.FromHex("#929292");
            (sender as RadioButton).TextColor = color;

        }

        private void TapGestureRecognizer_Tapped( object sender, EventArgs e )
        {
            RadioButton button = sender as RadioButton;
            switch ( button.GroupName )
            {
                case "T2": SetCheck(ref checkT2, button); x[0] = checkT2; break;
                case "T3": SetCheck(ref checkT3, button); x[1] = checkT3; break;
                case "T4": SetCheck(ref checkT4, button); x[2] = checkT4; break;
                case "T5": SetCheck(ref checkT5, button); x[3] = checkT5; break;
                case "T6": SetCheck(ref checkT6, button); x[4] = checkT6; break;
                case "T7": SetCheck(ref checkT7, button); x[5] = checkT7; break;
                case "CN": SetCheck(ref checkCN, button); x[6] = checkCN; break;
            }
            calendarProduct.Schedule = String.Join(",", x);
        }
        private void SetCheck( ref bool check, RadioButton button )
        {
            if ( !check )
            {
                button.IsChecked = true;
                check = true;
            }
            else
            {
                button.IsChecked = false;
                check = false;
            }
        }
        private string StandartDayMonth( int dayOrMonth ) => (dayOrMonth < 10) ? "0" + dayOrMonth : dayOrMonth.ToString();
    }

}