/// <reference path="./typings/jquery/jquery.d.ts"/>
// *****************************************************
// ********This is generated file, do not edit! ********
// *****************************************************
var utils = (function () {
    function utils() {
    }
    utils.CopyProperties = function (source, target) {
        for (var prop in source) {
            target[prop] = source[prop];
        }
    };
    return utils;
})();

var MoinClassesBase = (function () {
    function MoinClassesBase(source) {
        utils.CopyProperties(source, this);
    }
    return MoinClassesBase;
})();

function MoinClassesBaseArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new MoinClassesBase(json[i]));
    return (retval);
}

var Permissions = (function () {
    function Permissions(source) {
        utils.CopyProperties(source, this);
    }
    return Permissions;
})();

function PermissionsArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new Permissions(json[i]));
    return (retval);
}

var PermissionsInRoles = (function () {
    function PermissionsInRoles(source) {
        utils.CopyProperties(source, this);
    }
    return PermissionsInRoles;
})();

function PermissionsInRolesArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new PermissionsInRoles(json[i]));
    return (retval);
}

var Roles = (function () {
    function Roles(source) {
        utils.CopyProperties(source, this);
    }
    return Roles;
})();

function RolesArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new Roles(json[i]));
    return (retval);
}

var UsersInRoles = (function () {
    function UsersInRoles(source) {
        utils.CopyProperties(source, this);
    }
    return UsersInRoles;
})();

function UsersInRolesArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new UsersInRoles(json[i]));
    return (retval);
}

var Customers = (function () {
    function Customers(source) {
        utils.CopyProperties(source, this);
    }
    return Customers;
})();

function CustomersArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new Customers(json[i]));
    return (retval);
}

var MoinRowState = (function () {
    function MoinRowState(source) {
        utils.CopyProperties(source, this);
    }
    return MoinRowState;
})();

function MoinRowStateArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new MoinRowState(json[i]));
    return (retval);
}

var Users = (function () {
    function Users(source) {
        utils.CopyProperties(source, this);
    }
    return Users;
})();

function UsersArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new Users(json[i]));
    return (retval);
}

var IMoin;
(function (IMoin) {
    function GetCurrentCustomer(callback, scope) {
        $.getJSON('Moin.svc/GetCurrentCustomer', function (result, status) {
            var o = new Customers(result);
            if (typeof scope === 'undefined')
                callback(o);
            else
                scope.$apply(function () {
                    callback(o);
                });
        });
    }
    IMoin.GetCurrentCustomer = GetCurrentCustomer;

    function GetCustomers(callback, scope) {
        $.getJSON('Moin.svc/GetCustomers', function (result, status) {
            var o = CustomersArrayFromJSON(result);
            if (typeof scope === 'undefined')
                callback(o);
            else
                scope.$apply(function () {
                    callback(o);
                });
        });
    }
    IMoin.GetCustomers = GetCustomers;

    function GetUsers(customerID, callback, scope) {
        $.getJSON('Moin.svc/GetUsers?customerID=' + customerID + '', function (result, status) {
            var o = UsersArrayFromJSON(result);
            if (typeof scope === 'undefined')
                callback(o);
            else
                scope.$apply(function () {
                    callback(o);
                });
        });
    }
    IMoin.GetUsers = GetUsers;
})(IMoin || (IMoin = {}));
//# sourceMappingURL=Classes.js.map
