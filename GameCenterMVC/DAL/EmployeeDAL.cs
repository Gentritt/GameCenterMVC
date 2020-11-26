using GameCenterMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameCenterMVC.DAL
{
	public class EmployeeDAL
	{
		public static List<Employee> GetAll()
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
									users.IsActive = bool.Parse(reader["IsActive"].ToString());
									if(reader["ActiveDate"]!= DBNull.Value)
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


	}
}