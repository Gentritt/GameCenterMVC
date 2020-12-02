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
	public class RolesDAL : Roles, ICrudOperations<Roles>
	{
		public int ADD(Roles model)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Add_Roles", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@roleName", model.Name);
						cmd.Parameters.AddWithValue("@description", model.Description);
						cmd.Parameters.AddWithValue("@insertBy", model.InsertBy);
						cmd.Parameters.AddWithValue("@inserDate", model.InsertDate);

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

		public static List<Roles> GetALL()
		{
			try
			{
				List<Roles> roles = null;
				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText:"Get_allRoles",cmdtype:System.Data.CommandType.StoredProcedure))
					{
						using (SqlDataReader rdr = cmd.ExecuteReader())
						{
							
							if (rdr.HasRows)
							{
								roles = new List<Roles>();
								while (rdr.Read())
								{

								

								Roles role = new Roles();
								role.RoleID = int.Parse(rdr["RoleID"].ToString());
								role.Name = rdr["RoleName"].ToString();
								role.Description = rdr["Description"].ToString();
								  if (rdr["InsertBy"] != DBNull.Value)
									role.InsertBy = rdr["InsertBy"].ToString();
								if (rdr["InsertDate"] != DBNull.Value)
									role.InsertDate = DateTime.Parse(rdr["InsertDate"].ToString());
								if (rdr["UpdateBy"] != DBNull.Value)
									role.UpdateBy = rdr["UpdateBy"].ToString();
								if (rdr["UpdateDate"] != DBNull.Value)
									role.UpdateDate = DateTime.Parse(rdr["UpdateDate"].ToString());
								roles.Add(role);
								}
							}

						}

					}

				}
				return roles;

			}
			catch (Exception e )
			{

				return null;
			}
		}

		public int Modify(Roles model)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Edit_Roles", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@roleid", model.RoleID);
						cmd.Parameters.AddWithValue("@rolename", model.Name);
						cmd.Parameters.AddWithValue("@description", model.Description);
						cmd.Parameters.AddWithValue("@updateby", model.UpdateBy);
						cmd.Parameters.AddWithValue("@updatedate", model.UpdateDate);
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
		public static Roles GetByID(int ID)
		{

			Roles role = null;
			try
			{
				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "GetRoleByID", cmdtype: CommandType.StoredProcedure))
					{

						cmd.Parameters.AddWithValue("@roleid", ID);


						using (SqlDataReader rdr = cmd.ExecuteReader())
						{

							if (rdr.HasRows)
							{

								role = new Roles();
								while (rdr.Read())
								{

									role.RoleID = int.Parse(rdr["RoleID"].ToString());
									role.Name = rdr["RoleName"].ToString();
									role.Description = rdr["Description"].ToString();
									if (rdr["UpdateBy"] != DBNull.Value)
										role.UpdateBy = rdr["UpdateBy"].ToString();
									if (rdr["UpdateDate"] != DBNull.Value)
										role.UpdateDate = DateTime.Parse(rdr["UpdateDate"].ToString());

								}
							}

						}
					}



				}

				return role;

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

					using (var cmd = SqlHelper.Command(conn, cmdText: "Delete_roles", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@roleid", ID);
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


		public List<Roles> Getall()
		{
			throw new NotImplementedException();
		}
	}
}