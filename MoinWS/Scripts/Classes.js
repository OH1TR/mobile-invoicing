/// <reference path="./typings/jquery/jquery.d.ts"/>
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

var Permissions = (function () {
    function Permissions(source) {
        utils.CopyProperties(source, this);
    }
    return Permissions;
})();

var PermissionsInRoles = (function () {
    function PermissionsInRoles(source) {
        utils.CopyProperties(source, this);
    }
    return PermissionsInRoles;
})();

var Roles = (function () {
    function Roles(source) {
        utils.CopyProperties(source, this);
    }
    return Roles;
})();

var UsersInRoles = (function () {
    function UsersInRoles(source) {
        utils.CopyProperties(source, this);
    }
    return UsersInRoles;
})();

var Customers = (function () {
    function Customers(source) {
        utils.CopyProperties(source, this);
    }
    return Customers;
})();

var MoinRowState = (function () {
    function MoinRowState(source) {
        utils.CopyProperties(source, this);
    }
    return MoinRowState;
})();

var Users = (function () {
    function Users(source) {
        utils.CopyProperties(source, this);
    }
    return Users;
})();
//# sourceMappingURL=Classes.js.map
