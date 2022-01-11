using System.Collections.Generic;
using Toure_Kadialy_P0.Models;

namespace Toure_Kadialy_P0.BL
{
    public interface TBBL
    {
        List<Customer> GetAllCustomer();

        void AddCustomer(Customer CustomerToAdd);
        Customer grabcurrentCustomerwithID(int CustomerID);
        int GetCurrentCustomerIndexByID(int CustomerID);

        void AddCustomerStoreOrder(Customer currCustomer, StoreOrder currStoreOrder);

        void AddProductOrder(Customer currCustomer, ProductOrder currProdOrder);

        void EditProductOrder(Customer currCustomer, int prodOrderIndex, int Quantity);
        void DeleteProductOrder(Customer currCustomer, int prodIndex);
        void ClearShoppingCart(Customer currCustomer, StoreOrder currStoreOrder);

    }
}
