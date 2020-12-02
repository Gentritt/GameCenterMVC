using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCenterMVC.Models.Interface
{
	interface ICrudOperations<T>
	{

		int ADD(T model);
		int Modify(T model);
		int Remove(int ID);
		List<T> Getall();
		
}   } 
