angular
    .module("app", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/pizzas", { templateUrl: "/App/admin/views/pizzas/index.html" })
            .when("/pizzas/novo", { templateUrl: "/App/admin/views/pizzas/form.html" })
            .when("/pizzas/editar/:id", { templateUrl: "/App/admin/views/pizzas/form.html" });
    });