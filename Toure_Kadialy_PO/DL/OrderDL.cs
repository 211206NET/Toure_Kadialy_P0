using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.DL
{
   public class OrderDL
    {
        private readonly SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader sdr;
        /// <summary>
        /// Initialize Connection with database
        /// </summary>
        public OrderDL()
        {
            con = ConnectDB.getConnection();
        }
        /// <summary>
        /// Get all orders available in database
        /// </summary>
        /// <returns>List of orders.</returns>
        public List<OrderMaster> GetOrders()
        {
            List<OrderMaster> orders = new List<OrderMaster>();
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "select OrderMaster.*,Name from OrderMaster inner join Customer on OrderMaster.CustomerId=Customer.CustomerId ";
                cmd.Connection = con;
               SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = int.Parse(dr["OrderId"].ToString());
                    orders.Add(new OrderMaster {  OrderId =id, CustomerId = int.Parse(dr["CustomerId"].ToString()),CustomerName= dr["Name"].ToString(), OrderDate =DateTime.Parse(dr["OrderDate"].ToString()), OrderAmount = decimal.Parse(dr["OrderAmount"].ToString()),LineItems=GetLineItemsForOrder(id)});
                }
                return orders!;
            }
        }
        /// <summary>
        /// Get orders of specific customer
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>List of orders</returns>
        public List<OrderMaster> GetOrders(int customerId)
        {
            List<OrderMaster> orders = new List<OrderMaster>();
            foreach (var item in GetOrders())
            {
                if (item.CustomerId == customerId)
                    orders.Add(item);
            }
            return orders;
        }
        /// <summary>
        /// Get all line items in specific order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns>List of line items</returns>
        public List<LineItem> GetLineItemsForOrder(int orderId)
        {
            List<LineItem> lineItems = new List<LineItem>();
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = "select LineItem.ID as ID, OrderId , Product.ID as ProductId,Name,LineItem.Qty as Qty,Price,Amount from LineItem inner join Product on LineItem.ProductId=Product.ID where OrderId='" + orderId + "'";
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    lineItems.Add(new LineItem { ID = int.Parse(sdr["ID"].ToString()), Name = sdr["Name"].ToString(), ProductId = int.Parse(sdr["ProductId"].ToString()), Price = decimal.Parse(sdr["Price"].ToString()), Qty = int.Parse(sdr["Qty"].ToString()),Amount=decimal.Parse(sdr["Amount"].ToString()),OrderId=int.Parse(sdr["OrderId"].ToString()) });
                }
                return lineItems!;
            }
        }
    }
}
