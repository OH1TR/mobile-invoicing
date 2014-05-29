using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using MoinClasses.Tables;

namespace MoinClasses
{
    public class MoanPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        string[] _roles;        

        public MoanPrincipal(string username, bool isAuthenticated, string[] roles,Customers customer)
        {
            Identity = new MoanIdentity("", isAuthenticated, username, customer);
            _roles = roles;
        }

        public bool IsInRole(string role)
        {
            return (_roles.Contains(role));
        }
    }

    public class MoanIdentity : IIdentity
    {
        public Customers Customer { get; private set; }

        public MoanIdentity(string authType, bool isAuthenticated, string name, Customers customer)
        {
            AuthenticationType = authType;
            IsAuthenticated = isAuthenticated;
            Name = name;
            Customer = customer;
        }
        public string AuthenticationType { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public string Name { get; private set; }
    }
  
}
