using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class NotifyPageViewModel : BaseViewModel
    {
        private ObservableCollection<Notification> _notifications;
        public ObservableCollection<Notification> Notifications { get { return _notifications; } set { SetProperty(ref _notifications, value); } }
        public INavigation Navigation { get; set; }

        public NotifyPageViewModel( INavigation navigation)
        {
            Notifications = new ObservableCollection<Notification>()
            {
               new Notification("ic_vinmart.jpg","VinMart + Mikita Shop + M...","Bạn đã đặt hàng thành công!","ic_success.png","870.000 Vnđ","10 phút", false),
               new Notification("ic_tea.jpg","Trà thảo mộc Mikita","Bạn đã lên lịch thành công!","ic_clock.png","14.000 Vnđ/đơn","25 phút", false),
               new Notification("ic_fruit.jpg","Tin nhắn từ Shipper","Bạn ơi hôm nay mãng cầu hết hàng","ic_message.png","215.000 Vnđ/đơn","1 tiếng", true),
               new Notification("ic_shirt.png","Cuộc gọi nhỡ từ Shipper","","ic_call.png","580.000 Vnđ","1 tiếng", true),
               new Notification("ic_tea.jpg","Trà thảo mộc Mikita","Giao hàng thành công!","ic_shipping.png","14.000 Vnđ/đơn","10 phút", false)
            };
            Navigation = navigation;
            SwitchSearchPage = new Command(() =>
            {
                navigation.PushAsync(new SearchPage());
            });
            DeleteNotify = new Command((x) =>
            {
                var item = x as Notification;
                Notification n =  Notifications.First(z => z.Title == item.Title);
                Notifications.Remove(n);
            });
        }
        public Command SwitchSearchPage { get; }
        public Command DeleteNotify {get;}
    }
}
