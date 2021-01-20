using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GameCenterMVC.Models.Interface;
using GameCenterMVC.Models;
using System.Data.SqlClient;

namespace GameCenterMVC.DAL
{
	public class BillsDAL : ICrudOperations<Bill>
	{
		public int ADD(Bill model)
		{
			throw new NotImplementedException();
		}

		public List<Bill> Getall()
		{
			try
			{
				List<Bill> bill = null;

				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "Bill_getALL", cmdtype: System.Data.CommandType.StoredProcedure))
					{


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{
								bill = new List<Bill>();
								while (reader.Read())
								{

									Bill bill1 = new Bill();

									bill1.BillID = int.Parse(reader["BillID"].ToString());
									bill1.ComputerID =int.Parse( reader["ComputerID"].ToString());
									bill1.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
									bill1.StartTime = DateTime.Parse(reader["StartTime"].ToString());
									bill1.EndTime = DateTime.Parse(reader["EndTime"].ToString());
									bill1.Total = Double.Parse(reader["Total"].ToString());

									bill.Add(bill1);

								}
							}


						}

					}


				}

				return bill;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public int Modify(Bill model)
		{
			throw new NotImplementedException();
		}

		public int Remove(int ID)
		{
			throw new NotImplementedException();
		}
	}
}