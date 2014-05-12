using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using MoinClasses;

namespace MoinDBTool
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Create database if not exists

                using (MoinDbContext contextDB = new MoinDbContext(connection, false))
                {
                    contextDB.Database.CreateIfNotExists();
                }
            }
        }
    }
}
