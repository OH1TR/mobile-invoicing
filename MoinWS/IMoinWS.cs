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
    Customers[] GetCustomers();

    [OperationContract]
    Users[] GetUsers(string customerID);    
}

