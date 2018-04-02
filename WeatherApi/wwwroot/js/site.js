(function () {
    'use strict';
    var app = angular.module('weather', ['chart.js', 'ngMaterial', 'ngMessages']);

    app.config(function (ChartJsProvider) {
        // Configure all charts
        ChartJsProvider.setOptions({
            colors: ['#97BBCD', '#DCDCDC', '#F7464A', '#46BFBD', '#FDB45C', '#949FB1', '#4D5360']
        });
        // Configure all doughnut charts
        ChartJsProvider.setOptions('doughnut', {
            cutoutPercentage: 60
        });
        ChartJsProvider.setOptions('bubble', {
            tooltips: { enabled: false }
        });
    });

    app.controller('weatherController', ['$scope', '$http', '$q', function ($scope, $http, $q) {


        $scope.forecast = function (forecastDate) {
            if (forecastDate) {
                var date = moment(forecastDate).format('YYYYMMDD');
                var urlDate = moment(forecastDate).format('X');
                var key = 'fb43e07XXXXXXXXXXXXXXXXXca2b';// get the key from darksky api website
               
                var promises = [];
                promises.push($http.get('forecast/' + date));


                var cors = 'https://cors-anywhere.herokuapp.com/';
                for (i = 0; i < 5; i++) {
                    urlDate = moment(forecastDate).add(i, 'days').format('X');
                    var url = 'https://api.darksky.net/forecast/' + key + '/39.1031,-84.5120,' + urlDate + '?exclude=currently,flags,hourly';
                    promises.push($http.get(cors + url));
                }



                $q.all(promises).then(function (data) {
                    $scope.labels = _.map(data[0].data, 'DATE');
                    $scope.series = ['TMAX', 'TMIN'];

                    var tmax = _.map(data[0].data, 'TMAX');
                    var tmin = _.map(data[0].data, 'TMIN');

                    $scope.data1 = [tmax, tmin]
                    tmax = [];
                    tmin = [];
                    for (i = 1; i < 6; i++) {
                        tmax.push(data[i].data.daily.data[0].temperatureMax);
                        tmin.push(data[i].data.daily.data[0].temperatureMin);
                    }
                    $scope.data2 = [tmax, tmin]
                })

            }
        }

    }]);


}());
