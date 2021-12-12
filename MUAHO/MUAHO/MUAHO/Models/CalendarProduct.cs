using System;
using System.Collections.Generic;
using System.Text;

namespace MUAHO.Models
{
    public class CalendarProduct
    {
        public string Image { get; set; }
        public string NameProduct { get; set; }
        public string Price { get; set; }
        public string Note { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Schedule { get; set; }
        public string ScheduleDay { get; set; }

        public CalendarProduct( string image, string nameProduct, string price, string note, string date, string time, string schedule, string scheduleDay )
        {
            this.Image = image;
            NameProduct = nameProduct;
            Price = price;
            Note = note;
            Date = date;
            Time = time;
            Schedule = schedule;
            ScheduleDay = scheduleDay;
        }
        public override string ToString()
        {
            return "[Product]" +
                " Image " + Image +
                " Price " + Price +
                " Note " + Note +
                " Date " + Date +
                " Time " + Time +
                " Schedule " + Schedule +
                " ScheduleDay " + ScheduleDay;
              
                
        }
    }
}
