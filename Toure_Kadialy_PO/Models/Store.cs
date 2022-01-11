using System.Collections.Generic;
using Toure_Kadialy_P0.Models;
namespace Toure_Kadialy_P0.Models
{
    public class Store
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public List<Product>? Products { get; set; }

        public List<StoreOrder>? AllOrders { get; set; }

        public override string ToString()
        {
            return ($"Store: {this.Name}\n    City: {this.City}, State: {this.State}\n    Address: {this.Address}");
        }




        public List<Product> ProductList { get; set; }
        public List<Product> ShoppingCart { get; set; }

        public bool IsValidStoreName()
        {
            if (this.Name.Length > 0)
                return true;
            else
                return false;
        }

    }



}

