using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class HomePageViewModel : INotifyPropertyChanged
    {
        INavigation navigation { get; set; }
        public ObservableCollection<Banner> Banners { get; set; }
        public ObservableCollection<ItemCart> ItemInMyCarts { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public HomePageViewModel( INavigation navigation)
        {     
            this.navigation = navigation;
            ItemInMyCarts = new ObservableCollection<ItemCart>();
            Banners = new ObservableCollection<Banner>()
            {
                 new Banner() {Title = "Càng mua, càng giảm", SubTitle = "Vinmart Lê Thanh Nghị, Hai Bà Trưng, Hà Nội", Image="ic_sea.jpg"},
                 new Banner() {Title = "Rau quả siêu sạch", SubTitle = "Vinmart Định Công, Hai Bà Trưng, Hà Nội", Image="ic_fruit.jpg"},
                 new Banner() {Title = "Nắm bắt xu thế", SubTitle = "AppleStore, Lạc Long Quân, Tây Hồ, Hà Nội", Image="ic_iphone.jpg"}
            };
            SwitchSearchPage = new Command(() =>
            {
                navigation.PushAsync(new SearchPage()); 
            });
            SwitchCartPage = new Command(() =>
            {
                navigation.PushAsync(new MyCartPage(ItemInMyCarts));
            });
            SwitchALlStorePage = new Command(() =>
            {
                navigation.PushAsync(new StorePage());
            });
            SwitchProfilePage = new Command(() =>
            {
                navigation.PushAsync(new ProfilePage());
            });    
        }
        public Command SwitchSearchPage { get; } 
        public Command SwitchCartPage { get; }
        public Command SwitchALlStorePage { get; }
        public Command SwitchProfilePage { get; }
        public void OnPropertyChanged( [CallerMemberName] string name = "" )
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
