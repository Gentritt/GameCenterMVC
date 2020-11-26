using GameCenterMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class ValidateUser
	{

		public bool ValidateUsers(string username, string password)
		{
			if  (EmployeeDAL.GetAll().Any(c => c.UserName == username && c.Password == password))
				return true;
				
			else
				return false;
		}
	}
}