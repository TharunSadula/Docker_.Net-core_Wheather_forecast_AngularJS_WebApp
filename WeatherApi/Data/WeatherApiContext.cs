using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Models;

namespace WeatherApi.Data
{
    public class WeatherApiContext : DbContext
    {
        public WeatherApiContext(DbContextOptions<WeatherApiContext> options)
            : base(options)
        {
        }
        public DbSet<WeatherReport> dailyWeather { get; set; }

    }
}
