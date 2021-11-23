using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirRestService.Models
{
    public class Air
    {
        [Key]
        public int ID { get; set; }
        public string Temperature { get; set; }
        public string CO2 { get; set; }
        public string Humidity { get; set; }

        public Air(string temp, string co2, string humidity)
        {
            Temperature = temp;
            CO2 = co2;
            Humidity = humidity;
        }
        public Air()
        {

        }
    }
}
