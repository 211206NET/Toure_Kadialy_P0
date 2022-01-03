namespace DL;

public interface IRepo 
{
    
    List<Customer> GetAllCustomer();

    void AddCustomer(Customer CustomerToAdd);

    Customer getCustomerWithID(int CustomerID);
    int getCustomerIndexByID(int CustomerID);

    void AddProductOrder(Customer currCustomer, ProductOrder currProdOrder);

    void EditProductOrder(Customer currCustomer, int prodOrderIndex, int quantity);

    void DeleteProductOrder(Customer currCustomer, int prodOrderIndex);
    
    void AddCustomerStoreOrder(Customer currCustomer, StoreOrder currStoreOrder);

    void ClearShoppingCart(Customer currCustomer);

}