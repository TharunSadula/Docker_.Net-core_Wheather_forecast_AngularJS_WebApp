
# WeatherForecast API's using .Net Core, Docker Image creation and Swagger for API testing


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


## Docker Image

## Adding Docker file
1. Add the Docker file and docker ignore file in the project directory. (get the files from the dot net core docker sample- https://github.com/dotnet/dotnet-docker-samples/tree/master/aspnetapp)

2. Update the Docker file ENTRYPOINT ["dotnet", "{yourdllname}.dll"]

## Building project and running the Docker Image
1.In the project directory run the following command
------  docker build -t {imageName} .

2.This creates the docker image

3. docker run -d -p 80:80 {imageName}    this make the application to run at port 80


## Saving the Docker Image

1. docker save {imageName} > {outputName}.tar

## Get Image from tar File

1. docker load -i {outputName}.tar

2.docker run -d -p {portNum}:80 {imageName} . Make sure your server listens at port this {portNum}

# Execution

Readme Link:- https://github.uc.edu/sadulatn/weatherApiDocker/blob/master/README.md

DockerImageLink:- https://s3.us-east-2.amazonaws.com/weatherapptharun/forecastapptharun.tar

Execution CMD:- docker run -d -p 80:80 forecastapptharun

### Swagger:

For testing the API using Swagger UI: https://weatherapitharun.azurewebsites.net/swagger

#### Used Technologies:
.NET Core framework,Microsoft Azure App-Service, SQL Server, Swagger

The application has been hosted on:
Base URL : https://weatherapitharun.azurewebsites.net/

Readme: https://github.com/TharunSadula/Docker_.Net-core_Wheather_forecast_AngularJS_WebApp/blob/master/README.md



#### References:
API: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api

.Net core- swagger: https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger?tabs=visual-studio



