using Android.App;
using MUAHO.Views.ChildPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUAHO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    [Application(HardwareAccelerated = true, LargeHeap = true)]
    public partial class MainAppPage : ContentPage
    {
        public MainAppPage()
        {
            InitializeComponent();
            mainAppPage.Children.Add(new HomePage());
            iHome.Source = "ic_store2.png";
        }

       

        private void iHome_Tapped( object sender, EventArgs e )
        {
            mainAppPage.Children.Clear();
            iHome.Source = "ic_store2.png";
            iCalendar.Source = "ic_calendar1.png";
            iNotify.Source = "ic_bell1.png";
            iSetting.Source = "ic_setting1.png";
            mainAppPage.Children.Add(new HomePage());
        }
        private void iCalendar_Tapped( object sender, EventArgs e )
        {
            mainAppPage.Children.Clear();
            iHome.Source = "ic_store.png";
            iCalendar.Source = "ic_calendar2.png";
            iNotify.Source = "ic_bell1.png";
            iSetting.Source = "ic_setting1.png";
            mainAppPage.Children.Add(new CalendarPage());
        }
        private void iNotify_Tapped( object sender, EventArgs e )
        {
            mainAppPage.Children.Clear();
            iHome.Source = "ic_store.png";
            iCalendar.Source = "ic_calendar1.png";
            iNotify.Source = "ic_bell2.png";
            iSetting.Source = "ic_setting1.png";
            mainAppPage.Children.Add(new NotifyPage());
        }
        private void iSetting_Tapped( object sender, EventArgs e )
        {
            mainAppPage.Children.Clear();
            iHome.Source = "ic_store.png";
            iCalendar.Source = "ic_calendar1.png";
            iNotify.Source = "ic_bell1.png";
            iSetting.Source = "ic_setting2.png";
            mainAppPage.Children.Add(new SettingPage());
        }
    }
}