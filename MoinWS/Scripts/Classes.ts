/// <reference path="./typings/jquery/jquery.d.ts"/>

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

	class Permissions
	{
		ID: string;
		Name: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
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

	class Roles
	{
		ID: string;
		Name: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
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

	class Customers
	{
		ID: string;
		Name: string;

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
	}

	class MoinRowState
	{

		constructor(source) 
		{
			utils.CopyProperties(source,this);
		}
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

