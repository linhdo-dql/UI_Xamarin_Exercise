using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;

namespace MUAHO.ViewModels
{
    public class CartPageViewModel : BaseViewModel
    {
        INavigation Navigation { get; set; }
        private int _totalMoney;
        public ObservableCollection<ItemCart> ItemInMyCarts { get; set; }
        public CartPageViewModel( Page page, INavigation navigation, ObservableCollection<ItemCart> s, string storeName )
        {
            Navigation = navigation;
            ItemInMyCarts = new ObservableCollection<ItemCart>(s);
            page.FindByName<ListView>("listItemInCart").ItemsSource = ItemInMyCarts;
            if ( ItemInMyCarts.Count != 0 )
            {
                TotalMoney = GetTotalMoney();
            }
           
            SwitchBeforePage = new Command(() =>
            {
                navigation.PushAsync(new ItemPage(storeName,ItemInMyCarts));
            });
            SkipItem = new Command((x) =>
            {
                var item = x as ItemCart;
                if ( item.IsSkip )
                {
                    item.IsSkip = false;
                    item.Opacity = 1;
                    TotalMoney = GetTotalMoney();
                }
                else
                {
                    item.IsSkip = true;
                    item.Opacity = 0.6;
                    TotalMoney = GetTotalMoney();
                }  
            });
            AddAmount = new Command(( x ) =>
            {
                var item = (x as ItemCart);
                if(!item.IsSkip)
                {
                    item.AmountItem++;
                    TotalMoney = GetTotalMoney();
                }  
            });
            SubAmount = new Command(( x ) =>
            {
                var item = (x as ItemCart);
                if(!item.IsSkip)
                {
                    if ( item.AmountItem - 1 > 0 )
                    {
                        item.AmountItem--;
                        TotalMoney = GetTotalMoney();
                    }
                    else
                    {
                        item.AmountItem--;
                        TotalMoney = GetTotalMoney();
                        ItemInMyCarts.Remove(item);
                    }
                }
            });
            DeleteItem = new Command((x) =>
            {
                var item = (x as ItemCart);
                if(!item.IsSkip)
                {
                  ItemInMyCarts.Remove(item);
                  TotalMoney = GetTotalMoney();
                }
                
            });
            CheckOutSuccess = new Command(() =>
            {
                navigation.PushPopupAsync(new PopupPage());
            });
            SwitchSearchPage = new Command(() =>
            {
                navigation.PushAsync(new SearchPage());
            });
            SwitchDatePage = new Command(( x ) =>
            {
                var item = x as ItemCart;
                navigation.PushAsync(new DatePage(item));
            });
        }
        public Command SwitchBeforePage { get; }
        public Command SkipItem { get; }
        public Command AddAmount { get; }
        public Command SubAmount { get; }
        public Command DeleteItem { get; }
        public Command CheckOutSuccess { get; }
        public Command SwitchSearchPage { get; }
        public Command SwitchDatePage { get; }
        
        public int TotalMoney
        {
            get
            {
                return _totalMoney;
            }
            set
            {
                SetProperty(ref _totalMoney, value);
            }
        }

        public int GetTotalMoney() => ItemInMyCarts.Where(x => x.IsSkip == false).Sum(x => x.Total);
        public string StandardPrice( string price )
        {
            return price.Substring(0, price.IndexOf('k'));
        }
        
        
    }
}
