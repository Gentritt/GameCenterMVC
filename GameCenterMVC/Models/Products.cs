﻿using System;
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
		public string Name { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		//
	}
}