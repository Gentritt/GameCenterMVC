using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Login
	{

		[Required(ErrorMessage ="Username is Required")]
		public string Username { get; set; }
		[Required(ErrorMessage ="Password is Required")]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}