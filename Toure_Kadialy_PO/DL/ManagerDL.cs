using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toure_Kadialy_P0.DL
{
    public class ManagerDL
    {
        private readonly SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader sdr;
        public ManagerDL()
        {
            con = ConnectDB.getConnection();
        }
        /// <summary>
        /// check if the manager details exists in database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>return true or false.</returns>
        public bool IsManagerExists(string username, string password)
        {
            cmd = new SqlCommand("Select * from Manager where Name='" + username + "' and Password='" + password + "'",con);
            sdr = cmd.ExecuteReader();
            //if there is enough rows in reader it means
            //details entered by manager is correct return true.
            if (sdr.HasRows)
                return true;
            else 
                return false;
        }
    }
}
