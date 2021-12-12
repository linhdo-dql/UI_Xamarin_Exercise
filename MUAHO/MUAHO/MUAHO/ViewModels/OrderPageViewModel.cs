using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class OrderPageViewModel
    {
        INavigation Navigation { get; set; }
        public OrderPageViewModel(INavigation navigation)
        {
            Navigation = navigation;
            SwitchDatePage = new Command(() =>
            {
                navigation.PushAsync(new DatePage(null));
            });
        }
        public Command SwitchDatePage { get;}
    }
}
