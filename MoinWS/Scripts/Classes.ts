/// <reference path="./typings/jquery/jquery.d.ts"/>

// *****************************************************
// ********This is generated file, do not edit! ********
// *****************************************************

class utils {
    public static CopyProperties(source:any, target:any):void {
        for(var prop in source){
                target[prop] = source[prop];
        }
    }
}

	class MoinClassesBase
	{
		ID: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function MoinClassesBaseArrayFromJSON(json : Object[]) : MoinClassesBase[]
	{
		var retval: MoinClassesBase[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new MoinClassesBase(json[i]));
		return (retval) ;
	}

	class Permissions
	{
		ID: string;
		Name: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function PermissionsArrayFromJSON(json : Object[]) : Permissions[]
	{
		var retval: Permissions[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new Permissions(json[i]));
		return (retval) ;
	}

	class PermissionsInRoles
	{
		ID: string;
		PermissionsID: string;
		RolesID: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function PermissionsInRolesArrayFromJSON(json : Object[]) : PermissionsInRoles[]
	{
		var retval: PermissionsInRoles[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new PermissionsInRoles(json[i]));
		return (retval) ;
	}

	class Roles
	{
		ID: string;
		Name: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function RolesArrayFromJSON(json : Object[]) : Roles[]
	{
		var retval: Roles[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new Roles(json[i]));
		return (retval) ;
	}

	class UsersInRoles
	{
		ID: string;
		UsersID: string;
		RolesID: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function UsersInRolesArrayFromJSON(json : Object[]) : UsersInRoles[]
	{
		var retval: UsersInRoles[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new UsersInRoles(json[i]));
		return (retval) ;
	}

	class Customers
	{
		ID: string;
		Name: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function CustomersArrayFromJSON(json : Object[]) : Customers[]
	{
		var retval: Customers[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new Customers(json[i]));
		return (retval) ;
	}

	class MoinRowState
	{

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function MoinRowStateArrayFromJSON(json : Object[]) : MoinRowState[]
	{
		var retval: MoinRowState[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new MoinRowState(json[i]));
		return (retval) ;
	}

	class Users
	{
		ID: string;
		CustomerID: string;
		Username: string;
		PasswordHash: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	function UsersArrayFromJSON(json : Object[]) : Users[]
	{
		var retval: Users[] = [];
		var len = json.length;
		for (var i = 0; i < len; i++)   
			retval.push(new Users(json[i]));
		return (retval) ;
	}

module IMoin {
export function GetCurrentCustomer(callback : (result : Customers) => any,scope? : any)
{
    $.getJSON('Moin.svc/GetCurrentCustomer',
        function (result, status) 
        {
            var o=new Customers(result);
            if (typeof scope === 'undefined')            
                callback(o);
            else
                scope.$apply(
                    function () { 
                        callback(o);
                    });
            
        });
}

export function GetCustomers(callback : (result : Customers[]) => any,scope? : any)
{
    $.getJSON('Moin.svc/GetCustomers',
        function (result, status) 
        {
            var o=CustomersArrayFromJSON(result);
            if (typeof scope === 'undefined')            
                callback(o);
            else
                scope.$apply(
                    function () { 
                        callback(o);
                    });
            
        });
}

export function GetUsers(customerID:string,callback : (result : Users[]) => any,scope? : any)
{
    $.getJSON('Moin.svc/GetUsers?customerID='+customerID+'',
        function (result, status) 
        {
            var o=UsersArrayFromJSON(result);
            if (typeof scope === 'undefined')            
                callback(o);
            else
                scope.$apply(
                    function () { 
                        callback(o);
                    });
            
        });
}

}