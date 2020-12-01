using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameCenterMVC.Models
{
	public class Products: BaseObjectTools
	{

		[Key]
		public int ProductID { get; set; }
		[Required(ErrorMessage = "Please Enter a Name")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Please Enter a Price")]
		public double Price { get; set; }
		[Required(ErrorMessage = "Please Enter a Quantity")]
		public int Quantity { get; set; }
		//
	}
}