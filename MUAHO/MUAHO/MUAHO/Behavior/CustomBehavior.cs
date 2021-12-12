using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.Behavior
{
    public class CustomBehavior : Behavior<View>
    {
        protected override void OnAttachedTo( View bindable )
        {
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom( View bindable )
        {
            base.OnDetachingFrom(bindable);
        }
    }
}
