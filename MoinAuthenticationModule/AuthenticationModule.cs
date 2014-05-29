using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using MoinClasses;
using MoinClasses.Tables;

namespace MoinAuthenticationModule
{
    public class AuthenticationModule : IHttpModule
    {
        public AuthenticationModule()
		{
		}

		public void Dispose()
		{
		}

        public void Init(HttpApplication application)
        {
            application.AuthenticateRequest += new EventHandler(this.OnAuthenticateRequest);
            application.EndRequest += new EventHandler(this.OnEndRequest);
        }

        public void OnAuthenticateRequest(object source, EventArgs eventArgs)
        {
            HttpApplication app = (HttpApplication)source;

            string authStr = app.Request.Headers["Authorization"];

            if (authStr == null || authStr.Length == 0)
            {
                DenyAccess(app);
                return;
            }

            authStr = authStr.Trim();
            if (authStr.IndexOf("Basic", 0) != 0)
            {
                // Don't understand this header...we'll pass it along and 
                // assume someone else will handle it
                return;
            }

            string encodedCredentials = authStr.Substring(6);

            byte[] decodedBytes = Convert.FromBase64String(encodedCredentials);
            string s = System.Text.Encoding.GetEncoding(28591).GetString(decodedBytes);

            string[] userPass = s.Split(new char[] { ':' });
            string username = userPass[0];
            string password = userPass[1];
            string[] roles;
            string customerName;
            Customers customer;

            if (AuthenticateUser(app, username, password, out roles, out customerName, out customer))
            {
                app.Context.User = new MoanPrincipal(username, true, roles,customer);
                HttpContext.Current.User = app.Context.User;
                return;
            }
            else
            {
                // Invalid credentials; deny access
                DenyAccess(app);
                return;
            }
        }
        public void OnEndRequest(object source, EventArgs eventArgs)
        {
            // We add the WWW-Authenticate header here, so if an authorization 
            // fails elsewhere than in this module, we can still request authentication 
            // from the client.

            HttpApplication app = (HttpApplication)source;
            if (app.Response.StatusCode == 401)
            {
                string realm = "Realm";
                string val = String.Format("Basic Realm=\"{0}\"", realm);
                app.Response.AppendHeader("WWW-Authenticate", val);
            }
        }

        private void DenyAccess(HttpApplication app)
        {
            app.Response.StatusCode = 401;
            app.Response.StatusDescription = "Access Denied";
            //app.Response.SuppressFormsAuthenticationRedirect = true;

            // Write to response stream as well, to give user visual 
            // indication of error during development
            app.Response.Write("401 Access Denied");

            app.CompleteRequest();
        }

        //insert into Users values('F61A2DAF-27D9-41BD-9329-B531F351FC1F','tommi','          000D8D505EC0FD237133622D1A3A01D6E60DC810F986D972D80461A7CF5D605C');
        //U:tommi P:123

        private bool AuthenticateUser(HttpApplication app,string username,string password,out string[] roles,out string customerRID,out Customers customer)
        {
            roles = null;
            customer = null;
            customerRID = "";
            //return (true);
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
                        Users user=users.FirstOrDefault();

                        if (user==null || user.PasswordHash==null || user.PasswordHash.Length < 74)
                            return (false);

                        System.Security.Cryptography.SHA256Managed sha=new System.Security.Cryptography.SHA256Managed();

                        byte[] hashPass = sha.ComputeHash(System.Text.UnicodeEncoding.Unicode.GetBytes(user.PasswordHash.Substring(0,10)+password));

                        if(user.PasswordHash.Substring(10)==BitConverter.ToString(hashPass).Replace("-",String.Empty))
                        {
                            customer = user.Customer;

                            var perms = from u in ctx.Users
                                        where u.Username == username
                                        join ur in ctx.UsersInRoles on u equals ur.User
                                        join r in ctx.Roles on ur.Role equals r
                                        join pr in ctx.PermissionsInRoles on r equals pr.Role
                                        join p in ctx.Permissions on pr.Permission equals p
                                        select p.Name ;                
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
    }
}
