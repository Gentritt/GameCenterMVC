using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using GameCenterMVC.Resources;

namespace GameCenterMVC.Models
{
	public class Employee:BaseObjectTools
	{

		[Key]
		public int EmployeeID { get; set; }
		[Display(Name = "Name", ResourceType = typeof(Employees))]
		[Required(ErrorMessage="Please Enter a Name")]
		public string Name { get; set; }
		[Display(Name ="RoleName", ResourceType = typeof(Employees))]
		public string RoleName { get; set; }
		public virtual Roles Roles { get; set; }
		[Display(Name ="LastName", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please enter a LastName")]
		public string  LastName { get; set; }
		[Display(Name = "PersonalID", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please Enter your PersonalID")]
		[MaxLength(11)]
		[MinLength(11)]
		[RegularExpression("^[0-9]*$", ErrorMessage = "PersonalID must be numeric")]
		public string PersonalID { get; set; }
		[Display(Name = "Address", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please enter the Address")]
		public string Address { get; set; }
		[Required(ErrorMessage ="Please Enter Birthday")]
		[Display(Name = "Birthday", ResourceType = typeof(Employees))]
		[DisplayFormat(DataFormatString ="{0:MM/dd/yyyy}")]
		public DateTime Birthday { get; set; }
		[Display(Name = "PhoneNumber", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please Enter PhoneNumber")]
		[DataType(DataType.PhoneNumber)]
		[RegularExpression(@"^[0-9]{9,15}$", ErrorMessage = "Please enter a valid phone number")]
		public string PhoneNumber { get; set; }
		[Display(Name = "Email", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please Enter Email")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }
		[Display(Name = "UserName", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please Enter Username")]
		
		public string UserName { get; set; }
		[Display(Name = "Password", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please Enter Password")]
		public string Password { get; set; }
		[NotMapped]
		//[Compare("Password", ErrorMessage ="The passwords are not the same")]
		public string ConfirmPassword { get; set; }
		[Display(Name = "PayCheck", ResourceType = typeof(Employees))]
		[Required(ErrorMessage ="Please Enter PayCheck")]
		public Decimal PayCheck { get; set; }
		public bool IsActive { get; set; }
		public int RoleID { get; set; }
		public DateTime ActiveDate { get; set; }


	}

}