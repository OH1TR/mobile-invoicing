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

        .when('/users', {
            templateUrl: 'Pages/users.html',
            controller: 'usersController'
        })
        .otherwise({
            redirectTo: '/'
        });
});

InvoiceApp.controller('loginController', function ($scope) {
    var username: string = localStorage.getItem("username");
    var password: string = localStorage.getItem("password");
    if (username != null && username != 'undefined') {
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

    $scope.SaveMethod = 'Moin.svc/UpdateCustomer';

    $scope.addNewFunction = function () {
        var newItem: Customers = new Customers();
        newItem.Name = '<new>';
        $scope.customers.push(newItem);
        $scope.current = newItem;
    }

    $scope.deleteFunction = function () {
        $scope.current.RowState = 3;
        $.ajax({
            url: $scope.SaveMethod,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify($scope.current),
            dataType: 'json'
        });
        var index = $scope.customers.indexOf($scope.current);
        if (index > -1)
            $scope.customers.splice(index, 1);

    }
    IMoin.GetCustomers(
        function (result) {
            $scope.customers = result;
            if ($scope.customers.length > 0)
                $scope.current = $scope.customers[0];
            else
                $scope.current = null;
        }, $scope);
});

InvoiceApp.controller('usersController', function ($scope) {

    $scope.SaveMethod = 'Moin.svc/UpdateUser';

    $scope.addNewFunction = function () {
        var newItem: Users = new Users();
        newItem.Username = '<new>';
        newItem.CustomerID = $scope.currentCustomer.ID;
        $scope.users.push(newItem);
        $scope.current = newItem;
    }

    $scope.deleteFunction = function () {
        $scope.current.RowState = 3;
        $.ajax({
            url: $scope.SaveMethod,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify($scope.current),
            dataType: 'json'
        });
        var index = $scope.users.indexOf($scope.current);
        if (index > -1)
            $scope.users.splice(index, 1);
    }

    $scope.getRoleName = function (roleID: string) {
        var i: number;
        for (i = 0; i < $scope.roles.length; ++i) {
            if ($scope.roles[i].ID == roleID)
                return ($scope.roles[i].Name);
        }
    }

    $scope.customerSelected = function () {
        IMoin.GetUsers($scope.currentCustomer.ID,
            function (result: Users[]) {
                $scope.users = result;
                if ($scope.users.length > 0)
                    $scope.current = $scope.users[0];
                else
                    $scope.current = null;
            }, $scope)
        }

    IMoin.GetCustomers(
        function (result) {
            $scope.customers = result;
            if ($scope.customers.length > 0)
                $scope.currentCustomer = $scope.customers[0];
            else
                $scope.currentCustomer = null;
        }, $scope);

    IMoin.GetRoles(function (result: Roles[]) {
        $scope.roles = result;
    }, $scope);

    $scope.userRoles = null;

    $scope.userSelected = function () {
        IMoin.GetUserRoles($scope.current.ID, function (result: UsersInRoles[]) {
            $scope.userRoles = result;
        }, $scope);
    }

    $scope.addProfile = function () {
        var i: number;
        for (i = 0; i < $scope.userRoles.length; ++i) {
            if ($scope.userRoles[i].RolesID == $scope.selectedRole.ID) {
                $scope.userRoles[i].Deleted = false;
                return;
            }
        }
        var o: UsersInRoles = new UsersInRoles();
        o.UsersID = $scope.current.ID;
        o.RolesID = $scope.selectedRole.ID;
        $scope.userRoles.push(o);
    }

    $scope.removeProfile = function () {
        if ($scope.xselectedRole.GetRowState() == 1) {
            for (var i = $scope.userRoles.length - 1; i >= 0; i--) {
                if ($scope.userRoles[i] === $scope.xselectedRole) {
                    $scope.userRoles.splice(i, 1);
                }
            }
        }
        else    
            $scope.xselectedRole.Deleted = true;
    };

    $scope.userRolesHasChanges = function () {
        return (MidleTableHasChanges($scope.userRoles));
    };
});