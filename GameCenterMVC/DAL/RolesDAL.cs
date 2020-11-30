using GameCenterMVC.Models;
using GameCenterMVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameCenterMVC.DAL
{
	public class RolesDAL : ICrudOperations<Roles>
	{
		public int ADD(Roles model)
		{
			throw new NotImplementedException();
		}

		public List<Roles> GetALL()
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
			throw new NotImplementedException();
		}

		public int Remove(int ID)
		{
			throw new NotImplementedException();
		}
	}
}