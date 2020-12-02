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
	public class ProductDAL : Products, ICrudOperations<Products>
	{
		public int ADD(Products model)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Add_Product", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@productName", model.Name);
						cmd.Parameters.AddWithValue("@productPrice", model.Price);
						cmd.Parameters.AddWithValue("@productQuantity", model.Quantity);
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

		public List<Products> GetALL()
		{
			try
			{
				List<Products> products = null;

				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "GetALL_Products", cmdtype: System.Data.CommandType.StoredProcedure))
					{


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{
								products = new List<Products>();
								while (reader.Read())
								{

									Products product = new Products();

									product.ProductID = int.Parse(reader["ProductID"].ToString());
									product.Name = reader["ProductName"].ToString();
									product.Price = double.Parse(reader["ProductPrice"].ToString());
									product.Quantity = int.Parse(reader["ProductQuantity"].ToString());
									if (reader["InsertBy"] != DBNull.Value)
										product.InsertBy = reader["InsertBy"].ToString();
									if (reader["InsertDate"] != DBNull.Value)
										product.InsertDate = DateTime.Parse(reader["InsertDate"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										product.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										product.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());

									products.Add(product);

								}
							}


						}

					}


				}

				return products;
			}
			catch (Exception e)
			{
				return null;
			}
		}

		public int Modify(Products model)
		{
			try
			{
				using (var conn = SqlHelper.GetConnection())
				{

					using (var cmd = SqlHelper.Command(conn, cmdText: "Edit_Product", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@productID", model.ProductID);
						cmd.Parameters.AddWithValue("@productName", model.Name);
						cmd.Parameters.AddWithValue("@productPrice", model.Price);
						cmd.Parameters.AddWithValue("@productQuantity", model.Quantity);
						cmd.Parameters.AddWithValue("@updateBy", model.UpdateBy);
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

		public static Products getByID(int id)
		{
			Products product = null;
			try
			{
				using (var con = SqlHelper.GetConnection())
				{
					using (var cmd = SqlHelper.Command(con, cmdText: "GetProductByID", cmdtype: CommandType.StoredProcedure))
					{

						cmd.Parameters.AddWithValue("@productid", id);


						using (SqlDataReader reader = cmd.ExecuteReader())
						{

							if (reader.HasRows)
							{

								product = new Products();
								while (reader.Read())
								{

									product.ProductID = int.Parse(reader["ProductID"].ToString());
									product.Name = reader["ProductName"].ToString();
									product.Price = double.Parse(reader["ProductPrice"].ToString());
									product.Quantity = int.Parse(reader["ProductQuantity"].ToString());
									if (reader["UpdateBy"] != DBNull.Value)
										product.UpdateBy = reader["UpdateBy"].ToString();
									if (reader["UpdateDate"] != DBNull.Value)
										product.UpdateDate = DateTime.Parse(reader["UpdateDate"].ToString());

								}
							}

						}
					}



				}

				return product;

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

					using (var cmd = SqlHelper.Command(conn, cmdText: "Remove_Products", cmdtype: System.Data.CommandType.StoredProcedure))
					{
						cmd.Parameters.AddWithValue("@productid", ID);
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

		public List<Products> Getall()
		{
			throw new NotImplementedException();
		}
	}
}