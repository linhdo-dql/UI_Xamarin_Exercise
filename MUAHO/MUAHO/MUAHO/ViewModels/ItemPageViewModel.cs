using MUAHO.Models;
using MUAHO.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
   
    public class ItemPageViewModel : BaseViewModel
    {
        private string _total;
        private int _totalMoney;
        private int _totalItem;
        INavigation navigation { get; set; }
        private List<string> _typeitems = new List<string>();
       
        public ItemPageViewModel(Page page, INavigation navigation, ObservableCollection<ItemCart> listCallBack, string storeName)
        {
            
            Total = "1 cửa hàng, 0 đơn vị, 0 sản phẩm";
            ItemCarts = new ObservableCollection<ItemCart>()
                {
                new ItemCart() {ImageItem = "ic_c_beef.png", PriceItem="290k/kg", NameItem="Bò lạc Mỹ", AmountItem =0, IsSkip = false},
                new ItemCart() {ImageItem = "ic_c_salad.png", PriceItem="6k/lạng", NameItem="Xà lách tươi", AmountItem =0, IsSkip = false},
                new ItemCart() {ImageItem = "ic_c_shark.png", PriceItem="140k/kg", NameItem="Cá mập tươi", AmountItem =0, IsSkip = false},
                new ItemCart() {ImageItem = "ic_c_carrot.png", PriceItem="14k/kg", NameItem="Cà rốt", AmountItem =0, IsSkip = false},
                new ItemCart() {ImageItem = "ic_c_beef.png", PriceItem="290k/kg", NameItem="Bò lạc Mỹ2", AmountItem =0, IsSkip = false},
                new ItemCart() {ImageItem = "ic_c_salad.png", PriceItem="6k/lạng", NameItem="Xà lách tươi2", AmountItem =0, IsSkip = false},
                new ItemCart() {ImageItem = "ic_c_shark.png", PriceItem="140k/kg", NameItem="Cá mập tươi2", AmountItem =0, IsSkip = false},
                new ItemCart() {ImageItem = "ic_c_carrot.png", PriceItem="14k/kg", NameItem="Cà rốt2", AmountItem =0, IsSkip = false}
                };
            if (listCallBack.Count != 0)
            {
                 foreach(ItemCart cart in ItemCarts)
                {
                    foreach(ItemCart cartCallBack in listCallBack)
                    {
                        if(cart.NameItem == cartCallBack.NameItem)
                        {
                            cart.AmountItem = cartCallBack.AmountItem;
                            cart.IsLayoutAmountVisible = true;
                            cart.IsBtnPlusVisible = false;
                            cart.BackgroundColor = "#40F2985A";
                        }
                    }
                }
                int b = listCallBack.Count(x => x.AmountItem != 0);
                TotalMoney = ItemCarts.Sum(z => z.Total);
                TotalItem = ItemCarts.Sum(z => z.AmountItem);
                Total = "1 cửa hàng, " + TotalItem + " đơn vị, " + b + " sản phẩm.";
            } 
            
            
            TotalMoney = ItemCarts.Sum(z => z.Total);
            UpAmount = new Command(( x ) =>
            {
                
                var item = (x as ItemCart);
                item.AmountItem++;
                string name = item.NameItem;
                TotalItem = ItemCarts.Sum(z => z.AmountItem);
                if (!_typeitems.Contains(name)){
                    _typeitems.Add(name);
                }
                Total = "1 cửa hàng, " + _totalItem + " đơn vị, " + _typeitems.Count + " sản phẩm.";
                TotalMoney = ItemCarts.Sum(z => z.Total);
                
            });
            DownAmount = new Command(( x ) =>
            {
                var item = (x as ItemCart);
                item.AmountItem--;
                TotalItem = ItemCarts.Sum(z => z.AmountItem);
                if ( item.AmountItem -1 < 0 ) {
                    TotalItem = ItemCarts.Sum(z => z.AmountItem);
                    item.BackgroundColor = "#0E929292";
                    TotalMoney = ItemCarts.Sum(z => z.Total);
                    
                    if (TotalMoney < 0) { TotalMoney = TotalMoney + Convert.ToInt32(StandardPrice(item.PriceItem)) * 1000; TotalItem++; }
                    item.AmountItem = 0;
                    string name = item.NameItem;
                    if ( _typeitems.Contains(name) )
                    {
                        _typeitems.Remove(name);
                    }
                    item.IsBtnPlusVisible = true;
                    item.IsLayoutAmountVisible = false ;
                    Total = "1 cửa hàng, " + _totalItem + " đơn vị, " + _typeitems.Count + " sản phẩm.";
                    return;
                }
                
                
                Total = "1 cửa hàng, " + _totalItem + " đơn vị, " + _typeitems.Count + " sản phẩm.";
                TotalMoney -= (Convert.ToInt32(StandardPrice(item.PriceItem)) * 1000);
               
                    
               
                //og..Write(item.AmountItem);
            });
          
            SwitchBackPage = new Command(() =>
            {
                navigation.PushAsync(new StorePage());
            });
            SwitchSearchPage = new Command(() =>
            {
                navigation.PushAsync(new SearchPage());
            });
            SwitchMyCartPage = new Command(() =>
            {
                List<ItemCart> list = new List<ItemCart>(ItemCarts);
                list.RemoveAll(( item ) => item.AmountItem == 0);
                foreach(var item in list)
                {
                    item.IsSkip = true;
                    item.Opacity = 0.6;
                }
                ObservableCollection<ItemCart> myCarts = new ObservableCollection<ItemCart>(list);
                navigation.PushAsync(new CartPage(myCarts, storeName));
            });
            ShowLayoutAmount = new Command((x) =>
            {
                var item = x as ItemCart;
    
                item.IsLayoutAmountVisible = true;
                item.IsBtnPlusVisible = false;
                item.BackgroundColor = "#40F2985A";
                item.AmountItem++;
                string name = item.NameItem;
                TotalItem = ItemCarts.Sum(z => z.AmountItem);
                if ( !_typeitems.Contains(name) )
                {
                    _typeitems.Add(name);
                }
                Total = "1 cửa hàng, " + _totalItem + " đơn vị, " + _typeitems.Count + " sản phẩm.";
                TotalMoney += (Convert.ToInt32(StandardPrice(item.PriceItem)) * 1000);
            });
           

        }

        public ObservableCollection<ItemCart> ItemCarts { get; set; }
        public string Total
        {
            get
            {
                return _total;
            }
            set
            {
                SetProperty(ref _total, value);
            }
        } 
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
        public int TotalItem
        {
            get
            {
                return _totalItem;
            }
            set
            {
                SetProperty(ref _totalItem, value);
            }
        }
        public string StandardPrice( string price )
        {
            return price.Substring(0, price.IndexOf('k'));
        }


        public Command UpAmount { get; }
        public Command DownAmount { get; }
        public Command SwitchBackPage { get; }
        public Command SwitchSearchPage { get; }
        public Command SwitchMyCartPage { get; }
        public Command ShowLayoutAmount { get; }
    }
}
