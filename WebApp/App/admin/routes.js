angular
    .module("app", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/orders", { templateUrl: "/App/admin/views/orders/index.html" })
            .when("/clients", { templateUrl: "/App/admin/views/clients/index.html" })
            .when("/pizzas", { templateUrl: "/App/admin/views/pizzas/index.html" })
            .when("/pizzas/novo", { templateUrl: "/App/admin/views/pizzas/form.html" })
            .when("/pizzas/editar/:id", { templateUrl: "/App/admin/views/pizzas/form.html" });
    });