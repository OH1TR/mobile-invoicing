using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Channels;
using MySql.Data.MySqlClient;
using MoinClasses.Tables;

namespace MoinClasses
{
    public class MoanServiceContext : IDisposable
    {
        public MoinDbContext ctx;

        public Customers CurrentCustomer;

        protected string[] _roles;

        public MoanServiceContext()
        {
            string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];
            MySqlConnection connection = new MySqlConnection(connectionString);
            ctx = new MoinDbContext(connection, false);

            object propObj;
            OperationContext.Current.IncomingMessageProperties.TryGetValue(HttpRequestMessageProperty.Name, out propObj);
            HttpRequestMessageProperty reqProp = (HttpRequestMessageProperty)propObj;
            string headerAuth = reqProp.Headers["Authorization"];
            if(!ProcessAuthenticationHeader(headerAuth))
            {
                throw new Exception("Authentication failed");
            }
        }

        bool ProcessAuthenticationHeader(string header)
        {
            header = header.Trim();
            if (header.IndexOf("Basic", 0) != 0)
            {
                return (false);
            }

            string encodedCredentials = header.Substring(6);

            byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
            string s = System.Text.Encoding.GetEncoding(28591).GetString(decodedBytes);

            string[] userPass = s.Split(new char[] { ':' });
            string username = userPass[0];
            string password = userPass[1];
            string[] roles;

            Customers customer;

            if (AuthenticateUser(username, password, out roles, out customer))
            {
                _roles = roles;
                CurrentCustomer = customer;
                return (true);
            }                
            return (false);                    
        }

        private bool AuthenticateUser(string username, string password, out string[] roles, out Customers customer)
        {
            roles = null;
            customer = null;
   
            try
            {
                string connectionString = ConfigurationManager.AppSettings["SQLConnectionString"];

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MoinDbContext ctx = new MoinDbContext(connection, false))
                    {
                        var users = from u in ctx.Users
                                    where u.Username == username
                                    select u;
                        Users user = users.FirstOrDefault();

                        if (user == null || user.PasswordHash == null || user.PasswordHash.Length < 74)
                            return (false);

                        System.Security.Cryptography.SHA256Managed sha = new System.Security.Cryptography.SHA256Managed();

                        byte[] hashPass = sha.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(user.PasswordHash.Substring(0, 10) + password));

                        if (user.PasswordHash.Substring(10) == BitConverter.ToString(hashPass).Replace("-", String.Empty))
                        {
                            customer = user.Customer;

                            var perms = from u in ctx.Users
                                        where u.Username == username
                                        join ur in ctx.UsersInRoles on u equals ur.User
                                        join r in ctx.Roles on ur.Role equals r
                                        join pr in ctx.PermissionsInRoles on r equals pr.Role
                                        join p in ctx.Permissions on pr.Permission equals p
                                        select p.Name;
                            roles = perms.ToArray();
                            return (true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception(ex);
                return (false);
            }
            return (false);
        }

        public void DemandPermission(string permission)
        {
            if (_roles.Contains(permission))
                return;
            throw new Exception("User not in role " + permission);
        }

        public virtual void Dispose()
        {
            ctx.Dispose();
        }
    }
}
