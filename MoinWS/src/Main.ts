/// <reference path="../Scripts/typings/jquery/jquery.d.ts"/> 
/// <reference path="../Scripts/typings/angularjs/angular.d.ts"/>
/// <reference path="../Scripts/Classes.ts"/>


function generateUUID() {
    var d = new Date().getTime();
    var uuid = 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = (d + Math.random() * 16) % 16 | 0;
        d = Math.floor(d / 16);
        return (c == 'x' ? r : (r & 0x7 | 0x8)).toString(16);
    });
    return uuid;
};

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
            localStorage.setItem("username", $('#username').val());
            localStorage.setItem("password", $('#password').val());
            window.location.href = "#home";            
        }).fail(function () {
            alert("Login failed!");
        });

}

function saveCurrent(viewref : string) {
    var controllerElement = document.querySelector('#' +viewref);
    var controllerScope = angular.element(controllerElement).scope();    
    controllerScope["current"].RowState = controllerScope["current"].GetRowState();
    $.ajax({
        url: controllerScope["SaveMethod"],
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(controllerScope["current"]),
        dataType: 'json'
    });   
    controllerScope["current"].ApplyChanges();
    controllerScope.$apply();
}

function revertCurrent(viewref: string) {
    var controllerElement = document.querySelector('#' + viewref);
    var controllerScope = angular.element(controllerElement).scope();
    controllerScope["current"].RevertChanges();
    controllerScope.$apply();
}

function addNew(viewref: string) {
    var controllerElement = document.querySelector('#' + viewref);
    var controllerScope = angular.element(controllerElement).scope();
    controllerScope["addNewFunction"]();
    controllerScope.$apply();
}

function deleteCurrent(viewref: string) {
    var controllerElement = document.querySelector('#' + viewref);
    var controllerScope = angular.element(controllerElement).scope();
    controllerScope["deleteFunction"]();
    controllerScope.$apply();
}

function MidleTableHasChanges(aObjects: MoinBase[]) {
    var len = aObjects.length;
    for (var i = 0; i < len; i++) {
        if (aObjects[i].GetRowState() != 0)
            return (true);
    }
    return (false);
}

