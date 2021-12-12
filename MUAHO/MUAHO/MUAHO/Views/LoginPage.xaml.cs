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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
           
            
        }

        

        private void TapGestureRecognizer_Tapped( object sender, EventArgs e )
        {
           
        }

        private void TapGestureRecognizer_Tapped_1( object sender, EventArgs e )
        {
            Navigation.PushAsync(new MainAppPage());
        }
    }
}