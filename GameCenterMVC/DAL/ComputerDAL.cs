﻿using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameCenterMVC.DAL
{
	public class ComputerDAL
	{
		public static List<Computer> GetAll()
		{

			try
			{
				List<Computer> computers = null;

				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "Get_ALLComputers", cmdtype: System.Data.CommandType.StoredProcedure))
					{


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{
								computers = new List<Computer>();
								while (reader.Read())
								{
									Computer pc = new Computer();
									pc.ComputerID = int.Parse(reader["ComputerID"].ToString());
									pc.ComputerPartID = int.Parse(reader["PartID"].ToString());
									pc.PricePerHour = double.Parse(reader["PricePerHour"].ToString());
									pc.IsActive = bool.Parse(reader["IsActive"].ToString());
									if (reader["InsertBy"] != DBNull.Value)
										pc.InsertBy = reader["InsertBy"].ToString();
									if (reader["InsertDate"] != DBNull.Value)
										pc.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										pc.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										pc.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());

									computers.Add(pc);

								}
							}


						}

					}


				}

				return computers;
			}
			catch (Exception e)
			{
				return null;
			}
		}

	}
}