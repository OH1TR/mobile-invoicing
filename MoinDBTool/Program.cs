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
            Console.WriteLine("R1");            
            string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
            Console.WriteLine("R2");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                Console.WriteLine("R3");
                // Create database if not exists

                
                using (MoinDbContext contextDB = new MoinDbContext(connection, false))
                {
                    Console.WriteLine("R4");
                    contextDB.Database.CreateIfNotExists();
                }
                
            }
        }
    }
}
