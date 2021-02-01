using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GameCenterMVC.Resources;

namespace GameCenterMVC.Models
{
	public class ComputerParts: BaseObjectTools
	{
		[Key]
		public int PartID { get; set; }
		[Display(Name = "Case", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a Case")]
		public string Case { get; set; }
		[Display(Name = "Mouse", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a Mouse")]
		public string Mouse { get; set; }
		[Display(Name = "KeyBoard", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a KeyBoard")]
		public string KeyBoard { get; set; }
		[Display(Name = "HeadSet", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a HeadSet")]
		public string HeadSet { get; set; }
		[Display(Name = "Monitor", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a Monitor")]
		public string Monitor { get; set; }
		[Display(Name = "MousePad", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a MousePad")]
		public string MousePad { get; set; }
		[Display(Name = "CPU", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a CPU")]
		public string CPU { get; set; }
		[Display(Name = "GPU", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a GPU")]
		public string GPU { get; set; }
		[Display(Name = "MotherBoard", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a MotherBoard")]
		public string MotherBoard { get; set; }
		[Display(Name = "RAM", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a RAM")]
		public string RAM { get; set; }
		[Display(Name = "SSD", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a SSD")]
		public string SSD { get; set; }
		[Display(Name = "HDD", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a HDD")]
		public string HDD { get; set; }
		[Display(Name = "PSU", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a PSU")]
		public string PSU { get; set; }
		[Display(Name = "Cooler", ResourceType = typeof(GameCenterMVC.Resources.ComputerParts))]
		[Required(ErrorMessage = "Please Enter a Cooler")]
		public string Cooler { get; set; }
	}
}