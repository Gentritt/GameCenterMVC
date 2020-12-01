using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Client:BaseObjectTools
	{

		[Key]
		public int ClientID { get; set; }
		[Required(ErrorMessage = "Please Enter a Name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please Enter a LastName")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Please Enter a Personal ID")]
		[MaxLength(11)]
		[MinLength(11)]
		public string PersonalID { get; set; }
		[Required(ErrorMessage = "Please Enter a Address")]
		public string Address { get; set; }
		[Required(ErrorMessage = "Please Enter Birthday")]
		[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
		[DataType(DataType.Date)]
		public DateTime Birthday { get; set; }
		[Required(ErrorMessage = "Please Enter PhoneNumber")]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage = "Please Enter Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please Enter Username")]
		public string Username { get; set; }
		[Required(ErrorMessage = "Please Enter Password")]
		public string Password { get; set; }
		[Required(ErrorMessage = "Please Enter Balance")]
		public Double Balance { get; set; }
		public bool IsActive { get; set; }
		public DateTime ActiveDate { get; set; }

	}
}