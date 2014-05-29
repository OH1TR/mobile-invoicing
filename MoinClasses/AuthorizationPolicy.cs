using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Policy;
using System.Security.Principal;
using System.Web;

namespace MoinClasses
{   
    //**************************************************************
    //Unused code. Mono does not support this?
    //**************************************************************
    /*
    public class AuthorizationPolicy : IAuthorizationPolicy
    {
        string id = Guid.NewGuid().ToString();

        public string Id
        {
            get { return this.id; }
        }

        public System.IdentityModel.Claims.ClaimSet Issuer
        {
            get { return System.IdentityModel.Claims.ClaimSet.System; }
        }

        // this method gets called after the authentication stage
        public bool Evaluate(EvaluationContext evaluationContext, ref object state)
        {
            // get the authenticated client identity
            //IIdentity client = HttpContext.Current.User.Identity;

            // set the custom principal
            evaluationContext.Properties["Principal"] = HttpContext.Current.User;

            return true;
        }
    }  
     */
}
