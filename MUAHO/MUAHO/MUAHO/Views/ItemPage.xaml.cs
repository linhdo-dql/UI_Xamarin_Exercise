using MUAHO.Models;
using MUAHO.ViewModels;
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
    public partial class ItemPage : ContentPage
    {
        public ItemPage(string storeName, ObservableCollection<ItemCart> listCallback)
        {
            InitializeComponent();
            DisplayAlert("Tên cửa hàng: ", storeName, "ok");
            BindingContext = new ItemPageViewModel(this, Navigation, listCallback, storeName);
        }

        private void RadioButton_CheckedChanged( object sender, CheckedChangedEventArgs e )
        {
            Color color = e.Value ? Color.White : Color.FromHex("#929292");
            (sender as RadioButton).TextColor = color;
        }   
    }
}