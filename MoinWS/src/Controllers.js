/// <reference path="../Scripts/typings/jquery/jquery.d.ts"/>
/// <reference path="../Scripts/typings/angularjs/angular.d.ts"/>
/// <reference path="../Scripts/Classes.ts"/>
var InvoiceApp = angular.module('InvoiceApp', ['ngRoute']);

InvoiceApp.config(function ($routeProvider) {
    $routeProvider.when('/', {
        templateUrl: 'Pages/login.html'
    }).when('/home', {
        templateUrl: 'Pages/home.html',
        controller: 'aboutController'
    }).when('/customers', {
        templateUrl: 'Pages/customers.html',
        controller: 'customersController'
    });
});

InvoiceApp.controller('customersController', function ($scope) {
    IMoin.GetCustomers(function (result) {
        $scope.customers = result;
    }, $scope);
});
//# sourceMappingURL=Controllers.js.map
