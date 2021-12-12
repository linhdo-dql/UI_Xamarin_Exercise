using MUAHO.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.ViewModels
{
    public class ShippingViewModel
    {
        INavigation Navigation { get; set; }
        public List<Order> Orders { get; set; }
    public ShippingViewModel( INavigation navigation)
        {
            Navigation = navigation;
            Orders = new List<Order>
            {
                new Order() { IdOrder = 1, NameOrder = "Vinmart, Cocomart, Neostyle Boutique", InfoOrder = "3 cửa hàng - 8 đơn vị - 4 sản phẩm", TotalMoney = "1.500.000 Vnd"},
                new Order() { IdOrder = 2, NameOrder = "Phi Long, Shin mart", InfoOrder = "2 cửa hàng - 2 đơn vị - 2 sản phẩm", TotalMoney = "820.000 Vnd"},
                new Order() { IdOrder = 3, NameOrder = "Nino max, Linh My boutique, Vinmart, Cocomart, Neostyle Boutique", InfoOrder = "5 cửa hàng - 9 đơn vị - 9 sản phẩm", TotalMoney = "12.560.000 Vnd"}
            };
        }
    }
}
