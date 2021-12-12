using MUAHO.Models;
using MUAHO.ViewModels;
using MUAHO.ViewModels.CartChildViewModel;
using MUAHO.Views.CartChildPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUAHO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyCartPage : ContentPage
    {
        private InCartViewModel _inCartViewModel;
        private ShippedViewModel _shippedPageViewModel;
        private ShippingViewModel _shippingPageViewModel;
        
        public MyCartPage(ObservableCollection<ItemCart> x)
        {
            InitializeComponent();
            _inCartViewModel = new InCartViewModel(this, Navigation, x);
            _shippedPageViewModel = new ShippedViewModel();
            _shippingPageViewModel = new ShippingViewModel(Navigation);
            BindingContext = _inCartViewModel;
        }

        private void CheckedChanged( object sender, CheckedChangedEventArgs e )
        {
            RadioButton button = sender as RadioButton;
            Color color = e.Value ? Color.White : Color.FromHex("#929292");
            button.TextColor = color;
            if ( button == this.FindByName<RadioButton>("inCart") )
            {
                MainContentPage.Children.Clear();
                MainContentPage.Children.Add(new InCartPage());
                BindingContext = _inCartViewModel;
               
            }
            else if ( button == this.FindByName<RadioButton>("shipping") )
            {
                MainContentPage.Children.Clear();
                MainContentPage.Children.Add(new ShippingPage());
                BindingContext = _shippingPageViewModel;
            }
            else if ( button == this.FindByName<RadioButton>("shipped") )
            {
                MainContentPage.Children.Clear();
                MainContentPage.Children.Add(new ShippedPage());
                BindingContext = _shippedPageViewModel;
            }

        }
        

    }
}