using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GameCenterMVC.Resources;

namespace GameCenterMVC.Models
{
	public class Roles:BaseObjectTools
	{

		[Key]
		public int RoleID { get; set; }
		[Display(Name ="Name", ResourceType = typeof(GameCenterMVC.Resources.Roles))]
		[Required(ErrorMessage ="Required")]
		public string Name { get; set; }
		[Display(Name = "Description", ResourceType = typeof(GameCenterMVC.Resources.Roles))]
		[Required(ErrorMessage ="Required")]
		public string Description { get; set; }
	}
}