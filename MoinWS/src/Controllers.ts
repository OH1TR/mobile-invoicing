/// <reference path="../Scripts/typings/jquery/jquery.d.ts"/> 
/// <reference path="../Scripts/typings/angularjs/angular.d.ts"/>
/// <reference path="../Scripts/Classes.ts"/>

var InvoiceApp = angular.module('InvoiceApp', ['ngRoute']);

InvoiceApp.config(function ($routeProvider) {
    $routeProvider

        .when('/', {
            templateUrl: 'Pages/login.html',
            controller: 'loginController'
        })

        .when('/home', {
            templateUrl: 'Pages/home.html',
            controller: 'aboutController'
        })

        .when('/customers', {
            templateUrl: 'Pages/customers.html',
            controller: 'customersController'
        })
        .otherwise({
            redirectTo: '/'
    });
});

InvoiceApp.controller('loginController', function ($scope) {
    var username: string = localStorage.getItem("username");
    var password: string = localStorage.getItem("password");
    if (username != null) {
        $.ajaxSetup({
            headers: {
                'Authorization': "Basic " + btoa(username + ":" + password)
            }
        });
        $.getJSON("Moin.svc/GetCurrentCustomer",
            function (result, status) {
                var o = new Customers(result);
                var controllerElement = document.querySelector('body');
                var controllerScope = angular.element(controllerElement).scope();
                controllerScope["customer"] = o;
                controllerScope["show"] = true;
                controllerScope.$apply();
                window.location.href = "#home";
            });    
    }
});


InvoiceApp.controller('customersController', function ($scope) {
    IMoin.GetCustomers(
        function (result) {
            $scope.SaveMethod = 'Moin.svc/UpdateCustomer';
            $scope.addNewFunction = function () {
                var newItem: Customers = new Customers();
                newItem.Name = '<new>';
                $scope.customers.push(newItem);
                $scope.current = newItem;
            }
            $scope.customers = result;
            if ($scope.customers.length > 0)
                $scope.current = $scope.customers[0]; 
            else
                $scope.current = null;                
        },$scope); 
});
