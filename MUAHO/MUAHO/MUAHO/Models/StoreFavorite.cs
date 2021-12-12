using System;
using System.Collections.Generic;
using System.Text;

namespace MUAHO.Models
{
    public class StoreFavorite
    {
        public string NameStore { get; set; }
        public string ImageStore { get; set; }
        public double RatingStore { get; set; }
        public string AdressStore { get; set; }

        public StoreFavorite( string nameStore, string imageStore, double ratingStore, string adressStore )
        {
            NameStore = nameStore;
            ImageStore = imageStore;
            RatingStore = ratingStore;
            AdressStore = adressStore;
        }
    }
}
