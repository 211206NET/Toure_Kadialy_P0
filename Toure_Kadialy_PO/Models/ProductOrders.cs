using Serilog;
using Toure_Kadialy_P0.Models;
namespace Toure_Kadialy_P0.Models
{
    public class ProductOrder
    {


      
        public int? ID { get; set; }
        public int? userID { get; set; }
        public int? storeID { get; set; }
        public int? productID { get; set; }

        public string? ItemName { get; set; }

        public decimal TotalPrice { get; set; }

        private int _quantity;
        public int Quantity
        {

            get => _quantity;

            set
            {
                //checks if the string is a valid integer  
                if (value <= 0)
                {
                    Log.Error("Quantity must greater than 0. Please enter a valid amount:");
                }

                this._quantity = value;
            }
        }
        public bool IsValidQuantity()
        {
            if (this.Quantity > 0)
                return true;
            else
                return false;
        }
        public bool IsValidProductId(string input)
        {
            int id;
            if (int.TryParse(input,out id))
                return true;
            else
                return false;
        }
        public bool IsValidPrice()
        {
            if (this.TotalPrice > 0)
                return true;
            else
                return false;
        }


    }
}

