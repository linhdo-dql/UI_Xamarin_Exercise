using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels.MainAppPageViewModel
{
    public class CalendarPageViewModel : BaseViewModel
    {
        INavigation Navigation { get; set; }
        public List<string> ListFilter { get; set; } 
        
        public List<CalendarProduct> CalendarProducts { get; set; }
        
        public CalendarPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            ListFilter = new List<string>() { "Giá", "Ngày cập nhật", "Loại" };
            CalendarProducts = new List<CalendarProduct>()
            {
               new CalendarProduct("ic_tea.jpg","Trà thảo mộc Mikita","14K/đơn","","15/05/2021-15/09/2021","08:30","Thứ 3 - 5 - 7 hàng tuần",""),
                new CalendarProduct("ic_fruit.jpg","Trái cây tươi","215K/Đơn","(theo giá)","15/05/2021-15/09/2021","08:00","Thứ 2 hàng tuần",""),
                 new CalendarProduct("ic_shirt.png","Sơ mi đen","580K/Đơn","","14/06/2021","15:45","","")
            };
            SwitchItem = new Command(( x ) =>
             {
                 var calendar = x as CalendarProduct;
                 //page.DisplayAlert("x", "tapped", "ok");
                 navigation.PushAsync(new OrderPage(calendar.NameProduct, new bool[] {}, new string[] {}));
             });
            SwitchToStorePage = new Command(() =>
            {
                navigation.PushAsync(new StorePage());
            });
        }
        public Command SwitchItem { get; }
        public Command SwitchToStorePage { get; }
    }
}
