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
		[Required(ErrorMessage = "Please Enter a Case")]
		public string Case { get; set; }
		[Required(ErrorMessage = "Please Enter a Mouse")]
		public string Mouse { get; set; }
		[Required(ErrorMessage = "Please Enter a KeyBoard")]
		public string KeyBoard { get; set; }
		[Required(ErrorMessage = "Please Enter a HeadSet")]
		public string HeadSet { get; set; }
		[Required(ErrorMessage = "Please Enter a Monitor")]
		public string Monitor { get; set; }
		[Required(ErrorMessage = "Please Enter a MousePad")]
		public string MousePad { get; set; }
		[Required(ErrorMessage = "Please Enter a CPU")]
		public string CPU { get; set; }
		[Required(ErrorMessage = "Please Enter a GPU")]
		public string GPU { get; set; }
		[Required(ErrorMessage = "Please Enter a MotherBoard")]
		public string MotherBoard { get; set; }
		[Required(ErrorMessage = "Please Enter a RAM")]
		public string RAM { get; set; }
		[Required(ErrorMessage = "Please Enter a SSD")]
		public string SSD { get; set; }
		[Required(ErrorMessage = "Please Enter a HDD")]
		public string HDD { get; set; }
		[Required(ErrorMessage = "Please Enter a PSU")]
		public string PSU { get; set; }
		[Required(ErrorMessage = "Please Enter a Cooler")]
		public string Cooler { get; set; }
	}
}