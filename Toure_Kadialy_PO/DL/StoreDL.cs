using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.DL
{
   public class StoreDL
    {
        private readonly SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader sdr;

        /// <summary>
        /// Initialize database connection
        /// </summary>
        public StoreDL()
        {
            con = ConnectDB.getConnection();
        }


        /// <summary>
        /// Get Store list from database
        /// </summary>
        /// <returns>List of stores</returns>
        public List<Store> GetAllStores()
        {
            List<Store> storefronts = new List<Store>();
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "select * from Store";
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    storefronts.Add(new Store { ID=int.Parse(sdr["ID"].ToString()), Name= sdr["Name"].ToString(), Address = sdr["Address"].ToString(), City = sdr["City"].ToString(), State = sdr["State"].ToString()});
                }
                return storefronts!;
            }
        }
        /// <summary>
        /// Add new store into database
        /// </summary>
        /// <param name="store"></param>
        internal void AddStore(Store store)
        {
            cmd = new SqlCommand("Insert into Store values('" + store.Name + "','" + store.Address + "','" + store.City + "','" + store.State + "')", con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Store added successfully!");
            Console.WriteLine("Press any key to go back");
            Console.ReadKey();
        }
        /// <summary>
        /// Get store by store id
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>list of stores.</returns>
        public List<Store> GetStoreById(int storeId)
        {
            List<Store> stores = new List<Store>();
            foreach (Store store in GetAllStores())
            {
                if (store.ID == storeId)
                {
                    stores.Add(store);
                }
            }
            return stores;
        }
    }
}
