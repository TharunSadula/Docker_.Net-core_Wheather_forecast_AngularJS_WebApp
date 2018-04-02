using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WeatherApi.Models;
using WeatherApi.Data;
using WeatherApi.Helpers;

namespace WeatherApi.Controllers
{
    [Produces("application/json")]
    [Route("historical")]
    public class HistoricalController : Controller
    {

        private readonly WeatherApiContext db;


        public HistoricalController(WeatherApiContext dbContext)
        {
            db = dbContext;
        }

        // GET: api/historical
        [HttpGet]
        public IEnumerable<object> Get()
        {

            return db.dailyWeather.Select(x => new { DATE = x.DATE });
        }



        // GET: api/historical/5
        [HttpGet("{date}", Name = "Get")]
        public IActionResult Get(string date)
        {
            var item = db.dailyWeather.FirstOrDefault(x => x.DATE == date);
            if (item == null)
            {
                return NotFound("Record Not Found");
            }
            return new ObjectResult(item);
        }

        // POST: api/historical
        [HttpPost]
        public IActionResult Post([FromBody] WeatherReport report)
        {
            if (report == null)
            {
                return BadRequest();
            }
            DateTime reportDate;
            bool isDate;
            WeatherHelper.CheckInputDate(report.DATE, out reportDate, out isDate);
            if (!isDate)
            {
                return BadRequest("Enter valid date in YYYYMMDD format");
            }

            if (db.dailyWeather.Any(x => x.DATE == report.DATE))
            {
                return BadRequest("Already Exists");
            }
            db.dailyWeather.Add(report);

            db.SaveChanges();
            return CreatedAtAction("Get", new { date = report.DATE }, new { DATE = report.DATE });

        }

        // PUT: api/historical/5
        [HttpPut]
        public IActionResult Put([FromBody] WeatherReport report)
        {
            if (report == null)
            {
                return BadRequest();
            }
            var item = db.dailyWeather.FirstOrDefault(x => x.DATE == report.DATE);
            if (item == null)
            {
                return NotFound("Record not found");
            }
            item.TMAX = report.TMAX;
            item.TMIN = report.TMIN;
            db.dailyWeather.Update(item);
            db.SaveChanges();
            return CreatedAtRoute("Get", new { date = item.DATE }, new { DATE = report.DATE });
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{date}")]
        public IActionResult Delete(string date)
        {
            var report = db.dailyWeather.FirstOrDefault(x => x.DATE == date);

            if (report == null)
            {
                return NotFound("Record not found");
            }
            db.dailyWeather.Remove(report);
            db.SaveChanges();
            return Ok("Success");
        }
    }
}
