using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Models
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
	public class AuthorizedUsers:AuthorizeAttribute
	{
		private readonly string[] AllowedRoles;
		public AuthorizedUsers(params string[] roles)
		{
			this.AllowedRoles = roles;
		}
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			//IPrincipal user = httpContext.User;
			ServiceHelper securityService = new ServiceHelper();
			bool authorize = false;
			string getusers = httpContext.User.Identity.Name;
			if (httpContext.User.Identity.IsAuthenticated)
			{
				if (AllowedRoles.Count() > 0)
				{
					var dbUser = securityService.GetRoles(getusers);
					foreach (var role in AllowedRoles)
					{
						if (dbUser.Name.Equals(role))
							authorize = true;


					}
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