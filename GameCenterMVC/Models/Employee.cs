using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Employee:BaseObjectTools
	{

		[Key]

		public int EmployeeID { get; set; }
		public string Name { get; set; }
		public virtual Roles Roles { get; set; }
		public string  LastName { get; set; }
		public string PersonalID { get; set; }
		public string Address { get; set; }
		public DateTime Birthday { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string UserName { get; set; }
		public string Password { get; set; }
		public Decimal PayCheck { get; set; }
		public bool IsActive { get; set; }
		public int RoleID { get; set; }
		public DateTime ActiveDate { get; set; }


	}

}