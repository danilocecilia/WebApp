angular.module("root")
    .controller("index", function ($scope, $http) {
        $http
            .get("/Services/PizzaServices.svc/GetAll")
            .then(function (response) {
                $scope.pizzas = response.data.GetAllResult;
            });
    });