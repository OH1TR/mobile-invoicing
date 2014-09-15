
 
 





declare module MoinClasses.Tables {
interface Customers extends MoinClasses.Tables.MoinClassesBase {
  ID: string;
  Name: string;
}
interface MoinClassesBase {
  ID: string;
}
interface Users extends MoinClasses.Tables.MoinClassesBase {
  ID: string;
  CustomerID: string;
  Username: string;
  PasswordHash: string;
  Customer: MoinClasses.Tables.Customers;
  UsersInRoles: MoinClasses.Tables.UsersInRoles[];
}
interface UsersInRoles extends MoinClasses.Tables.MoinClassesBase {
  ID: string;
  UsersID: string;
  RolesID: string;
  User: MoinClasses.Tables.Users;
  Role: MoinClasses.Tables.Roles;
}
interface Roles extends MoinClasses.Tables.MoinClassesBase {
  ID: string;
  Name: string;
  UsersInRoles: MoinClasses.Tables.UsersInRoles[];
}
}




