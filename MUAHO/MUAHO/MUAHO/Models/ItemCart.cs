using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MUAHO.Models
{
    public class ItemCart : BaseViewModel
    {
        public string ImageItem { get; set; }
        public string NameItem { get; set; }
        public string PriceItem { get; set; }
        private int _amountItem;
        private int _total;
        private bool _isBtnPlusVisible = true;
        private bool _isLayoutAmountVisible = false;
        private bool _isSkip;
        private double _opacity = 1;
        private string _backgroundColor = "#0E929292";
        
        public int AmountItem
        {

            get { return _amountItem; } 
            set
            {
               SetProperty(ref _amountItem, value);
               Total = AmountItem * Convert.ToInt32(StandardPrice(PriceItem)) * 1000;
            }
        }
        public bool IsBtnPlusVisible
        {
            get
            {
                return _isBtnPlusVisible;
            }
            set
            {
                SetProperty(ref _isBtnPlusVisible, value);
            }
        }
        public bool IsLayoutAmountVisible
        {
            get
            {
                return _isLayoutAmountVisible;
            }
            set
            {
                SetProperty(ref _isLayoutAmountVisible, value);
            }
        }
        public int Total
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
        public string StandardPrice( string price)
        {
            return price.Substring(0, price.IndexOf('k'));
        }

        public bool IsSkip
        {
            get
            {
                return _isSkip;
            }
            set
            {
                SetProperty(ref _isSkip, value);
            }
        }

        public double Opacity
        {
            get
            {
                return _opacity;
            }
            set
            {
                SetProperty(ref _opacity, value);
            }
        }
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }
            set
            {
                SetProperty(ref _backgroundColor, value);
            }
        }
       
    }
}
