using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace GameCenterMVC.DAL
{
	public class SqlHelper
	{

		private static string _connection = ConfigurationManager.ConnectionStrings["GameCenter"].ConnectionString;

		public static SqlConnection GetConnection()
		{

			try
			{
				SqlConnection conn = new SqlConnection(_connection);
				conn.Open();
				return conn;
			}
			catch (Exception e)
			{

				Console.WriteLine(e);
				throw;
			}
		}

		public static SqlCommand Command(SqlConnection conn, string cmdText, CommandType cmdtype = CommandType.StoredProcedure)
		{
			SqlCommand command = new SqlCommand(cmdText, conn);
			command.CommandType = CommandType.StoredProcedure;
			return command;
		}
	}
}