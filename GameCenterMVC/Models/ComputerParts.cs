using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class ComputerParts: BaseObjectTools
	{
		[Key]
		public int PartID { get; set; }
		public string Case { get; set; }
		public string Mouse { get; set; }
		public string KeyBoard { get; set; }
		public string HeadSet { get; set; }
		public string Monitor { get; set; }
		public string MousePad { get; set; }
		public string CPU { get; set; }
		public string GPU { get; set; }
		public string MotherBoard { get; set; }
		public string RAM { get; set; }
		public string SSD { get; set; }
		public string HDD { get; set; }
		public string PSU { get; set; }
		public string Cooler { get; set; }


	}
}