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

    protected MoinDbContext GetCtx()
    {
        string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
        MySqlConnection connection = new MySqlConnection(connectionString);
        MoinDbContext ctx = new MoinDbContext(connection, false);
        return (ctx);
    }

    public Customers GetCurrentCustomer()
    {
        using (MoanServiceContext sc = new MoanServiceContext())
        {
            return (sc.CurrentCustomer);
        }
    }


    public Users GetUsers(string customerID)
    {
        try
        {
            using (MoanServiceContext sc = new MoanServiceContext())
            {
                sc.ctx.Configuration.ProxyCreationEnabled = false;

                if (sc.CurrentCustomer.ID == customerID)
                {
                    var users = from u in sc.ctx.Users
                                where u.CustomerID == sc.CurrentCustomer.ID
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
        catch (Exception e)
        {
            System.IO.File.WriteAllText("/tmp/ex.txt", e.Message + e.StackTrace);
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
