using GameCenterMVC.Models;
using GameCenterMVC.Models.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GameCenterMVC.DAL
{
    public class ClientDAL : ICrudOperations<Client>
    {
        public int ADD(Client model)
        {

			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Add_Clients", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@name", model.Name);
						cmd.Parameters.AddWithValue("@personalID", model.PersonalID);
						cmd.Parameters.AddWithValue("@lastName", model.LastName);
						cmd.Parameters.AddWithValue("@birthday", model.Birthday);
						cmd.Parameters.AddWithValue("@email", model.Email);
						cmd.Parameters.AddWithValue("@phoneNumber", model.PhoneNumber);
						cmd.Parameters.AddWithValue("@userName", model.Username);
						cmd.Parameters.AddWithValue("@password", model.Password);
						cmd.Parameters.AddWithValue("@balance", model.Balance);
						cmd.Parameters.AddWithValue("@insertBy", model.InsertBy);
						cmd.Parameters.AddWithValue("@insertDate", model.InsertDate);
						cmd.Parameters.AddWithValue("@address", model.Address);
						

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

        public List<Client> GetALL()
        {
			try
			{
				List<Client> clients = null;

				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "GetALL_Client", cmdtype: System.Data.CommandType.StoredProcedure))
					{


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{
								clients = new List<Client>();
								while (reader.Read())
								{

									Client users = new Client();

									users.ClientID = int.Parse(reader["ClientID"].ToString());
									users.Name = reader["Name"].ToString();
									users.LastName = reader["LastName"].ToString();
									users.PersonalID = reader["PersonalID"].ToString();
									users.Address = reader["Adress"].ToString();
									users.Birthday = DateTime.Parse(reader["Birthday"].ToString());
									users.PhoneNumber = reader["PhoneNumber"].ToString();
									users.Email = reader["Email"].ToString();
									users.Username = reader["UserName"].ToString();
									users.Password = reader["Password"].ToString();
									users.Balance = Double.Parse(reader["Balance"].ToString());
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

									clients.Add(users);

								}
							}


						}

					}


				}

				return clients;
			}
			catch (Exception e)
			{
				return null;
			}
		}

        public int Modify(Client model)
        {
            throw new NotImplementedException();
        }

        public int Remove(int ID)
        {
            throw new NotImplementedException();
        }
    }
}