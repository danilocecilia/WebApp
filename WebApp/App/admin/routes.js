angular
    .module("app", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider
            .when("/admin-pizzas/", { templateUrl: "/App/admin/views/pizzas/index.html" })
            .when("/admin-pizzas/novo", { templateUrl: "/App/admin/views/pizzas/form.html" })
            .when("/admin-pizzas/editar/:id", { templateUrl: "/App/admin/views/pizzas/form.html" });
    });