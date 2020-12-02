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
		private readonly string[] AllowedUsers;
		public AuthorizedUsers(params string[] users)
		{
			this.AllowedUsers = users;
		}
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			//IPrincipal user = httpContext.User;
			ServiceHelper securityService = new ServiceHelper();
			bool authorize = false;
			string getusers = httpContext.User.Identity.Name;
			if (httpContext.User.Identity.IsAuthenticated)
			{
				if (AllowedUsers.Count() > 0)
				{
					var dbUser = securityService.GetUsers(getusers);
					foreach (var user in AllowedUsers)
					{
						if (dbUser.UserName.Equals(user))
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