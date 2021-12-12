using MUAHO.Models;
using MUAHO.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUAHO.Views.ChildPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotifyPage : StackLayout
    {
        public NotifyPage()
        {
            InitializeComponent();
            BindingContext = new NotifyPageViewModel(Navigation);
        }
    }
}