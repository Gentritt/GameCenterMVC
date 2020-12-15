using GameCenterMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class ServiceHelper
	{
		public bool ValidateUsers(string username, string password)
		{
			EmployeeDAL employee = new EmployeeDAL();
			if (employee.GetALL().Any(c => c.UserName.Equals(username) && c.Password.Equals(password)))
				return true;
				
			else
				return false;
		}
		public Employee GetUsers(string user)
		{
			EmployeeDAL employeeDAL = new EmployeeDAL();
			return employeeDAL.GetALL().Where(x => x.UserName.Equals(user)).FirstOrDefault();
		}
		public Roles GetRoles(string username)
		{
			RolesDAL rolesDAL = new RolesDAL();
			return RolesDAL.GetALL().Where(x => x.Name.Equals(username)).FirstOrDefault();
		}
	}
}