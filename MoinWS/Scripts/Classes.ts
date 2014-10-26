/// <reference path="./typings/jquery/jquery.d.ts"/>

// *****************************************************
// ********This is generated file, do not edit! ********
// *****************************************************

class utils {
    public static CopyProperties(source:any, target:any):void {
        for (var prop in source) {
                if((prop != 'RowState') && (prop != 'Original'))
                    target[prop] = source[prop];
        }
    }
}

class MoinBase {
    Original: any;
    Deleted: boolean;

    GetRowState(): number {
        if (this.Deleted)
            return (4);

        if (this.Original == null)
            return (1);
        for (var prop in this.Original) {
            if (prop != 'Original' && prop != 'RowState' && this[prop] !== this.Original[prop])
                return (2);
        }
        return (0);
    }

    RevertChanges() {
        utils.CopyProperties(this.Original, this);
    }

    ApplyChanges() {
        if (this.Original == null)
            this.Original = new Object();

        utils.CopyProperties(this, this.Original);
    }
}


	class Permissions extends MoinBase
	{
		ID: string;
		Name: string;
		RowState: number;

		Original : any;
		Deleted : boolean;

		constructor(source? :any) 
        {
			super();
			this.Deleted=false;
            if (typeof source === 'undefined') {
                this.ID = generateUUID();
                this.Original = null;
            }
            else {
                utils.CopyProperties(source, this);
                this.Original = source;
            }
		}

		GetRowState() : number
		{
			if(this.Original==null)
				return(1);
			for(var prop in this.Original){
				if(prop!='Original' && prop!='RowState' && this[prop] !== this.Original[prop])
					return(2);
			}
		    return(0);
		}

		RevertChanges() 
		{
			utils.CopyProperties(this.Original,this);
		}

        ApplyChanges() {
            if (this.Original == null)
                this.Original = new Object();

            utils.CopyProperties(this, this.Original);
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

	class PermissionsInRoles extends MoinBase
	{
		ID: string;
		PermissionsID: string;
		RolesID: string;
		RowState: number;

		Original : any;
		Deleted : boolean;

		constructor(source? :any) 
        {
			super();
			this.Deleted=false;
            if (typeof source === 'undefined') {
                this.ID = generateUUID();
                this.Original = null;
            }
            else {
                utils.CopyProperties(source, this);
                this.Original = source;
            }
		}

		GetRowState() : number
		{
			if(this.Original==null)
				return(1);
			for(var prop in this.Original){
				if(prop!='Original' && prop!='RowState' && this[prop] !== this.Original[prop])
					return(2);
			}
		    return(0);
		}

		RevertChanges() 
		{
			utils.CopyProperties(this.Original,this);
		}

        ApplyChanges() {
            if (this.Original == null)
                this.Original = new Object();

            utils.CopyProperties(this, this.Original);
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

	class Roles extends MoinBase
	{
		ID: string;
		Name: string;
		RowState: number;

		Original : any;
		Deleted : boolean;

		constructor(source? :any) 
        {
			super();
			this.Deleted=false;
            if (typeof source === 'undefined') {
                this.ID = generateUUID();
                this.Original = null;
            }
            else {
                utils.CopyProperties(source, this);
                this.Original = source;
            }
		}

		GetRowState() : number
		{
			if(this.Original==null)
				return(1);
			for(var prop in this.Original){
				if(prop!='Original' && prop!='RowState' && this[prop] !== this.Original[prop])
					return(2);
			}
		    return(0);
		}

		RevertChanges() 
		{
			utils.CopyProperties(this.Original,this);
		}

        ApplyChanges() {
            if (this.Original == null)
                this.Original = new Object();

            utils.CopyProperties(this, this.Original);
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

	class UsersInRoles extends MoinBase
	{
		ID: string;
		UsersID: string;
		RolesID: string;
		RowState: number;

		Original : any;
		Deleted : boolean;

		constructor(source? :any) 
        {
			super();
			this.Deleted=false;
            if (typeof source === 'undefined') {
                this.ID = generateUUID();
                this.Original = null;
            }
            else {
                utils.CopyProperties(source, this);
                this.Original = source;
            }
		}

		GetRowState() : number
		{
			if(this.Original==null)
				return(1);
			for(var prop in this.Original){
				if(prop!='Original' && prop!='RowState' && this[prop] !== this.Original[prop])
					return(2);
			}
		    return(0);
		}

		RevertChanges() 
		{
			utils.CopyProperties(this.Original,this);
		}

        ApplyChanges() {
            if (this.Original == null)
                this.Original = new Object();

            utils.CopyProperties(this, this.Original);
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

	class Customers extends MoinBase
	{
		ID: string;
		Name: string;
		RowState: number;

		Original : any;
		Deleted : boolean;

		constructor(source? :any) 
        {
			super();
			this.Deleted=false;
            if (typeof source === 'undefined') {
                this.ID = generateUUID();
                this.Original = null;
            }
            else {
                utils.CopyProperties(source, this);
                this.Original = source;
            }
		}

		GetRowState() : number
		{
			if(this.Original==null)
				return(1);
			for(var prop in this.Original){
				if(prop!='Original' && prop!='RowState' && this[prop] !== this.Original[prop])
					return(2);
			}
		    return(0);
		}

		RevertChanges() 
		{
			utils.CopyProperties(this.Original,this);
		}

        ApplyChanges() {
            if (this.Original == null)
                this.Original = new Object();

            utils.CopyProperties(this, this.Original);
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

	class Users extends MoinBase
	{
		ID: string;
		CustomerID: string;
		Username: string;
		PasswordHash: string;
		RowState: number;

		Original : any;
		Deleted : boolean;

		constructor(source? :any) 
        {
			super();
			this.Deleted=false;
            if (typeof source === 'undefined') {
                this.ID = generateUUID();
                this.Original = null;
            }
            else {
                utils.CopyProperties(source, this);
                this.Original = source;
            }
		}

		GetRowState() : number
		{
			if(this.Original==null)
				return(1);
			for(var prop in this.Original){
				if(prop!='Original' && prop!='RowState' && this[prop] !== this.Original[prop])
					return(2);
			}
		    return(0);
		}

		RevertChanges() 
		{
			utils.CopyProperties(this.Original,this);
		}

        ApplyChanges() {
            if (this.Original == null)
                this.Original = new Object();

            utils.CopyProperties(this, this.Original);
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

export function UpdateCustomer(customer:Customers,callback : (result : string) => any,scope? : any)
{
    $.getJSON('Moin.svc/UpdateCustomer?customer='+customer+'',
        function (result, status) 
        {
            var o=result
            if (typeof scope === 'undefined')            
                callback(o);
            else
                scope.$apply(
                    function () { 
                        callback(o);
                    });
            
        });
}

export function UpdateUser(customer:Users,callback : (result : string) => any,scope? : any)
{
    $.getJSON('Moin.svc/UpdateUser?customer='+customer+'',
        function (result, status) 
        {
            var o=result
            if (typeof scope === 'undefined')            
                callback(o);
            else
                scope.$apply(
                    function () { 
                        callback(o);
                    });
            
        });
}

export function GetRoles(callback : (result : Roles[]) => any,scope? : any)
{
    $.getJSON('Moin.svc/GetRoles',
        function (result, status) 
        {
            var o=RolesArrayFromJSON(result);
            if (typeof scope === 'undefined')            
                callback(o);
            else
                scope.$apply(
                    function () { 
                        callback(o);
                    });
            
        });
}

export function GetUserRoles(userID:string,callback : (result : UsersInRoles[]) => any,scope? : any)
{
    $.getJSON('Moin.svc/GetUserRoles?userID='+userID+'',
        function (result, status) 
        {
            var o=UsersInRolesArrayFromJSON(result);
            if (typeof scope === 'undefined')            
                callback(o);
            else
                scope.$apply(
                    function () { 
                        callback(o);
                    });
            
        });
}

export function UpdateUsersInRoles(usersInRoles:UsersInRoles[],callback : (result : string) => any,scope? : any)
{
    $.getJSON('Moin.svc/UpdateUsersInRoles?usersInRoles='+usersInRoles+'',
        function (result, status) 
        {
            var o=result
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