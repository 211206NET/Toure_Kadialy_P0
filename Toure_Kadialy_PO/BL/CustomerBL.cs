using System;
using System.Collections.Generic;
using Toure_Kadialy_P0.BL;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.BL
 {
    public class CustomerBL
    {
        private CustomerRepo _dl;

        public CustomerBL()
        {
            _dl = new CustomerRepo();
        }
        /// <summary>
        /// Gets all Customers
        /// </summary>
        /// <returns>list of all Customers</returns>
        public List<Customer> GetAllCustomer()
        {
            return _dl.GetAllCustomer();

        }
        /// <summary>
        /// Returns a Customer by their id
        /// </summary>
        /// <param name="CustomerID">Customer ID</param>
        /// <returns>Customer object</returns>
        public Customer grabcurrentCustomerwithID(int CustomerID)
        {
            return _dl.getCustomerWithID(CustomerID);
        }
        /// <summary>
        /// Returns a Customer's index by their ID
        /// </summary>
        /// <param name="CustomerID">Customer ID</param>
        /// <returns>index of current Customer</returns>
        public int GetCurrentCustomerIndexByID(int CustomerID)
        {
            return _dl.getCustomerIndexByID(CustomerID);
        }
        /// <summary>
        /// Adds a new Customer to the list
        /// </summary>
        /// <param name="CustomerToAdd">Customer object to add</param>
        public int AddCustomer(Customer CustomerToAdd)
        {
           return _dl.AddCustomer(CustomerToAdd);
        }

        internal void UpdateCustomer(Customer custToUpdate, int customerId)
        {
            _dl.UpdateCustomer(custToUpdate, customerId);
        }
    }
}

