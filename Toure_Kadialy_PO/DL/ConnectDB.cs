using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Toure_Kadialy_P0.DL
{
    public class ConnectDB
    {
        public static string conStr = @"Data Source=.\SQLEXPRESS; Initial Catalog=Store; MultipleActiveResultSets=true;Trusted_Connection=true;";
        public static SqlConnection con;

        /// <summary>
        /// Establish connection with database.
        /// </summary>
        /// <returns>Sqlconnection</returns>
        public static SqlConnection getConnection()
        {
            con = new SqlConnection(conStr);
            try
            {

                if (con.State == ConnectionState.Closed)
                    con.Open();
                return con;
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);                
            }

            return con;
        }

    }
}
