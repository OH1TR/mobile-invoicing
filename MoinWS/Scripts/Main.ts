/// <reference path="./typings/jquery/jquery.d.ts"/> 
/// <reference path="./typings/angularjs/angular.d.ts"/>
/// <reference path="Classes.ts"/>


function login() {
    var username = $('#username').val();
    var password = $('#password').val();

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
        }).fail(function () {
            alert("Login failed!");
        });

}
