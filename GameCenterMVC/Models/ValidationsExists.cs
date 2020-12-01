using GameCenterMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class ValidationsExists
	{
		public bool Exits(string username)
		{
			EmployeeDAL employeeDAL = new EmployeeDAL();
			return employeeDAL.GetALL().Any(x => x.UserName == username);
		}
	}
}