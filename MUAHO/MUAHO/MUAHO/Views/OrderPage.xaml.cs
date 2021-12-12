using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUAHO.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderPage : ContentPage
    {
        bool[] y = { true, false, true, false, false, false, false }; 
        string[] x = { "22/12/2022", "21/12/2021", "12/02/2012", "02/11/2011", "01/01/2001", "02/11/2011", "02/02/2011" };
        public OrderPage(string title,bool[] x, string[] y)
        {
            InitializeComponent();
            DisplayAlert("Title", title, "ok");
            LoadRadioButton();
            LoadGridDay();
           
        }

        private void ScrollView_Scrolled( object sender, ScrolledEventArgs e )
        {
            if ( e.ScrollY < 30 )
            {
                layoutButton.IsVisible = true;
            }
            else
            {
                layoutButton.IsVisible = false;
            }
        }

        private void OnCheckedChange( object sender, CheckedChangedEventArgs e )
        {
            Color color = e.Value ? Color.White : Color.FromHex("#929292");
            (sender as RadioButton).TextColor = color;           
        }

        private void LoadRadioButton()
        {
            string[] nameRadio = { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            for(int i = 0 ; i< nameRadio.Length-1 ; i++)
            {
                (this.FindByName<RadioButton>(nameRadio[i]) as RadioButton).IsChecked = y[i];
            }    
        }
        private void LoadGridDay()
        {
            gridDay.Children.Clear();
            int dem = 0;
            for ( int i = 0 ; i < 2 ; i++ )
            {
                for ( int j = 0 ; j < x.Length / 2 ; j++ )
                {
                    Frame f = new Frame()
                    {
                        Padding = new Thickness(0),
                        BackgroundColor = Color.FromHex("#F2985a"),
                        CornerRadius = 10,
                        HeightRequest = 40,
                        Content = new StackLayout()
                        {
                            Padding = new Thickness(10, 0, 10, 0),
                            WidthRequest = 130,
                            Orientation = StackOrientation.Horizontal,
                            Children =
                            {
                                new Label()
                                {
                                    Text = x[dem],
                                    VerticalOptions = LayoutOptions.Center,
                                    TextColor = Color.White,
                                    HorizontalOptions = LayoutOptions.StartAndExpand
                                },
                                new Image()
                                {
                                    Source = "ic_calendar2.png",
                                    WidthRequest = 30,
                                    HeightRequest = 30,
                                    HorizontalOptions = LayoutOptions.End
                                }
                            }

                        }
                    };
                    gridDay.Children.Add(f, i, j);
                    dem++;
                }
            }
            if ( x.Length / 2 != 0 )
            {
                gridDay.Children.Add(new Frame()
                {
                    Padding = new Thickness(0),
                    BackgroundColor = Color.FromHex("#F2985a"),
                    CornerRadius = 10,
                    HeightRequest = 40,
                    Content = new StackLayout()
                    {
                        Padding = new Thickness(10, 0, 10, 0),
                        WidthRequest = 130,
                        Orientation = StackOrientation.Horizontal,
                        Children =
                        {
                            new Label()
                            {
                                Text = x[x.Length-1],
                                VerticalOptions = LayoutOptions.Center,
                                TextColor = Color.White,
                                HorizontalOptions = LayoutOptions.StartAndExpand
                            },
                            new Image()
                            {
                                Source = "ic_calendar2.png",
                                WidthRequest = 30,
                                HeightRequest = 30,
                                HorizontalOptions = LayoutOptions.End
                            }
                        }

                    }
                }, 0, x.Length / 2);
            }
        }
        
    }
}                                      