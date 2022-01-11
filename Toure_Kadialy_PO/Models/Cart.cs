using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toure_Kadialy_P0.Models
{
   public class Cart
    {
        public int ID { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public  int Qty { get; set; }
        public decimal Amount { get { return Price*Qty; } set { Amount = value; } }

        public bool IsValidProductAmount()
        {
            if (this.Amount > 0)
                return true;
            else
                return false;
        }
        public bool IsValidProductQty()
        {
            if (this.Qty > 0)
                return true;
            else
                return false;
        }
        public bool IsValidCartProduct(string name)
        {
            if (name.Length > 0)
                return true;
            else
                return false;
        }
    }
}
