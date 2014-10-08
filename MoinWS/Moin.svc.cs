using System;
using System.Linq;
using System.ServiceModel;
using MySql.Data.MySqlClient;
using System.Configuration;
using MoinClasses;
using MoinClasses.Tables;
using System.ServiceModel.Activation;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Data;

namespace MoinWS
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    //[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class MoinWS : IMoinWS
    {
            
        public Customers GetCurrentCustomer()
        {
            try
            {
                using (MoanServiceContext sc = new MoanServiceContext())
                {
                    return (sc.CurrentCustomer);
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
            return (null);
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
                    //sc.DemandPermission(Permission.SystemAdmin);

                    return ((from c in sc.ctx.Customers orderby c.Name select c).ToArray());
                }
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
            return (null);
        }


        public string UpdateCustomer(Customers customer)
        {
            try
            {            
                if (customer==null)
                    Log.WriteLine("Customer is null");

                if (customer.ID == null)
                    Log.WriteLine("customer.ID is null");

                Log.WriteLine(":" + customer.ID.ToString() + ":");
                using (MoanServiceContext sc = new MoanServiceContext())
                {
                    sc.ctx.Database.Log = Log.WriteLine;

                    switch (customer.RowState)
                    {
                        case MoinRowState.New:
                            sc.ctx.Customers.Add(customer);
                            break;
                        case MoinRowState.Updated:
                            sc.ctx.Customers.Attach(customer);
                            sc.ctx.Entry(customer).State = System.Data.Entity.EntityState.Modified;
                            break;
                        case MoinRowState.Deleted:
                            sc.ctx.Customers.Attach(customer);
                            sc.ctx.Entry(customer).State = System.Data.Entity.EntityState.Deleted;
                            break;
                    }
                    sc.ctx.SaveChanges();
                }
                 
            }
            catch (Exception e)
            {
                Log.Exception(e);
            }
            return ("");
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