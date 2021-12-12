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
#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerAndroid))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace MUAHO.Droid
{
    [Obsolete]
    public class CustomPickerAndroid : PickerRenderer
    {
        protected override void OnElementChanged( ElementChangedEventArgs<Xamarin.Forms.Picker> e )
        {
            base.OnElementChanged(e);
            var gd = new GradientDrawable();
            gd.SetStroke(0, Android.Graphics.Color.Transparent);
            Control.SetBackground(gd);
        }
    }
}