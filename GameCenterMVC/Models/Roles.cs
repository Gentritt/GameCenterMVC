using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Roles:BaseObjectTools
	{

		[Key]
		public int RoleID { get; set; }
		[Required(ErrorMessage ="Required")]
		public string Name { get; set; }
		[Required(ErrorMessage ="Required")]
		public string Description { get; set; }
	}
}