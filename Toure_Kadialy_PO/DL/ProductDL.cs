using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.DL
{
   public class ProductDL
    {
        //declare essential variables.
        private readonly SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader sdr;
        /// <summary>
        /// Initialize connection
        /// </summary>
        public ProductDL()
        {
            con = ConnectDB.getConnection();
        }
        /// <summary>
        /// Get all products availablle in database
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            List<Product> products = new List<Product>();
            using(cmd=new SqlCommand())
            {
                cmd.CommandText = "select * from Product";
                cmd.Connection = con;
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    products.Add(new Product { ID = int.Parse(sdr["ID"].ToString()), Name =sdr["Name"].ToString(),Description= sdr["Description"].ToString(),Price=decimal.Parse(sdr["Price"].ToString()),Location=int.Parse(sdr["Location"].ToString()),Qty=int.Parse(sdr["Qty"].ToString()) });
                }
                return products!;
            }
        }
        /// <summary>
        /// Add product to user cart
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="customer"></param>
        /// <param name="qty"></param>
        internal void AddToCart(int prodId, Customer customer, int qty)
        {
           using(cmd=new SqlCommand())
            {
                cmd.CommandText="Insert into Cart values('"+prodId+"','" + customer.CustomerId + "','"+qty+"')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                Console.WriteLine("Product added successfully!");
                Console.WriteLine("Press any key to go back");
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Get all avalaible store products
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>List of products</returns>
        public List<Product> GetStoreProdcuts(int storeId)
        {
            List<Product> storeProducts = new List<Product>();
            foreach(Product product in GetAllProducts())
            {
                if (product.Location == storeId)
                {
                    storeProducts.Add(product);
                }
            }
            return storeProducts;
        }
        /// <summary>
        /// Add new product to database
        /// </summary>
        /// <param name="product"></param>
        internal void AddProduct(Product product)
        {
            cmd = new SqlCommand("Insert into Product values('" + product.Name + "','" + product.Description + "','" + product.Price + "','" + product.Qty + "','" + product.Location + "')", con);
            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// update specific product inventory in store
        /// </summary>
        /// <param name="productToUpdate"></param>
        /// <param name="qty"></param>
        public void UpdateProductInventory(Product productToUpdate, int qty)
        {
            cmd = new SqlCommand("Update Product Set Qty=Qty+'" + qty + "' where Location='" + productToUpdate.Location + "' and ID='" + productToUpdate.ID + "'", con);
            cmd.ExecuteNonQuery();
        }
    }
}
