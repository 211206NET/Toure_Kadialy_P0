using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Toure_Kadialy_P0.Models
{
    public class OrderMaster
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal OrderAmount { get; set; }

        public List<LineItem> LineItems { get; set; }
        

        public bool IsValidOrderDate()
        {
            if (this.OrderDate >= DateTime.Now)
            {
                return true;
            }
            else
                return false;
        }

        public bool IsValidCustomerName()
        {
            if (this.CustomerName.Length > 0)
                return true;
            else
                return false;
        }

    }
}
