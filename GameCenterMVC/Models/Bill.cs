using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Bill
	{
		[Key]
		public int BillID { get; set; }
		public virtual Client Client { get; set; }
		public virtual Computer Computer { get; set; }
		[DisplayName("Computer ID")]
		public int ComputerID { get; set; }
		public int ClientID { get; set; }
		public virtual Employee Employee { get; set; }
		public int EmployeeID { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public Double Total { get; set; }



	}
}