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
		public virtual ComputerParts ComputerParts { get; set; }
		public double PricePerHour { get; set; }
		public bool IsActive { get; set; }





	}
}