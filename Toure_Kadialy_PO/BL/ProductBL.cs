using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toure_Kadialy_P0.DL;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.BL
{
    public class ProductBL
    {

        private readonly ProductDL _pdl;

        public ProductBL()
        {
            _pdl = new ProductDL();
        }
        /// <summary>
        /// Return all available products in database
        /// </summary>
        /// <returns>List of all products</returns>
        public List<Product> GetAllProducts()
        {
            return _pdl.GetAllProducts();
        }
        /// <summary>
        /// Returns list of products for specific store.
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns>List of specific store products</returns>
        public List<Product> GetStoreProdcuts(int storeId)
        {
            return _pdl.GetStoreProdcuts(storeId);
        }
        /// <summary>
        /// Add item to cart by request customer
        /// </summary>
        /// <param name="prodId"></param>
        /// <param name="customer"></param>
        /// <param name="qty"></param>
        public void AddToCart(int prodId,Customer customer, int qty)
        {
            _pdl.AddToCart(prodId,customer, qty);
        }

        /// <summary>
        /// Show all products in a specific
        /// store so that customer can choose and 
        /// add it to cart.
        /// </summary>
        /// <param name="storeId"></param>
        public void ShowProducts(int storeId)
        {
            List<Product> products = _pdl.GetAllProducts();
            if (products.Count <= 0)
                Console.WriteLine("No Products available in store");
            else
                foreach (Product product in _pdl.GetStoreProdcuts(storeId))
                    if (product.Qty > 0)
                        Console.WriteLine($"{product.ID}) {product.Name} Price: {product.Price}");

            Console.WriteLine("\nEnter Product Id to add to Cart");
            Console.WriteLine("Enter C Checkout");
            Console.WriteLine("Enter (E) to go back;");
            Console.WriteLine("---------------------------------------");

        }
    }
}
