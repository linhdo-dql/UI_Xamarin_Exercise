using MUAHO.Models;
using MUAHO.Views;
using MUAHO.Views.CartChildPage;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels.CartChildViewModel
{
    public class InCartViewModel : BaseViewModel
    {
        INavigation Navigation { get; set; }
        private int _totalMoney;
        
        public ObservableCollection<ItemCart> ItemInMyCarts { get; set; }
        public InCartViewModel( Page page, INavigation navigation, ObservableCollection<ItemCart> s)
        {
            ItemInMyCarts = new ObservableCollection<ItemCart>()
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
            Navigation = navigation;
            if(ItemInMyCarts.Count!=0)
            {
                TotalMoney = GetTotalMoney();
            }
            page.FindByName<StackLayout>("MainContentPage").Children.Clear();
            page.FindByName<StackLayout>("MainContentPage").Children.Add(new InCartPage());
            SwitchBeforePage = new Command(() =>
            {
                navigation.PushAsync(new MainAppPage());
            });
            AddAmount = new Command((x) =>
            {
                var item = (x as ItemCart);
                item.AmountItem++;
                TotalMoney = GetTotalMoney();
            });
            SubAmount = new Command((x) =>
            {
                var item = (x as ItemCart);
                if(item.AmountItem-1>=0)
                {
                    item.AmountItem--;
                    TotalMoney = GetTotalMoney();
                }
                else
                {
                    ItemInMyCarts.Remove(item);
                }
                
            });
            
        }

        private void Button_CheckedChanged( object sender, CheckedChangedEventArgs e )
        {
            RadioButton button = sender as RadioButton;
            Color color = e.Value ? Color.White : Color.FromHex("#929292");
            button.TextColor = color;

        }

        public Command SwitchBeforePage { get; }
        public Command AddAmount { get; }                       
        public Command SubAmount { get; }
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
        public Command CheckedCommand { get; }
        public int GetTotalMoney() => ItemInMyCarts.Sum(x => x.Total);
        public string StandardPrice( string price )
        {
            return price.Substring(0, price.IndexOf('k'));
        }
        
    }
}
