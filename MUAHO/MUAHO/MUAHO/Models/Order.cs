using System;
using System.Collections.Generic;
using System.Text;

namespace MUAHO.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string NameOrder { get; set; }
        public string InfoOrder { get; set; }
        public string TotalMoney { get; set; }
        public string FromOrder { get; set; }
        public string ToOrder { get; set; }
    }
}
