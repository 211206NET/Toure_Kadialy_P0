using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Toure_Kadialy_P0.Models
{
    
    public class Product
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
        public int Qty { get; set; }
        public int Location { get; set; }

        public Product()
        {
            this.Name = "";
            this.Description = "";
            this.Price = 0.00M;

        }

        public Product(string name, string description, decimal price, int qty, int location)
        {
            this.Name = name;
            this.Description = description;
            this.Price = price;
            this.Qty = qty;
            this.Location = location;
            
        }
        public bool IsValidProductLocation()
        {
            if (this.Location > 0)
                return true;
            else
                return false;
        }
        public bool IsValidProductName()
        {
            if (this.Name.Length > 0)
                return true;
            else
                return false;
        }

    }
}

