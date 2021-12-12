using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace MUAHO.Behavior
{
    public class SearchValidateBehavior : Behavior<Entry>

    {
        protected override void OnAttachedTo( Entry bindable )
        {
            bindable.TextChanged += Entry_TextChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom( Entry bindable )
        {
            bindable.TextChanged -= Entry_TextChanged;
            base.OnDetachingFrom(bindable);
        }

        private static void Entry_TextChanged( object sender, TextChangedEventArgs e )
        {
            bool isValid = Regex.IsMatch(e.NewTextValue,"[a-zA-Z]",RegexOptions.RightToLeft,TimeSpan.FromMilliseconds(100));
            (sender as Entry).TextColor = isValid ? Color.Black : Color.Red;
        }
    }
}
