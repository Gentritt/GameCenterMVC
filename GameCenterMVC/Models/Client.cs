﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Client:BaseObjectTools
	{

		[Key]
		public int ClientID { get; set; }
		public string Name { get; set; }
		public string LastName { get; set; }
		public string PersonalID { get; set; }
		public string Address { get; set; }
		public DateTime Birthday { get; set; }
		public string PhoneNumber { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public Double Balance { get; set; }
		public bool IsActive { get; set; }
		public DateTime ActiveDate { get; set; }

	}
}