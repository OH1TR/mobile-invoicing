using System;
using System.Linq;
using System.ServiceModel;
using MySql.Data.MySqlClient;
using System.Configuration;
using MoinClasses;
using MoinClasses.Tables;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;

namespace MoinWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class MoinWS : IMoinWS
    {
        public Customers GetCurrentCustomer()
        {
            using (MoanServiceContext sc = new MoanServiceContext())
            {
                return (sc.CurrentCustomer);
            }
        }

        public Users[] GetUsers(string customerID)
        {
            try
            {
                using (MoanServiceContext sc = new MoanServiceContext())
                {
                    sc.DemandPermission(Permission.ManageUsers);

                    sc.ctx.Configuration.ProxyCreationEnabled = false;

                    if (sc.CurrentCustomer.ID == customerID)
                    {
                        var users = from u in sc.ctx.Users
                                    where u.CustomerID == sc.CurrentCustomer.ID
                                    select u;
                        Users[] retval = users.ToArray();
                        return (retval);
                    }
                    else
                    {
                        sc.DemandPermission(Permission.SystemAdmin);

                        var users = from u in sc.ctx.Users
                                    where u.CustomerID == customerID
                                    select u;
                        return (users.ToArray());
                    }
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
            return (null);
        }


        public Customers[] GetCustomers()
        {
            try
            {
                using (MoanServiceContext sc = new MoanServiceContext())
                {
                    sc.DemandPermission(Permission.SystemAdmin);

                    return (sc.ctx.Set<Customers>().ToArray());
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
            return (null);
        }


        /* function template
            public x[] x()
            {
                try
                {
                    using (MoanServiceContext sc = new MoanServiceContext())
                    {

                        return ();
                    }
                }
                catch (Exception e)
                {
                    Log.Exception(e);
                }
                return (null);
            }
        */


    }

}