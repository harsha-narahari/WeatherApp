var weatherApp = angular.module("weatherApp", []);

weatherApp.controller("weatherController", function ($scope, $http, $sce) {
    $scope.cities = [];

    var getCountries = function () {

        var url = "Weather/GetAllCountries";
        $http.get(url)
            .then(function (result) {

                $scope.countries = result.data;
                $scope.country = $scope.countries[0];
            },
            function (error) {
                console.log(error);
                $scope.cities = [];
            }
        );
    }

    getCountries();

    $scope.$watch('country', function () {
        $scope.datetime = new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();
        if ($scope.country) {
            var url = "Weather/GetCities?Country=" + $scope.country;
            $http.get(url)
                .then(function (result) {

                    $scope.cities = result.data;
                    $scope.city = $scope.cities[0];
                },
                function (error) {
                    console.log(error);
                    $scope.cities = [];
                }
            );
        }
    });

    $scope.$watch('city', function () {
        $scope.datetime = new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();
        if ($scope.city) {
            var url = "Weather/GetWeather?CityID=" + $scope.city.id;
            $http.get(url)
                .then(function (result) {
                    if (result.data) {
                        var data = JSON.parse(result.data);
                        $scope.temperature = data.main.temp;
                        $scope.pressure = data.main.pressure;
                        $scope.humidity = data.main.humidity;
                        $scope.minTemperature = data.main.temp_min;
                        $scope.maxTemperature = data.main.temp_max;
                        $scope.wind = data.main.wind;
                    }
                },
                function (error) {
                    console.log(error);
                    $scope.cities = [];
                }
            );
        }
    });
    $scope.datetime = new Date().toLocaleDateString() + " " + new Date().toLocaleTimeString();

});