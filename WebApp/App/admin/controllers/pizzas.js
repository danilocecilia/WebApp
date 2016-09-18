angular.module("app")
    .controller("index", function ($scope, $http) {
        $http
            .get("/Services/PizzaServices.svc/GetAll")
            .then(function (response) {
                $scope.pizzas = response.data.GetAllResult;
            });
    })
    .controller("form", ["$scope", "$http", "$routeParams", "$location", function ($scope, $http, $routeParams, $location) {
        document
            .getElementById("Img")
            .addEventListener(
                "change",
                function (fileEvent) {
                    var formData = new FormData();
                    var xhr = new XMLHttpRequest();
                    var file = fileEvent.target.files[0];
                    var filename = file.name;

                    var url = "/Services/FileServices.svc/Upload";

                    xhr.open("POST", url, true);
                    xhr.send(file);
                },
                false);

        $scope.pizza = {};

        $scope.save = function (pizza) {
            $http
               .post("/Services/PizzaServices.svc/Save", { pizza: pizza })
               .then(function (response) { $location.path("/pizzas"); });
        };

        if ($routeParams.id) {
            $http
               .get("/Services/PizzaServices.svc/Get", { params: { id: $routeParams.id } })
               .then(function (response) { $scope.pizza = response.data.GetResult });
        }
    }]);