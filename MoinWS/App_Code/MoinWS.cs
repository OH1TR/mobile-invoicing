using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using MoinClasses;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class MoinWS : IMoinWS
{
	public Customers[] GetCustomers()
	{
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
        catch(Exception ex)
        {
            System.IO.File.WriteAllText("/tmp/exception.txt", ex.Message + ex.StackTrace + (ex.InnerException!=null ? ex.InnerException.Message : ""));
        }
        return (null);
	}
}
