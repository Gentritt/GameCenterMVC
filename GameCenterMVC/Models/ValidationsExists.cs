using GameCenterMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class ValidationsExists
	{
		public bool ExitsEmployee(string username)
		{
			EmployeeDAL employeeDAL = new EmployeeDAL();
			return employeeDAL.GetALL().Any(x => x.UserName == username);
		}

		public bool ExitsMember(string username)
		{
			ClientDAL clientDAL = new ClientDAL();
			return clientDAL.GetALL().Any(x => x.Username == username);
		}

		public bool ExitsRole(string name)
		{

			return RolesDAL.GetALL().Any(x => x.Name == name);
		}
	}
}