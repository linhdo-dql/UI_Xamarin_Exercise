using MUAHO.Views;
using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly:ExportFont("OpenSans-Bold.ttf", Alias = "FontBold")]
[assembly: ExportFont("OpenSans-Regular.ttf", Alias = "FontRegular")]
[assembly: ExportFont("OpenSans-SemiBold.ttf", Alias = "FontSemiBold")]
namespace MUAHO
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage( new SplashScreen());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
