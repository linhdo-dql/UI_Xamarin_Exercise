using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class StorePageViewModel
    {
        public List<StoreFavorite> StoreFavorites { get; set; } 

        public StorePageViewModel(Page page, INavigation navigation)
        {
            StoreFavorites = new List<StoreFavorite>()
            {
               new StoreFavorite("VinMart Định Công","ic_vinmart.png",4.5,"Ngõ 245, Định Công, Hoàng Mai, Hà Nội"),
               new StoreFavorite("Coco Mart","ic_m_coco.png",1.5,"Ngõ 210, Bạch Đằng, Hải Châu, Đà Nẵng"),
               new StoreFavorite("Joly Mart","ic_m_joly.jpg",2.5,"Số 6, Bạch Đằng, Hải Châu, Đà Nẵng"),
               new StoreFavorite("Vita Mart","ic_m_vita.png",1.5,"Số 62, Trần Quốc Toản, Hải Châu, Đà Nẵng"),
               new StoreFavorite("Danavi Mart","ic_m_danavi.jpg",2.5,"Số 6, Lê Đình Lý, Thanh Khê, Đà Nẵng")
            };
            SwitchHomePage = new Command(() =>
            {
                navigation.PushAsync(new MainAppPage());
            });
            SwitchStorePage = new Command(( x ) =>
            {
                var store = x as StoreFavorite;
                navigation.PushAsync(new ItemPage(store.NameStore, new ObservableCollection<ItemCart>()));
            });
            SwitchSearchPage = new Command(( x ) =>
            {
                navigation.PushAsync(new SearchPage());
            });
        }
        public Command SwitchHomePage { get; }
        public Command SwitchStorePage { get; }
        public Command SwitchSearchPage { get; }
    }
}
