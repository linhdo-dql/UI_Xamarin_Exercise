using MUAHO.Models;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUAHO.Views.CartChildPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InCartPage : AbsoluteLayout
    {
        int itemPreviousIndex = 0;
        
        public InCartPage()
        {
            InitializeComponent();
        }

        private void listItemInCart_ItemAppearing( object sender, ItemVisibilityEventArgs e )
        {
            if ( e.ItemIndex > itemPreviousIndex )
            {
               
                (this.FindByName<Frame>("bigFrame") as Frame).IsVisible = false;
                (this.FindByName<Frame>("smallFrame") as Frame).IsVisible = false;
            }
            else
            {
                (this.FindByName<Frame>("bigFrame") as Frame).IsVisible = true;
                (this.FindByName<Frame>("smallFrame") as Frame).IsVisible = true;
            }
            itemPreviousIndex = e.ItemIndex;
        }
        private void ImageButton_Clicked( object sender, EventArgs e )
        {
            ImageButton button = sender as ImageButton;
            if ( int.Parse(button.StyleId) == 0 )
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
        private async void TapGestureRecognizer_Tapped( object sender, EventArgs e )
        {
            await Navigation.PushPopupAsync(new PopupPage());
        }
    }
}