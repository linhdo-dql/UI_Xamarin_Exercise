using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MUAHO.Droid;
using MUAHO.Views.CustomView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(CustomTimePickerAndroid))]
namespace MUAHO.Droid
{

    public class CustomTimePickerAndroid : TimePickerRenderer
    {
        protected override void OnElementChanged( ElementChangedEventArgs<Xamarin.Forms.TimePicker> e )
        {
            base.OnElementChanged(e);
            var gd = new GradientDrawable();
            gd.SetStroke(0, Android.Graphics.Color.Transparent);
            Control.SetBackground(gd);
        }
    }
}