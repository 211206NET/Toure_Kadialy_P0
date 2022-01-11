using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.DL;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.BL
{
   public class StoreBL
    {

        private StoreDL _storeDL;

        public StoreBL()
        {
            _storeDL = new StoreDL();
        }
        /// <summary>
        /// Returns list of available stores in
        /// a database.
        /// </summary>
        /// <returns>List of all stores</returns>
        public List<Store> GetAllStores()
        {
            return _storeDL.GetAllStores();
        }
        /// <summary>
        /// Get a specific store by supplying it's id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of stores.</returns>
        public List<Store> GetStoreById(int id)
        {
            return _storeDL.GetStoreById(id);
        }
        /// <summary>
        /// Add a new store to database.
        /// </summary>
        /// <param name="store"></param>
        internal void AddStore(Store store)
        {
            _storeDL.AddStore(store);
        }
    }
}
