using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public  class StaticCLass
	{
		[DisplayName("ComputerID")]
		public static int ComputerID { get; set; }
		public static int EmployeeID { get; set; }
	}
}