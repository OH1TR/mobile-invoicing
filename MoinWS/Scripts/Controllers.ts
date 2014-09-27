var InvoiceApp = angular.module('InvoiceApp', ['ngRoute']);

InvoiceApp.config(function ($routeProvider) {
    $routeProvider

        .when('/', {
            templateUrl: 'Pages/login.html',
           // controller: 'mainController'
        })

        .when('/home', {
            templateUrl: 'Pages/home.html',
            controller: 'aboutController'
        })
});


InvoiceApp.controller('CustomersCtrl', function ($scope) {
    $scope.customer = null;
    $scope.show = false;
});