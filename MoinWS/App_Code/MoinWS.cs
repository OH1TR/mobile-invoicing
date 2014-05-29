using System;
using System.Linq;
using System.ServiceModel;
using MySql.Data.MySqlClient;
using System.Configuration;
using MoinClasses;
using MoinClasses.Tables;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
public class MoinWS : IMoinWS
{
    protected void DemandRole(string role)
    {
        if (System.Web.HttpContext.Current.User.IsInRole(role))
            return;

        throw new UnauthorizedAccessException("User not in role:" + role);
    }

    protected Customers CurrentCustomer
    {
        get
        {
            return (((MoinClasses.MoanIdentity)((System.Web.HttpContext.Current.User).Identity)).Customer);
        }
    }

    protected MoinDbContext GetCtx()
    {
        string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
        MySqlConnection connection = new MySqlConnection(connectionString);
        MoinDbContext ctx = new MoinDbContext(connection, false);
        return (ctx);
    }

    public Customers GetCurrentCustomer()
    {
        return (CurrentCustomer);
    }


    public Users GetUsers(string customerID)
    {
        //DemandRole("ManageUsers");

        try
        {
            object propObj;

            OperationContext.Current.IncomingMessageProperties.TryGetValue(HttpRequestMessageProperty.Name, out propObj);

            HttpRequestMessageProperty reqProp = (HttpRequestMessageProperty)propObj;
            string headerAuth = reqProp.Headers["Authorization"];
            System.IO.File.WriteAllText("/tmp/auth.txt", headerAuth);

            using (MoinDbContext ctx = GetCtx())
            {
                ctx.Configuration.ProxyCreationEnabled = false;

                if (CurrentCustomer.ID == customerID)
                {
                    var users = from u in ctx.Users
                                where u.CustomerID == CurrentCustomer.ID
                                select u;
                    Users[] retval = users.ToArray();
                    return (retval[0]);
                }
                /*
            else
            {
                DemandRole("Developer");
                var users = from u in ctx.Users
                            where u.CustomerID == customerID
                            select u;
                return (users.ToArray());
            }*/
            }
        }
        catch(Exception e)
        {            
            string s="";
            if(System.Web.HttpContext.Current==null)
                s+="System.Web.HttpContext.Current==null";
            else
                if(System.Web.HttpContext.Current.User==null)
                    s+="System.Web.HttpContext.Current.User==null";
                else
                    s+="User:"+System.Web.HttpContext.Current.User.ToString();


            System.IO.File.WriteAllText("/tmp/ex.txt", e.Message + e.StackTrace+s);
        }
        return (null);
    }


    public Customers[] GetCustomers()
    {
        DemandRole("Developer");
        try
        {
            string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MoinDbContext contextDB = new MoinDbContext(connection, false))
                {
                    return (contextDB.Set<Customers>().ToArray());
                }
            }
        }
        catch (Exception ex)
        {
            System.IO.File.WriteAllText("/tmp/exception.txt", ex.Message + ex.StackTrace + (ex.InnerException != null ? ex.InnerException.Message : ""));
        }
        return (null);
    }
}
