using MUAHO.Models;
using MUAHO.ViewModels.MainAppPageViewModel;
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
    public partial class CalendarPage : StackLayout
    {
        public CalendarPage()
        {
            InitializeComponent();
            BindingContext = new CalendarPageViewModel(Navigation);

        }

    }
}