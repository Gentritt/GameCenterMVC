using GameCenterMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameCenterMVC.Models
{
	public class AuthroizeRoles:AuthorizeAttribute
	{
		ServiceHelper service = new ServiceHelper();
		RolesDAL rolesDAL = new RolesDAL();
		public string userRole { get; set; }
		protected override bool AuthorizeCore(HttpContextBase httpContext)
		{
			var isAuthorized = base.AuthorizeCore(httpContext);
			if (!isAuthorized)
			{
				return false;
			}
			
			string currentuser = httpContext.User.Identity.Name;
			//string[] roles = System.Web.Security.Roles.GetRolesForUser(currentuser);
			var res = rolesDAL.GetRoleName(currentuser);
			string currentUserRoles = res.Name;
			if (this.userRole.Contains(currentUserRoles))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}