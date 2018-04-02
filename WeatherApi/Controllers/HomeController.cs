using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Weather
        public ActionResult Index()
        {
            return View();
        }

    }

}