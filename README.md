
# WeatherForecast API's using .Net Core

## Cloud Computing Homework2 Weather API  Tharun Sadula

### Implementation Details:

The assignment is on developing RESTful Web Services. I have used .NET Core API-framework to create a REST API to host weather information.
The data used is weather information Provided. The attributes are
DATE in YYYYMMDD format,
TMAX - Maximum Temperature for the particular date,
TMIN - Minimum Temperature for the particular date.

The Historical data is imported into SQL Database which is hosted in Azure. And accessed the database through connection strings.
#### Weather API

##### GET:

https://weatherapitharun.azurewebsites.net/historical returns the list of all the dates that are available.

Output Sample:[{"DATE":"20130101"},{"DATE":"20130102"},{"DATE":"20130103"},......]


Ex: https://weatherapitharun.azurewebsites.net/historical/20130920
Output: {
  "DATE": "20130920",
  "TMAX": 86,
  "TMIN": 64
}

Ex: https://weatherapitharun.azurewebsites.net/historical/20190101  returns 404 not found

Output: "Record Not Found"

#### POST:
https://weatherapitharun.azurewebsites.net/historical 201 response code

formbody:{
  "DATE": "20160229",
  "TMAX": 60,
  "TMIN": 38
}

Output:
{
  "DATE": "20200229"
}

#### DELETE:
https://weatherapitharun.azurewebsites.net/historical/20240304 deletes the weather data of that date returns 200 success code

Output:"Success"

### Forecast API
https://weatherapitharun.azurewebsites.net/forecast/20240227 returns weather forecast for next 7days

Output:
[
  {
    "DATE": "20240227",
    "TMAX": 42.24,
    "TMIN": 23.24
  },
  {
    "DATE": "20240228",
    "TMAX": 46.7,
    "TMIN": 25.12
  },
  {
    "DATE": "20240229",
    "TMAX": 60,
    "TMIN": 38
  },
  {
    "DATE": "20240301",
    "TMAX": 47.26,
    "TMIN": 27.74
  },
  {
    "DATE": "20240302",
    "TMAX": 36.44,
    "TMIN": 22.84
  },
  {
    "DATE": "20240303",
    "TMAX": 35,
    "TMIN": 22.3
  },
  {
    "DATE": "20240304",
    "TMAX": 38.66,
    "TMIN": 21.14
  }
]





#### Used Technologies:
.NET Core framework,Microsoft Azure App-Service, SQL Server, Swagger

The application has been hosted on:
Base URL : https://weatherapitharun.azurewebsites.net/

Readme: https://github.uc.edu/sadulatn/WeatherApi/blob/master/README.md

### Extra Credits: 

For testing the API using Swagger UI: https://weatherapitharun.azurewebsites.net/swagger

#### References:
API: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api

.Net core- swagger: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio



