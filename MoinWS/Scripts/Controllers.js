﻿var InvoiceApp = angular.module('InvoiceApp', ['ngRoute']);

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

InvoiceApp.controller('CustomersCtrl', function ($scope) {
    $scope.customer = null;
    $scope.show = false;
});

InvoiceApp.controller('customersController', function ($scope) {
    IMoin.GetCustomers(function (result) {
        $scope.customers = result;
    }, $scope);
});
//# sourceMappingURL=Controllers.js.map
