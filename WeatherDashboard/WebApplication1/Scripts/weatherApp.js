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
                        //var data = JSON.parse(result.data);
                        //setOpenWeatherData(data);
                        //setApixuData(data);
                        //setApiData(result.data);                        
                        setGenericProperties(JSON.parse(result.data));
                        debugger;
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
    $scope.genericProperties = [];
    var setGenericProperties = function (data) {
        //debugger;
        for (var propertyName in data) {
            if (data.hasOwnProperty(propertyName) && typeof data[propertyName] !== "function")
            {
                if (typeof data[propertyName] == "object") {
                    setGenericProperties(data[propertyName])
                }
                else if (propertyName != null && propertyName != undefined
                    && data[propertyName] != null && data[propertyName] != undefined) {
                    $scope.genericProperties.push({ key: propertyName, value: data[propertyName] });
                    //debugger;
                }
            }            
        }        
    }

    var setApiData = function (data) {
        debugger;
        $scope.temperature = data.Temperature;
        $scope.minTemperature = data.MinTemperature;
        $scope.maxTemperature = data.MaxTemperature;
        $scope.wind = data.Wind;
        $scope.pressure = data.Pressure;
        $scope.humidity = data.Humidity;
        $scope.datetime = UpdatedOn;
    };

    var setApixuData = function (data) {
        //{"location":{"name":"Sydney","region":"New South Wales","country":"Australia","lat":-33.88,"lon":151.22,"tz_id":"Australia/Sydney","localtime_epoch":1499665277,"localtime":"2017-07-10 15:41"},"current":{"last_updated_epoch":1499664606,"last_updated":"2017-07-10 15:30","temp_c":17.0,"temp_f":62.6,"is_day":1,"condition":{"text":"Sunny","icon":"//cdn.apixu.com/weather/64x64/day/113.png","code":1000},"wind_mph":11.9,"wind_kph":19.1,"wind_degree":300,"wind_dir":"WNW","pressure_mb":1024.0,"pressure_in":30.7,"precip_mm":0.0,"precip_in":0.0,"humidity":39,"cloud":0,"feelslike_c":17.0,"feelslike_f":62.6,"vis_km":10.0,"vis_miles":6.0}}
        $scope.temperature = data.current.temp_c;
        $scope.pressure = data.current.pressure_in;
        $scope.humidity = data.current.humidity;
        $scope.minTemperature = data.current.temp_min;
        $scope.maxTemperature = data.current.temp_max;
        $scope.wind = data.current.wind_kmph;
    };

    var setOpenWeatherData = function(data)
    {
        //{"coord":{"lon":84.63,"lat":28},"weather":[{"id":500,"main":"Rain","description":"light rain","icon":"10d"}],"base":"stations","main":{"temp":289.078,"pressure":804.05,"humidity":100,"temp_min":289.078,"temp_max":289.078,"sea_level":1016.94,"grnd_level":804.05},"wind":{"speed":0.61,"deg":12.001},"rain":{"3h":2.13},"clouds":{"all":88},"dt":1499669119,"sys":{"message":0.0129,"country":"NP","sunrise":1499643153,"sunset":1499692863},"id":1283378,"name":"Gorkhā","cod":200}
        $scope.temperature = data.main.temp;
        $scope.pressure = data.main.pressure;
        $scope.humidity = data.main.humidity;
        $scope.minTemperature = data.main.temp_min;
        $scope.maxTemperature = data.main.temp_max;
        $scope.wind = data.main.wind.speed;
    }

});