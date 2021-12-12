using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MUAHO.Models
{
    public class Notification
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageType { get; set; }
        public string Price { get; set; }
        public string Time { get; set; }
        public bool Seen { get; set; }

        public Notification( string image, string title, string description, string imageType, string price, string time, bool seen )
        {
            Image = image;
            Title = title;
            Description = description;
            ImageType = imageType;
            Price = price;
            Time = time;
            Seen = seen;
        }

        public string Color
        {
            get
            {
                return Seen ? "#F6EADF" : "#FFFFFF";
            }
        }
    }
}
