using AirLibrary;
using System;

namespace AirRestService.Data
{
    public class Average
    {
        public int ID { get; set; }
        public double CO2 { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public DateTime TimeStamp { get; set; }
        public type Type  { get; set; }
        public Average(Average.type type, double co2, double temp, double hum, DateTime time)
        {
            Type = type;
            CO2 = co2;
            Temperature = temp;
            Humidity = hum;
            TimeStamp = time;
        }
        public Average() { }

        public enum type
        {
            today, yesterday, lastweek, lastmonth
        }
    }
}
