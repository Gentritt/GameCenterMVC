using GameCenterMVC.Models;
using GameCenterMVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameCenterMVC.DAL
{
	public class ComputerPartsDAL 
	{

		public int ADD(ComputerParts model)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Add_ComputerParts", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@case", model.Case);
						cmd.Parameters.AddWithValue("@mouse", model.Mouse);
						cmd.Parameters.AddWithValue("@keyboard", model.KeyBoard);
						cmd.Parameters.AddWithValue("@headset", model.HeadSet);
						cmd.Parameters.AddWithValue("@monitor", model.Monitor);
						cmd.Parameters.AddWithValue("@mousepad", model.MousePad);
						cmd.Parameters.AddWithValue("@cpu", model.CPU);
						cmd.Parameters.AddWithValue("@gpu", model.GPU);
						cmd.Parameters.AddWithValue("@motherboard", model.MotherBoard);
						cmd.Parameters.AddWithValue("@ram", model.RAM);
						cmd.Parameters.AddWithValue("@ssd", model.SSD);
						cmd.Parameters.AddWithValue("@hdd", model.HDD);
						cmd.Parameters.AddWithValue("@psu", model.PSU);
						cmd.Parameters.AddWithValue("@cooler", model.Cooler);
						cmd.Parameters.AddWithValue("@insertby", model.InsertBy);
						cmd.Parameters.AddWithValue("@insertdate", model.InsertDate);

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

		public static  List<ComputerParts> GetALL()
		{
			try
			{
				List<ComputerParts> pcParts = null;

				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "GetAll_ComputerParts", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{
								pcParts = new List<ComputerParts>();
								while (reader.Read())
								{

									ComputerParts parts = new ComputerParts();


									parts.PartID = int.Parse(reader["PartID"].ToString());
									parts.Case = reader["Case"].ToString();
									parts.Mouse = reader["Mouse"].ToString();
									parts.KeyBoard = reader["Keyboard"].ToString();
									parts.HeadSet = reader["HeadSet"].ToString();
									parts.Monitor = reader["Monitor"].ToString();
									parts.MousePad = reader["MousePad"].ToString();
									parts.CPU = reader["CPU"].ToString();
									parts.GPU = reader["GPU"].ToString();
									parts.MotherBoard = reader["Motherboard"].ToString();
									parts.RAM = reader["RAM"].ToString();
									parts.SSD = reader["SSD"].ToString();
									parts.HDD = reader["HDD"].ToString();
									parts.PSU = reader["PSU"].ToString();
									parts.Cooler = reader["Cooler"].ToString();
									if (reader["InsertBy"] != DBNull.Value)
										parts.InsertBy = reader["InsertBy"].ToString();
									if (reader["InsertDate"] != DBNull.Value)
										parts.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										parts.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										parts.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());

									pcParts.Add(parts);

								}
							}


						}

					}


				}

				return pcParts;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public int Modify(ComputerParts model)
		{

			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Edit_ComputerParts", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@partID", model.PartID);
						cmd.Parameters.AddWithValue("@case", model.Case);
						cmd.Parameters.AddWithValue("@mouse", model.Mouse);
						cmd.Parameters.AddWithValue("@keyboard", model.KeyBoard);
						cmd.Parameters.AddWithValue("@headset", model.HeadSet);
						cmd.Parameters.AddWithValue("@monitor", model.Monitor);
						cmd.Parameters.AddWithValue("@mousepad", model.MousePad);
						cmd.Parameters.AddWithValue("@cpu", model.CPU);
						cmd.Parameters.AddWithValue("@gpu", model.GPU);
						cmd.Parameters.AddWithValue("@motherboard", model.MotherBoard);
						cmd.Parameters.AddWithValue("@ram", model.RAM);
						cmd.Parameters.AddWithValue("@ssd", model.SSD);
						cmd.Parameters.AddWithValue("@hdd", model.HDD);
						cmd.Parameters.AddWithValue("@psu", model.PSU);
						cmd.Parameters.AddWithValue("@cooler", model.Cooler);
						cmd.Parameters.AddWithValue("@updatebBy", model.UpdateBy);
						cmd.Parameters.AddWithValue("@updateDate", model.UpdateDate);
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

		public static ComputerParts GetByID(int id)
		{
			ComputerParts parts = null;
			try
			{
				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "getPcPartsByID", cmdtype: CommandType.StoredProcedure))
					{

						cmd.Parameters.AddWithValue("@partID", id);


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{

								parts = new ComputerParts();
								while (reader.Read())
								{

									//Guest guest = new Guest();
									//Employee users = new Employee();

									parts.PartID = int.Parse(reader["PartID"].ToString());
									parts.Case = reader["Case"].ToString();
									parts.Mouse = reader["Mouse"].ToString();
									parts.KeyBoard = reader["Keyboard"].ToString();
									parts.HeadSet = reader["HeadSet"].ToString();
									parts.Monitor = reader["Monitor"].ToString();
									parts.MousePad = reader["MousePad"].ToString();
									parts.CPU = reader["CPU"].ToString();
									parts.GPU = reader["GPU"].ToString();
									parts.MotherBoard = reader["Motherboard"].ToString();
									parts.RAM = reader["RAM"].ToString();
									parts.SSD = reader["SSD"].ToString();
									parts.HDD = reader["HDD"].ToString();
									parts.PSU = reader["PSU"].ToString();
									parts.Cooler = reader["Cooler"].ToString();
										parts.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										parts.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										parts.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());
								}
							}

						}
					}



				}

				return parts;

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

					using (var cmd = SqlHelper.Command(conn, cmdText: "Remove_PcParts", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@partID", ID);
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
	
	}
}