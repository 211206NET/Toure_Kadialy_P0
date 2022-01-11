using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.DL
{
    public class CartDL
    {
        private readonly SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader sdr;
      
        public CartDL()
        {
            con = ConnectDB.getConnection();
            
        }
        /// <summary>
        /// Get cart for a customer 
        /// by joining two tables Cart
        /// and Product to get all the product 
        /// details available in the cart table
        /// </summary>
        /// <param name="custId"></param>
        /// <returns>List of cart items</returns>
        public List<Cart> getCartForCustomer(int custId)
        {
            List<Cart> carts = new List<Cart>();
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "select Cart.ID AS ID, Product.ID as ProductId,Name,Cart.Qty as Qty,Price from Cart inner join Product on Cart.ProdId=Product.ID where CustomerId='"+custId+"'";
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    carts.Add(new Cart { ID = int.Parse(sdr["ID"].ToString()), Name = sdr["Name"].ToString(), ProductId = int.Parse(sdr["ProductId"].ToString()), Price = decimal.Parse(sdr["Price"].ToString()), Qty = int.Parse(sdr["Qty"].ToString()) });
                }
                return carts!;
            }
        }

        /// <summary>
        /// Check out to place order
        /// update the order master table 
        /// to capture the order date,
        /// amount and other details
        /// and line items to be inserted into 
        /// LineItem Table in database also 
        /// update product inventory in product
        /// Table based on product id.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="carts"></param>
        public void CheckOut(Customer customer, List<Cart> carts)
        {

            try
            {
                OrderMaster order = new OrderMaster
                {
                    CustomerId = customer.CustomerId,
                    OrderDate = DateTime.Now,
                    OrderAmount = carts.Sum(x => x.Amount)
                };
                cmd = new SqlCommand("Insert into OrderMaster Values('" + order.CustomerId + "','" + order.OrderDate + "','" + order.OrderAmount + "'); SELECT SCOPE_IDENTITY()", con);
                order.OrderId = int.Parse(cmd.ExecuteScalar().ToString());
                foreach (var item in carts)
                {
                    cmd = new SqlCommand("insert into LineItem values('" + order.OrderId + "','" + item.ProductId + "','" + item.Qty + "','" + item.Amount + "'); Update Product Set Qty=Qty-'" + item.Qty + "' where ID='" + item.ProductId + "'", con);
                    cmd.ExecuteNonQuery();
                }
                if (order.OrderId > 0)
                {
                    ClearCart(customer);
                    Console.WriteLine("Order placed successfully!");
                    Console.WriteLine("Pre any key to continue");
                    Console.ReadKey();
                }
            }
            catch(Exception exp)
            {
                
            }

        }

        /// <summary>
        /// Clear user cart by supplying customer object.
        /// </summary>
        /// <param name="customer"></param>
        private void ClearCart(Customer customer)
        {
            cmd = new SqlCommand("DELETE FROM Cart where CustomerId='" + customer.CustomerId + "'", con);
            cmd.ExecuteNonQuery();
        }
    }
}
