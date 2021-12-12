using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class MessagePageViewModel
    {
        INavigation Navigation { get; set; }
        public ObservableCollection<Notification> Messages { get; set; }
        public MessagePageViewModel( INavigation navigation )
        {
            this.Navigation = navigation;
            Messages = new ObservableCollection<Notification>()
            {
               new Notification("ic_vinmart.jpg","VinMart + Mikita Shop + M...","Bạn đã đặt hàng thành công!","ic_success.png","870.000 Vnđ","10 phút", true),
               new Notification("ic_tea.jpg","Trà thảo mộc Mikita","Bạn đã lên thành công!","ic_message.png","14.000 Vnđ/đơn","25 phút", false),
               new Notification("ic_fruit.jpg","Tin nhắn từ Shipper","Bạn ơi hôm nay mãng cầu hết hàng","ic_message.png","215.000 Vnđ/đơn","1 tiếng", true),
               new Notification("ic_tea.jpg","Trà thảo mộc Mikita","Giao hàng thành công!","ic_message.png","14.000 Vnđ/đơn","10 phút", true)
            };
            SwitchBeforePage = new Command(() =>
            {
                navigation.PopAsync();
            });
            SwitchSearchPage = new Command(() =>
            {
                navigation.PushAsync(new SearchPage());
            });
        }
        public Command SwitchBeforePage { get; }
        public Command SwitchSearchPage { get; }
    }
}
