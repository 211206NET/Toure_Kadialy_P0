namespace BL;
public interface TBBL
{
    List<Customer> GetAllCustomer();

    void addCustomer(CustomerBL CustomerToAdd);
    Customer getCustomerWithID(int CustomerID);
    int getCustomerIndexByID(int CustomerID);
    void AddProductOrder(Customer currCustomer, ProductOrder currProdOrder);
    void EditProductOrder(Customer currCustomer, int prodOrderIndex, int Quantity);
    void DeleteProductOrder(Customer currCustomer, int prodIndex);
    void ClearShoppingCart(Customer currCustomer, StoreOrder currStoreOrder);

    void AddCustomerStoreOrder(Customer currCustomer);

}