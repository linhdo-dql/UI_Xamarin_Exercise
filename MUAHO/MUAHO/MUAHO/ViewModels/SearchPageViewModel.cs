using MUAHO.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class SearchPageViewModel : BaseViewModel
    {
        public ObservableCollection<StoreFavorite> StoreFavorites { get; set; }
        public INavigation Navigation { get; set; }
        public SearchPageViewModel(INavigation navigation)
        {
            StoreFavorites = new ObservableCollection<StoreFavorite>()
            {
               new StoreFavorite("VinMart Định Công","ic_vinmart.png",4.5,"Ngõ 245, Định Công, Hoàng Mai, Hà Nội"),
                new StoreFavorite("Coco Mart","ic_m_coco.png",1.5,"Ngõ 210, Bạch Đằng, Hải Châu, Đà Nẵng"),
                 new StoreFavorite("Joly Mart","ic_m_joly.jpg",2.5,"Số 6, Bạch Đằng, Hải Châu, Đà Nẵng"),
                 new StoreFavorite("Vita Mart","ic_m_vita.png",1.5,"Số 62, Trần Quốc Toản, Hải Châu, Đà Nẵng")

            };
            SwitchBeforePage = new Command(() =>
            {
                navigation.PopAsync();
            });
        }
        public Command SwitchBeforePage { get; }
    }
}
