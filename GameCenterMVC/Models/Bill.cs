using System;
using System.Collections.Generic;
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
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public Double Total { get; set; }



	}
}