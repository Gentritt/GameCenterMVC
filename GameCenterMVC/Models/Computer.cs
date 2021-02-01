using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Computer: BaseObjectTools
	{
		[Key]
		public int ComputerID { get; set; }
		[Required(ErrorMessage = "Required!")]
		public int ComputerPartID { get; set; }
		public virtual ComputerParts ComputerParts { get; set; }
		[Display(Name = "PricePerHour", ResourceType = typeof(GameCenterMVC.Resources.Computers))]
		[Required(ErrorMessage ="Required!")]
		//[RegularExpression("^[0-9]*$", ErrorMessage = "PricePerHour must be numeric")]
		public double PricePerHour { get; set; }
		public bool IsActive { get; set; }





	}
}