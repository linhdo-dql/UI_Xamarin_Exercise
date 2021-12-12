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
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
            btnStartWelcomePage.Clicked += BtnStartWelcomePage_Clicked;
        }

        private void BtnStartWelcomePage_Clicked( object sender, EventArgs e )
        {
          Navigation.PushAsync(new LoginPage());
        }
    }
}