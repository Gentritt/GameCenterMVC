using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using GameCenterMVC.Resources;

namespace GameCenterMVC.Models
{
	public class Client:BaseObjectTools
	{

		[Key]
		public int ClientID { get; set; }
		[Display(Name ="Name",ResourceType = typeof(Clients) )]
		[Required(ErrorMessage = "Please Enter a Name")]
		public string Name { get; set; }
		[Display(Name = "LastName", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter a LastName")]
		public string LastName { get; set; }
		[Display(Name = "PersonalID", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter a Personal ID")]
		[MaxLength(11)]
		[MinLength(11)]	
		[RegularExpression("^[0-9]*$", ErrorMessage = "PersonalID must be numeric")]
		public string PersonalID { get; set; }
		[Display(Name = "Address", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter a Address")]
		public string Address { get; set; }
		[Display(Name = "Birthday", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter Birthday")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		//[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }
		[Display(Name = "PhoneNumber", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter PhoneNumber")]
		//[DataType(DataType.PhoneNumber)]
		//[RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
		[RegularExpression(@"^[0-9]{9,15}$", ErrorMessage ="Please enter a valid phone number")]
		public string PhoneNumber { get; set; }
		[Display(Name = "Email", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter Email")]
		[EmailAddress(ErrorMessage ="Invalid Email")]
		public string Email { get; set; }
		[Display(Name = "Username", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter Username")]	
		public string Username { get; set; }
		[Display(Name = "Password", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter Password")]
		public string Password { get; set; }
		[Display(Name = "Balance", ResourceType = typeof(Clients))]
		[Required(ErrorMessage = "Please Enter Balance")]
		public Double Balance { get; set; }
		public bool IsActive { get; set; }
		public DateTime ActiveDate { get; set; }

	}
}