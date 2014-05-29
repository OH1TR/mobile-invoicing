using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using MoinClasses;
using MoinClasses.Tables;

namespace MoinDBTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("R1");
                string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
                Console.WriteLine("R2");
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    Console.WriteLine("R3");
                    // Create database if not exists


                    using (MoinDbContext ctx = new MoinDbContext(connection, false))
                    {
                        Console.WriteLine("R4");
                        ctx.Database.CreateIfNotExists();

                        if (ctx.Customers.Count() == 0)
                        {
                            //insert into Users values('F61A2DAF-27D9-41BD-9329-B531F351FC1F','tommi','          000D8D505EC0FD237133622D1A3A01D6E60DC810F986D972D80461A7CF5D605C');
                            Customers c = new Customers() { Name = "System owner company" };
                            Roles r = new Roles() { Name = "Administrators" };
                            Users u = new Users() { Username = "admin", PasswordHash = "          000D8D505EC0FD237133622D1A3A01D6E60DC810F986D972D80461A7CF5D605C", Customer = c };
                            Permissions p1 = new Permissions() { Name = "ManageUsers" };
                            Permissions p2 = new Permissions() { Name = "Developer" };
                            PermissionsInRoles pr1 = new PermissionsInRoles() { Permission = p1, Role = r };
                            PermissionsInRoles pr2 = new PermissionsInRoles() { Permission = p2, Role = r };
                            UsersInRoles ur = new UsersInRoles() { User = u, Role = r };
                            ctx.Customers.Add(c);
                            ctx.Permissions.Add(p1);
                            ctx.Permissions.Add(p2);
                            ctx.Roles.Add(r);
                            ctx.PermissionsInRoles.Add(pr1);
                            ctx.PermissionsInRoles.Add(pr2);
                            ctx.UsersInRoles.Add(ur);
                            ctx.Users.Add(u);
                            ctx.SaveChanges();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
            }
        }
    }
}
