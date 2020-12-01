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
	public class EmployeeDAL: ICrudOperations<Employee>
	{
		public  List<Employee> GetALL()
		{

			try
			{
				List<Employee> employees = null;

				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "GetALL_Employess", cmdtype: System.Data.CommandType.StoredProcedure))
					{


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{
								employees = new List<Employee>();
								while (reader.Read())
								{

									Employee users = new Employee();

									users.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
									users.Name = reader["Name"].ToString();
									users.LastName = reader["LastName"].ToString();
									users.RoleID =int.Parse(reader["RoleID"].ToString());
									users.PersonalID = reader["PersonalID"].ToString();
									users.Address = reader["Adress"].ToString();
									users.Birthday = DateTime.Parse(reader["Birthday"].ToString());
									users.PhoneNumber = reader["PhoneNumber"].ToString();
									users.Email = reader["Email"].ToString();
									users.UserName = reader["UserName"].ToString();
									users.Password = reader["Password"].ToString();
									users.PayCheck = Decimal.Parse( reader["PayCheck"].ToString());
									if(reader["IsActive"]!= DBNull.Value)
									    users.IsActive = bool.Parse(reader["IsActive"].ToString());
									if (reader["ActiveDate"]!= DBNull.Value)
										users.ActiveDate = DateTime.Parse(reader["ActiveDate"].ToString());
									if (reader["InsertBy"] != DBNull.Value)
										users.InsertBy = reader["InsertBy"].ToString();
									if (reader["InsertDate"] != DBNull.Value)
										users.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										users.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										users.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());

									employees.Add(users);

								}
							}


						}

					}


				}

				return employees;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public int ADD(Employee model)
		{
		
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Add_Employee" , cmdtype:System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@name", model.Name);
						cmd.Parameters.AddWithValue("@personalID", model.PersonalID);
						cmd.Parameters.AddWithValue("@lastName", model.LastName);
						cmd.Parameters.AddWithValue("@birthday", model.Birthday);
						cmd.Parameters.AddWithValue("@email", model.Email);
						cmd.Parameters.AddWithValue("@phoneNumber", model.PhoneNumber);
						cmd.Parameters.AddWithValue("@userName", model.UserName);
						cmd.Parameters.AddWithValue("@password", model.Password);
						cmd.Parameters.AddWithValue("@payCheck", model.PayCheck);
						cmd.Parameters.AddWithValue("@insertBy", model.InsertBy);
						cmd.Parameters.AddWithValue("@insertDate", model.InsertDate);
						cmd.Parameters.AddWithValue("@adress", model.Address);
						cmd.Parameters.AddWithValue("@roleID", model.RoleID);

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

		public int Modify(Employee model)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Edit_Employee", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@employeeID", model.EmployeeID);
						cmd.Parameters.AddWithValue("@name", model.Name);
						cmd.Parameters.AddWithValue("@personalID", model.PersonalID);
						cmd.Parameters.AddWithValue("@lastName", model.LastName);
						cmd.Parameters.AddWithValue("@birthday", model.Birthday);
						cmd.Parameters.AddWithValue("@email", model.Email);
						cmd.Parameters.AddWithValue("@phoneNumber", model.PhoneNumber);
						cmd.Parameters.AddWithValue("@userName", model.UserName);
						cmd.Parameters.AddWithValue("@password", model.Password);
						cmd.Parameters.AddWithValue("@payCheck", model.PayCheck);
						cmd.Parameters.AddWithValue("@updateBy", model.UpdateBy);
						cmd.Parameters.AddWithValue("@updateDate", model.UpdateDate);
						cmd.Parameters.AddWithValue("@adress", model.Address);
						cmd.Parameters.AddWithValue("@roleID", model.RoleID);

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

		public int Remove(int ID)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Remove_Employee", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@employeid", ID);
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

		public static Employee GetByID(int id)
		{
			Employee users = null;
			try
			{
				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "getEmployeByID", cmdtype: CommandType.StoredProcedure))
					{

						cmd.Parameters.AddWithValue("@employeid", id);


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{

								users = new Employee();
								while (reader.Read())
								{

									//Guest guest = new Guest();
									//Employee users = new Employee();

									users.EmployeeID = int.Parse(reader["EmployeeID"].ToString());
									users.Name = reader["Name"].ToString();
									users.LastName = reader["LastName"].ToString();
									users.RoleID = int.Parse(reader["RoleID"].ToString());
									users.PersonalID = reader["PersonalID"].ToString();
									users.Address = reader["Adress"].ToString();
									users.Birthday = DateTime.Parse(reader["Birthday"].ToString());
									users.PhoneNumber = reader["PhoneNumber"].ToString();
									users.Email = reader["Email"].ToString();
									users.UserName = reader["UserName"].ToString();
									users.Password = reader["Password"].ToString();
									users.PayCheck = Decimal.Parse(reader["PayCheck"].ToString());
									if (reader["IsActive"] != DBNull.Value)
										users.IsActive = bool.Parse(reader["IsActive"].ToString());
									if (reader["ActiveDate"] != DBNull.Value)
										users.ActiveDate = DateTime.Parse(reader["ActiveDate"].ToString());
									if (reader["InsertBy"] != DBNull.Value)
										users.InsertBy = reader["InsertBy"].ToString();
									if (reader["InsertDate"] != DBNull.Value)
										users.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										users.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										users.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());

								}
							}

						}
					}



				}

				return users;

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}

		}
	}

	//public List<Employee> GetALL()
	//{
	//	throw new NotImplementedException();
	//}
}

	
