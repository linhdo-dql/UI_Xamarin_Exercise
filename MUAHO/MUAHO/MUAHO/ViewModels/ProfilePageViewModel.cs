using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class ProfilePageViewModel
    {
        public ObservableCollection<StoreFavorite> StoreFavorites { get;  set; }
        public ObservableCollection<MyVoucher> MyVouchers { get; set; }

        public ProfilePageViewModel( INavigation navigation )
        {
            StoreFavorites = new ObservableCollection<StoreFavorite>()
            {
               new StoreFavorite("VinMart Định Công","ic_vinmart.png",4.5,"Ngõ 245, Định Công, Hoàng Mai, Hà Nội"),
                new StoreFavorite("Coco Mart","ic_m_coco.png",1.5,"Ngõ 210, Bạch Đằng, Hải Châu, Đà Nẵng"),
                 new StoreFavorite("Joly Mart","ic_m_joly.jpg",2.5,"Số 6, Bạch Đằng, Hải Châu, Đà Nẵng"),
                 new StoreFavorite("Vita Mart","ic_m_vita.png",1.5,"Số 62, Trần Quốc Toản, Hải Châu, Đà Nẵng"),
                 new StoreFavorite("Danavi Mart","ic_m_danavi.jpg",2.5,"Số 6, Lê Đình Lý, Thanh Khê, Đà Nẵng"),

            };
            MyVouchers = new ObservableCollection<MyVoucher>()
            {
                new MyVoucher() {ImageBrand = "ic_vinmart.png", Date = "02/10/2021", NameBrand="VinMart", NameVoucher="Mua nhiều, Tặng nhiều"},
                                new MyVoucher() {ImageBrand = "ic_m_coco.png", Date = "12/10/2021", NameBrand="Coco Mart", NameVoucher="Sale sốc, Đầu đông"},
                                                new MyVoucher() {ImageBrand = "ic_m_vita.png", Date = "02/11/2021", NameBrand="Vita Mart", NameVoucher="Quà tặng giáng sinh"}


            };
            SwitchBeforePage = new Command(() =>
            {
                navigation.PopAsync();
            });
            SwitchMessagePage = new Command(() =>
            {
                navigation.PushAsync(new MessagePage());
            });
        }
        public Command SwitchBeforePage { get; }
        public Command SwitchMessagePage { get; }
        
    }
}
