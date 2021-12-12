using Android.Graphics.Drawables;
using MUAHO.Droid;
using MUAHO.Views.CustomView;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
#pragma warning disable CS0612 // Type or member is obsolete
[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorAndroid))]
#pragma warning restore CS0612 // Type or member is obsolete
namespace MUAHO.Droid
{
    public class CustomEditorAndroid : EditorRenderer
    {
        protected override void OnElementChanged( ElementChangedEventArgs<Editor> e )
        {
            base.OnElementChanged(e);
            if ( Control != null )
            {
                GradientDrawable gd = new GradientDrawable();

                gd.SetColor(Android.Graphics.Color.Transparent);
                this.Control.SetBackground(gd);
                this.Control.SetPadding(20, 0, 0, 0);

            }
        }
    }
}