/// <reference path="./typings/jquery/jquery.d.ts"/>
// *****************************************************
// ********This is generated file, do not edit! ********
// *****************************************************
var utils = (function () {
    function utils() {
    }
    utils.CopyProperties = function (source, target) {
        for (var prop in source) {
            if ((prop != 'RowState') && (prop != 'original'))
                target[prop] = source[prop];
        }
    };
    return utils;
})();

var Permissions = (function () {
    function Permissions(source) {
        if (typeof source === 'undefined') {
            this.ID = generateUUID();
            this.original = null;
        } else {
            utils.CopyProperties(source, this);
            this.original = source;
        }
    }
    Permissions.prototype.GetRowState = function () {
        if (this.original == null)
            return (1);
        for (var prop in this.original) {
            if (prop != 'original' && prop != 'RowState' && this[prop] !== this.original[prop])
                return (2);
        }
        return (0);
    };

    Permissions.prototype.RevertChanges = function () {
        utils.CopyProperties(this.original, this);
    };

    Permissions.prototype.ApplyChanges = function () {
        if (this.original == null)
            this.original = new Object();

        utils.CopyProperties(this, this.original);
    };
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
        if (typeof source === 'undefined') {
            this.ID = generateUUID();
            this.original = null;
        } else {
            utils.CopyProperties(source, this);
            this.original = source;
        }
    }
    PermissionsInRoles.prototype.GetRowState = function () {
        if (this.original == null)
            return (1);
        for (var prop in this.original) {
            if (prop != 'original' && prop != 'RowState' && this[prop] !== this.original[prop])
                return (2);
        }
        return (0);
    };

    PermissionsInRoles.prototype.RevertChanges = function () {
        utils.CopyProperties(this.original, this);
    };

    PermissionsInRoles.prototype.ApplyChanges = function () {
        if (this.original == null)
            this.original = new Object();

        utils.CopyProperties(this, this.original);
    };
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
        if (typeof source === 'undefined') {
            this.ID = generateUUID();
            this.original = null;
        } else {
            utils.CopyProperties(source, this);
            this.original = source;
        }
    }
    Roles.prototype.GetRowState = function () {
        if (this.original == null)
            return (1);
        for (var prop in this.original) {
            if (prop != 'original' && prop != 'RowState' && this[prop] !== this.original[prop])
                return (2);
        }
        return (0);
    };

    Roles.prototype.RevertChanges = function () {
        utils.CopyProperties(this.original, this);
    };

    Roles.prototype.ApplyChanges = function () {
        if (this.original == null)
            this.original = new Object();

        utils.CopyProperties(this, this.original);
    };
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
        if (typeof source === 'undefined') {
            this.ID = generateUUID();
            this.original = null;
        } else {
            utils.CopyProperties(source, this);
            this.original = source;
        }
    }
    UsersInRoles.prototype.GetRowState = function () {
        if (this.original == null)
            return (1);
        for (var prop in this.original) {
            if (prop != 'original' && prop != 'RowState' && this[prop] !== this.original[prop])
                return (2);
        }
        return (0);
    };

    UsersInRoles.prototype.RevertChanges = function () {
        utils.CopyProperties(this.original, this);
    };

    UsersInRoles.prototype.ApplyChanges = function () {
        if (this.original == null)
            this.original = new Object();

        utils.CopyProperties(this, this.original);
    };
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
        if (typeof source === 'undefined') {
            this.ID = generateUUID();
            this.original = null;
        } else {
            utils.CopyProperties(source, this);
            this.original = source;
        }
    }
    Customers.prototype.GetRowState = function () {
        if (this.original == null)
            return (1);
        for (var prop in this.original) {
            if (prop != 'original' && prop != 'RowState' && this[prop] !== this.original[prop])
                return (2);
        }
        return (0);
    };

    Customers.prototype.RevertChanges = function () {
        utils.CopyProperties(this.original, this);
    };

    Customers.prototype.ApplyChanges = function () {
        if (this.original == null)
            this.original = new Object();

        utils.CopyProperties(this, this.original);
    };
    return Customers;
})();

function CustomersArrayFromJSON(json) {
    var retval = [];
    var len = json.length;
    for (var i = 0; i < len; i++)
        retval.push(new Customers(json[i]));
    return (retval);
}

var Users = (function () {
    function Users(source) {
        if (typeof source === 'undefined') {
            this.ID = generateUUID();
            this.original = null;
        } else {
            utils.CopyProperties(source, this);
            this.original = source;
        }
    }
    Users.prototype.GetRowState = function () {
        if (this.original == null)
            return (1);
        for (var prop in this.original) {
            if (prop != 'original' && prop != 'RowState' && this[prop] !== this.original[prop])
                return (2);
        }
        return (0);
    };

    Users.prototype.RevertChanges = function () {
        utils.CopyProperties(this.original, this);
    };

    Users.prototype.ApplyChanges = function () {
        if (this.original == null)
            this.original = new Object();

        utils.CopyProperties(this, this.original);
    };
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

    function UpdateCustomer(customer, callback, scope) {
        $.getJSON('Moin.svc/UpdateCustomer?customer=' + customer + '', function (result, status) {
            var o = result;
            if (typeof scope === 'undefined')
                callback();
            else
                scope.$apply(function () {
                    callback();
                });
        });
    }
    IMoin.UpdateCustomer = UpdateCustomer;
})(IMoin || (IMoin = {}));
//# sourceMappingURL=Classes.js.map
