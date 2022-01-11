using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text.Json;
using Toure_Kadialy_P0.DL;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.BL
{
    public class CustomerRepo
    {

        private readonly SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader sdr;

        public CustomerRepo()
        {
            con = ConnectDB.getConnection();
        }


        /// <summary>
        /// Gets all Customers from the database    /// </summary>
        /// <returns>List of all Customers</returns>
        public List<Customer> GetAllCustomer()
        {

            List<Customer> customers = new List<Customer>();
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "Select * from Customer";
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    customers.Add(new Customer { CustomerId = int.Parse(sdr["CustomerId"].ToString()), Name = sdr["Name"].ToString(), Password = sdr["Password"].ToString(), Age = int.Parse(sdr["Age"].ToString()), city = sdr["City"].ToString(), state = sdr["State"].ToString() });
                }
            }
            return customers!;
        }

        /// <summary>
        /// Adds a Customer to the file
        /// </summary>
        /// <param name="CustomerToAdd">Customer object</param>
        public int AddCustomer(Customer CustomerToAdd)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "Insert into Customer Values('" + CustomerToAdd.Name + "','" + CustomerToAdd.Password + "','" + CustomerToAdd.Age + "','" + CustomerToAdd.city + "','" + CustomerToAdd.state + "'); SELECT SCOPE_IDENTITY()";
                cmd.Connection = con;
                int newCustomerId = int.Parse(cmd.ExecuteScalar().ToString());
                Console.WriteLine("Customer added successfully!");
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
                return newCustomerId;
            }
        }
        /// <summary>
        /// Update customer information after login and 
        /// view profile
        /// </summary>
        /// <param name="custToUpdate"></param>
        /// <param name="customerId"></param>
        public void UpdateCustomer(Customer custToUpdate, int customerId)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "Update Customer Set Name='" + custToUpdate.Name + "', Age='" + custToUpdate.Age + "', State='" + custToUpdate.state + "', City='" + custToUpdate.city + "' where CustomerId='"+customerId+"'";
                cmd.Connection = con;
                Console.WriteLine("Profile updated successfully!");
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
              
            }
        }

        /// <summary>
        /// Gets the current Customer by their ID
        /// </summary>
        /// <param name="ID">integer of the Customer's ID</param>
        /// <returns>Customer object</returns>
        public Customer getCustomerWithID(int ID)
        {
            List<Customer> allCustomers = GetAllCustomer();
            Customer currCustomer = new Customer();
            foreach (Customer customer in allCustomers)
            {
                if (customer.CustomerId == ID)
                {
                    currCustomer = customer;
                }
            }
            return currCustomer;
        }
        /// <summary>
        /// Gets the current Customer's index by their ID
        /// </summary>
        /// <param name="ID">integer of the Customer's ID</param>
        /// <returns>Customer's index in list of Customers'</returns>
        public int getCustomerIndexByID(int CustomerID)
        {
            List<Customer> allCustomers = GetAllCustomer();
            int i = 0;
            foreach (Customer customer in allCustomers)
            {
                if (customer.CustomerId == CustomerID)
                {
                    return i;
                }
                i++;
            }
            return 0;
        }



    }
}

