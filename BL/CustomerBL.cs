namespace BL;

public class CustomerBL : TBBL
{
    private TBBL _dl;

    public CustomerBL(TBBL repo) {
        _dl = repo;
    }
     /// <summary>
    /// Gets all Customers
    /// </summary>
    /// <returns>list of all Customers</returns>
    public List<Customer> GetAllCustomer(){
        return _dl.GetAllCustomer();

    }
    /// <summary>
    /// Returns a Customer by their id
    /// </summary>
    /// <param name="CustomerID">Customer ID</param>
    /// <returns>Customer object</returns>
    public Customer grabcurrentCustomerwithID(int CustomerID){
        return _dl.grabcurrentCustomerwithID(CustomerID);
    }
    /// <summary>
    /// Returns a Customer's index by their ID
    /// </summary>
    /// <param name="CustomerID">Customer ID</param>
    /// <returns>index of current Customer</returns>
    public int GetCurrentCustomerIndexByID(int CustomerID){
        return _dl.GetCurrentCustomerIndexByID(CustomerID);
    }
    /// <summary>
    /// Adds a new Customer to the list
    /// </summary>
    /// <param name="CustomerToAdd">Customer object to add</param>
    public void AddCustomer(Customer CustomerToAdd){
        _dl.AddCustomer(CustomerToAdd);
    }
    /// <summary>
    /// Adds a product order to the Customer's shopping list
    /// </summary>
    /// <param name="currCustomer">Current Customer [object]</param>
    /// <param name="currProdOrder">New product order to be added to the Customer's shopping cart</param>
    public void AddProductOrder(Customer currCustomer, ProductOrder currProdOrder){
        _dl.AddProductOrder(currCustomer, currProdOrder);
    }
    /// <summary>
    /// Edits an existing product's order by quantity
    /// </summary>
    /// <param name="currCustomer">Current Customer [object]</param>
    /// <param name="prodOrderIndex">Product order's index in the shopping cart</param>
    /// <param name="quantity">New quantity to be update to</param>
    public void EditProductOrder(Customer currCustomer, int prodOrderIndex, string quantity){
        _dl.EditProductOrder(currCustomer, prodOrderIndex, quantity);
    }
    /// <summary>
    /// Deletes a product from your shopping list
    /// </summary>
    /// <param name="currCustomerIndex">Current Customer [object]</param>
    /// <param name="prodIndex">Product to delete at index</param>
    public void DeleteProductOrder(Customer currCustomer , int prodIndex){
        _dl.DeleteProductOrder(currCustomer, prodIndex);
    }
    /// <summary>
    /// Adds a store order to the Customer's order list
    /// </summary>
    /// <param name="currCustomerIndex">Current Customer [object]</param>
    /// <param name="currStoreOrder">Store order to add</param>
    public void AddCustomerStoreOrder(Customer currCustomer, StoreOrder currStoreOrder){
        _dl.AddCustomerStoreOrder(currCustomer, currStoreOrder);
    }
    /// <summary>
    /// Clears the Customer's shopping cart
    /// </summary>
    /// <param name="currCustomer">Current Customer [object]</param>
    public void ClearShoppingCart(Customer currCustomer){
        _dl.ClearShoppingCart(currCustomer);
    }
}