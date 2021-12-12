using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MUAHO.Plugins
{
    [ContentProperty(nameof(Source))]
    public class ImageEmbedResource : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue( IServiceProvider serviceProvider )
        {

            if ( Source == null )
            {
                return null;
            }
            var imgSource = ImageSource.FromResource(Source, typeof(ImageEmbedResource).GetTypeInfo());
            return imgSource;
        }
    }
}
