using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Helpers
{
    public class WeatherHelper
    {
        public static void CheckInputDate(string date, out DateTime reportDate, out bool isDate)
        {
            isDate = DateTime.TryParseExact(date.ToString(), "yyyyMMdd",
                                      CultureInfo.InvariantCulture,
                                      DateTimeStyles.None, out reportDate);
        }
    }
}
