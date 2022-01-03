using System.Text.Json;

namespace DL;

public class CustomerRepo : IRepo {

    public CustomerRepo(){
    }
    //make path from UI folder to file location
    private string? filePath = "../DL/Customer.json";

    /// <summary>
    /// Gets all Customers from the file
    /// </summary>
    /// <returns>List of all Customers</returns>
    public List<Customer> GetAllCustomer(){
        //returns all restaurants written in the file
        string jsonString = File.ReadAllText(filePath!);
        List<Customer> jsonDeserialized = JsonSerializer.Deserialize<List<Customer>>(jsonString)!;
        return jsonDeserialized!;
    }   

    /// <summary>
    /// Adds a Customer to the file
    /// </summary>
    /// <param name="CustomerToAdd">Customer object</param>
    public void AddCustomer(Customer CustomerToAdd){
        List<Customer> allCustomers = GetAllCustomer();
        allCustomers.Add(CustomerToAdd);
        string jsonString = JsonSerializer.Serialize(allCustomers)!;
        File.WriteAllText(filePath!, jsonString!);
    }
    /// <summary>
    /// Gets the current Customer by their ID
    /// </summary>
    /// <param name="ID">integer of the Customer's ID</param>
    /// <returns>Customer object</returns>
    public Customer getCustomerWithID(int ID){
        List<Customer> allCustomers = GetAllCustomer();
        Customer currCustomer = new Customer();
        foreach(Customer Customer in allCustomers){
            if (CustomerID == ID){
                currCustomer = Customer;
            }
        }
        return currCustomer;
    }
    /// <summary>
    /// Gets the current Customer's index by their ID
    /// </summary>
    /// <param name="ID">integer of the Customer's ID</param>
    /// <returns>Customer's index in list of Customers'</returns>
    public int getCustomerIndexByID(int CustomerID){
        List<Customer> allCustomers = GetAllCustomer();
        int i = 0;
        foreach(Customer Customer in allCustomers){
            if (Customer.ID == CustomerID){
                return i;
            }
            i++;
        }
        return 0;
    }
    /// <summary>
    /// Adds a product to the shopping cart
    /// </summary>
    /// <param name="currCustomer">Current Customer [object]</param>
    /// <param name="currProdOrder">The current product object</param>
    public void AddProductOrder(Customer currCustomer, ProductOrder currProdOrder){
        List<Customer> allCustomers = GetAllCustomer();
        if(currCustomer.ShoppingCart == null)
            {
                currCustomer.ShoppingCart = new List<ProductOrder>();
            }
        currCustomer.ShoppingCart!.Add(currProdOrder!);
        //Remapping the current Customer to update the list of Customers
        allCustomers[GetcurrCustomerIndex((int)currCustomer.ID!)] = currCustomer;
        string jsonString = JsonSerializer.Serialize(allCustomers)!;
        File.WriteAllText(filePath!, jsonString!);
    }
    /// <summary>
    /// Edits an existing product order in the shopping cart
    /// </summary>
    /// <param name="currCustomer">Current Customer object</param>
    /// <param name="prodOrderIndex">Index of the product order in the shopping cart</param>
    /// <param name="quantity">New Updates quantity</param>
    public void EditProductOrder(Customer currCustomer, int prodOrderIndex, int quantity){
        List<Customer> allCustomers = GetAllCustomer();
        //Selected the current product based off the Customers index and the product order's index in the shopping cart
        List<ProductOrder> allProdOrders = currCustomer.ShoppingCart!;
        ProductOrder currProduct = allProdOrders[prodOrderIndex]!;
        string oldQuantity = currProduct.Quantity!;
        //First check to throw exception if quantity is not an integer
        currProduct.Quantity = quantity;
        //Replacing the old quantity back in for calculations
        currProduct.Quantity = oldQuantity;
        //Calculating the new total amount
        string Quantity = int.Parse(quantity);
        string currentTotal = decimal.Parse(currProduct.TotalPrice!);
        int currentQuantity = int.Parse(currProduct.Quantity!);
        decimal itemPrice = (currentTotal / currentQuantity);
        string newTotal = (itemPrice * intQuantity).ToString();
        //Declaring new quantity, total
        currProduct.TotalPrice = newTotal;
        currProduct.Quantity = quantity;
        //Remapping the current Customer to update the list of Customers
        allCustomers[GetcurrCustomerIndex((int)currCustomer.ID!)] = currCustomer;
        string jsonString = JsonSerializer.Serialize(allCustomers);
        File.WriteAllText(filePath!, jsonString!);
    }
    /// <summary>
    /// Delete's a product order from the Customer's shopping cart
    /// </summary>
    /// <param name="currCustomer">Current Customer [object]</param>
    /// <param name="prodIndex">Current product orders' index</param>
    public void DeleteProductOrder(Customer currCustomer, int prodIndex){
        List<Customer> allCustomers = GetAllCustomer();
        List<ProductOrder> allProdOrders = currCustomer.ShoppingCart!;
        allProdOrders!.RemoveAt(prodIndex);
        //Remapping the current Customer to update the list of Customers
        allCustomers[GetcurrCustomerIndex((int)currCustomer.ID!)] = currCustomer;
        string jsonString = JsonSerializer.Serialize(allCustomers);
        File.WriteAllText(filePath!, jsonString!);
    }
    /// <summary>
    /// Adds a store order to the Customer's store order list
    /// </summary>
    /// <param name="currCustomer">Current Customer [object]</param>
    /// <param name="currStoreOrder">Store order to add</param>
    public void AddCustomerStoreOrder(Customer currCustomer, StoreOrder currStoreOrder){
        List<Customer> allCustomers = GetAllCustomer();
        if(currCustomer.FinishedOrders == null) {
            currCustomer.FinishedOrders = new List<StoreOrder>();
        }
        currCustomer.FinishedOrders.Add(currStoreOrder);

        //Remapping the current Customer to update the list of Customers
        allCustomers[GetcurrCustomerIndex((int)currCustomer.ID!)] = currCustomer;

        string jsonString = JsonSerializer.Serialize(allCustomers);
        File.WriteAllText(filePath!, jsonString!);
    }
    /// <summary>
    /// Clears a Customer's shopping cart
    /// </summary>
    /// <param name="currCustomer">Current Customer [object]</param>
    public void ClearShoppingCart(Customer currCustomer){
        List<Customer> allCustomers = GetAllCustomer();
        currCustomer.ShoppingCart!.Clear();
        //Remapping the current Customer to update the list of Customers
        allCustomers[getCustomerIndexByID((int)currCustomer.ID!)] = currCustomer;
        string jsonString = JsonSerializer.Serialize(allCustomers);
        File.WriteAllText(filePath!, jsonString!);
    }
}