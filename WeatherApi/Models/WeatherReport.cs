using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Models
{
    public class WeatherReport
    {
        [Key]
        public string DATE { get; set; }

        public double TMAX { get; set; }

        public double TMIN { get; set; }
    }
}
