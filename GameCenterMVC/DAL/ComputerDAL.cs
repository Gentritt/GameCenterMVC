﻿using GameCenterMVC.Models;
using GameCenterMVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameCenterMVC.DAL
{
	public class ComputerDAL:Computer, ICrudOperations<Computer>
	{
		public List<Computer> GetALL()
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
									if (reader["IsActive"] != DBNull.Value)
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
		public int IsActive(Computer model)
        {
            try
            {
				using(var conn = SqlHelper.GetConnection())
                {
					using(var cmd= SqlHelper.Command(conn, cmdText: "IsActivePC", cmdtype: System.Data.CommandType.StoredProcedure))
                    {
						cmd.Parameters.AddWithValue("@pcID", model.ComputerID);
						cmd.Parameters.AddWithValue("@isActive", model.IsActive);

						int rowaffected = cmd.ExecuteNonQuery();


						return rowaffected;
					}
                }
            }
			catch (Exception e)
			{

				return -1;
			}
		}
		public int ADD(Computer model)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Add_Computer", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@pricePerHour", model.PricePerHour);
						cmd.Parameters.AddWithValue("@partID", model.ComputerPartID);
						cmd.Parameters.AddWithValue("@insertBy", model.InsertBy);
						cmd.Parameters.AddWithValue("@insertDate", model.InsertDate);
						

						int rowaffected = cmd.ExecuteNonQuery();


						return rowaffected;
					}


				}

			}
			catch (Exception e)
			{

				return -1;
			}
		}

		public int Modify(Computer model)
		{

			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Edit_Computer", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@computerID", model.ComputerID);
						cmd.Parameters.AddWithValue("@pricePerHour", model.PricePerHour);
						cmd.Parameters.AddWithValue("@partID", model.ComputerPartID);
						cmd.Parameters.AddWithValue("@updateBy", model.UpdateBy);
						cmd.Parameters.AddWithValue("@UpdateDate", model.UpdateDate);
						int rowaffected = cmd.ExecuteNonQuery();
						return rowaffected;
					}


				}

			}
			catch (Exception e)
			{

				return -1;
			}
		}
		public static Computer getPcByID(int ID)
		{
			Computer pc = null;
			try
			{
				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "getPcByID", cmdtype: CommandType.StoredProcedure))
					{

						cmd.Parameters.AddWithValue("@computerID", ID);


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{

								pc = new Computer();
								while (reader.Read())
								{

									//Guest guest = new Guest();
									//Employee users = new Employee();

									pc.ComputerID = int.Parse(reader["ComputerID"].ToString());
									pc.ComputerPartID = int.Parse(reader["PartID"].ToString());
									pc.PricePerHour = double.Parse(reader["PricePerHour"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										pc.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										pc.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
								}
							}

						}
					}



				}

				return pc;

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
		public int Remove(int ID)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Delete_Computer", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@computerID", ID);
						int rowaffected = cmd.ExecuteNonQuery();
						return rowaffected;
					}


				}

			}
			catch (Exception e)
			{

				return -1;
			}
		}

		public List<Computer> Getall()
		{
			throw new NotImplementedException();
		}
	}
}