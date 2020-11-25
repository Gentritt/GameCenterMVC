using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Order
	{

		[Key]
		public int OrderID { get; set; }
		public virtual Products Products { get; set; }
		public virtual Bill Bill { get; set; }
		public int Quantity { get; set; }
		public Double Price { get; set; }
	}
}