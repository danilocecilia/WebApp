angular
    .module("app", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            //.when("/", { templateUrl: "/App/root/views/landing.html" })
            .when("/cardapio", { templateUrl: "/App/root/views/cardapio/index.html" });
    });