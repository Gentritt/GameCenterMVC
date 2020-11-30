using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Employee:BaseObjectTools
	{

		[Key]
		public int EmployeeID { get; set; }
		[Required(ErrorMessage="Please Enter a Name")]
		public string Name { get; set; }
		public virtual Roles Roles { get; set; }
		[Required(ErrorMessage ="Please enter a LastName")]
		public string  LastName { get; set; }
		[Required(ErrorMessage ="Please Enter your PersonalID")]
		public string PersonalID { get; set; }
		[Required(ErrorMessage ="Please enter the Address")]
		public string Address { get; set; }
		[Required(ErrorMessage ="Please Enter Birthday")]
		[DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
		public DateTime Birthday { get; set; }
		[Required(ErrorMessage ="Please Enter PhoneNumber")]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage ="Please Enter Email")]
		public string Email { get; set; }
		[Required(ErrorMessage ="Please Enter Username")]
		
		public string UserName { get; set; }
		[Required(ErrorMessage ="Please Enter Password")]
		public string Password { get; set; }
		[NotMapped]
		[Compare("Password", ErrorMessage ="The passwords are not the same")]
		public string ConfirmPassword { get; set; }
		[Required(ErrorMessage ="Please Enter PayCheck")]
		public Decimal PayCheck { get; set; }
		public bool IsActive { get; set; }
		public int RoleID { get; set; }
		public DateTime ActiveDate { get; set; }


	}

}