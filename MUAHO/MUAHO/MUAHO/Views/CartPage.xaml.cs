using MUAHO.Models;
using MUAHO.ViewModels;
using Rg.Plugins.Popup.Extensions;
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
    public partial class CartPage : ContentPage
    {
        
        int itemPreviousIndex = 1;
        
        public CartPage(ObservableCollection<ItemCart> x, string storeName)
        {
            InitializeComponent();
            BindingContext = new CartPageViewModel(this, Navigation, x, storeName);
            
        }

        private void listItem_ItemAppearing( object sender, ItemVisibilityEventArgs e )
        {
            ObservableCollection<ItemCart> x = (ObservableCollection<ItemCart>) listItemInCart.ItemsSource;
            if ( x.Count > 3 )
            {
                if ( e.ItemIndex > itemPreviousIndex )
                {
                    // Hide the layout here
                    bigFrame.IsVisible = false;
                    smallFrame.IsVisible = false;
                }
                else
                {
                    bigFrame.IsVisible = true;
                    smallFrame.IsVisible = true;
                }
                itemPreviousIndex = e.ItemIndex;
            }
            else
            {
                bigFrame.IsVisible = true;
                smallFrame.IsVisible = true;
            }

        }


        private void ImageButton_Clicked( object sender, EventArgs e )
        {
            ImageButton button = sender as ImageButton;
            if( int.Parse(button.StyleId) == 0)
            {
                button.Source = "ic_check.png";
                
                button.StyleId = "1";
            }    
            else
            {
                button.Source = "ic_uncheck.png";
                
                button.StyleId = "0";
            }
            
        }
    }
}