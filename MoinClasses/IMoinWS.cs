using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MoinClasses.Tables;

[ServiceContract]
public interface IMoinWS
{
    [OperationContract]
    [WebGet(
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetCurrentCustomer")]
    Customers GetCurrentCustomer();

    [OperationContract]
    [WebGet(
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
    Customers[] GetCustomers();

    [OperationContract]
    [WebGet(
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetUsers?customerID={customerID}")]
    Users[] GetUsers(string customerID);

    [OperationContract]
    [WebInvoke(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "POST",
        UriTemplate = "UpdateCustomer")]
    string UpdateCustomer(Customers customer);

    [OperationContract]
    [WebInvoke(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "POST",
        UriTemplate = "UpdateUser")]
    string UpdateUser(Users customer);

    [OperationContract]
    [WebGet(
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetRoles")]
    Roles[] GetRoles();

    [OperationContract]
    [WebGet(
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "GetUserRoles?userID={userID}")]
    UsersInRoles[] GetUserRoles(string userID);

    [OperationContract]
    [WebInvoke(
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        Method = "POST",
        UriTemplate = "UpdateUsersInRoles")]
    string UpdateUsersInRoles(UsersInRoles[] usersInRoles);
}

