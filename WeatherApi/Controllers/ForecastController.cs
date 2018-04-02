using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherApi.Data;
using WeatherApi.Models;
using WeatherApi.Helpers;

namespace WeatherApi.Controllers
{
    [Produces("application/json")]
    [Route("forecast")]
    public class ForecastController : Controller
    {
        private readonly WeatherApiContext _context;

        public ForecastController(WeatherApiContext context)
        {
            _context = context;
        }


        // GET: api/Forecast/5
        [HttpGet("{date}")]
        public async Task<IActionResult> GetWeatherReport([FromRoute] string date)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<WeatherReport> forecast = new List<WeatherReport>();
            DateTime reportDate;
            bool isDate;
            WeatherHelper.CheckInputDate(date, out reportDate, out isDate);
            if (!isDate)
            {
                return BadRequest("Enter valid date in YYYYMMDD format");
            }
            while (forecast.Count < 5)
            {
                reportDate = await ProcessForecast(forecast, reportDate);
            }
            return Ok(forecast);
        }

        

        private async Task<DateTime> ProcessForecast(List<WeatherReport> forecast, DateTime reportDate)
        {
            reportDate = forecast.Count == 0 ? reportDate : reportDate.AddDays(1);
            WeatherReport weatherReport = await _context.dailyWeather.SingleOrDefaultAsync(m => m.DATE.ToString() == reportDate.ToString("yyyyMMdd"));

            if (weatherReport == null)
            {
                weatherReport = new WeatherReport();
                var monthDay = reportDate.ToString("MMdd");
                var dateData = _context.dailyWeather.Where(x => x.DATE.ToString().Contains(monthDay));
                weatherReport.DATE = reportDate.ToString("yyyyMMdd");
                weatherReport.TMAX = Math.Round((dateData.Average(x => x.TMAX)), 2);
                weatherReport.TMIN = Math.Round((dateData.Average(x => x.TMIN)), 2);
                forecast.Add(weatherReport);
            }
            else
            {
                forecast.Add(weatherReport);
            }

            return reportDate;
        }
    }
}