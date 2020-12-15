using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Models
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizedUsers : AuthorizeAttribute
    {
        private readonly string[] allowedRoles;
        public AuthorizedUsers(params string[] roles)
        {
            this.allowedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            ServiceHelper securityService = new ServiceHelper();
            bool authorize = false;
            string username = httpContext.User.Identity.Name;
            if (httpContext.User.Identity.IsAuthenticated)
            {
                if (allowedRoles.Count() > 0)
                {
                    var user = securityService.GetUsers(username);
                    if (user == null)
                        return false;
                    foreach (var allowedRole in allowedRoles)
                    {
                        if (user.RoleName == allowedRole)
                        {
                            authorize = true;
                            return true;
                        }
                    }


                    //var dbUser = securityService.GetUsers(getusers);
                    //foreach (var user in allowedRoles)
                    //{
                    //	if (dbUser.UserName.Equals(user))
                    //		authorize = true;
                    //}
                }
            }
            else
                authorize = true;

            return authorize;

        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new ViewResult() { ViewName = "AuthorizeFailed" };
            else
                filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}